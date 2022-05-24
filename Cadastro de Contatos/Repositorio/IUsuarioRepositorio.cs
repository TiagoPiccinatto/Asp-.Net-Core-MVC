using Cadastro_de_Contatos.Models;

namespace Cadastro_de_Contatos.Repositorio
{
    public interface IUsuarioRepositorio
    {

        UsuarioModel ListarPorId(int id);


        List<UsuarioModel> BuscarTodos();


        UsuarioModel Adicionar(UsuarioModel usuario);

        UsuarioModel Atualizar(UsuarioModel usuario);

        bool Apagar(int id);
    }
}
