/*
 *  Copyright (c) Microsoft. All rights reserved. Licensed under the MIT license.
 *  See LICENSE in the source repository root for complete license information.
 */

namespace XamarinNativePropertyManager.Models
{
    public class ParticipantModel
    {
        public EmailAddressModel EmailAddress { get; set; }

        public ParticipantModel()
        {
            
        }

        public ParticipantModel(string name, string address)
            : this(new EmailAddressModel(name, address))
        {

        }

        public ParticipantModel(EmailAddressModel emailAddress)
        {
            EmailAddress = emailAddress;
        }
    }
}
