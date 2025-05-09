using System.ComponentModel.DataAnnotations;

namespace MotoSecurityX.Models
{
    public class Moto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "A placa é obrigatória.")]
        public required string Placa { get; set; }

        [Required(ErrorMessage = "O modelo é obrigatório.")]
        public required string Modelo { get; set; }

        [Required(ErrorMessage = "A situação deve ser 'dentro' ou 'fora'.")]
        public required string Situacao { get; set; }
    }
}
