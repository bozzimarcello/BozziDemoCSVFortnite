using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections.ObjectModel;

namespace BozziDemoCSVFortnite
{
    public class Partite
    {
        public ObservableCollection<Partita> ElencoPartite { get; set; }

        public Partite()
        {
            ElencoPartite = new ObservableCollection<Partita>();
        }

        public int LeggiDati()
        {
            int numeroRighe = 0;
            bool intestazione = true;

            try
            {
                string percorsoRelativo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "FortniteStatistics.csv");

                using (FileStream stream = new FileStream(percorsoRelativo, FileMode.Open, FileAccess.Read))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        while (reader.EndOfStream == false)
                        {
                            // leggo una riga dal file
                            string riga = reader.ReadLine();

                            if (intestazione)
                            {
                                intestazione = false;
                                continue;
                            }

                            // splitto la riga in base al carattere ','
                            string[] celle = riga.Split(',');

                            // creo l'oggetto partita
                            Partita partita = new Partita();

                            // assegno i valori alle proprietà dell'oggetto partita
                            partita.Date = celle[0];
                            partita.TimeOfDay = celle[1];
                            partita.Placed = celle[2];
                            partita.MentalState = celle[3];
                            partita.Eliminations = int.Parse(celle[4]);
                            partita.Assists = celle[5];
                            partita.Revives = celle[6];
                            partita.Accuracy = celle[7];
                            partita.Hits = celle[8];
                            partita.HeadShots = celle[9];
                            partita.DistanceTraveled = celle[10];
                            partita.MaterialsGathered = celle[11];
                            partita.MaterialsUsed = celle[12];
                            partita.DamageTaken = celle[13];
                            partita.DamageToPlayers = celle[14];
                            partita.DamageToStructures = celle[15];

                            // aggiungo l'oggetto partita alla lista
                            ElencoPartite.Add(partita);

                            // incremento il contatore delle righe
                            numeroRighe++;
                        }
                    }

                }

            }
            catch (Exception eccezione)
            {
                throw eccezione;
            }

            return numeroRighe;
        }

        internal string CalcolaMassimoEliminazioni()
        {
            int massimo = int.MinValue;

            foreach (var partita in ElencoPartite)
            {
                if (partita.Eliminations > massimo)
                {
                    massimo = partita.Eliminations;
                }
            }

            return massimo.ToString();
        }

        public int ContaHigh()
        {
            int contatore = 0;

            foreach (var partita in ElencoPartite)
            {
                if (partita.MentalState == "high")
                {
                    contatore++;
                }
            }

            return contatore;
        }
    }
}
