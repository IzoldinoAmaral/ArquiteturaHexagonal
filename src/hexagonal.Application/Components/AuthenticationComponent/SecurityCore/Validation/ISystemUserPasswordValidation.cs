using hexagonal.Application.Bases.Interfaces;
using hexagonal.Domain.Entities;

namespace hexagonal.Application.Components.AuthenticationComponent.SecurityCore.Validation;

public interface ISystemUserPasswordValidation
{
    ISingleResult<SystemUser> Execute(string email, string password);
}