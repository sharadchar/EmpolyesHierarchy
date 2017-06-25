using System.IO;
using System.Reflection;

namespace Common
{
    public static class EmbededFileHelper
    {
        public static string ReadEmbededfile(Assembly asse, string name)
        {            
            using (Stream stream = asse.GetManifestResourceStream(asse.GetName().Name+"."+name))
            {
                using (var reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }
    }
}
