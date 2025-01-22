namespace MontresETPrestiges
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void NavGestionStock(object sender, EventArgs e)
        {
            Navigation.PushAsync(new GestionStocksPage());
        }

        public void NavSuivieCommande(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SuivieCommandePage());
        }
    }
}
