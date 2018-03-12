using DesafioWebMotors.Application.Interfaces;
using DesafioWebMotors.Application.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace DesafioWebMotors.Application.Servicos
{
    public class ServicoApi : IServicoApi
    {
        private readonly string _urlWebApi;
        private readonly HttpClient _client;
        public ServicoApi(string urlWebApi)
        {
            this._urlWebApi = urlWebApi;

            if (_client == null)
            {
                this._client = new HttpClient();
                _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            }

        }

        public string ListarMarcas()
        {
            return _client.GetStringAsync(_urlWebApi + @"Make/").Result;
        }

        public string ListarModelos(int MarcaId)
        {
            return _client.GetStringAsync(_urlWebApi + @"Model?MakeID=" + string.Format("{0}", MarcaId)).Result;
        }

        public string ListarVersoes(int ModeloId)
        {
            return _client.GetStringAsync(_urlWebApi + @"Version?ModelID=" + string.Format("{0}", ModeloId)).Result;
        }
    }
}
