using josh_bnb.Controllers.ApiModels;

namespace josh_bnb.Interfaces;

/// <summary>
/// Represents a basic service layer providing domain specific validation, get and insert methods
/// </summary>
public interface IService<T>
{
    bool Validate(T Entity);
    IEnumerable<T> GetAll();
    IEnumerable<T> GetBy(string keyValue);
    Response Insert(Criteria criteria);
    Response Delete(string reference);
    Response DeleteAll();
}