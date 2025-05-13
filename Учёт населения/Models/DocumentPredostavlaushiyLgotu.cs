using System;
using Newtonsoft.Json;

namespace Учёт_населения
{
    public class DocumentPredostavlaushiyLgotu
    {
        [JsonProperty("кодДокументаПредоставляющегоЛьготу")]
        public int КодДокументаПредоставляющегоЛьготу { get; set; }

        [JsonProperty("фио")]
        public string Фио { get; set; }

        [JsonProperty("типДокумента")]
        public string ТипДокумента { get; set; }

        [JsonProperty("серия")]
        public string Серия { get; set; }

        [JsonProperty("номер")]
        public string Номер { get; set; }

        [JsonProperty("датаВыдачи")]
        public DateTime? ДатаВыдачи { get; set; }

        [JsonProperty("датаОкончанияСрокаДействия")]
        public DateTime? ДатаОкончанияСрокаДействия { get; set; }
    }
}
