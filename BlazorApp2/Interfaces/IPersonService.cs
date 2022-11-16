namespace BlazorApp2.Interfaces
{
    public interface IPersonService
    {
        List<Person> persons { get; set; }
        Task GetPerson();
        Task GetSinglePerson(int id);
    }
}
