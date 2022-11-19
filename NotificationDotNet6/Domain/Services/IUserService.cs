using System;
using NotificationDotNet6.Domain.Commands;
using NotificationDotNet6.Domain.Commands.User;
using NotificationDotNet6.Domain.Entities;

namespace NotificationDotNet6.Domain.Services
{
	public interface IUserService : IService<UserCreateCommand>
	{
		public Task<GenericCommandResult> GetAll();
	}
}