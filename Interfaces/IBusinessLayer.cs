using josh_bnb.Controllers.ApiModels;

namespace josh_bnb.Interfaces;

/// <summary>
/// Represents a a business layer combining two domains in order to provide cross entity validation and filtration
/// </summary>
public interface IBusinessLayer<T1, T2>
{
    public IEnumerable<T1> Filter(IEnumerable<T1> toFilter, IEnumerable<T2> basedOn, Criteria criteria);
    public bool Validate(IEnumerable<T1> toFilter, IEnumerable<T2> basedOn, Criteria criteria);
}