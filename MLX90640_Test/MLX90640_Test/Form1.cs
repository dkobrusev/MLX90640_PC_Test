using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Security.Cryptography.X509Certificates;
using System.Reflection.Emit;


namespace MLX90640_Test
{
    public partial class Form1 : Form
    {
        // Com port
        int portsNumOld = 0;

        // Buffer
        const int bufferSize = 1542;

        byte[] bufferTempData = new byte[bufferSize]; // Кадр + нач символ + номер кадра + Ta
        int[] intTempData = new int[bufferSize / 2];
        float[] floatTempData = new float[bufferSize / 2];

        // Thermal image
        const int W = 32;
        const int H = 24;
        const int pixScale = 20;

        const int width = W * pixScale;
        const int height = H * pixScale;
        Bitmap bmpThermalImage = new Bitmap(width, height);

        // Temperature scale
        Bitmap bmpTempScale = new Bitmap(640, 20);
        float minTemp = 1001.0f; // `C * 100
        float maxTemp = 5002.0f;


        public Form1()
        {
            InitializeComponent();
        }

        //-------------------------------------------------------------------------------------------------------------------//

        private void Form1_Load_1(object sender, EventArgs e)
        {
            comPortList.Items.AddRange(SerialPort.GetPortNames());
            comPortBauds.Items.AddRange(new[] { "9600", "19200", "38400", "57600", "115200" });
            comPortBauds.SelectedIndex = comPortBauds.Items.Count - 1;

            for (int i = 0; i < H; i++)
            {
                for (int j = 0; j < W; j++)
                {
                    for (int k = 0; k < pixScale; k++)
                    {
                        for (int l = 0; l < pixScale; l++)
                        {
                            bmpThermalImage.SetPixel(j * pixScale + k, i * pixScale + l, From1024ToRGB(Convert.ToInt32(1023.0f / 54.0f * (i + j))));
                        }
                    }
                }
            }

            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < W * pixScale; j++)
                {
                    bmpTempScale.SetPixel(j, i, From1024ToRGB(Convert.ToInt32(1023.0f / (W * pixScale - 1) * j)));
                }
            }

            thermalPic.Width = width;
            thermalPic.Height = height;
            thermalPic.Image = bmpThermalImage;
            scalePic.Image = bmpTempScale;

