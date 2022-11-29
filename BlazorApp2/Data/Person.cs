namespace BlazorApp2.Data
{
    public class Person
    {
        public int Id { get; set; }
        public String name { get; set; } = String.Empty;
        //public int age { get; set; }
        public Person()
        {

        }
        public Person(int id, string name)
        {
            Id = id;
            this.name = name;
        }
    }
}
