using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTeste.Shared.Utilidades {
    static class DicionarioToObject {
        public static Jogador DictionaryTojogador(Jogador jogador, IDictionary<string, object> value) {

            if (jogador == null) {
                jogador = new Jogador();
            }

            foreach (string field in value.Keys) {
                switch (field) {
                    case "Id":
                        jogador.Id = (int)value[nameof(Jogador.Id)];
                        break;
                    case "Camisa":
                        jogador.Camisa = (int)value[nameof(Jogador.Camisa)];
                        break;
                    case "Nome":
                        jogador.Nome = (string)value[nameof(Jogador.Nome)];
                        break;
                    case "Idade":
                        jogador.Idade = (int)value[nameof(Jogador.Idade)];
                        break;
                    case "TimesId":
                        jogador.TimesId = (int)value[nameof(Jogador.TimesId)];
                        break;
                }
            }
            return jogador;
        }
    }
}
