using System.ComponentModel.DataAnnotations;

namespace ProjetoEscola_API.Models
{
    public class Curso

    {   
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public int codCurso { get; set; }
        
        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(30 , ErrorMessage = "Este campo deve ter no máximo 30 caracteres")]   
        public string nomeCurso { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(1 , ErrorMessage = "Este campo deve ter no máximo 1 caracteres")]   
        public string periodo { get; set; }

    }
}