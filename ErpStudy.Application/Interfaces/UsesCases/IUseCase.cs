using ErpStudy.Domain.Entities;
using FluentResults;

namespace ErpStudy.Application.Interfaces.UsesCases;

public interface IUseCase<TRequest, TResponse>
{
    public Task<TResponse> ExecuteAsync(TRequest request);
}

public interface IUseCase<TRequest>
{
    public Task ExecuteAsync(TRequest request);
}