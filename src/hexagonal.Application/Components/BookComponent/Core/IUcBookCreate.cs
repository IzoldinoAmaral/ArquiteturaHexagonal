﻿using hexagonal.Application.Bases.Interfaces;
using hexagonal.Domain;
using hexagonal.Domain.Bases;

namespace hexagonal.Application.Components.BookComponent.Core;

public interface IUcBookCreate
{
    Task<ISingleResult<Entity>> Execute(Book newRecord);
}