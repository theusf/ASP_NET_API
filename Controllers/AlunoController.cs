using System.Collections.Generic;
using System.Linq;
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
        public AlunoController(EscolaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<Aluno>> GetAll()
        {
            return _context.Aluno.ToList();  //ToList() do Entity Framework
        }

        // Com o uso do Entity Framework, não manipulamos diretamente o SQL para resgatar ou gravar os dados na tabela no banco de dados.
        // (ORM)
    }
}