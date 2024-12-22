using MediatR;

namespace BuildingBlocks.CQRS;

public interface IQueryHandler<in TQuery, TResponce>
    : IRequestHandler<TQuery, TResponce>
    where TQuery : ICommand<TResponce>
    where TResponce : notnull
{

}