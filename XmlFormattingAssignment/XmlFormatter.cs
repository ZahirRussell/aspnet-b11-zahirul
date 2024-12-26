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
            SerializeObject(obj, type.Name, sb);
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

            Type type = obj.GetType();
            //ToDO Append Plain Object
            if (type.IsPrimitive ||
                   type.IsEnum ||
                   type == typeof(string) ||
                   type == typeof(decimal) ||
                   type == typeof(DateTime) ||
                   type == typeof(Guid))
            {
                AppendTag(xmlBuilder,tagName,obj.ToString());
            }
            else if (typeof(IEnumerable).IsAssignableFrom(type))
            {
                AppendOpeningTag(xmlBuilder, tagName); // set openining tag

                foreach (var item in (IEnumerable)obj)
                {
                    SerializeObject(item, item.GetType().Name, xmlBuilder);
                }

                AppendClosingTag(xmlBuilder, tagName); // set closing tag
            }
            else
            {
                AppendOpeningTag(xmlBuilder, tagName); // set opening tag

                foreach (var property in type.GetProperties(BindingFlags.Public | BindingFlags.Instance))
                {
                    if (property.CanRead)
                    {
                        object value = property.GetValue(obj);
                        SerializeObject(value, property.Name, xmlBuilder);
                    }
                }

                AppendClosingTag(xmlBuilder, tagName); // set closing tag
            }
        }

        private static void AppendTag(StringBuilder xmlBuilder, string tagName, string value)
        {
            if (value == null)
            {
                xmlBuilder.AppendLine($"<{tagName}></{tagName}>");
            }
            else
            {
                xmlBuilder.AppendLine($"<{tagName}>{value}</{tagName}>");
            }
        }

        private static void AppendOpeningTag(StringBuilder xmlBuilder, string tagName)
        {
            xmlBuilder.AppendLine($"<{tagName}>");
        }

        private static void AppendClosingTag(StringBuilder xmlBuilder, string tagName)
        {
            xmlBuilder.AppendLine($"</{tagName}>");
        }

    }
}