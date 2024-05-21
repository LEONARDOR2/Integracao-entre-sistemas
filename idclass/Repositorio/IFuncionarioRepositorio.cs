using idclass.Models;
using System.Collections.Generic;

namespace idclass.Controllers
{
    public interface IFuncionarioRepositorio
    {
        FuncionarioModel ListarId(int id);
        List<FuncionarioModel> BuscarTodos();
        FuncionarioModel Adicionar(FuncionarioModel funcionario);
        IEnumerable<FuncionarioModel> AdicionarConjunto(IEnumerable<FuncionarioModel> funcionarios);
        FuncionarioModel Atualizar(FuncionarioModel funcionario);
        bool Apagar(int id);
    }
}
