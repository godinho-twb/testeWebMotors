using DesafioWebMotors.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace DesafioWebMotors.Application.Interfaces
{

    public interface IServicoApi
    {
        string ListarMarcas();
        string ListarModelos(int MarcaId);
        string ListarVersoes(int ModeloId);

    }
}
