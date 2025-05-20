using System;
using System.Collections.Generic;

namespace Transferencia.Dominio.Entidades;

public partial class Billetera
{
    /// <summary>
    /// Identificador unico, numero entero autoincrmental
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Documento de identidad de la persona propietaria de la billetera
    /// </summary>
    public string? Documentid { get; set; }

    /// <summary>
    /// Nombre del propietario de la billetera
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Saldo de la billetera
    /// </summary>
    public decimal? Balance { get; set; }

    /// <summary>
    /// Fecha de Apertura de la billetera
    /// </summary>
    public DateTime? CreateAt { get; set; }

    /// <summary>
    /// Fecha de ultima actualizacion de la billetera
    /// </summary>
    public DateTime? UpdateAt { get; set; }

    public virtual ICollection<Movimiento> Movimientos { get; set; } = new List<Movimiento>();
}
