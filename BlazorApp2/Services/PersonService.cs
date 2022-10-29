using BlazorApp2.Interfaces;
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

        public Task GetSinglePerson(int id)
        {
            throw new NotImplementedException();
        }
    }
}
