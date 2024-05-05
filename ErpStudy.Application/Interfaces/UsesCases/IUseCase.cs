using ErpStudy.Domain.Entities;
using FluentResults;

namespace ErpStudy.Application.Interfaces.UsesCases;

public interface IUseCase<TRequest, TResponse>
{
    public Task<Result<TResponse>> ExecuteAsync(TRequest request);
}

public interface IUseCase<TRequest>
{
    public Task<Result> ExecuteAsync(TRequest request);
}