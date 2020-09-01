using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace EGA_Lijst.Models
{
    public class Weeklijst
    {
        [PrimaryKey, AutoIncrement]
        public int WeekLijstId { get; set; }
        public DateTime StartDatum { get; set; }
    }
    public class Voeding
    {
        [PrimaryKey, AutoIncrement]
        public int VoedingId { get; set; }
        public int WeekLijstId { get; set; }
        public string NaamVoeding { get; set; }
        public bool IsVerplichteVoeding { get; set; }
        public bool IsGenuttigd { get; set; }
    }
}
