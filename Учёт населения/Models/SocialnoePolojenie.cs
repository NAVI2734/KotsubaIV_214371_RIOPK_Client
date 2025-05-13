using System;
using Newtonsoft.Json;

namespace Учёт_населения
{
    public class SocialnoePolojenie
    {
        [JsonProperty("кодСоциальногоПоложения")]
        public int КодСоциальногоПоложения { get; set; }

        [JsonProperty("фио")]
        public string Фио { get; set; }

        [JsonProperty("социальнаяКатегория")]
        public string СоциальнаяКатегория { get; set; }

        [JsonProperty("инвалидность")]
        public string Инвалидность { get; set; }

        [JsonProperty("группаИнвалидности")]
        public string ГруппаИнвалидности { get; set; }

        [JsonProperty("семейноеПоложение")]
        public string СемейноеПоложение { get; set; }
    }
}
