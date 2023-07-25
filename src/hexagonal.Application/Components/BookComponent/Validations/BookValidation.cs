using FluentValidation;
using hexagonal.Application.Bases;
using hexagonal.Application.Components.BookComponent.Contracts;

namespace hexagonal.Application.Components.BookComponent.Validations;

public class BookValidation<TDto> : DtoValidation<TDto>
    where TDto : BookDto
{
    protected void ValidateNamee()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Nome do Name is required")
            .Length(0, 50).WithMessage("Nome do Name must be up to 50 characters long");
    }

    protected void ValidateAuthor()
    {
        RuleFor(x => x.Author)
            .NotEmpty().WithMessage("Author do Name is required")
            .Length(0, 50).WithMessage("Author do Name must be up to 50 characters long");
    }

    protected void ValidateTotalPages()
    {
        RuleFor(x => x.TotalPages)
            .GreaterThan(0).WithMessage("Total de Páginas must be greater than 0");
    }


    protected void ValidateCategoryId()
    {
        RuleFor(x => x.CategoryId).NotNull().WithMessage("Category Id cannot be null");
        RuleFor(x => x.CategoryId).NotEqual(Guid.Empty).WithMessage("Category Id cannot be empty");
    }
}