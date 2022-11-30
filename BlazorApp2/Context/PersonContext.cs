using BlazorApp2.Pages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace BlazorApp2.Context
{
    public class PersonContext : DbContext
    {
        public PersonContext()
        {

        }
        public void SaveData(List<Person> persons)
        {
            using (StreamWriter sr = new StreamWriter("C:/Data.json"))
            {
               
                    //persons = JsonConvert.DeserializeObject<List<Person>>(sr.ReadToEnd());
                    string json = JsonConvert.SerializeObject(persons, Formatting.Indented);
                    Console.WriteLine(json);
                    sr.Write(json);
                    //sr
            }
        }
        public List<Person> GetData()
        {
            List<Person> persons;
            using (StreamReader sr = new StreamReader("C:/Data.json"))
            {
                persons = JsonConvert.DeserializeObject<List<Person>>(sr.ReadToEnd());
            }
            return persons;
        }
    }
}
