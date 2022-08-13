using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAula.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class PessoaController : Controller
    {
       private static readonly List<Pessoa> pessoas = new List<Pessoa>();

        [HttpPost]
        public IActionResult Salvar(Pessoa pessoa)
        {
            pessoas.Add (pessoa);

            return Ok (pessoa);
        }
        [HttpPut]
        public IActionResult Atualizar(Pessoa pessoa)
        {
            var res = pessoas.FirstOrDefault(p => p.Nome == pessoa.Nome);
            

            if (res != null)
            {
                res.Nome = pessoa.Nome ;
                res.Cpf = pessoa.Cpf;
                res.Idade = pessoa.Idade;
            }
           
            else
            {
                return NotFound();
            }

            return Ok (pessoa);

            
        }
        [HttpGet]
        public IActionResult BuscarTodos()
        {
            return Ok(pessoas);
        }
        [HttpDelete]
        public IActionResult Deletar(Pessoa pessoa)
        {
            Pessoa x = pessoas.Find(p => p.Nome == pessoa.Nome);

            if (x != null)
            {
                pessoas.Remove(x);

                return Ok("true");
            }

            return NotFound("erro ao tentar deletar");
            
                
            

        }

    }
}
