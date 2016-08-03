using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace XamarinNativePropertyManager.Models
{
    public class TableColumnModel
    {
        public string Id { get; set; }

        public int Index { get; set; }

        public string Name { get; set; }

        public List<List<JToken>> Values { get; set; }
    }
}
