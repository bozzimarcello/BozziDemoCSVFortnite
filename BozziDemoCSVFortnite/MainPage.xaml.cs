// dati presi da https://www.kaggle.com/datasets/joebeachcapital/fortnite-statistics?select=Fortnite+Statistics.csv

namespace BozziDemoCSVFortnite
{
    public partial class MainPage : ContentPage
    {
        private Partite _partite;

        public MainPage()
        {
            InitializeComponent();
            _partite = new Partite();
            ListaElementi.ItemsSource = _partite.ElencoPartite;
        }


        private void BtnCaricaDati_Clicked(object sender, EventArgs e)
        {
            try
            {
                int numeroRighe = _partite.LeggiDati();
                LblNumeroRighe.Text = $"Numero di righe lette: {numeroRighe}";
            }
            catch (Exception eccezione)
            {
                DisplayAlert("Errore", eccezione.Message, "OK");
            }
        }

        private void BtnMAssimoEliminazioni_Clicked(object sender, EventArgs e)
        {
            LblMassimoElminazioni.Text = _partite.CalcolaMassimoEliminazioni();
        }
    }

}
