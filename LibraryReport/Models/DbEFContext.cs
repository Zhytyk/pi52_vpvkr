using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryReport.Models
{
    public class DbEFContext : DbContext
    {
        public DbEFContext() : base("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=library_report;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
        { }

        // Отражение таблиц базы данных на свойства с типом DbSet
        public DbSet<Library> Libraries { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<BookClientArchive> BookClientArchives { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<BookClient> BookClients { get; set; }
        public DbSet<AuthorBook> AuthorBooks { get; set; }
        public DbSet<Book> Books { get; set; } 
    }
}
