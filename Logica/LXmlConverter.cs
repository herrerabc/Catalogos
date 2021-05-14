using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Logica
{
    public class LXmlConverter
    {
        public XmlDocument SerializeToXmlDocument(object input)
        {
            XmlSerializer ser = new XmlSerializer(input.GetType(), "http://schemas.yournamespace.com");

            XmlDocument xd = null;

            using (MemoryStream memStm = new MemoryStream())
            {
                ser.Serialize(memStm, input);

                memStm.Position = 0;

                XmlReaderSettings settings = new XmlReaderSettings();
                settings.IgnoreWhitespace = true;

                using (var xtr = XmlReader.Create(memStm, settings))
                {
                    xd = new XmlDocument();
                    xd.Load(xtr);
                    
                }
            }

            return xd;
        }
    }
}
