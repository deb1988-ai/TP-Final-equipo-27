﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Motivo
    {
        public int idMotivo { get; set; }

        public string motivo { get; set; }

        public override string ToString()
        {
            return motivo;
        }
    }
}
