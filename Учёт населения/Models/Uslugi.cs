using System;
using Newtonsoft.Json;

namespace Учёт_населения
{
    public class Uslugi
    {
        [JsonProperty("кодУслуги")]
        public int КодУслуги { get; set; }

        [JsonProperty("кодОбщихСведений")]
        public int? КодОбщихСведений { get; set; }

        [JsonProperty("фио")]
        public string Фио { get; set; }

        [JsonProperty("наименованиеУслуги")]
        public string НаименованиеУслуги { get; set; }

        [JsonProperty("датаОказанияУслуги")]
        public DateTime? ДатаОказанияУслуги { get; set; }
    }
}
