#if !NET35
using System.IO;

namespace Twilio.Types
{
    public interface IUploadFile
    {
        string FileName { get; }
        Stream Stream { get; }
    }

    public class UploadFile: IUploadFile
    {
        public UploadFile(string fileName, Stream stream)
        {
            FileName = fileName;
            Stream = stream;
        }

        public string FileName { get; private set; }
        public Stream Stream { get; private set; }
    }
}
#endif