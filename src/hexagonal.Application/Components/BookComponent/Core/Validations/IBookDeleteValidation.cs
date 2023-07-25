using hexagonal.Domain.Entities;

namespace hexagonal.Application.Components.BookComponent.Core.Validations;

public interface IBookDeleteValidation
{
    bool Execute(Book entity);
}