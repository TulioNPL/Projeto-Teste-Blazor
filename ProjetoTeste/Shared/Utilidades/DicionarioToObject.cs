using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTeste.Shared.Utilidades {
    public static class DicionarioToObject {
        public static Jogador DictionaryToJogador(Jogador jogador, IDictionary<string, object> value) {

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

        public static Time DictionaryToTime(Time time, IDictionary<string, object> value) {

            if (time == null) {
                time = new Time();
            }

            foreach (string field in value.Keys) {
                switch (field) {
                    case "Id":
                        time.Id = (int)value[nameof(Time.Id)];
                        break;
                    case "Ano":
                        time.Ano = (int)value[nameof(Time.Ano)];
                        break;
                    case "Nome":
                        time.Nome = (string)value[nameof(Time.Nome)];
                        break;
                }
            }
            return time;
        }
    }
}
