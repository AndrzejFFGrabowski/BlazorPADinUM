using BlazorApp2.Controllers;
using BlazorApp2.Interfaces;
using BlazorApp2.Pages;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Reactive;
using System.Text;
using System.Web;


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
        //private const string uri = "http://localhost:44367/api/Person";
        private const string uri = "http://192.168.1.118:7205/api/Person";
        public async Task GetPerson()
        {
            var result = await _http.GetFromJsonAsync<List<Person>>(uri);
            if (result != null)
                people = result;
        }

        public async Task AddPerson(Person person)
        {
            var result = await _http.PostAsJsonAsync<Person>(uri, person);    
        }
        public async Task EditPerson(Person person)
        {
            var result = await _http.PutAsJsonAsync<Person>(uri, person);
        }

        public async Task DeletePerson(int id)
        {
            //UriBuilder builder = new UriBuilder(uri);
            //var query = HttpUtility.ParseQueryString(builder.Query);
            //query["id"] = id.ToString();
            //builder.Query = query.ToString();
            //var result = await _http.DeleteAsync(builder.Uri);
            var result = await _http.DeleteAsync(uri+"/"+id.ToString());
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
