# MLX90640_PC_Test
Приложение для теста матрицы MLX90640 для ПК. MLX90640 Matrix Test Application for PC

Приложение для проверки работы камеры MLX90640. Написано на C# на коленке для диплома.
Для работы с приложением необходимо и достаточно:
# 1. Скачать файл "MLX90640_Test.exe"
# 2. На микроконтроллере получить массив температур с матрицы MLX90640 и преобразовать его.
Программа принимает по 768 чисел типа uint16_t вида Temp**100.
Получить числа можно с микроконтроллера через UART и USB-UART преобразователь, например кодом:
float mlx90640_get_temp_frame(uint8_t* buf)
{
  float Ta, tr;
  MLX90640_GetFrameData(MLX90640_I2C_ADDR, mlx90640_frame_data); // Получение данных
  Ta = MLX90640_GetTa(mlx90640_frame_data, &mlx90640_parameters); // Ta
  tr = Ta - TA_SHIFT;
  MLX90640_CalculateTo(mlx90640_frame_data, &mlx90640_parameters, MLX90640_EMISSIVITY_STANDARD, tr, mlx90640_temp_frame); // Расчет тепловой картины
  
  for (uint16_t i = 0; i < 768; i++) // first send low 8bit and then high 8bit
  {
    buf[i * 2] = BYTE_1((uint16_t)(mlx90640_temp_frame[i] * 100));		// Запись кадра в UART буффер
    buf[i * 2 + 1] = BYTE_0((uint16_t)(mlx90640_temp_frame[i] * 100));
  }
  return Ta;
}
# Затем полученный "buf" отправлять по UART через USB-UART в ПК.
# 3. Запустить запустить файл "MLX90640_Test.exe" и настроить COM Port.
# 4. Начать отправлять данные с микроконтроллера
Также, делюсь исходными файлами, может кому-то будут полезны. Писалось в Visual Studio Community 2022 winForms
