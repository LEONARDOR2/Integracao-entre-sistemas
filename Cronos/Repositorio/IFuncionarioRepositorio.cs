using Cronos.Models;
using System.Collections.Generic;

namespace Cronos.Repositorio
{
    public interface IFuncionarioRepositorio
    {


        FuncionarioModel ListarId(int id);
        List<FuncionarioModel> BuscarTodos();



        FuncionarioModel Adicionar(FuncionarioModel funcionario);
        FuncionarioModel Atualizar(FuncionarioModel funcionario);
        bool Apagar(int id);
    }
}
