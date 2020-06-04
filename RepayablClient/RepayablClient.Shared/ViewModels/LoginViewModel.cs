using AsyncCommands;
using Microsoft.Identity.Client;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Services.Dialogs;
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
        public DelegateCommand SignUp1NextCommand { get; set; }
        public DelegateCommand SignUp2NextCommand { get; set; }
        public DelegateCommand SignUp2BackCommand { get; set; }

        string graphAPIEndpoint = "https://graph.microsoft.com/v1.0/me";
        private string _loginUser;
        private bool _isBusy;
        private Member _currentUser;
        private Visibility _isSignUp1Visible;
        private Visibility _isSignUp2Visible;
        private Visibility _isBusyVisible;
        private bool isLoginUiRequired;
        IUserClient _userClient;
        IDialogService _dialogService;
        private bool _isTenantChecked;
        private bool _isOwnerChecked;
        private User _signUpUser;
        private bool _isApartmentChecked;
        private bool _isFloorChecked;
        private bool _isHouseChecked;
        private Property _signUpUserProperty;
        public LoginViewModel(IUserClient userClient)
        {
            Title = "Login Page";
            _userClient = userClient;
            //_dialogService = dialogService;
            LoginUser = "Attempt to Login";
            LoginCommand = new AsyncCommand(LoginCommandExecutedAsync);
            SignUp1NextCommand = new DelegateCommand(SignUp1NextCommandExecuted);
            SignUp2NextCommand = new DelegateCommand(SignUp2NextCommandExecuted);
            SignUp2BackCommand = new DelegateCommand(SignUp2BackCommandExecuted);
            IsSignUp1Visible = Visibility.Collapsed;
            IsSignUp2Visible = Visibility.Collapsed;
            IsSignUp3Visible = Visibility.Collapsed;
            IsBusyVisible = Visibility.Visible;
        }

        private void SignUp2BackCommandExecuted()
        {
            IsBusyVisible = Visibility.Collapsed;
            IsSignUp1Visible = Visibility.Visible;
            IsSignUp2Visible = Visibility.Collapsed;
            IsSignUp3Visible = Visibility.Collapsed;
        }

        private void SignUp2NextCommandExecuted()
        {
            IsBusyVisible = Visibility.Collapsed;
            IsSignUp1Visible = Visibility.Collapsed;
            IsSignUp2Visible = Visibility.Collapsed;
            IsSignUp3Visible = Visibility.Visible;
        }

        private void SignUp1NextCommandExecuted()
        {
            if (SignUpUserProperty == null)
            {
                SignUpUserProperty = new Property();
            }
            IsBusyVisible = Visibility.Collapsed;
            IsSignUp1Visible = Visibility.Collapsed;
            IsSignUp2Visible = Visibility.Visible;
            IsSignUp3Visible = Visibility.Collapsed;
        }


        public Property SignUpUserProperty
        {
            get { return _signUpUserProperty; }
            set
            {
                _signUpUserProperty = value;
                RaisePropertyChanged();
            }
        }

        public bool IsApartmentChecked
        {
            get { return _isApartmentChecked; }
            set
            {
                _isApartmentChecked = value;
                if (value)
                {
                    SignUpUserProperty.Type = "Apartments";
                    IsFloorChecked = false;
                    IsHouseChecked = false;
                }
                RaisePropertyChanged();
            }
        }
        public bool IsFloorChecked
        {
            get { return _isFloorChecked; }
            set
            {
                _isFloorChecked = value;
                if (value)
                {
                    SignUpUserProperty.Type = "Floors";
                    IsApartmentChecked = false;
                    IsHouseChecked = false;
                }
                RaisePropertyChanged();
            }
        }
        public bool IsHouseChecked
        {
            get { return _isHouseChecked; }
            set
            {
                _isHouseChecked = value;
                if (value)
                {
                    SignUpUserProperty.Type = "House";
                    IsApartmentChecked = false;
                    IsFloorChecked = false;
                }
                RaisePropertyChanged();
            }
        }
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
        public Visibility IsSignUp3Visible
        {
            get { return _isSignUp3Visible; }
            set
            {
                _isSignUp3Visible = value;
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
        private bool isUserSaved;
        private Visibility _isSignUp3Visible;

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
            // _dialogService.ShowDialog("sdfsd", null, null);
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
                                Password = GeneratePassword(8)
                            };
                            await SaveUserAsync(SignUpUser);
                            IsBusyVisible = Visibility.Collapsed;
                            IsSignUp1Visible = Visibility.Visible;
                        }
                    }
                }
                catch (Exception ex)
                {
                    //IDialogService dialogService = new DialogService(); 
                }
            }
        }
        private async Task SaveUserAsync(User user)
        {
            await _userClient.SaveUserAsync(user);
            isUserSaved = true;
        }
        public string GeneratePassword(int lenth)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, lenth)
              .Select(s => s[random.Next(s.Length)]).ToArray());
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

                catch
                {
                    throw;
                }
            }
        }
    }
}
