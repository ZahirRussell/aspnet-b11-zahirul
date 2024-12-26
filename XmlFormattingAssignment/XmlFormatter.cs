using System.Collections;
using System.Reflection;
using System.Text;

namespace XmlFormattingAssignment
{
    public static class XmlFormatter
    {
        public static string Convert(object obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            StringBuilder sb = new StringBuilder();
            Type type = obj.GetType();
            //ToDo XML Serialize
            return sb.ToString();
        }

        private static void SerializeObject(object obj, string tagName, StringBuilder xmlBuilder)
        {
            if(obj == null)
            {
                //ToDo Append Null Properties
                AppendTag(xmlBuilder, tagName, null);
                return;
            }
        }

        private static void AppendTag(StringBuilder xmlBuilder, string tagName, string value) { xmlBuilder.Append(tagName); xmlBuilder.Append(value); }

    }
}