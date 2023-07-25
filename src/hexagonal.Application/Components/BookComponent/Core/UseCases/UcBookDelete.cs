using hexagonal.Application.Bases;
using hexagonal.Application.Bases.Interfaces;
using hexagonal.Application.Components.BookComponent.Core.Validations;
using hexagonal.Data.Repository;
using hexagonal.Domain.Bases;
using hexagonal.Domain.Entities;

namespace hexagonal.Application.Components.BookComponent.Core.UseCases;

public class UcBookDelete : UseCase, IUcBookDelete
{
    private readonly IBookDeleteValidation _bookDeleteValidation;
    private readonly IBookRepository _repository;

    public UcBookDelete(IBookDeleteValidation bookDeleteValidation, IBookRepository repository)
    {
        _bookDeleteValidation = bookDeleteValidation;
        _repository = repository;
    }

    public async Task<ISingleResult<Entity>> Execute(Guid id)
    {
        var entity = new Book {Id = id};

        var savedRecord = await _repository.GetById(entity.Id).ConfigureAwait(false);

        if (savedRecord is null)
        {
            return new ErrorResult<Entity>
            {
                Message = "Book not found."
            };
        }

        var validate = _bookDeleteValidation.Execute(savedRecord);
        if (!validate)
        {
            return new ErrorResult<Entity>(false, "Name esta ativo");
        }

        var bookId = savedRecord.Id;

        await _repository.BeginTransactionAsync().ConfigureAwait(false);
        _repository.Remove(bookId);
        await _repository.CommitTransactionAsync().ConfigureAwait(false);


        return new DeleteResult<Entity>(true,
            "");
    }
}