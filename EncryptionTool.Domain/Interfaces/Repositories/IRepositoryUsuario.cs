using System;
using System.Collections.Generic;
using System.Text;
using EncryptionTool.Domain.Entities;
namespace EncryptionTool.Domain.Repositories
{
    public interface IRepositoryUsuario
    {
        void Cadastrar(Usuario usuario);
        Usuario Obter(string email, string senha);
        bool Existe(string email);
        void Deletar(Guid Id);
        IEnumerable<Usuario> ObterTodosUsuarios();
    }
}
