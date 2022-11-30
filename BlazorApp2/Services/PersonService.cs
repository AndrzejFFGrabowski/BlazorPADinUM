using BlazorApp2.Controllers;
using BlazorApp2.Interfaces;
using BlazorApp2.Pages;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text;

namespace BlazorApp2.Services
{
    public class PersonService : IPersonService
    {
        private readonly HttpClient _http;
        public PersonService(HttpClient http)
        {
            _http = http;
        }
        public List<Person> people { get; set; } = new List<Person>();

        public async Task GetPerson()
        {
            //var result = await _http.GetFromJsonAsync<List<Person>>("https://localhost:44367/api/Person");
            //var result = await _http.GetFromJsonAsync<List<Person>>("C:\\data.json");
            string str = await ReadTextAsync("C:/test.json");
            int y = 2 * 2;
            people= JsonConvert.DeserializeObject<List<Person>>(str);

            //if (result != null)
            //    people = result;
        }

        public async Task AddPerson(Person person)
        {
            //var result = await _http.GetFromJsonAsync<List<Person>>("https://localhost:44367/api/Person");
            string str = await ReadTextAsync("C:/test.json");
            people = JsonConvert.DeserializeObject<List<Person>>(str);
            people.Add(person);
            string json = JsonConvert.SerializeObject(people, Formatting.Indented);

            await WriteTextAsync("C:/test.json", json);

            
        }

        static async Task WriteTextAsync(string filePath, string text)
        {
            byte[] encodedText = Encoding.Unicode.GetBytes(text);

            using (FileStream sourceStream = new FileStream(filePath,
                FileMode.Create, FileAccess.Write, FileShare.None,
                bufferSize: 4096, useAsync: true))
            {
                await sourceStream.WriteAsync(encodedText, 0, encodedText.Length);
            };
        }

        static async Task<string> ReadTextAsync(string filePath)
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

                return sb.ToString();
            }
        }

        public Task GetSinglePerson(int id)
        {
            /*
            var result = await _http.GetFromJsonAsync<List<Person>>("https://localhost:44367/api/Person/{id}");
            //var result = await _http.GetFromJsonAsync<List<Person>>("C:\\data.json");
            if (result != null)return result;
            throw new Exception("Person not found");
            */
            throw new NotImplementedException();
        }

    }
    }
