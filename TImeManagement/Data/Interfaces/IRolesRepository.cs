namespace TImeManagement.Data.Interfaces
{
    public interface IRolesRepository<T>
    {
        IEnumerable<T> GetAll();
    }
}
