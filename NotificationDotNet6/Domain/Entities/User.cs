using System;
using NotificationDotNet6.Domain.Abstracts;

namespace NotificationDotNet6.Domain.Entities;

public record User : Entity
{
    // Constructor
    public User()
    {
    }

    public User(string name)
    {
        Name = name;
    }

    // Properties
    /// <summary>
    /// Atributo utilizado para definir o nome do usuário
    /// </summary>
    public string Name { get; private set; }

    // Relationship
    public virtual ICollection<Notification> Notifications { get; set; }
}