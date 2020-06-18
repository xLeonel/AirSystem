﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirSystem.ViewModels
{
    public class AcessoViewModel
    {
        public int IdAcesso { get; set; }
        public string NomeUsuario { get; set; }
        public DateTime DataEntrada { get; set; }
        public DateTime? DataSaida { get; set; }
    }
}
