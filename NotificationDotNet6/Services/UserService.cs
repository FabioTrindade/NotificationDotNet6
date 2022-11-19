using NotificationDotNet6.Domain.Commands;
using NotificationDotNet6.Domain.Commands.User;
using NotificationDotNet6.Domain.Entities;
using NotificationDotNet6.Domain.Repositories;
using NotificationDotNet6.Domain.Services;

namespace NotificationDotNet6.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<GenericCommandResult> GetAll()
    {
        var result = await _userRepository.GetAll();
        return new GenericCommandResult(true, "", result);
    }

    public async Task<GenericCommandResult> Handle(UserCreateCommand command)
    {
        var user = new User(command.Name);
        var result = await _userRepository.Create(user);

        return new GenericCommandResult(true, "", result);
    }
}