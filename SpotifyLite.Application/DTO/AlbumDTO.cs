using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyLite.Application.DTO
{
    public class AlbumDTO
    {
        public Guid Id { get; set; }

        [Required]
        public Guid BandaId { get; set; }

        [Required]
        public string Nome { get; set; }
        public List<MusicaDTO> Musicas { get; set; } = new List<MusicaDTO>();

    }

    public class MusicaDTO
    {
        public Guid Id { get; set; }
        public String Nome { get; set; }
        public int Duracao { get; set; }
    }

    public class MusicaPlaylistDTO
    {
        public Guid Id { get; set; }
        public Guid? IdPlaylist { get; set; }
        public String Nome { get; set; }
        public int Duracao { get; set; }
        public bool Favorito { get; set; }

    }
}
