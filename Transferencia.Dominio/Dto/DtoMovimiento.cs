﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transferencia.Dominio.Dto
{
    public class DtoMovimiento
    {
        public string? DocumentId { get; set; }
        public decimal? Amount { get; set; }        
        public string? Type { get; set; }
    }
}
