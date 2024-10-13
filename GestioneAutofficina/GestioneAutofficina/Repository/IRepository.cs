namespace GestioneAutofficina.Repository
{
    public interface IRepository<T>
    {
        T? GetById(int id);
        List<T> GetAll();
        bool Insert(T t);
        bool Update(T t);
        bool Delete(int id);
    }
}
