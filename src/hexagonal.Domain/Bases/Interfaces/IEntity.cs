﻿namespace hexagonal.Domain.Bases.Interfaces;

public interface IEntity
{
    Guid Id { get; }
    Guid Key { get; }
    string Value { get; }
}