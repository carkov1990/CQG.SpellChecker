using System;

namespace CQG.SpellChecker.Models
{
    /// <summary>
    /// Модель редакционного предписания.
    /// </summary>
    public class Prescription
    {
        /// <summary>
        /// Редакционное предписание.
        /// </summary>
        public String Route { get; set; }
        
        /// <summary>
        /// Редакционное расстояние.
        /// </summary>
        public int Distance { get; set; }

        /// <summary>
        /// .ctor
        /// </summary>
        public Prescription(int distance, String route) {
            Distance = distance;
            Route = route;
        }
    }
}