            thermalImageMaxTemp.Text = Convert.ToString(maxTemp / 100.0f);
            thermalImageMinTemp.Text = Convert.ToString(minTemp / 100.0f);
            thermalImageAvgTemp.Text = Convert.ToString((maxTemp + minTemp) / 200.0f);

        }

        //-------------------------------------------------------------------------------------------------------------------//

        private void connectBtn_Click(object sender, EventArgs e)
        {
            if (comPort.IsOpen) // Если ком порт открыт по нажатию кнопки
            {
                comPortDisconnect();        // Действия по закрытию порта
            }
            else                // Если ком порт закрыт по нажатию кнопки
            {
                comPortConnect();
                if (comPort.BytesToRead > 0)
                    comPort.ReadExisting();
            }
        }

        //-------------------------------------------------------------------------------------------------------------------//

        private void timer1_Tick(object sender, EventArgs e)    // Таймер на 100 мл проверяет не появились ли новые компорты
        {
            string[] portNames = SerialPort.GetPortNames();

            if (portNames.Length != portsNumOld)
            {
                comPortList.Items.Clear();
                comPortList.Items.AddRange(portNames);
                comPortList.SelectedIndex = portNames.Length - 1;
            }
            portsNumOld = portNames.Length;

        }

        //-------------------------------------------------------------------------------------------------------------------//

        private void timer1_Tick_1(object sender, EventArgs e)  // Таймер на 100 мл проверяет не отключились ли устройства
        {
            if (!comPort.IsOpen)
            {
                comPortDisconnect();    // Действия по закрытию порта
            }


        }

        //-------------------------------------------------------------------------------------------------------------------//

        private void comPortDisconnect()    // Действия по закрытию порта
        {
            comPort.Close();                                    // Закрыть порт
            connectBtn.Text = "Connect";                        // Изменить текст кнопки
            comPortList.Enabled = comPortBauds.Enabled = true;  // Заблокировать изменения порта и скорости
            updTimer.Enabled = true;                            // Вкл таймер отслеживания изменения кол-ва портов
            checkTimer.Enabled = false;                         // Выкл таймер отслеживания отключения устройства
        }

        //-------------------------------------------------------------------------------------------------------------------//

        private void comPortConnect()    // Действия по закрытию порта
        {
            comPort.PortName = comPortList.SelectedItem.ToString();         // Задать выбранный ком порт
            comPort.BaudRate = Convert.ToInt32(comPortBauds.SelectedItem);  // Установить порту заданную скорость
            comPort.Open();                                                 // Открыть порт
            connectBtn.Text = "Disconnect";                                 // Изменить текст кнопки
            comPortList.Enabled = comPortBauds.Enabled = false;             // Запретить изменения порта и скорости
            updTimer.Enabled = false;                                       // Выкл таймер отслеживания изменения кол-ва портов
            checkTimer.Enabled = true;                                      // Вкл таймер отслеживания отключения устройства
        }

        //-------------------------------------------------------------------------------------------------------------------//

        private async void comPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (comPort.BytesToRead >= bufferSize)
            {
                Console.WriteLine(comPort.BytesToRead);
                comPort.Read(bufferTempData, 0, bufferSize);

                for (int i = 0; i < bufferSize / 2; i++)
                {
                    intTempData[i] = (Convert.ToInt16(bufferTempData[2 * i]) << 8) + (Convert.ToInt16(bufferTempData[2 * i + 1]));
                    //floatTempData[i] = intTempData[i] / 100.0f;
                    if (i > 1 && i < 770)
                    {
                        if (i == 2)
                        {
                            maxTemp = minTemp = intTempData[i];
                        }
                        else
                        {
                            if (intTempData[i] < minTemp)
                            {
                                minTemp = intTempData[i];
                            }
                            if (intTempData[i] > maxTemp)
                            {
                                maxTemp = intTempData[i];
                            }
                        }
                    }
                }

                // Построение распределения в консоли
                for (int i = 0; i < 24; i++)
                {
                    for (int j = 0; j < 32; j++)
                    {
                        Console.Write(intTempData[(i * 32 + j + 2)]);
                        Console.Write('\t');
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
                Console.WriteLine("/-----------------------------------/");

                // Обновление изображения на экране
                updatePic(intTempData);
            }
        }

        //-------------------------------------------------------------------------------------------------------------------//
        
        // Преобразует значения от 0 до 1023 в 256 цветов от синего до красного
        public Color From1024ToRGB(int hue)
        {
            int red = 0, green = 0, blue = 0;
            if (hue < 0 || hue > 1023) // Защита от ошибок
                return Color.Black;
            else
            {
                switch (hue / 256)
                {
                    case 0:
                        red = 0;
                        green = hue;
                        blue = 255;
                        break;
                    case 1:
                        red = 0;
                        green = 255;
                        blue = 511 - hue; // 255 - (hue - 256)
                        break;
                    case 2:
                        red = hue - 512;
                        green = 255;
                        blue = 0;
                        break;
                    case 3:
                        red = 255;
                        green = 1023 - hue; // 255 - (hue - 768)
                        blue = 0;
                        break;
                }

                return Color.FromArgb(255, red, green, blue);
            }
        }

        //-------------------------------------------------------------------------------------------------------------------//

        // Обновление изображения на экране
        public void updatePic(int[] tempData)
        {
            for (int i = 0; i < H; i++)
            {
                for (int j = 0; j < W; j++)
                {
                    for (int k = 0; k < pixScale; k++)
                    {
                        for (int l = 0; l < pixScale; l++)
                        {
                            // Закрашивает каждый пиксель определенным цветом (зависит от температуры)
                            // Функция принимает массив температур (значение температуры умноженое на 100), преобразует в диапазон от min до max, где 0 - min, 1023 - max
                            bmpThermalImage.SetPixel(j * pixScale + k, i * pixScale + l, From1024ToRGB(Convert.ToInt32(Convert.ToDouble(tempData[32 * i + j + 2] - minTemp) / (maxTemp - minTemp) * 1023.0f)));
                        }
                    }
                }
            }

            // Обновление картинки
            thermalPic.Image = bmpThermalImage;

            // Махинации с обновлением значений температур (min, max, (min+max/2) and center)
            thermalImageMinTemp.Invoke((MethodInvoker)(() => thermalImageMinTemp.Text = Convert.ToString(minTemp / 100.0f)));
            thermalImageMaxTemp.Invoke((MethodInvoker)(() => thermalImageMaxTemp.Text = Convert.ToString(maxTemp / 100.0f)));
            thermalImageAvgTemp.Invoke((MethodInvoker)(() => thermalImageAvgTemp.Text = Convert.ToString((maxTemp + minTemp) / 200.0f)));
            thermalImageCenterTemp.Invoke((MethodInvoker)(() => thermalImageCenterTemp.Text = Convert.ToString(intTempData[367] / 100.0f)));
        }

        //-------------------------------------------------------------------------------------------------------------------//
    }
}
