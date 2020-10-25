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
    public class CursoController : Controller
    {
        private readonly EscolaContext _context; //Definimos aqui qual contexto de dados usaremos 


        // Com o uso do Entity Framework, não manipulamos diretamente o SQL para resgatar ou gravar os dados na tabela no banco de dados.
        // (ORM)

        public CursoController(EscolaContext context)
        {
            _context = context;
        }

        [HttpGet] //Index
        public ActionResult<List<Curso>> GetAll()
        {
            return _context.Curso.ToList();  //ToList() do Entity Framework
        }

        [HttpGet("{id}")]  //GET pelo id
        public ActionResult<List<Curso>> Get(int id)
        {
            try
            {
                var result = _context.Curso.Find(id); // Para pegar apenas um no Entity Framework

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
        public async Task<ActionResult> post(Curso model)
        {
            try
            {
                _context.Curso.Add(model);

                int ok = await _context.SaveChangesAsync();
                // Efetua o commit e retorna o resultado de quantas linhas foram afetadas, nesse caso tem de ser 1 linha

                if (ok == 1)
                    return Created($"/api/curso/{model.codCurso}", model);
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
                Curso curso = await _context.Curso.FindAsync(id);

                if (curso == null)
                    return NotFound();


                _context.Curso.Remove(curso);

                int result = await _context.SaveChangesAsync();

                if (result == 1)
                    return Ok(curso);

            }
            catch
            {
                return this.StatusCode(500, "Falha no acesso ao banco de dados.");

            }

            return BadRequest();

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> put(int id, Curso cursoAlt)
        {
            try
            {
                //verifica se existe aluno a ser alterado
                var result = await _context.Curso.FindAsync(id);

                if (id != result.id)
                    return NotFound();

                result.codCurso = cursoAlt.codCurso;
                result.nomeCurso = cursoAlt.nomeCurso;
                result.periodo = cursoAlt.periodo;

                cursoAlt.id = result.id;

                await _context.SaveChangesAsync();

                //return Ok(alunoAlt);

                return Created($"/api/curso/{cursoAlt.id}", cursoAlt);
            }
            catch
            {
                return this.StatusCode(500, "Falha no acesso ao banco de dados.");

            }
        }
    }
}