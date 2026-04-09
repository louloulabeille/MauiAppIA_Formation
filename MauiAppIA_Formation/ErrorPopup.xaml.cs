namespace MauiAppIA_Formation;

public partial class ErrorPopup : ContentPage
{


	public ErrorPopup(HttpResponseMessage response)
	{
		InitializeComponent();
		ErrorMessageLabel.Text = $"Error: {response.StatusCode}";
	}
}