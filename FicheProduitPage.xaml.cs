namespace MontresETPrestiges;

public partial class FicheProduitPage : ContentPage
{
	private Montre _montre; // la montre a afficher
	public FicheProduitPage(Montre montre)
	{
		InitializeComponent();
		_montre = montre;
		BindingContext = _montre;
	}

    private async void OnEnregistrerClicked(object sender, EventArgs e)
    {
        if (int.TryParse(SeuilAlerteEntry.Text, out int seuilAlerte))
        {
            _montre.SeuilAlerte = seuilAlerte;
            bool success = await Contexte.UpdateSeuilMontre(_montre.Id, seuilAlerte);

            if (success)
            {
                await DisplayAlert("Modification", "Le seuil a bien été changé", "OK");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Erreur", "La mise à jour du seuil a échoué. Veuillez réessayer.", "OK");
            }
        }
        else
        {
            await DisplayAlert("Erreur", "Veuillez entrer une quantité d'alerte valide", "OK");
        }
    }

}