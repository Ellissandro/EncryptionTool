using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EncryptionTool.Domain.Entities;
using EncryptionTool.Infra.Persistence.EF;
using Microsoft.EntityFrameworkCore;

namespace EncryptionTool.Domain.Repositories
{
    public class RepositoryUsuario : IRepositoryUsuario
    {
        private readonly EncryptionToolContext _context;

        public RepositoryUsuario(EncryptionToolContext context)
        {
            _context = context;
        }

        public void Cadastrar(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }

        public void Deletar(Guid Id)
        {
           Usuario ususario =_context.Usuarios.FirstOrDefault(x => x.Id == Id);
           _context.Usuarios.Remove(ususario);
           _context.SaveChanges();

        }

        public bool Existe(string email)
        {
           return _context.Usuarios.Any(x => x.Email == email);
        }

        public Usuario Obter(string email, string senha)
        {
            return _context.Usuarios.FirstOrDefault(x => x.Email == email && x.Senha == senha);
        }

        public IEnumerable<Usuario> ObterTodosUsuarios()
        {
            return _context.Usuarios.Include(a => a.Usuarios).ToList();
        }
    }
}
