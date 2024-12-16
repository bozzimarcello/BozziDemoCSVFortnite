using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BozziDemoCSVFortnite
{
    public class Partita
    {
        public string Date { get; set; }
        public string TimeOfDay { get; set; }
        public string Placed { get; set; }
        public string MentalState { get; set; }
        public int Eliminations { get; set; }
        public string Assists { get; set; }
        public string Revives { get; set; }
        public string Accuracy { get; set; }
        public string Hits { get; set; }
        public string HeadShots { get; set; }
        public string DistanceTraveled { get; set; }
        public string MaterialsGathered { get; set; }
        public string MaterialsUsed { get; set; }
        public string DamageTaken { get; set; }
        public string DamageToPlayers { get; set; }
        public string DamageToStructures { get; set; }
    }
}
