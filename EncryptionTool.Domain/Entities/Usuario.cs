using EncryptionTool.Domain.Entities.Base;
using EncryptionTool.Domain.Extensions;
using EncryptionTool.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EncryptionTool.Domain.Entities
{
    public class Usuario : EntityBase
    {
        [Required(ErrorMessage = "Campo Obrigatório")]
        public Nome Nome { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Senha { get; set; }
        public string SenhaCriptografada { get; set; }

        public ICollection<Usuario> Usuarios { get; set; }

        public Usuario()
        {

        }

        public Usuario(Nome nome, string email, string senha, string senhaCriptografada)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
            SenhaCriptografada = senhaCriptografada;

            SenhaCriptografada = SenhaCriptografada.ConvertToMd5();
        }

        public Usuario(string email, string senha)
        {
            Email = email;
            Senha = senha;

            SenhaCriptografada = SenhaCriptografada.ConvertToMd5();
        }
    }
}
