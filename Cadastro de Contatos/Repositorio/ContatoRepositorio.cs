using Cadastro_de_Contatos.Data;
using Cadastro_de_Contatos.Models;

namespace Cadastro_de_Contatos.Repositorio
{

    public class ContatoRepositorio : IContatoRepositorio
    {
        private readonly BancoContext _bancoContext;

        public ContatoRepositorio(BancoContext bancoContext)
        {
            this._bancoContext = bancoContext;
        }

        public List<Contatomodel> BuscarTodos()
        {
            return _bancoContext.Contatos.ToList();
        }

        public Contatomodel Adicionar(Contatomodel contatos)
        {
            _bancoContext.Contatos.Add(contatos);
            _bancoContext.SaveChanges();
            return contatos;
        }

        public Contatomodel ListarPorId(int Id)
        {

            return _bancoContext.Contatos.FirstOrDefault(x => x.id == Id);
        }

        public Contatomodel Atualizar(Contatomodel contatos)
        {
            Contatomodel DbContato = ListarPorId(contatos.id);

            if (DbContato == null) throw new Exception("error de contato");

            DbContato.Name = contatos.Name;
            DbContato.email = contatos.email;
            DbContato.celular = contatos.celular;
            _bancoContext.Contatos.Update(DbContato);
            _bancoContext.SaveChanges();
            return (DbContato);
        }

        public bool Apagar(int Id)
        {
            Contatomodel DbContato = ListarPorId(Id);
            if (DbContato == null) throw new Exception("erro inesperado");
            _bancoContext.Contatos.Remove(DbContato);
            _bancoContext.SaveChanges();
            return true;
                    
              

        }
    }

}