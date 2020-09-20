using Microsoft.EntityFrameworkCore;
using ProjetoEscola_API.Models; // Erro aqui era using ProjetoEscola_SQLServer.Models;

namespace ProjetoEscola_API.Data

{   //Para acessarmos o banco de dados vamos usar o Entity Framework.
    //dotnet add package Microsoft.EntityFrameworkCore.SqlServer

    //Para usarmos o Entity Framework é necessário criar uma classe onde vamos definir o banco de dados que usaremos e as respectivas tabelas.
    public class EscolaContext : DbContext
    {

        //Nessa classe definiremos o contexto de dados na nossa aplicação, assim como as tabelas. Nesse caso, só
        //teremos a tabela Alunos, por isso nossa classe ficará da seguinte forma:
        public EscolaContext(DbContextOptions<EscolaContext> options) : base(options)
        {
        }

        public DbSet<Aluno> Aluno {get; set;} 

    }
}