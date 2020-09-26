using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoEscola_API.Data;
using ProjetoEscola_API.Models;

namespace ProjetoEscola_API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : Controller
    {
        private readonly EscolaContext _context; //Definimos aqui qual contexto de dados usaremos 


        // Com o uso do Entity Framework, não manipulamos diretamente o SQL para resgatar ou gravar os dados na tabela no banco de dados.
        // (ORM)

        public AlunoController(EscolaContext context)
        {
            _context = context;
        }

        [HttpGet] //Index
        public ActionResult<List<Aluno>> GetAll()
        {
            return _context.Aluno.ToList();  //ToList() do Entity Framework
        }

        [HttpGet("{id}")]  //GET pelo id
        public ActionResult<List<Aluno>> Get(int id)
        {
            try
            {
                var result = _context.Aluno.Find(id); // Para pegar apenas um no Entity Framework

                if (result == null)
                    return NotFound();

                return Ok(result);

            }
            catch
            {

                return this.StatusCode(500, "Falha no acesso ao banco de dados.");

            }

        }

        [HttpPost] // Metodo POST
        public async Task<ActionResult> post(Aluno model)
        {
            try
            {
                _context.Aluno.Add(model);

                int ok = await _context.SaveChangesAsync();
                // Efetua o commit e retorna o resultado de quantas linhas foram afetadas, nesse caso tem de ser 1 linha

                if (ok == 1)
                    return Created($"/api/aluno/{model.RA}", model);
            }
            catch
            {
                return this.StatusCode(500, "Falha no acesso ao banco de dados.");
            }

            return BadRequest();
            /* 
            
            As funções Ok(), Created() e BadRequest() são alguns métodos do Entity Framework para retorno de status
            ou respostas com dados. 

            */

        }

        [HttpDelete("{id}")] // Metodo delete
        public async Task<ActionResult> delete(int id)
        {
            try
            {
                Aluno aluno = await _context.Aluno.FindAsync(id);

                if (aluno == null)
                    return NotFound();


                _context.Aluno.Remove(aluno);

                int result = await _context.SaveChangesAsync();

                if (result == 1)
                    return Ok(aluno);

            }
            catch
            {
                return this.StatusCode(500, "Falha no acesso ao banco de dados.");

            }

            return BadRequest();

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> put(int id, Aluno alunoAlt)
        {
            try
            {
                //verifica se existe aluno a ser alterado
                var result = await _context.Aluno.FindAsync(id);

                if (id != result.id)
                    return NotFound();

                result.RA = alunoAlt.RA;
                result.Nome = alunoAlt.Nome;
                result.codCurso = alunoAlt.codCurso;

                alunoAlt.id = result.id;

                await _context.SaveChangesAsync();

                return Ok(alunoAlt);
            }
            catch
            {
                return this.StatusCode(500, "Falha no acesso ao banco de dados.");

            }
        }
    }
}