using System.ComponentModel.DataAnnotations;

namespace ProjetoEscola_API.Models
{
    public class Aluno

    {   
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(5 , ErrorMessage = "Este campo deve ter no máximo 5 caracteres")]   
        public string RA { get; set; }
        
        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(30 , ErrorMessage = "Este campo deve ter no máximo 30 caracteres")]   
        public string Nome { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        //[MaxLength(5 , ErrorMessage = "Este campo deve ter no máximo 2 caracteres")] 
        [Range(1,99)]  
        public int codCurso { get; set; }

    }
}