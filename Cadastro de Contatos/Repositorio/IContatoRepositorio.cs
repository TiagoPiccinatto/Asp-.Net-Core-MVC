using Cadastro_de_Contatos.Data;
using Cadastro_de_Contatos.Models;

namespace Cadastro_de_Contatos.Repositorio
 
{
    public interface IContatoRepositorio 
    {

        Contatomodel ListarPorId(int Id);


        List<Contatomodel> BuscarTodos();


        Contatomodel Adicionar(Contatomodel contatos);

        Contatomodel Atualizar(Contatomodel contatos);

        bool  Apagar(int Id);
    }
}
