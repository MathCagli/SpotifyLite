﻿using AutoMapper;
using SpotifyLite.Application.DTO;
using SpotifyLite.Domain.Models.Streaming.Agreggates;
using SpotifyLite.Domain.Repository;

namespace SpotifyLite.Application.Service
{
    public class BandaService : IBandaService
    {
        private readonly IBandaRepository bandaRepository;
        private readonly IMapper mapper;

        public BandaService(IBandaRepository bandaRepository, IMapper mapper)
        {
            this.bandaRepository = bandaRepository;
            this.mapper = mapper;
        }

        public BandaDTO Criar(BandaDTO dto)
        {
            Banda banda = this.mapper.Map<Banda>(dto);
            this.bandaRepository.Save(banda);

            return this.mapper.Map<BandaDTO>(banda);
        }

        public BandaDTO Obter(Guid id)
        {
            var banda = this.bandaRepository.Get(id);
            return this.mapper.Map<BandaDTO>(banda);
        }

        public IEnumerable<BandaDTO> Obter()
        {
            var banda = this.bandaRepository.GetAll();
            return this.mapper.Map<IEnumerable<BandaDTO>>(banda);
        }

        public AlbumDTO AssociarAlbum(AlbumDTO dto)
        {
            var banda = this.bandaRepository.Get(dto.BandaId);

            if (banda == null)
            {
                throw new Exception("Banda não encontrada");
            }

            var novoAlbum = this.AlbumDtoParaAlbum(dto);

            //banda.AdicionarAlbum(novoAlbum);

            //this.bandaRepository.Update(banda);
            var result = this.AlbumParaAlbumDto(novoAlbum);

            return result;

        }

        public AlbumDTO ObterAlbumPorId(Guid idBanda, Guid id)
        {
            var banda = this.bandaRepository.Get(idBanda);

            if (banda == null)
            {
                throw new Exception("Banda não encontrada");
            }

            //var album = (from x in banda.Albums
            // select x
            //).FirstOrDefault(x => x.Id == id);
            var album = new Album();
            var result = AlbumParaAlbumDto(album);
            //result.BandaId = banda.Id;

            return result;

        }

        public List<AlbumDTO> ObterAlbum(Guid idBanda)
        {
            var banda = this.bandaRepository.Get(idBanda);

            if (banda == null)
            {
                throw new Exception("Banda não encontrada");
            }

            var result = new List<AlbumDTO>();

            //foreach (var item in banda.Albums)
            //{
            //    result.Add(AlbumParaAlbumDto(item));
            //}

            return result;

        }

        private Album AlbumDtoParaAlbum(AlbumDTO dto)
        {
            Album album = new Album()
            {
                Nome = dto.Nome
            };

            foreach (MusicaDTO item in dto.Musicas)
            {
                album.AdicionarMusica(new Musica
                {
                    Nome = item.Nome,
                    Duracao = new SpotifyLite.Domain.Models.Streaming.ValueObject.Duracao(item.Duracao)
                });
            }
            return album;
        }

        private AlbumDTO AlbumParaAlbumDto(Album album)
        {
            AlbumDTO dto = new AlbumDTO();
            dto.Id = album.Id;
            dto.Nome = album.Nome;

            foreach (var item in album.Musica)
            {
                var musicaDto = new MusicaDTO()
                {
                    Id = item.Id,
                    Duracao = item.Duracao.Valor,
                    Nome = item.Nome
                };

                dto.Musicas.Add(musicaDto);
            }

            return dto;
        }
    }
}