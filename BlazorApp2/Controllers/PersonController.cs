using Grpc.Core;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using static System.Net.WebRequestMethods;
//using BlazorApp1.Data;

namespace BlazorApp2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        public static List<Person> persons = new List<Person>();
        /*
        {
            new Person{Id = 1, name="Ala", age = 22},
            new Person{Id = 2, name = "Olo", age =33}
        };
        */
        
        public PersonController()
        {
            using (StreamReader sr = new StreamReader("C:/Data.json"))
            {
                persons = JsonConvert.DeserializeObject<List<Person>>(sr.ReadToEnd());
            }
        }
        

        [HttpGet]
        public async Task<ActionResult<List<Person>>> GetPerson()
        {
            //var res = await Http.GetJsonAsync<List<Person>>("/data");

                //(HttpMethod.Post, "/api/Customer",< List<Person>>("data.json");
            return Ok(persons);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Person>>> GetPerson(int id)
        {
            var someone = persons.FirstOrDefault(h => h.Id == id);
            if(someone == null)
            {
                return NotFound("No person:/");
            }
            return Ok(persons);
        }
        [HttpPost("AddActor")]
        public async Task<ActionResult> AddPerson(Person person)
        {
            
            var result = await _http.GetFromJsonAsync<List<Person>>("https://localhost:44367/api/Person");
            using (StreamWriter sr = new StreamWriter("C:/Data.json"))
            {
                persons.Add(person);
                string json = JsonConvert.SerializeObject(persons, Formatting.Indented);
                Console.WriteLine(json);
                sr.Write(json);
                //sr
            }
            return Ok(persons);
        }
    }
}
