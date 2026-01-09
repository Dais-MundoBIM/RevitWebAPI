using Microsoft.EntityFrameworkCore;
using DataBase_Web.Data.Models_Tablas;
using Npgsql.EntityFrameworkCore.PostgreSQL;

namespace DataBase_Web.Data
{
    public class ApplicationDbContex : DbContext
    {

        public ApplicationDbContex(DbContextOptions<ApplicationDbContex> options) : base(options)
        {

        }



        //TABLASSSS
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<PConstruccion> PConstruccions { get; set; }







    }
}
