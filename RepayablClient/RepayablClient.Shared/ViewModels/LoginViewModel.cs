using AsyncCommands;
using Microsoft.Identity.Client;
using Newtonsoft.Json;
using RepayablClient.Shared.Models;
using RepayablClient.Shared.Repositories;
using RepayablClient.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml;

namespace RepayablClient.Shared.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        public ICommand LoginCommand { get; set; }
        string graphAPIEndpoint = "https://graph.microsoft.com/v1.0/me";
        private string _loginUser;
        private bool _isBusy;
        private Member _currentUser;
        private Visibility _isSignUp1Visible;
        private Visibility _isSignUp2Visible;
        private Visibility _isBusyVisible;
        private bool isLoginUiRequired;
        IUserClient _userClient;

        public LoginViewModel(IUserClient userClient)
        {
            Title = "Login Page";
            _userClient = userClient;
            LoginUser = "Attempt to Login";

            //_ = CoreWindow.GetForCurrentThread().Dispatcher.RunAsync(CoreDispatcherPriority.Normal, async () => await LoginCommandExecutedAsync());
            //_ = LoginCommandExecutedAsync();
            LoginCommand = new AsyncCommand(LoginCommandExecutedAsync);
            IsSignUp1Visible = Visibility.Collapsed;
            IsBusyVisible = Visibility.Visible;
        }
        private bool _isTenantChecked;
        private bool _isOwnerChecked;
        private User _signUpUser;

        public User SignUpUser
        {
            get { return _signUpUser; }
            set
            {
                _signUpUser = value;
                RaisePropertyChanged();
            }
        }
        public bool IsTenantChecked
        {
            get { return _isTenantChecked; }
            set
            {
                _isTenantChecked = value;
                if (value)
                {
                    IsOwnerChecked = false;
                }
                RaisePropertyChanged();
            }
        }
        public bool IsOwnerChecked
        {
            get { return _isOwnerChecked; }
            set
            {
                _isOwnerChecked = value;
                if (value)
                {
                    IsTenantChecked = false;
                }
                if (SignUpUser != null)
                {
                    SignUpUser.IsAdmin = value;
                }
                RaisePropertyChanged();
            }
        }
        public Visibility IsSignUp1Visible
        {
            get { return _isSignUp1Visible; }
            set
            {
                _isSignUp1Visible = value;
                RaisePropertyChanged();
            }
        }
        public Visibility IsSignUp2Visible
        {
            get { return _isSignUp2Visible; }
            set
            {
                _isSignUp2Visible = value;
                RaisePropertyChanged();
            }
        }
        public Visibility IsBusyVisible
        {
            get { return _isBusyVisible; }
            set
            {
                _isBusyVisible = value;
                RaisePropertyChanged();
            }
        }
        public Member CurrentUser
        {
            get { return _currentUser; }
            set
            {
                SetProperty(ref _currentUser, value);
            }
        }
        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                RaisePropertyChanged();
            }
        }
        public string LoginUser
        {
            get { return _loginUser; }
            set
            {
                _loginUser = value;
                RaisePropertyChanged();
            }
        }

        AuthenticationResult authResult = null;
        private async Task LoginCommandExecutedAsync()
        {

            IsBusy = true;
            await ValidateUerAsync();
            await MsalUILoginAsync();
            await CallGraphAsync(authResult);
            IsBusy = false;

        }

        private async Task MsalUILoginAsync()
        {
            if (isLoginUiRequired)
            {
                try
                {
                    authResult = await App.publicClientApplication.AcquireTokenInteractive(Consts.Scopes)
#if __ANDROID__
                   .WithParentActivityOrWindow(App.ParentWindow)
#endif
                       .ExecuteAsync();
                }
                catch (MsalException msalex)
                {
                }
                catch (Exception exx)
                {
                }
            }
        }

        private async Task ValidateUerAsync()
        {
            IEnumerable<IAccount> accounts = await App.publicClientApplication.GetAccountsAsync().ConfigureAwait(false);
            IAccount firstAccount = accounts.FirstOrDefault();
            if (firstAccount != null)
            {
                try
                {
                    authResult = await App.publicClientApplication.AcquireTokenSilent(Consts.Scopes, firstAccount)
                                                            .ExecuteAsync();
                }
                catch (MsalUiRequiredException ex)
                {
                    isLoginUiRequired = true;
                }
            }
            else
            {
                isLoginUiRequired = true;
            }
        }
        private async Task CallGraphAsync(AuthenticationResult authResult)
        {
            if (authResult != null)
            {
                try
                {
                    LoginUser = "User" + authResult.Account.Username;
                    var content = await GetHttpContentWithTokenAsync(graphAPIEndpoint,
                                                                authResult.AccessToken);
                    CurrentUser = JsonConvert.DeserializeObject<Member>(content);
                    if (CurrentUser != null)
                    {
                        var users = await _userClient.GetManyUsersAsync(azureId: CurrentUser.Id);
                        if (users?.Count > 0)
                        {

                        }
                        else
                        {
                            SignUpUser = new User
                            {
                                Id = Guid.NewGuid(),
                                AzureId = CurrentUser.Id,
                                DisplayName = CurrentUser.DisplayName,
                                GivenName = CurrentUser.GivenName,
                                JobTitle = CurrentUser.JobTitle,
                                Mail = CurrentUser.Mail,
                                MobilePhone = CurrentUser.MobilePhone,
                                OfficeLocation = CurrentUser.OfficeLocation,
                                Surname = CurrentUser.Surname,
                                UserPrincipalName = CurrentUser.UserPrincipalName,
                                UserName = CurrentUser.UserPrincipalName,
                            };
                            IsBusyVisible = Visibility.Collapsed;
                            IsSignUp1Visible = Visibility.Visible;
                        }
                    }
                }
                catch (Exception ex)
                {

                }
            }
        }

        public async Task<string> GetHttpContentWithTokenAsync(string url, string token)
        {
            using (var httpClient = new System.Net.Http.HttpClient())
            {
                System.Net.Http.HttpResponseMessage response;
                try
                {
                    var request = new System.Net.Http.HttpRequestMessage(System.Net.Http.HttpMethod.Get, url);
                    // Add the token in Authorization header
                    request.Headers.Authorization =
                      new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                    response = await httpClient.SendAsync(request);
                    return await response.Content.ReadAsStringAsync();
                }

                catch (Exception ex)
                {
                    return ex.ToString();
                }
            }
        }
    }
}
