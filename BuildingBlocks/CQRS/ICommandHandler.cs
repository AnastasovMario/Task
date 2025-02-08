using MediatR;

namespace BuildingBlocks.CQRS
{
  public interface ICommandHandler<in TCommand>  // doesn't return result
      : ICommandHandler<TCommand, Unit>
      where TCommand : ICommand<Unit>
  {

  }

  public interface ICommandHandler<in TCommand, TResponse> // returns result
      : IRequestHandler<TCommand, TResponse>
      where TCommand : ICommand<TResponse>
      where TResponse : notnull
  {
  }
}
