using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DesafioWebMotors.Application.ViewModels
{
    public class AnuncioViewModel
    {
        [Key]
        public int ID { get;  set; }
        [MaxLength(45)]
        [Required]
        public string Marca { get;  set; }
        [MaxLength(45)]
        [Required]
        public string Modelo { get;  set; }
        [MaxLength(45)]
        [Required]
        public string Versao { get;  set; }
        [Required]
        public int Ano { get;  set; }
        [Required]
        public int Quilometragem { get;  set; }
        public string Observacao { get;  set; }
    }
}
