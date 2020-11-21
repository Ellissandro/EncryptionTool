using EncryptionTool.Domain.Entities;
using EncryptionTool.Domain.Interfaces.Services;
using EncryptionTool.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EncryptionTool.Domain.Services
{
    public class ServiceUsuario : IServiceUsuario
    {
        private readonly IRepositoryUsuario _repositoryUsuario;

        public ServiceUsuario(IRepositoryUsuario repositoryUsuario)
        {
            _repositoryUsuario = repositoryUsuario;
        }

        public bool AdicionarUsuario(Usuario usuario)
        {
            var email =_repositoryUsuario.Existe(usuario.Email);

            if (!email)
            {
                Usuario usuarioCript = new Usuario(usuario.Nome, usuario.Email, usuario.Senha, usuario.Senha);
                _repositoryUsuario.Cadastrar(usuarioCript);
                return true;
            }
            else
                return false;

        }

        public void AutenticarUsuario(string email, string senha)
        {
            _repositoryUsuario.Obter(email, senha);
        }

        public void Excluir(Guid id)
        {
            _repositoryUsuario.Deletar(id);
        }

        IEnumerable<Usuario> IServiceUsuario.ObterTodosUsuarios()
        {
            return _repositoryUsuario.ObterTodosUsuarios();
        }
    }
}
