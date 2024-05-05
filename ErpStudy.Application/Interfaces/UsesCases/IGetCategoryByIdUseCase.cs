using ErpStudy.Application.DTOs.Categories;
using ErpStudy.Domain.Entities;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpStudy.Application.Interfaces.UsesCases
{
    internal interface IGetCategoryByIdUseCase : IUseCase<GetCategoryByIdDTO, Category>
    {
    }
}
