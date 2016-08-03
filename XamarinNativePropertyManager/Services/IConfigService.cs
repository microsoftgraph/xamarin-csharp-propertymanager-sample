using System.Collections.Generic;
using XamarinNativePropertyManager.Models;

namespace XamarinNativePropertyManager.Services
{
    public interface IConfigService
    {
        UserModel User { get; set; }

        GroupModel AppGroup { get; set; }

        List<GroupModel> Groups { get; set; }

        DataFileModel DataFile { get; set; }
    }
}
