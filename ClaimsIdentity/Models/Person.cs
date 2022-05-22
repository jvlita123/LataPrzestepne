using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClaimsIdentity.Models
{

    public class Person
    {
        public int Id { get; set; }
        public DateTime data { get; set; }

        public string email { get; set; }


        [Display(Name = "Twój rok urodzenia")]
        [Required(ErrorMessage = "uzupełnij dane"), Range(1899, 2022, ErrorMessage = "Oczekiwana wartość {0} z zakresu {1} i {2}.")]
        [Column(TypeName = "varchar(100)")]
        public int? Year { get; set; }

        [Display(Name = "Twoje imie")]
        [Required(ErrorMessage = "Pole jest obowiązkowe")]
        [MaxLength(100)]

        [Column(TypeName = "varchar(100)")]

        public string? Name { get; set; }

        [MaxLength(100)]
        [Display(Name = "Twoje nazwisko (opcjonalne)")]
        [Column(TypeName = "varchar(100)")]

        public string? Surname { get; set; }

        public string? ErrorMessage { get; set; }

        public string IsLeap(object? number)
        {

            if ((int)number % 100 != 0 && (int)number % 4 == 0 || (int)number % 400 == 0 && number != null)
            {
                this.ErrorMessage = "rok przestępny";
                return "rok przestępny";
            }
            this.ErrorMessage = "rok przestępny";
            return "rok nie przestępny";
        }

        public bool IsValid(object? value)
        {
            string array1 = Convert.ToString(value);

            if (array1[^1] != 'a')
            {
                this.ErrorMessage = "urodził się w ";
                return true;
            }

            this.ErrorMessage = "urodziła się w ";
            return true;
        }



    }



}
