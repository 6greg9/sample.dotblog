using System;

namespace WebApiCore31
{
    public class WeatherForecast
    {
        /// <summary>
        /// ���
        /// </summary>
        /// <example>2019/01/02</example>
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        /// <summary>
        /// ²��
        /// </summary>
        /// <example>Summary</example>
        public string Summary { get; set; }
    }
}
