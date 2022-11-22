namespace BlazorApp2.Interfaces
{
    public interface IPersonService
    {
        List<Person> people { get; set; }
        Task GetPerson();
        Task GetSinglePerson(int id);

        Task AddPerson(Person person);
    }
}
