using System;
using josh_bnb.Controllers.ApiModels;
using Microsoft.AspNetCore.Mvc;

namespace josh_bnb.Interfaces;

public interface IBusinessLayer<T1, T2>
{
    public IEnumerable<T1> Filter(IEnumerable<T1> toFilter, IEnumerable<T2> basedOn, Criteria criteria);
    public bool Validate(IEnumerable<T1> toFilter, IEnumerable<T2> basedOn, Criteria criteria);
}