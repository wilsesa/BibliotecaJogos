﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaJogos.Entities
{
    public class Jogo: IntId
    {
        public double? ValorPago { get; set; }
        public string Imagem { get; set; }
        public DateTime? DataCompra { get; set; }
        public string Titulo { get; set; }

    }
}
