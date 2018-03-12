using AutoMapper;
using DesafioWebMotors.Application.ViewModels;
using DesafioWebMotors.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioWebMotors.Application.AutoMapper
{
    public class PerfilViewModelParaDominio : Profile
    {
        public PerfilViewModelParaDominio()
        {
            CreateMap<AnuncioViewModel, Anuncio>();
        }
    }
}
