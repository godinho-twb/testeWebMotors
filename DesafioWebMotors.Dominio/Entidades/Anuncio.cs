using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioWebMotors.Dominio.Entidades
{
    public class Anuncio
    {
        public int ID { get; private set; }
        public string Marca { get; private set; }
        public string Modelo { get; private set; }
        public string Versao { get; private set; }
        public int Ano { get; private set; }
        public int Quilometragem { get; private set; }
        public string Observacao { get; private set; }

        public Anuncio(int ID,
            string Marca,
            string Modelo,
            string Versao,
            int Ano,
            int Quilometragem,
            string Observacao)
        {
            this.ID = ID;
            this.Marca = Marca;
            this.Modelo = Modelo;
            this.Versao = Versao;
            this.Ano = Ano;
            this.Quilometragem = Quilometragem;
            this.Observacao = Observacao;
        }

        public Anuncio()
        {

        }
    }

}
