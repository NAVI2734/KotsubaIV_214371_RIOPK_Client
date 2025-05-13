using System;
using Newtonsoft.Json;

namespace Учёт_населения
{
    public class ObshieSvedenya
    {
        [JsonProperty("кодОбщихСведений")]
        public int КодОбщихСведений { get; set; }

        [JsonProperty("фио")]
        public string Фио { get; set; }

        [JsonProperty("датаРождения")]
        public DateTime? ДатаРождения { get; set; }

        [JsonProperty("пол")]
        public string Пол { get; set; }

        [JsonProperty("адресРегистрации")]
        public string АдресРегистрации { get; set; }

        [JsonProperty("адресПроживания")]
        public string АдресПроживания { get; set; }

        [JsonProperty("телефон")]
        public string Телефон { get; set; }
    }
}
