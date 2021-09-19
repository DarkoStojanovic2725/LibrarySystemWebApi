namespace LibrarySystem.Data.Models.Interfaces
{
    public interface IEntity <T>
    {
        T Id { get; set; }
    }
}
