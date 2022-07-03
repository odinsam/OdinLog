using System.IO;
using Newtonsoft.Json;

namespace OdinLog.OdinUtils
{
    public static class StringExtensions
    {
        /// <summary>
        /// 格式化json字符串
        /// </summary>
        /// <param name="str">json string</param>
        /// <returns>json format string</returns>
        public static string ToJsonFormatString(this string str)
        {
            //格式化json字符串
            JsonSerializer serializer = new JsonSerializer();
            TextReader tr = new StringReader(str);
            JsonTextReader jtr = new JsonTextReader(tr);
            object obj = serializer.Deserialize(jtr);
            if (obj != null)
            {
                StringWriter textWriter = new StringWriter();
                JsonTextWriter jsonWriter = new JsonTextWriter(textWriter)
                {
                    Formatting = Newtonsoft.Json.Formatting.Indented,
                    Indentation = 4,
                    IndentChar = ' '
                };
                serializer.Serialize(jsonWriter, obj);
                return textWriter.ToString();
            }
            else
            {
                return str;
            }
        }
    }
}

