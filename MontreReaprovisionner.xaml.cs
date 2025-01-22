namespace MontresETPrestiges;

public partial class MontreReaprovisionner : ContentPage
{
    private List<Montre> montresReaprovisionner;
	public MontreReaprovisionner()
	{
		InitializeComponent();
        LoadMontres();
	}
    private async void LoadMontres()
    {
        try
        {
            montresReaprovisionner = await Contexte.GetProduitsReapprovisionnement();
            MontresListView.ItemsSource = montresReaprovisionner;
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erreur", "Impossible de récupérer la liste des montres : " + ex.Message, "OK");
        }
    }
}