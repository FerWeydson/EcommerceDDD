using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Notifications
{
    public class Notifies
    {
        public Notifies()
        {
            Notitycoes = new List<Notifies>();
        }

        [NotMapped]
        public string NomeProriedade { get; set; }
        [NotMapped]
        public string Mensagem { get; set; }

        [NotMapped]
        public List<Notifies> Notitycoes;

        public bool ValidaString(string valor, string nomeProriedade)
        {
            if (string.IsNullOrWhiteSpace(valor) || string.IsNullOrWhiteSpace(nomeProriedade))
            {
                Notitycoes.Add(new Notifies
                {
                    Mensagem = "Campo Obrigatório",
                    NomeProriedade = nomeProriedade
                });
                return false;
            }
            return true;
        }
        public bool ValidaInt(int valor, string nomeProriedade)
        {
            if (valor < 1 || string.IsNullOrWhiteSpace(nomeProriedade))
            {
                Notitycoes.Add(new Notifies
                {
                    Mensagem = "Valor deve ser maior do que 0",
                    NomeProriedade = nomeProriedade
                });
                return false;
            }
            return true;

        }
        public bool ValidaDecimal(decimal valor, string nomeProriedade)
        {
            if (valor < 1 || string.IsNullOrWhiteSpace(nomeProriedade))
            {
                Notitycoes.Add(new Notifies
                {
                    Mensagem = "Valor deve ser maior do que 0",
                    NomeProriedade = nomeProriedade
                });
                return false;
            }
            return true;
        }
    }
}
