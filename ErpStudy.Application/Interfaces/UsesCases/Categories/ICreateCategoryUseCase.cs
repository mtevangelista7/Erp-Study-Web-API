﻿using ErpStudy.Application.DTOs.Categories;
using ErpStudy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpStudy.Application.Interfaces.UsesCases.Categories
{
    public interface ICreateCategoryUseCase : IUseCase<CreateCategoryDTO, Category>
    {
    }
}
