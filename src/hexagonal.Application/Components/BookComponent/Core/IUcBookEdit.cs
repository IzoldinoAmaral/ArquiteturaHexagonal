using hexagonal.Application.Bases.Interfaces;
using hexagonal.Domain.Bases;
using hexagonal.Domain.Entities;

namespace hexagonal.Application.Components.BookComponent.Core;

public interface IUcBookEdit
{
    Task<ISingleResult<Entity>> Execute(Book newRecord);
}