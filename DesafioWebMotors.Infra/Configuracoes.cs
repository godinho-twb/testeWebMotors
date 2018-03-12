using Microsoft.Extensions.Configuration;
using System;

namespace DesafioWebMotors.Infra
{
    public class Configuracoes
    {
        private readonly IConfigurationBuilder _configuracao;
        public Configuracoes(IConfigurationBuilder configuracao)
        {
            _configuracao = configuracao;


        }
    }
}
