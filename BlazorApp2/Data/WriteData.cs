using BlazorApp2.Pages;
using Newtonsoft.Json;

namespace BlazorApp2.Data
{
    public class WriteData
    {
        public void addPerson(List<Person>persons)
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
        private void writeNewList(List<Person> persons)
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
    }
}
