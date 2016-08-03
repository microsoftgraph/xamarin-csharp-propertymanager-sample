using System.IO;

namespace XamarinNativePropertyManager.Extensions
{
    public static class StringExtensions
    {
        public static Stream GetStream(this string str)
        {
            var stream = new MemoryStream();
            var streamWriter = new StreamWriter(stream);
            streamWriter.Write(str);
            streamWriter.Flush();
            stream.Position = 0;
            return stream;
        }
    }
}
