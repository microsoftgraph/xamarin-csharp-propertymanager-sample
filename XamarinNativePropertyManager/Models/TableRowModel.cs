using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace XamarinNativePropertyManager.Models
{
    public class TableRowModel : List<JToken>
    {
        public TableRowModel()
        {
            
        }

        public TableRowModel(IEnumerable<JToken> collection)
            : base(collection)
        {
            
        }

        protected string GetString(int tokenIndex)
        {
            var token = this[tokenIndex];

            // Value is of type string when empty.
            return token.Type == JTokenType.String
                ? token.Value<string>()
                : (token.Value<int?>())?.ToString();
        }

        protected void TrySetInt(int tokenIndex, string value)
        {
            // Remove value if null or whitespace.
            if (string.IsNullOrWhiteSpace(value))
            {
                this[tokenIndex] = "";
                return;
            }

            // Try to parse.
            int i;
            if (int.TryParse(value, out i))
            {
                this[tokenIndex] = i;
            }
        }
    }
}
