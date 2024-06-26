﻿using ErpStudy.Application.DTOs;
using ErpStudy.Application.DTOs.Categories;
using ErpStudy.Application.Interfaces.UsesCases.Categories;
using ErpStudy.Application.Validator.CategoryDTOValidator;
using ErpStudy.Domain.Entities;
using ErpStudy.Infrastructure.Data.Interfaces;
using FluentResults;
using FluentValidation.Results;

namespace ErpStudy.Application.UseCases.Categories
{
    public class GetCategoryByIdUseCase(ICategoryRepository categoryRepository) : IGetCategoryByIdUseCase
    {
        public async Task<Result<Category>> ExecuteAsync(GetCategoryByIdDTO request)
        {
            try
            {
                ValidationResult validationResult = await new GetCategoryByIdDTOValidator().ValidateAsync(request);

                if (validationResult.IsValid)
                {
                    return Result.Ok(await categoryRepository.GetById(request.Id))!;
                }

                IEnumerable<string> err = validationResult.Errors.Select(e => e.ErrorMessage);
                return Result.Fail(err);
            }
            catch (Exception ex)
            {
                return Result.Fail([ex.Message]);
            }
        }
    }
}