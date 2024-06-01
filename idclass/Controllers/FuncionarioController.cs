using idclass.Models;
using Cronos.Repositorio;
using Microsoft.AspNetCore.Mvc;


namespace idclass.Controllers
{



    public class FuncionarioController : Controller

    {
       
        



        private readonly IFuncionarioRepositorio _funcionarioRepositorio;
        

        public FuncionarioController(IFuncionarioRepositorio funcionarioRepositorio) 
        {
         _funcionarioRepositorio = funcionarioRepositorio;
        
        
        }
     
        public IActionResult Index()
        {
           List<FuncionarioModel> funcionarios = _funcionarioRepositorio.BuscarTodos();

            return View(funcionarios);
       }



        public IActionResult Criar()
        {
         
            return View();
        }

        public IActionResult Configuracoes()
        {

            return View();
        }

        public IActionResult Editar(int  id)
        {
            FuncionarioModel funcionario = _funcionarioRepositorio.ListarId(id);
            return View(funcionario);
        }



        public IActionResult ApagarConfirmacao(int  id)

        {
            FuncionarioModel funcionario = _funcionarioRepositorio.ListarId(id);
            return View(funcionario);
        }

       public IActionResult Apagar(int id)
        {
            try
            {


              bool apagado =  _funcionarioRepositorio.Apagar(id);

                if(apagado)
                {
                    TempData["MensagemSucesso"] = "Funcionário deletado com sucesso!";
                }
                else
                {
                    TempData["MensagemErro"] = "Ops!, não foi possivel deletar o funcionário!";

                }
                   return RedirectToAction("Index");
            }

            catch (Exception erro)
            {

                TempData["MensagemErro"] = $"Ops!, não foi possivel deletar o funcionário, mais detales do erro: {erro.Message}";
                return RedirectToAction("Index");
            }

        }

        [HttpPost]
        public IActionResult Criar(FuncionarioModel funcionario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _funcionarioRepositorio.Adicionar(funcionario);
                    TempData["MensagemSucesso"] = "Funcionário cadastrado com sucesso!";
                    return RedirectToAction("Index");

                }
                return View(funcionario);
            }
            catch (Exception erro)
            {

                TempData["MensagemErro"] =$"Ops, não foi possivel cadastra o funcionário, tente novamente, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");

            }
        }

        [HttpPost]
        public IActionResult Alterar(FuncionarioModel funcionario)
        {

            try
            {
                
                    if (ModelState.IsValid)
            {
                _funcionarioRepositorio.Atualizar(funcionario);
                    TempData["MensagemSucesso"] = "Funcionário alterado com sucesso!";
                    return RedirectToAction("Index");

            }
            return View("Editar", funcionario);

            }
            catch (Exception erro)
            {

                TempData["MensagemErro"] = $"Ops, não foi possivel atualizar o funcionário, tente novamente, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");

            }
        }

        // cria um conjunto de objetos FuncionarioModel.
        // recebe uma coleção de FuncionarioModel do corpo de uma solicitação HTTP POST.
        [HttpPost("api/funcionarios")]
        public IActionResult CriarConjunto([FromBody] IEnumerable<FuncionarioModel> funcionarios)
        {
            IEnumerable<FuncionarioModel> funcionariosBanco = _funcionarioRepositorio.AdicionarConjunto(funcionarios);

            return Ok(funcionariosBanco);
        }

    }


}
