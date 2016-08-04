/*
 *  Copyright (c) Microsoft. All rights reserved. Licensed under the MIT license.
 *  See LICENSE in the source repository root for complete license information.
 */

namespace XamarinNativePropertyManager.Models
{
    public class EmailAddressModel
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public EmailAddressModel()
        {
            
        }

        public EmailAddressModel(string name, string address)
        {
            Name = name;
            Address = address;
        }
    }
}
