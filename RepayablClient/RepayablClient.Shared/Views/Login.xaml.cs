using RepayablClient.Shared.ViewModels;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace RepayablClient.Shared.Views
{
    public sealed partial class Login : UserControl
    {
        string graphAPIEndpoint = "https://graph.microsoft.com/v1.0/me";
        public Login()
        {
            this.InitializeComponent();
#if !NETFX_CORE
            this.DataContext = new LoginViewModel();
#endif
        }

    }
}
