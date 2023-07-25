﻿using hexagonal.Application.Bases.Interfaces;
using hexagonal.Domain.Enums;

namespace hexagonal.Application.Bases;

public class ListResultDto<T> : ResultDto, IListResultDto<T>
    where T : Dto
{
    public ListResultDto(List<T>? data)
    {
        Data = data;
        Code = data == null ? (int) EnumResponse.NotFound : (int) EnumResponse.Ok;
        Success = data != null;
        Message = data == null
            ? ""
            : string.Empty;
    }

    public List<T>? Data { get; set; }
}