using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioWebMotors.Application.AutoMapper
{
    public class AutoMapperConfiguration
    {

        public static MapperConfiguration RegistrarMapeamento()
        {
            Mapper.Initialize(x => x.AddProfile<PerfilDominioParaViewModel>());
            Mapper.Initialize(x => x.AddProfile<PerfilViewModelParaDominio>());


            return new MapperConfiguration(c =>
           {
               c.AddProfile(new PerfilDominioParaViewModel());
               c.AddProfile(new PerfilViewModelParaDominio());
           });
        }

    }
}
