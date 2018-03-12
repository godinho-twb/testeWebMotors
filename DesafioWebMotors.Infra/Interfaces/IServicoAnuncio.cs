using DesafioWebMotors.Application.ViewModels;
using DesafioWebMotors.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesafioWebMotors.Application.Interfaces
{
    public interface IServicoAnuncio : IDisposable
    {
        void Adicionar(AnuncioViewModel obj);
        IQueryable<AnuncioViewModel> ObterTodos();
        AnuncioViewModel ObterPeloID(int ID);
        void Atualizar(AnuncioViewModel obj);
        void Remover(int ID);
        int SalvarAlteracoes();
    }
}
