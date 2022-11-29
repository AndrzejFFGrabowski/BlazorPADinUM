using BlazorApp2.Controllers;
using BlazorApp2.Interfaces;
using BlazorApp2.Pages;
using Newtonsoft.Json;
using System.Net.Http.Json;

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
            var result = await _http.GetFromJsonAsync<List<Person>>("https://localhost:44367/api/Person");
            //var result = await _http.GetFromJsonAsync<List<Person>>("C:\\data.json");

            if (result != null)
                people = result;
        }

        public async Task AddPerson(Person person)
        {
            //var result = await _http.GetFromJsonAsync<List<Person>>("https://localhost:44367/api/Person/AddActor");
            string json = JsonConvert.SerializeObject(person, Formatting.Indented);
            var result = await _http.PostAsJsonAsync(json, "https://localhost:44367/api/Person/AddActor");
            
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
