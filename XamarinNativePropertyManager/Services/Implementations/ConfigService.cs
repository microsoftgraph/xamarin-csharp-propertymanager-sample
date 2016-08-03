using System.Collections.Generic;
using XamarinNativePropertyManager.Models;

namespace XamarinNativePropertyManager.Services
{
    public class ConfigService : IConfigService
    {
        public UserModel User { get; set; }

        public GroupModel AppGroup { get; set; }

        public List<GroupModel> Groups { get; set; }

        public DataFileModel DataFile { get; set; }
    }
}
