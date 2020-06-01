using RepayablClient.Shared.Repositories;
using RepayablClient.Shared.ViewModels;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace RepayablClient.Shared.Views
{
    public sealed partial class Login : UserControl
    {
        string graphAPIEndpoint = "https://graph.microsoft.com/v1.0/me";
        public Login(IUserClient userClient)
        {

            this.InitializeComponent();
#if !NETFX_CORE
            this.DataContext = new LoginViewModel(userClient);
#endif
        }
        //public void OnClick(object sender, object args)
        //{
        //    var dt = DateTime.Now.ToString();
        //    TxtUser.Text = dt;
        //}

    }
}
