using AutoMapper;
using AutoMapper.QueryableExtensions;
using DesafioWebMotors.Application.Interfaces;
using DesafioWebMotors.Application.ViewModels;
using DesafioWebMotors.Dominio.Entidades;
using DesafioWebMotors.Dominio.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DesafioWebMotors.Application.Servicos
{
    public class ServicoAnuncio : IServicoAnuncio
    {

        private readonly IAnuncioRepositorio _anuncioRepositorio;
        private readonly IMapper _mapper;
        public ServicoAnuncio(IAnuncioRepositorio anuncioRepositorio,
            IMapper mapper)
        {
            this._mapper = mapper;
            this._anuncioRepositorio = anuncioRepositorio;
        }

        public AnuncioViewModel ObterPeloID(int ID)
        {
            return _mapper.Map<Anuncio, AnuncioViewModel>(_anuncioRepositorio.ObterPeloID(ID));
        }

        public void Adicionar(AnuncioViewModel obj)
        {
            var anuncio = _mapper.Map<AnuncioViewModel, Anuncio>(obj);
            _anuncioRepositorio.Adicionar(anuncio);
            SalvarAlteracoes();
        }

        public void Atualizar(AnuncioViewModel obj)
        {
            _anuncioRepositorio.Atualizar(_mapper.Map<AnuncioViewModel, Anuncio>(obj));
            SalvarAlteracoes();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IQueryable<AnuncioViewModel> ObterTodos()
        {
            return _anuncioRepositorio.ObterTodos().ProjectTo<AnuncioViewModel>();
        }

        public void Remover(int ID)
        {
            _anuncioRepositorio.Remover(ID);
            SalvarAlteracoes();
        }

        public int SalvarAlteracoes()
        {
           return _anuncioRepositorio.SalvarAlteracoes();
        }
    }
}
