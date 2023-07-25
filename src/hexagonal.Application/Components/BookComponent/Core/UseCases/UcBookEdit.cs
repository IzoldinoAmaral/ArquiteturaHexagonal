using hexagonal.Application.Bases;
using hexagonal.Application.Bases.Interfaces;
using hexagonal.Application.Components.BookComponent.Core.Validations;
using hexagonal.Data.Repository;
using hexagonal.Domain.Bases;
using hexagonal.Domain.Entities;

namespace hexagonal.Application.Components.BookComponent.Core.UseCases;

public class UcBookEdit : UseCase, IUcBookEdit
{
    private readonly IBookEditValidation _bookEditValidation;
    private readonly IBookRepository _repository;

    public UcBookEdit(IBookEditValidation bookEditValidation, IBookRepository repository)
    {
        _bookEditValidation = bookEditValidation;
        _repository = repository;
    }

    public async Task<ISingleResult<Entity>> Execute(Book newRecord)
    {
        var isValid = ValidateEntity(newRecord);
        if (!isValid.Success)
        {
            return isValid;
        }

        var savedRecord = await _repository.GetById(newRecord.Id).ConfigureAwait(false);

        if (savedRecord is null)
        {
            return new ErrorResult<Entity>();
        }

        var validate = _bookEditValidation.Execute(newRecord, savedRecord);
        if (!validate)
        {
            return new ErrorResult<Entity>();
        }

        var obj = savedRecord;
        HydrateValues(obj, newRecord);

        await _repository.BeginTransactionAsync().ConfigureAwait(false);
        _repository.Update(obj);
        await _repository.CommitTransactionAsync().ConfigureAwait(false);

        return new EditResult<Entity>(true,
            "");
    }

    private static void HydrateValues(Book target, Book source)
    {
        target.Name = source.Name;
        target.Author = source.Author;
        target.CategoryId = source.CategoryId;
        target.TotalPages = source.TotalPages;
        target.IsActive = source.IsActive;
    }
}