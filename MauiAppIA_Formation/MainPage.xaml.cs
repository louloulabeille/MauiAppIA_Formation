using MauiAppIA_Formation.Infrastructure.ModelConfiguration;
using Microsoft.Extensions.Options;

namespace MauiAppIA_Formation
{
    public partial class MainPage : ContentPage
    {
        #region private readonly properties
        private readonly IOptions<ApiConfig> _api;
        #endregion

        #region constructeur
        public MainPage(IOptions<ApiConfig> api)
        {
            InitializeComponent();

            // - passe les valeurs de la configuration de l'api dans la page par injection dépendance 
            _api = api;

        }
        #endregion

        #region event handler clicled
        private void OnSendClicked(object? sender, EventArgs e)
        {
            
        }
        #endregion
    }
}
