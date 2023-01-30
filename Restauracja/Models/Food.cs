using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restauracja.Models
{
    public class Food
    {
        public const string name = "Nazwa";
        public const string price = "Cena";
        public const string desc = "Opis";
        public const string vegan = "Wegańskie";
        public const string vegetarian = "Wegetariańskie";
        public const string gluten = "Bez glutenu";
        public const string lactose = "Bez laktozy";
        public const string cat = "Kategoria";

        public int Id { get; set; }

        [Display(Name = name), StringLength(40, MinimumLength = 3)]
        public string Name { get; set; } = string.Empty;

        [Display(Name = desc), StringLength(250)]
        public string? Description { get; set; }

        [Display(Name = cat), StringLength(20)]
        public string? Category { get; set; }

        [Display(Name = price), DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Display(Name = vegan)]
        public bool IsVegan { get; set; }

        [Display(Name = vegetarian)]
        public bool IsVegetarian { get; set;}

        [Display(Name = lactose)]
        public bool IsLactoseFree { get; set; }

        [Display(Name = gluten)]
        public bool IsGlutenFree { get; set; }

    }
}
