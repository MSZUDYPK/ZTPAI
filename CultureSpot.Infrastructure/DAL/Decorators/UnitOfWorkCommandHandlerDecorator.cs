using CultureSpot.Application.Shared;

namespace CultureSpot.Infrastructure.DAL.Decorators;

internal sealed class UnitOfWorkCommandHandlerDecorator<TCommand, TResult> : ICommandHandler<TCommand, TResult>
    where TCommand : ICommand<TResult>
{
    private readonly ICommandHandler<TCommand, TResult> _commandHandler;
    private readonly IUnitOfWork _unitOfWork;


    public UnitOfWorkCommandHandlerDecorator(ICommandHandler<TCommand, TResult> commandHandler, IUnitOfWork unitOfWork)
    {
        _commandHandler = commandHandler;
        _unitOfWork = unitOfWork;
    }

    public async Task<TResult> Handle(TCommand command, CancellationToken cancellationToken)
    {
        Console.ForegroundColor = ConsoleColor.Red;

        Console.WriteLine("UnitOfWorkCommandHandlerDecorator: Started");

        TResult result = await _unitOfWork.ExecuteAsync(() => _commandHandler.Handle(command, cancellationToken));

        Console.ForegroundColor = ConsoleColor.Green;

        Console.WriteLine("UnitOfWorkCommandHandlerDecorator: Transaction has been committed.");

        Console.ForegroundColor = ConsoleColor.White;

        return result;
    }
}

internal sealed class UnitOfWorkCommandHandlerDecorator<TCommand> : ICommandHandler<TCommand>
    where TCommand : ICommand
{
    private readonly ICommandHandler<TCommand> _commandHandler;
    private readonly IUnitOfWork _unitOfWork;


    public UnitOfWorkCommandHandlerDecorator(ICommandHandler<TCommand> commandHandler, IUnitOfWork unitOfWork)
    {
        _commandHandler = commandHandler;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(TCommand command, CancellationToken cancellationToken)
    {
        Console.ForegroundColor = ConsoleColor.Red;

        Console.WriteLine("UnitOfWorkCommandHandlerDecorator: Started");

        await _unitOfWork.ExecuteAsync(() => _commandHandler.Handle(command, cancellationToken));

        Console.ForegroundColor = ConsoleColor.Green;

        Console.WriteLine("UnitOfWorkCommandHandlerDecorator: Transaction has been committed.");

        Console.ForegroundColor = ConsoleColor.White;
    }
}
