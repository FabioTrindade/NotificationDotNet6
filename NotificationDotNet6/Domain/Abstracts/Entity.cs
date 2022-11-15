using System;
using System.ComponentModel.DataAnnotations;

namespace NotificationDotNet6.Domain.Abstracts;

public abstract record Entity
{
    // Constructor
    public Entity()
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.Now;
        Active = true;
    }

    // Properties
    /// <summary>
    /// Atributo utilizado para definir a chave primaria
    /// </summary>
    [Key]
    public Guid Id { get; private set; }

    /// <summary>
    /// Atributo utilizado para definir a data de criação
    /// </summary>
    public DateTime CreatedAt { get; private set; }

    /// <summary>
    /// Atributo utilizado para controlar alteração no registro
    /// </summary>
    public DateTime? UpdatedAt { get; private set; }

    /// <summary>
    /// Atributo utilizado para definir se o registro esta ativo
    /// </summary>
    public bool Active { get; private set; }

    // Modifier
    /// <summary>
    /// Metodo utilizado para controlar data de alteracao do registro
    /// </summary>
    /// <param name="updatedAt"></param>
    public void SetUpdatedAt(DateTime? updatedAt)
    {
        this.UpdatedAt = updatedAt;
    }

    /// <summary>
    /// Metodo utilizado para controlar estado de ativo
    /// </summary>
    /// <param name="active"></param>
    public void SetActive(bool active)
    {
        this.Active = active;
    }
}