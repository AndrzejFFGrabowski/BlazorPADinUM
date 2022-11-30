namespace BlazorApp2.Interfaces
{
    public interface IPersonService
    {
        List<Person> people { get; set; }
        Task GetPerson();
        Task GetSinglePerson(int id);

        Task DeletePerson(int id);
        Task AddPerson(Person person);

        Task EditPerson(Person person);
    }
}
