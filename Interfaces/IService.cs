namespace josh_bnb.Interfaces;

public interface IService<T>
{
    bool Validate(T Entity);
    IEnumerable<T> GetAll();
    IEnumerable<T> GetBy(string keyValue);
}