namespace XamarinNativePropertyManager.Models
{
    public class FileModel
    {
        public DriveItemModel DriveItem { get; set; }

        public FileType Type { get; set; }

        public FileModel()
        {
            
        }

        public FileModel(DriveItemModel driveItem, FileType type)
        {
            DriveItem = driveItem;
            Type = type;
        }
    }
}
