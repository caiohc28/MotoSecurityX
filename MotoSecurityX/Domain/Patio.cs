using System.ComponentModel.DataAnnotations;

namespace MotoSecurityX.Domain
{
    public class Patio
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório!")]
        public string Nome_local { get; set; } = string.Empty;
    }
}
