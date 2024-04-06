using System.ComponentModel.DataAnnotations;

namespace SpotifyLite.Application.DTO
{
    public class BandaDTO
    {
        public Guid Id { get; set; }

        [Required]
        public String Nome { get; set; }

        [Required]
        public String Descricao { get; set; }

        public String Backdrop { get; set; }
    }
}
