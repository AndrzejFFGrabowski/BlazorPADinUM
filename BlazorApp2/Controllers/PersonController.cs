using BlazorApp2.Context;
using Grpc.Core;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using static System.Net.WebRequestMethods;
//using BlazorApp1.Data;

namespace BlazorApp2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        public static List<Person> persons = new List<Person>();
        public PersonContext personContext=new PersonContext();
        /*
        {
            new Person{Id = 1, name="Ala", age = 22},
            new Person{Id = 2, name = "Olo", age =33}
        };
        */
        
        public PersonController()
        {
            persons = personContext.GetData();
        }
        

        [HttpGet]
        public async Task<ActionResult<List<Person>>> GetPerson()
        {
            //var res = await Http.GetJsonAsync<List<Person>>("/data");

            //(HttpMethod.Post, "/api/Customer",< List<Person>>("data.json");
            var res =await ReadTextAsync("C:/test.json");
            persons = JsonConvert.DeserializeObject<List<Person>>(res);
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
        [HttpPost]
        public async Task AddPerson(Person person)
        {
            //var result = await _http.GetFromJsonAsync<List<Person>>("C:\\data.json");
            Console.WriteLine("tada");
            persons.Add(person);
            personContext.SaveData(persons);
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
    }
}
