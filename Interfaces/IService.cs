using josh_bnb.Controllers.ApiModels;

namespace josh_bnb.Interfaces;

public interface IService<T>
{
    bool Validate(T Entity);
    IEnumerable<T> GetAll();
    IEnumerable<T> GetBy(string keyValue);
    Response Insert(Criteria criteria);
    // IEnumerable<T> GetByCriteria(Criteria criteria);
}