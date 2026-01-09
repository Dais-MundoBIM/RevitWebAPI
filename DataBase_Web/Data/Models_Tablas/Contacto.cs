using System.ComponentModel.DataAnnotations;

namespace DataBase_Web.Data.Models_Tablas
{
    public class Contact
    {


        [Key]
        public int ID { get; set; }

        [Display(Name= "Nombre")]
        [Required(ErrorMessage ="Ingresa tu nombre")]
        public string Name { get; set; }
        [Display(Name = "Correo electronico")]
        [Required(ErrorMessage = "Ingresa tu correo")]
        public string Email { get; set; }
        [Display(Name = "Numero de telefono")]
        [Required(ErrorMessage = "Ingresa tu telefono")]
        public string Phone { get; set; }

        [Display(Name = "Direccion")]
        [Required(ErrorMessage = "Ingresa tu direccion")]
        public string Addres { get; set; }
        [Required()]
        public DateTime Date_Create { get; set; }

    }
}
