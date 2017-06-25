using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

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
