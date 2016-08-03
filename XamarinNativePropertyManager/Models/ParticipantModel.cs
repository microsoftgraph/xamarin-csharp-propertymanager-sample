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
