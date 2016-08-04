/*
 *  Copyright (c) Microsoft. All rights reserved. Licensed under the MIT license.
 *  See LICENSE in the source repository root for complete license information.
 */

using System.Collections.Generic;

namespace XamarinNativePropertyManager.Models
{
    public class UserModel
    {
        public string Id { get; set; }

        public bool AccountEnabled { get; set; }

        public string City { get; set; }

        public string CompanyName { get; set; }

        public string Country { get; set; }

        public string Department { get; set; }

        public string DisplayName { get; set; }

        public string GivenName { get; set; }

        public string JobTitle { get; set; }

        public string Mail { get; set; }

        public string MailNickname { get; set; }

        public string MobilePhone { get; set; }

        public string OfficeLocation { get; set; }

        public string PostalCode { get; set; }

        public string PreferredLanguage { get; set; }

        public List<string> ProxyAddresses { get; set; }

        public string StreetAddress { get; set; }

        public string Surname { get; set; }

        public string UsageLocation { get; set; }

        public string UserPrincipalName { get; set; }

        public string UserType { get; set; }
    }
}