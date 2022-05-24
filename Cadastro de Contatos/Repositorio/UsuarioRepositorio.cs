using Cadastro_de_Contatos.Data;
using Cadastro_de_Contatos.Models;

namespace Cadastro_de_Contatos.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly BancoContext _bancoContext;

        public UsuarioRepositorio(BancoContext bancoContext)
        {
            this._bancoContext = bancoContext;
        }


        public UsuarioModel Adicionar(UsuarioModel usuario)
        {
            _bancoContext.Usuarios.Add(usuario);
            _bancoContext.SaveChanges();
            return usuario;
        }

        public bool Apagar(int Id)
        {
            UsuarioModel DbUsuario = ListarPorId(Id);
            if (DbUsuario == null) throw new Exception("erro inesperado");
            _bancoContext.Usuarios.Remove(DbUsuario);
            _bancoContext.SaveChanges();
            return true;
        }

        public UsuarioModel Atualizar(UsuarioModel usuario)
        {
            UsuarioModel DbUsuario = ListarPorId(usuario.Id);

            if (DbUsuario == null) throw new Exception("error de contato");

            DbUsuario.Nome = usuario.Nome;
            DbUsuario.Email = usuario.Email;
            DbUsuario.Login = usuario.Login;
            DbUsuario.Senha = usuario.Senha;
            DbUsuario.DataAtualizacao = usuario.DataAtualizacao;

            _bancoContext.Usuarios.Update(DbUsuario);
            _bancoContext.SaveChanges();
            return (DbUsuario);
        }

        public List<UsuarioModel> BuscarTodos()
        {
            return _bancoContext.Usuarios.ToList();
        }

        public UsuarioModel ListarPorId(int id)
        {
            return _bancoContext.Usuarios.FirstOrDefault(x => x.Id == id);
        }
    }
}
