using System;
using NotificationDotNet6.Domain.Contracts;

namespace NotificationDotNet6.Domain.Commands.User;

public class UserCreateCommand : ICommand
{
	public string Name { get; set; }
}