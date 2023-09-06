using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SportsShop.Domain.Entities
{
    public class Product
    {
        [HiddenInput(DisplayValue=false)]
        public int ProductId { get; set; }
        [DisplayName("Nazwa")]
        [Required(ErrorMessage ="Prosze podać nazwę produktu.")]
        public string Name { get; set; }
        [DataType(DataType.MultilineText)]
        [DisplayName("Opis")]
        [Required(ErrorMessage = "Prosze podać opis.")]
        public string Description { get; set; }
        [DisplayName("Cena")]
        [Required]
        [Range(0.01,double.MaxValue, ErrorMessage = "Prosze podać dodatnią cenę.")]
        public decimal Price { get; set; }
        [DisplayName("Kategoria")]
        [Required(ErrorMessage = "Prosze określić kategorię.")]
        public string Category { get; set; }

        public byte[] ImageData {  get; set; }
        [HiddenInput(DisplayValue = false)]
        public string ImageMimeType { get; set; }
    }
}
