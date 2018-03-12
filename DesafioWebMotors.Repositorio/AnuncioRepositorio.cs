using DesafioWebMotors.Dominio.Entidades;
using DesafioWebMotors.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioWebMotors.Infra.Repositorio
{
    public class AnuncioRepositorio : Repositorio<Anuncio>, IAnuncioRepositorio
    {
        public AnuncioRepositorio(Contexto contexto) : base(contexto)
        {

        }
    }
}
