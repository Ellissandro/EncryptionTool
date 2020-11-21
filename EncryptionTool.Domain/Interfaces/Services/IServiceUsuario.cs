using EncryptionTool.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EncryptionTool.Domain.Interfaces.Services
{
    public interface IServiceUsuario
    {
        bool AdicionarUsuario(Usuario usuario);
        void AutenticarUsuario(string usuario, string senha);
        IEnumerable<Usuario> ObterTodosUsuarios();
        void Excluir(Guid id);
    }
}
