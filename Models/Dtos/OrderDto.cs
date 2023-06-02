using System.ComponentModel.DataAnnotations;
using VerstaTask.Arrtibutes;

namespace VerstaTask.Models.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "Это поле обязательно для заполнения!")]
        [MaxLength(32)]
        public string SenderCity { get; set; } = null!;

        public string? SenderAddress { get; set; }

        [Required(ErrorMessage = "Это поле обязательно для заполнения!")]
        [MaxLength(37)]
        [Street(ErrorMessage = "Название улицы не должно содержать запятых!")]
        public string SenderStreet { get; set; } = null!;

        [Required(ErrorMessage = "Это поле обязательно для заполнения!")]
        [Range(1, 1000, ErrorMessage = "Введён некорректный номер дома!")]
        public int SenderHouseNumber { get; set; }

        [Range(1, 100, ErrorMessage = "Введён некорректный номер корпуса!")]
        public int? SenderCaseNumber { get; set; }

        [Range(1, 10000, ErrorMessage = "Введён некорректный номер квартиры!")]
        public int? SenderFlatNumber { get; set; }


        [Required(ErrorMessage = "Это поле обязательно для заполнения!")]
        [MaxLength(32)]
        public string RecipientCity { get; set; } = null!;

        public string? RecipientAddress { get; set; }

        [Required(ErrorMessage = "Это поле обязательно для заполнения!")]
        [MaxLength(37)]
        [Street(ErrorMessage = "Название улицы не должно содержать запятых!")]
        public string RecipientStreet { get; set; } = null!;

        [Required(ErrorMessage = "Это поле обязательно для заполнения!")]
        [Range(1, 1000, ErrorMessage = "Введён некорректный номер дома!")]
        public int RecipientHouseNumber { get; set; }

        [Range(1, 100, ErrorMessage = "Введён некорректный номер корпуса!")]
        public int? RecipientCaseNumber { get; set; }
            
        [Range(1, 10000, ErrorMessage = "Введён некорректный номер квартиры!")]
        public int? RecipientFlatNumber { get; set; }


        [Required(ErrorMessage = "Это поле обязательно для заполнения!")]
        [RegularExpression(@"[5-9]\d{0,2}((,|\.)\d{1,3}){0,1}", ErrorMessage = "Вес груза должен находиться в диапазоне от 5 до 1000 кг!")]
        public string CargoWeightStr { get; set; } = null!;

        [Required(ErrorMessage = "Это поле обязательно для заполнения!")]
        [Date("2000-01-01", format: "yyyy-MM-dd", ErrorMessage = "Введена недопустимая дата забора груза!")]
        public DateTime PickupDate { get; set; }
    }
}
