using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_App_Veiculos.Models
{
    [Table("Consumos")]
    public class Consumo
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Obrigatório informar a descrição")]
        [Display(Name ="Descrição")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Obrigatório informar a data")]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o valor")]
        public Decimal Valor { get; set; }

        [Required(ErrorMessage = "Obrigatório informar a quilometragem")]
        public int Km { get; set; }

        [Display(Name = "Tipo de Combustível")]
        public TipoCombustivel Tipo { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o veículo")]
        [Display(Name = "Veiculo")]
        public int VeiculoId { get; set; }

        [ForeignKey("VeiculoId")]
        public Veiculo Veiculo { get; set; }
    }

    public enum TipoCombustivel 
    {
        Gasolina,
        Etanol
    }
}
