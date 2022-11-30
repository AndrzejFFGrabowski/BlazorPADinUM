using Newtonsoft.Json;
using System.Text;

namespace BlazorApp2.Data
{
    public class Database
    {
        static string filePath = "C:/test.json";
        public static async Task WriteTextAsync(List<Person>persons)
        {
            
            string text = JsonConvert.SerializeObject(persons, Formatting.Indented);
            byte[] encodedText = Encoding.Unicode.GetBytes(text);

            using (FileStream sourceStream = new FileStream(filePath,
                FileMode.Create, FileAccess.Write, FileShare.None,
                bufferSize: 4096, useAsync: true))
            {
                await sourceStream.WriteAsync(encodedText, 0, encodedText.Length);
            };
        }

        public static async Task<List<Person>> ReadTextAsync()
        {
            using (FileStream sourceStream = new FileStream(filePath,
                FileMode.Open, FileAccess.Read, FileShare.Read,
                bufferSize: 4096, useAsync: true))
            {
                StringBuilder sb = new StringBuilder();

                byte[] buffer = new byte[0x1000];
                int numRead;
                while ((numRead = await sourceStream.ReadAsync(buffer, 0, buffer.Length)) != 0)
                {
                    string text = Encoding.Unicode.GetString(buffer, 0, numRead);
                    sb.Append(text);
                }

                List<Person> result = JsonConvert.DeserializeObject<List<Person>>(sb.ToString());

                return result;
            }
        }
    }
}
