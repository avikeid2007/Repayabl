using Prism.Mvvm;
using System.Collections.Generic;

namespace RepayablClient.Shared.Models
{
    public class Member : BindableBase
    {
        //{"@odata.context":"https://graph.microsoft.com/v1.0/$metadata#users/$entity","displayName":"Avnish Kumar","surname":"Kumar","givenName":"Avnish","id":"f1ca44fe05a0afef","userPrincipalName":"avikeid2007@live.com","businessPhones":[],"jobTitle":null,"mail":null,"mobilePhone":null,"officeLocation":null,"preferredLanguage":null}

        private string _context;
        private string _id;
        private string _displayName;
        private string _givenName;
        private string _surname;
        private string _userPrincipalName;
        private List<string> _businessPhones;
        private string _jobTitle;
        private string _mail;
        private string _mobilePhone;
        private string _officeLocation;
        private string _preferredLanguage;
        /////////////////////////////////public properties by Avnish's property generator utility////////////////////////
        public string Context
        {
            get { return _context; }
            set
            {
                _context = value;
                //RaisePropertyChanged();
            }
        }
        public string Id
        {
            get { return _id; }
            set
            {
                _id = value;
                //RaisePropertyChanged();
            }
        }
        public string DisplayName
        {
            get { return _displayName; }
            set
            {
                _displayName = value;
                //RaisePropertyChanged();
            }
        }
        public string GivenName
        {
            get { return _givenName; }
            set
            {
                _givenName = value;
                //RaisePropertyChanged();
            }
        }
        public string Surname
        {
            get { return _surname; }
            set
            {
                _surname = value;
                //RaisePropertyChanged();
            }
        }
        public string UserPrincipalName
        {
            get { return _userPrincipalName; }
            set
            {
                _userPrincipalName = value;
                //RaisePropertyChanged();
            }
        }
        public List<string> BusinessPhones
        {
            get { return _businessPhones; }
            set
            {
                _businessPhones = value;
                //RaisePropertyChanged();
            }
        }
        public string JobTitle
        {
            get { return _jobTitle; }
            set
            {
                _jobTitle = value;
                //RaisePropertyChanged();
            }
        }
        public string Mail
        {
            get { return _mail; }
            set
            {
                _mail = value;
                //RaisePropertyChanged();
            }
        }
        public string MobilePhone
        {
            get { return _mobilePhone; }
            set
            {
                _mobilePhone = value;
                //RaisePropertyChanged();
            }
        }
        public string OfficeLocation
        {
            get { return _officeLocation; }
            set
            {
                _officeLocation = value;
                //RaisePropertyChanged();
            }
        }
        public string PreferredLanguage
        {
            get { return _preferredLanguage; }
            set
            {
                _preferredLanguage = value;
                //RaisePropertyChanged();
            }
        }
        // public Value[] value { get; set; }
    }
    //public class Value
    //{
    //    public string odatatype { get; set; }
    //    public object deletedDateTime { get; set; }
    //    public object classification { get; set; }
    //    public DateTime createdDateTime { get; set; }
    //    public object[] creationOptions { get; set; }
    //    public object description { get; set; }
    //    public string displayName { get; set; }
    //    public string[] groupTypes { get; set; }
    //    public string mail { get; set; }
    //    public bool mailEnabled { get; set; }
    //    public string mailNickname { get; set; }
    //    public object onPremisesLastSyncDateTime { get; set; }
    //    public object onPremisesSecurityIdentifier { get; set; }
    //    public object onPremisesSyncEnabled { get; set; }
    //    public object preferredDataLocation { get; set; }
    //    public string[] proxyAddresses { get; set; }
    //    public DateTime renewedDateTime { get; set; }
    //    public object[] resourceBehaviorOptions { get; set; }
    //    public object[] resourceProvisioningOptions { get; set; }
    //    public bool securityEnabled { get; set; }
    //    public string visibility { get; set; }
    //    public object[] onPremisesProvisioningErrors { get; set; }

    //    public override string ToString()
    //    {
    //        return displayName;
    //    }
    //}

}
