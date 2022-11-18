using System;
using NotificationDotNet6.Domain.Commands.User;

namespace NotificationDotNet6.Domain.Services
{
	public interface IUserService : IService<UserCreateCommand>
	{
	}
}