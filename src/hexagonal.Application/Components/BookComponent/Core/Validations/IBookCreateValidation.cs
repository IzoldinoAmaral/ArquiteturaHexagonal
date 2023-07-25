using hexagonal.Domain.Entities;

namespace hexagonal.Application.Components.BookComponent.Core.Validations;

public interface IBookCreateValidation
{
    bool Execute(Book entity);
}