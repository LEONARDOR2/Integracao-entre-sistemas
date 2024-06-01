
using Cronos.Data;
using Cronos.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace Cronos.Repositorio
{
    public class FuncionarioRepositorio : IFuncionarioRepositorio

    {
        private readonly BancoContext _bancoContext;

        private readonly HttpClient _httpClient;

        public FuncionarioRepositorio(BancoContext bancoContext)
        {

            _bancoContext = bancoContext;

        }

     
        public FuncionarioModel ListarId(int id)
        {
            return _bancoContext.Funcionarios.FirstOrDefault(x => x.Id == id);
        }

      

        public List<FuncionarioModel> BuscarTodos()
        {
            return _bancoContext.Funcionarios.ToList();

        }


        // gravar no banco de dados 
        public FuncionarioModel Adicionar(FuncionarioModel funcionario)
        {
            _bancoContext.Funcionarios.Add(funcionario);
            _bancoContext.SaveChanges(); //comita
            return funcionario;
        }

                                   //Editar
        public FuncionarioModel Atualizar(FuncionarioModel funcionario)
        {
            FuncionarioModel funcionarioDB = ListarId(funcionario.Id);

            if (funcionarioDB == null) throw new System.Exception("hOUVE UM ERRO NA ATUALAIZAÇÃO DO FUNCIONÁRIO");

            funcionarioDB.Nome = funcionario.Nome;

            funcionarioDB.Email = funcionario.Email;

            funcionarioDB.Pis = funcionario.Pis;

            funcionarioDB.Referencia = funcionario.Referencia;

            funcionarioDB.Telefone = funcionario.Telefone;

            _bancoContext.Funcionarios.Update(funcionarioDB);
            _bancoContext.SaveChanges();

            return funcionarioDB;
        }

        public bool Apagar(int id)
        {
            FuncionarioModel funcionarioDB = ListarId(id);

            if (funcionarioDB == null) throw new System.Exception("hOUVE UM ERRO NA DELECÇAO DO FUNCIONÁRIO");

            _bancoContext.Funcionarios.Remove(funcionarioDB);
            _bancoContext.SaveChanges();

            return true;


        }

       
    }
}
