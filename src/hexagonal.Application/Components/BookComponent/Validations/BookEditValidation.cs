﻿using hexagonal.Application.Components.BookComponent.Contracts;

namespace hexagonal.Application.Components.BookComponent.Validations;

public class BookEditValidation : BookValidation<BookEditDto>
{
    public BookEditValidation()
    {
        ValidateNamee();
        ValidateAuthor();
        ValidateTotalPages();
        ValidateCategoryId();
    }
}