using System.Collections.ObjectModel;

namespace MontresETPrestiges;

public partial class GestionStocksPage : ContentPage
{
    private List<Montre> montres;
    private List<Montre> montresReaprovisionner;

    public GestionStocksPage()
    {
        InitializeComponent();
        LoadMontre();
    }
    private async void LoadMontre()
    {
        montres = await Contexte.GetLesMontres(0); // DE BASE ON PREND TOUTES LES MONTRES
        MontresCollection.ItemsSource = montres;
    }

    private void OnTrierCroissantClicked(object sender, EventArgs e)
    {
        MontresCollection.ItemsSource = new ObservableCollection<Montre>(montres.OrderBy(m => m.Quantite));
    }

    private void OnTrierDecroissantClicked(Object sender, EventArgs e)
    {
        MontresCollection.ItemsSource = new ObservableCollection<Montre>(montres.OrderByDescending(m => m.Quantite));
    }

    private async void OnCategoriePickerSelectedIndexChanged(object sender, EventArgs e)
    {
        montres = await Contexte.GetLesMontres(CategoriePicker.SelectedIndex); 
        MontresCollection.ItemsSource = montres;
    }

    private async void OnMontreTapped(object sender, EventArgs e)
    {
        var frame = sender as Frame;
        var montre = frame.BindingContext as Montre;
        if (montre != null)
        {
            await Navigation.PushAsync(new FicheProduitPage(montre));
        }
    }

    private async void OnMontreReaproviser(object sender,EventArgs e)
    {
        await Navigation.PushAsync(new MontreReaprovisionner());
    }
}