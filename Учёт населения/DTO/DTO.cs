using System;

namespace Server.Models.DTO
{
    public class DokumentDto
    {
        public int КодДокументаУдостоверяющегоЛичность { get; set; }
        public string Фио { get; set; } = string.Empty;
        public string ТипДокумента { get; set; } = null;
        public string Серия { get; set; } = string.Empty;
        public string Номер { get; set; } = string.Empty;
        public DateTime? ДатаВыдачи { get; set; }
        public DateTime? ДатаОкончанияСрокаДействия { get; set; }
        public string КемВыдан { get; set; } = string.Empty;
    }

}
