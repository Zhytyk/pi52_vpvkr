using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryReport.Utils
{
    class Constants
    {
        public const string CONTEXT = "context";
        public const string IOC = "IOC";


        //tables
        public const string LIBRARIES = "libraries";
        public const string SECTIONS = "sections";
        public const string AUTHORS = "authors";
        public const string PUBLISHERS = "publishers";
        public const string BOOKS = "books";
        public const string AUTHORS_BOOKS = "authors_books";
        public const string CLIENTS = "clients";
        public const string BOOKS_CLIENTS = "books_clients";
        public const string BOOKS_CLIENTS_ARCHIVE = "books_clients_archive";
        public const string USERS = "users";
        public const string REPORTS = "reports";


        //fields
        public const string ID = "Id";
        public const string NAME = "Name";
        public const string DESCRIPTION = "Description";
        public const string MODIFIED_ON = "ModifiedOn";
        public const string CREATED_ON = "CreatedOn";
        public const string UNTIL_TO = "UntilTo";
        public const string LIBRARY_ID = "LibraryId";
        public const string SURNAME = "SurName";
        public const string SECTION_ID = "SectionId";
        public const string PUBLISHER_ID = "PublisherId";
        public const string BOOK_ID = "BookId";
        public const string AUTHOR_ID = "AuthorId";
        public const string CLIENT_ID = "ClientId";
        public const string LOGIN = "Login";
        public const string PASSWORD = "Password";
        public const string EMAIL = "EMAIL";
        public const string ROLE = "Role";
        public const string CONDITION = "Condition";
        public const string COUNT_CLIENTS = "CountClients";
        public const string COUNT_SECTIONS = "CountSections";
        public const string COUNT_BOOKS = "CountBooks";
        public const string COUNT_BOOKS_IN_USE = "CountBooksInUse";
        public const string COUNT_BOOKS_NOT_IN_USE = "CountBooksNotInUse";


        //repo
        public const string LIBRARY_REPOSITORY = "libraryRepository";
        public const string SECTION_REPOSITORY = "sectionRepository";


        //controllers
        public const string LIBRARY_CONTROLLER = "libraryController";
        public const string SECTION_CONTROLLER = "sectionController";

        //role
        public const string USER = "User";
        public const string ADMIN = "Admin";



        //view
        public const string EDIT = "Edit";

        //template vars
        public const string REPORT_VIEW_MODEL_TEMPLATE_PATH = @"Utils\templates\ReportViewModelTemplate.txt";

        public static string ToTemplateVar(string name)
        {
            return "${" + name + "}";
        } 

        public const string LIBRARY_NAME = "LibraryName";



    }
}
