using NotificationDotNet6.Domain.Commands;
using NotificationDotNet6.Domain.Contracts;

namespace NotificationDotNet6.Domain.Services;

public interface IService<T> where T : ICommand
{
    Task<GenericCommandResult> Handle(T command);
}