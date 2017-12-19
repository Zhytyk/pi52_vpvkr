using LibraryReport.Controllers;
using LibraryReport.Interfaces;
using LibraryReport.Models;
using LibraryReport.Repositories;
using LibraryReport.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryReport.IOC
{
    public static class IOCContainer
    {
        private static DependencyInjector di;

        static IOCContainer()
        {
            di = new DependencyInjector();
            Initialize();
        }

        public static IRegistry Registry {
            get
            {
                return di;
            }
        }

        public static Injector Injector
        {
            get
            {
                return di;
            }
        }

        private static void Initialize()
        {
            Registry.RegisterBean(typeof(DbEFContext));


            //repo
            Registry.RegisterBean(typeof(LibraryRepository), Injector.Inject(typeof(DbEFContext)));
            Registry.RegisterBean(typeof(SectionRepository), Injector.Inject(typeof(DbEFContext)));
            Registry.RegisterBean(typeof(AuthorRepository), Injector.Inject(typeof(DbEFContext)));
            Registry.RegisterBean(typeof(PublisherRepository), Injector.Inject(typeof(DbEFContext)));
            Registry.RegisterBean(typeof(AuthorBookRepository), Injector.Inject(typeof(DbEFContext)));
            Registry.RegisterBean(typeof(BookRepository), Injector.Inject(typeof(DbEFContext)));
            Registry.RegisterBean(typeof(ClientRepository), Injector.Inject(typeof(DbEFContext)));
            Registry.RegisterBean(typeof(BookClientRepository), Injector.Inject(typeof(DbEFContext)));
            Registry.RegisterBean(typeof(BookClientArchiveRepository), Injector.Inject(typeof(DbEFContext)));
            Registry.RegisterBean(typeof(UserRepository), Injector.Inject(typeof(DbEFContext)));
            Registry.RegisterBean(typeof(ReportRepository), Injector.Inject(typeof(DbEFContext)));

            //controllers
            Registry.RegisterBean(typeof(LibraryController));
            Registry.RegisterBean(typeof(SectionController));
            Registry.RegisterBean(typeof(AuthorController));
            Registry.RegisterBean(typeof(PublisherController));
            Registry.RegisterBean(typeof(AuthorBookController));
            Registry.RegisterBean(typeof(BookController));
            Registry.RegisterBean(typeof(ClientController));
            Registry.RegisterBean(typeof(BookClientController));
            Registry.RegisterBean(typeof(BookClientArchiveController));
            Registry.RegisterBean(typeof(UserController));
            Registry.RegisterBean(typeof(ReportController));
        }
    }
}
