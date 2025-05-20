using System;
using System.Collections.Generic;

namespace Transferencia.Dominio.Entidades;

public partial class Movimiento
{
    /// <summary>
    /// Identificador unico del movimiento
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Identificador de la billetera
    /// </summary>
    public int? WalletId { get; set; }

    /// <summary>
    /// Monto de la transaccion
    /// </summary>
    public decimal? Amount { get; set; }

    /// <summary>
    /// Tipo de Transaccion Debito/Credito
    /// </summary>
    public string? Type { get; set; }

    /// <summary>
    /// Fecha de la transaccion
    /// </summary>
    public DateTime? CreateAt { get; set; }

    public virtual Billetera? Wallet { get; set; }
}
