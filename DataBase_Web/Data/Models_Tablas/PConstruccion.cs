using System.ComponentModel.DataAnnotations;

namespace DataBase_Web.Data.Models_Tablas
{
    public class PConstruccion
    {


        [Key]
        public string ElementGUID { get; set; }
        public int ElementID { get; set; }

        public string Category { get; set; }
       
        public string ElementName { get; set; }

       
        public string FechaProgramada { get; set; }
        public string FechaEjecutada { get; set; }



    }
}
