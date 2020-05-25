using System;
using System.Collections.Generic;

namespace RepayablClient.Shared.Models
{
    public class Member
    {
        //{"@odata.context":"https://graph.microsoft.com/v1.0/$metadata#users/$entity","displayName":"Avnish Kumar","surname":"Kumar","givenName":"Avnish","id":"f1ca44fe05a0afef","userPrincipalName":"avikeid2007@live.com","businessPhones":[],"jobTitle":null,"mail":null,"mobilePhone":null,"officeLocation":null,"preferredLanguage":null}

        public string Context { get; set; }
        public string Id { get; set; }
        public string DisplayName { get; set; }
        public string GivenName { get; set; }
        public string Surname { get; set; }
        public string UserPrincipalName { get; set; }
        public List<string> BusinessPhones { get; set; }
        public string JobTitle { get; set; }
        public string Mail { get; set; }
        public string MobilePhone { get; set; }
        public string OfficeLocation { get; set; }
        public string PreferredLanguage { get; set; }
        // public Value[] value { get; set; }
    }
    public class Value
    {
        public string odatatype { get; set; }
        public object deletedDateTime { get; set; }
        public object classification { get; set; }
        public DateTime createdDateTime { get; set; }
        public object[] creationOptions { get; set; }
        public object description { get; set; }
        public string displayName { get; set; }
        public string[] groupTypes { get; set; }
        public string mail { get; set; }
        public bool mailEnabled { get; set; }
        public string mailNickname { get; set; }
        public object onPremisesLastSyncDateTime { get; set; }
        public object onPremisesSecurityIdentifier { get; set; }
        public object onPremisesSyncEnabled { get; set; }
        public object preferredDataLocation { get; set; }
        public string[] proxyAddresses { get; set; }
        public DateTime renewedDateTime { get; set; }
        public object[] resourceBehaviorOptions { get; set; }
        public object[] resourceProvisioningOptions { get; set; }
        public bool securityEnabled { get; set; }
        public string visibility { get; set; }
        public object[] onPremisesProvisioningErrors { get; set; }

        public override string ToString()
        {
            return displayName;
        }
    }

}
