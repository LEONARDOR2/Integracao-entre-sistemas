
using idclass.Controllers;
using idclass.Data;
using idclass.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Cronos.Repositorio
{
    public class FuncionarioRepositorio : IFuncionarioRepositorio

    {
        private readonly BancoContext _bancoContext;

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

        public FuncionarioModel Adicionar(FuncionarioModel funcionario)
        {
            _bancoContext.Funcionarios.Add(funcionario);
            _bancoContext.SaveChanges();
            return funcionario;
        }

        //Obtém todos os funcionários já existentes no banco de dados
        //Filtra a coleção recebida, removendo os funcionários que já existem.
        //Se houver novos funcionários, adiciona eles ao banco de dados e salva as alterações.
        public IEnumerable<FuncionarioModel> AdicionarConjunto(IEnumerable<FuncionarioModel> funcionarios)
        {
            IEnumerable<FuncionarioModel> funcionariosJaExistentes = BuscarTodos();
            funcionarios = funcionarios
                .Where(x => !funcionariosJaExistentes.Select(y => y.Id).Contains(x.Id));

            if (funcionarios.Any())
            {
                _bancoContext.Funcionarios.AddRange(funcionarios);
                _bancoContext.SaveChanges();
            }
            return funcionarios;
        }

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
