using System.Collections.Generic;

namespace XamarinNativePropertyManager.Models
{
    public class NewPostModel
    {
        public BodyModel Body { get; set; }

        public List<ParticipantModel> NewParticipants { get; set; }
    }
}
