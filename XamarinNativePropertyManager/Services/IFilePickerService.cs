using System.Threading.Tasks;
using XamarinNativePropertyManager.Models;

namespace XamarinNativePropertyManager.Services
{
    public interface IFilePickerService
    {
        Task<PickedFileModel> GetFileAsync();
    }
}
