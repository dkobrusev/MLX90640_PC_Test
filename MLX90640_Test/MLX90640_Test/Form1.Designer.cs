namespace MLX90640_Test
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.comPortList = new System.Windows.Forms.ComboBox();
            this.connectBtn = new System.Windows.Forms.Button();
            this.comPort = new System.IO.Ports.SerialPort(this.components);
            this.updTimer = new System.Windows.Forms.Timer(this.components);
            this.comPortBauds = new System.Windows.Forms.ComboBox();
            this.checkTimer = new System.Windows.Forms.Timer(this.components);
            this.labelSerialPort = new System.Windows.Forms.Label();
            this.thermalPic = new System.Windows.Forms.PictureBox();
            this.scalePic = new System.Windows.Forms.PictureBox();
            this.lableTmax = new System.Windows.Forms.Label();
            this.labelTmin = new System.Windows.Forms.Label();
            this.thermalImageMinTemp = new System.Windows.Forms.Label();
            this.thermalImageMaxTemp = new System.Windows.Forms.Label();
            this.thermalImageAvgTemp = new System.Windows.Forms.Label();
            this.thermalImageCenterTemp = new System.Windows.Forms.Label();
            this.lableCentralTemp = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.thermalPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scalePic)).BeginInit();
            this.SuspendLayout();
            // 
            // comPortList
            // 
            this.comPortList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comPortList.FormattingEnabled = true;
            this.comPortList.Location = new System.Drawing.Point(74, 12);
            this.comPortList.Name = "comPortList";
            this.comPortList.Size = new System.Drawing.Size(60, 21);
            this.comPortList.TabIndex = 0;
            // 
            // connectBtn
            // 
            this.connectBtn.Location = new System.Drawing.Point(250, 12);
            this.connectBtn.Name = "connectBtn";
            this.connectBtn.Size = new System.Drawing.Size(75, 21);
            this.connectBtn.TabIndex = 1;
            this.connectBtn.Text = "Connect";
            this.connectBtn.UseVisualStyleBackColor = true;
            this.connectBtn.Click += new System.EventHandler(this.connectBtn_Click);
            // 
            // comPort
            // 
            this.comPort.BaudRate = 115200;
            this.comPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.comPort_DataReceived);
            // 
            // updTimer
            // 
            this.updTimer.Enabled = true;
            this.updTimer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // comPortBauds
            // 
            this.comPortBauds.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comPortBauds.FormattingEnabled = true;
            this.comPortBauds.Location = new System.Drawing.Point(142, 12);
            this.comPortBauds.Name = "comPortBauds";
            this.comPortBauds.Size = new System.Drawing.Size(100, 21);
            this.comPortBauds.TabIndex = 2;
            // 
            // checkTimer
            // 
            this.checkTimer.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // labelSerialPort
            // 
            this.labelSerialPort.AutoSize = true;
            this.labelSerialPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.labelSerialPort.Location = new System.Drawing.Point(11, 16);
            this.labelSerialPort.Name = "labelSerialPort";
            this.labelSerialPort.Size = new System.Drawing.Size(55, 13);
            this.labelSerialPort.TabIndex = 3;
            this.labelSerialPort.Text = "Serial Port";
            // 
            // thermalPic
            // 
            this.thermalPic.Location = new System.Drawing.Point(10, 40);
            this.thermalPic.Name = "thermalPic";
            this.thermalPic.Size = new System.Drawing.Size(640, 480);
            this.thermalPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.thermalPic.TabIndex = 4;
            this.thermalPic.TabStop = false;
            // 
            // scalePic
            // 
            this.scalePic.Location = new System.Drawing.Point(10, 550);
            this.scalePic.Name = "scalePic";
            this.scalePic.Size = new System.Drawing.Size(640, 20);
            this.scalePic.TabIndex = 5;
            this.scalePic.TabStop = false;
            // 
            // lableTmax
            // 
            this.lableTmax.AutoSize = true;
            this.lableTmax.Location = new System.Drawing.Point(584, 531);
            this.lableTmax.Name = "lableTmax";
            this.lableTmax.Size = new System.Drawing.Size(33, 13);
            this.lableTmax.TabIndex = 6;
            this.lableTmax.Text = "Tmax";
            // 
            // labelTmin
            // 
            this.labelTmin.AutoSize = true;
            this.labelTmin.Location = new System.Drawing.Point(7, 531);
            this.labelTmin.Name = "labelTmin";
            this.labelTmin.Size = new System.Drawing.Size(30, 13);
            this.labelTmin.TabIndex = 7;
            this.labelTmin.Text = "Tmin";
            // 
            // thermalImageMinTemp
            // 
            this.thermalImageMinTemp.AutoSize = true;
            this.thermalImageMinTemp.Location = new System.Drawing.Point(36, 531);
            this.thermalImageMinTemp.Name = "thermalImageMinTemp";
            this.thermalImageMinTemp.Size = new System.Drawing.Size(34, 13);
            this.thermalImageMinTemp.TabIndex = 8;
            this.thermalImageMinTemp.Text = "12.34";
            // 
            // thermalImageMaxTemp
            // 
            this.thermalImageMaxTemp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.thermalImageMaxTemp.AutoSize = true;
            this.thermalImageMaxTemp.Location = new System.Drawing.Point(616, 531);
            this.thermalImageMaxTemp.Name = "thermalImageMaxTemp";
            this.thermalImageMaxTemp.Size = new System.Drawing.Size(34, 13);
            this.thermalImageMaxTemp.TabIndex = 9;
            this.thermalImageMaxTemp.Text = "12,34";
            // 
            // thermalImageAvgTemp
            // 
            this.thermalImageAvgTemp.AutoSize = true;
            this.thermalImageAvgTemp.Location = new System.Drawing.Point(313, 531);
            this.thermalImageAvgTemp.Name = "thermalImageAvgTemp";
            this.thermalImageAvgTemp.Size = new System.Drawing.Size(34, 13);
            this.thermalImageAvgTemp.TabIndex = 10;
            this.thermalImageAvgTemp.Text = "12.34";
            // 
            // thermalImageCenterTemp
            // 
            this.thermalImageCenterTemp.AutoSize = true;
            this.thermalImageCenterTemp.BackColor = System.Drawing.Color.Transparent;
            this.thermalImageCenterTemp.Location = new System.Drawing.Point(545, 16);
            this.thermalImageCenterTemp.Name = "thermalImageCenterTemp";
            this.thermalImageCenterTemp.Size = new System.Drawing.Size(34, 13);
            this.thermalImageCenterTemp.TabIndex = 11;
            this.thermalImageCenterTemp.Text = "36.66";
            // 
            // lableCentralTemp
            // 
            this.lableCentralTemp.AutoSize = true;
            this.lableCentralTemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lableCentralTemp.Location = new System.Drawing.Point(465, 16);
            this.lableCentralTemp.Name = "lableCentralTemp";
            this.lableCentralTemp.Size = new System.Drawing.Size(76, 13);
            this.lableCentralTemp.TabIndex = 12;
            this.lableCentralTemp.Text = "Central Temp -";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 581);
            this.Controls.Add(this.lableCentralTemp);
            this.Controls.Add(this.thermalImageCenterTemp);
            this.Controls.Add(this.thermalImageAvgTemp);
            this.Controls.Add(this.thermalImageMaxTemp);
            this.Controls.Add(this.thermalImageMinTemp);
            this.Controls.Add(this.labelTmin);
            this.Controls.Add(this.lableTmax);
            this.Controls.Add(this.scalePic);
            this.Controls.Add(this.thermalPic);
            this.Controls.Add(this.labelSerialPort);
            this.Controls.Add(this.comPortBauds);
            this.Controls.Add(this.connectBtn);
            this.Controls.Add(this.comPortList);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(675, 620);
            this.MinimumSize = new System.Drawing.Size(675, 620);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MLX90640 Test";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.thermalPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scalePic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comPortList;
        private System.Windows.Forms.Button connectBtn;
        private System.IO.Ports.SerialPort comPort;
        private System.Windows.Forms.Timer updTimer;
        private System.Windows.Forms.ComboBox comPortBauds;
        private System.Windows.Forms.Timer checkTimer;
        private System.Windows.Forms.Label labelSerialPort;
        private System.Windows.Forms.PictureBox thermalPic;
        private System.Windows.Forms.PictureBox scalePic;
        private System.Windows.Forms.Label lableTmax;
        private System.Windows.Forms.Label labelTmin;
        private System.Windows.Forms.Label lableCentralTemp;
        public System.Windows.Forms.Label thermalImageMinTemp;
        public System.Windows.Forms.Label thermalImageMaxTemp;
        public System.Windows.Forms.Label thermalImageAvgTemp;
        public System.Windows.Forms.Label thermalImageCenterTemp;
    }
}

