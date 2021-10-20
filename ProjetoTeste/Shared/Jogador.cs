using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoTeste.Shared {
    public class Jogador {

        public int Id { get; set; }
        public int Camisa { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }

        public int TimesId { get; set; }
        public Time Times { get; set; }
    }
}