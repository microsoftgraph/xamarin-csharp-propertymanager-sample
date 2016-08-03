using Newtonsoft.Json.Linq;

namespace XamarinNativePropertyManager.Models
{
    public class PropertyTableRowModel : TableRowModel
    {
        public string Id
        {
            get { return this[0].Value<string>(); }
            set { this[0] = value; }
        }

        public string Description
        {
            get { return this[1].Value<string>(); }
            set { this[1] = value; }
        }

        public string Rooms
        {
            get { return GetString(2); }
            set { TrySetInt(2, value); }
        }

        public string LivingArea
        {
            get { return GetString(3); }
            set { TrySetInt(3, value); }
        }

        public string LotSize
        {
            get { return GetString(4); }
            set { TrySetInt(4, value); }
        }

        public string OperatingCosts
        {
            get { return GetString(5); }
            set { TrySetInt(5, value); }
        }

        public PropertyTableRowModel()
        {
            // Add default values.
            for (var i = 0; i < Constants.DataFilePropertyTableColumns; i++)
            {
                Add("");
            }
        }
    }
}
