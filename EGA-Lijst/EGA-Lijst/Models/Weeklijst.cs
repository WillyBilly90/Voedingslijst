using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace EGA_Lijst.Models
{
    public class Weeklijst
    {
        [PrimaryKey, AutoIncrement]
        public int WeekLijstID { get; set; }
        public class Lever
        {
            string Naam = "Lever";
            bool Verplicht = true;
            int MaxPerWeek = 1;
        }
        public class Vlees
        {
            string Naam = "Vlees";
            bool Verplicht = false;
            int MaxPerWeek = 3;
        }
        public class Vis
        {
            string Naam = "Vis";
            bool Verplicht = false;
            int MaxPerWeek = 5;
        }
        public class Kaas
        {
            string Naam = "Kaas";
            bool Verplicht = false;
            int MaxPerWeek = 4;
        }
        public class Kip
        {
            string Naam = "Kip";
            bool Verplicht = false;
        }
        public class Ei
        {
            string Naam = "Ei";
            bool Verplicht = false;
            int MaxPerWeek = 3;
        }
        public class VerplichteGroenten
        {
            string Naam = "Verplichte groenten";
            bool Verplicht = true;
            int MaxPerWeek = 7;
        }
    }
}
