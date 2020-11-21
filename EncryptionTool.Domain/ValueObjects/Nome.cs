using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EncryptionTool.Domain.ValueObjects
{
    public class Nome
    {
        public Nome()
        {

        }

        public Nome(string primeiroNome, string ultimoNome)
        {
            PrimeiroNome = primeiroNome;
            UltimoNome = ultimoNome;
        }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string PrimeiroNome { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string UltimoNome { get; set; }
    }
}
