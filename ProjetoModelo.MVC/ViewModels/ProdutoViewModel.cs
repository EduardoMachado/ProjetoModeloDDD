using System;
using System.ComponentModel.DataAnnotations;

namespace ProjetoModelo.MVC.ViewModels
{
    public class ProdutoViewModel
    {
        [Key]
        public int ProdutoId { get; set; }

        [Required(ErrorMessage = "Preencha o campo Nome")]
        [MaxLength(200, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Minímo {0} caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Preencha um valor")]
        [DataType(DataType.Currency)]
        [Range(typeof(decimal),"0","9999999999999999")]
        public decimal Valor { get; set; }

        [Display(Name ="Disponível ?")]
        public bool Disponivel { get; set; }

        public int ClienteId { get; set; }

        public virtual ClienteViewModel Cliente { get; set; }
    }
}