using Comrade.Core.Bases.Interfaces;
using hexagonal.Domain.Entities;

namespace hexagonal.Data.Repository;

public interface IBookRepository : IRepository<Book>
{
}