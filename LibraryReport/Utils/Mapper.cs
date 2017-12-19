using LibraryReport.Models;
using LibraryReport.Views.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryReport.Utils
{
    public static class Mapper
    {
        #region library
        public static LibraryViewModel LibraryToLibraryViewModel(Library library)
        {
            return new LibraryViewModel(library);
        }

        public static IList<LibraryViewModel> LibrariesToLibraryViewModels(IList<Library> libraries)
        {
            return libraries.Select(e => LibraryToLibraryViewModel(e)).ToList();
        }

        public static Library LibraryViewModelToLibrary(LibraryViewModel libVM)
        {
            Library library = new Library();

            library.Name = libVM.Name;
            library.Description = libVM.Description;
            library.ModifiedOn = libVM.ModifiedOn;
            library.CreatedOn = libVM.CreatedOn;

            return library;
        }

        public static IList<Library> LibraryViewModelsToLibraries(IList<LibraryViewModel> libVMs)
        {
            return libVMs.Select(e => LibraryViewModelToLibrary(e)).ToList();
        }
        #endregion

        #region section
        public static SectionViewModel SectionToSectionViewModel(Section section)
        {
            return new SectionViewModel(section);
        }

        public static IList<SectionViewModel> SectionsToSectionViewModels(IList<Section> sections)
        {
            return sections.Select(e => SectionToSectionViewModel(e)).ToList();
        }

        public static Section SectionViewModelToSection(SectionViewModel secVM)
        {
            Section section = new Section();

            section.Name = secVM.Name;
            section.Description = secVM.Description;
            section.ModifiedOn = secVM.ModifiedOn;
            section.CreatedOn = secVM.CreatedOn;

            return section;
        }

        public static IList<Section> SectionViewModelsToSections(IList<SectionViewModel> secVMs)
        {
            return secVMs.Select(e => SectionViewModelToSection(e)).ToList();
        }
        #endregion

        #region author
        public static AuthorViewModel AuthorToAuthorViewModel(Author author)
        { 
            return new AuthorViewModel(author);
        }

        public static IList<AuthorViewModel> AuthorsToAuthorViewModels(IList<Author> authors)
        {
            return authors.Select(e => AuthorToAuthorViewModel(e)).ToList();
        }

        public static Author AuthorViewModelToAuthor(AuthorViewModel authVM)
        {
            Author author = new Author();

            author.Name = authVM.Name;
            author.SurName = authVM.SurName;

            return author;
        }

        public static IList<Author> AuthorViewModelsToAuthors(IList<AuthorViewModel> authVMs)
        {
            return authVMs.Select(e => AuthorViewModelToAuthor(e)).ToList();
        }
        #endregion

        #region publisher
        public static PublisherViewModel PublisherToPublisherViewModel(Publisher publisher)
        {
            return new PublisherViewModel(publisher);
        }

        public static IList<PublisherViewModel> PublishersToPublisherViewModels(IList<Publisher> publishers)
        {
            return publishers.Select(e => PublisherToPublisherViewModel(e)).ToList();
        }

        public static Publisher PublisherViewModelToPublisher(PublisherViewModel publisherVM)
        {
            Publisher publisher = new Publisher();

            publisher.Name = publisherVM.Name;
            publisher.Description = publisherVM.Description;

            return publisher;
        }

        public static IList<Publisher> PublisherViewModelsToPublishers(IList<PublisherViewModel> publisherVMs)
        {
            return publisherVMs.Select(e => PublisherViewModelToPublisher(e)).ToList();
        }

        #endregion

        #region user

        public static UserViewModel UserToUserViewModel(User user)
        {
            return new UserViewModel(user);
        }

        public static IList<UserViewModel> UsersToUserViewModels(IList<User> users)
        {
            return users.Select(e => UserToUserViewModel(e)).ToList();
        }

        public static User UserViewModelToUser(UserViewModel userVM)
        {
            User user = new User();

            user.Login = userVM.Login;
            user.Email = userVM.Email;
            user.Password = userVM.Password;
            user.Role = userVM.Role;

            return user;
        }

        public static IList<User> UserViewModelsToUsers(IList<UserViewModel> userVMs)
        {
            return userVMs.Select(e => UserViewModelToUser(e)).ToList();
        }

        #endregion

        #region book

        public static BookViewModel BookToBookViewModel(Book book)
        {
            return new BookViewModel(book);
        }

        public static IList<BookViewModel> BooksToBookViewModels(IList<Book> books)
        {
            return books.Select(e => BookToBookViewModel(e)).ToList();
        }

        public static Book BookViewModelToBook(BookViewModel bookVM)
        {
            Book book = new Book();

            book.Name = bookVM.Name;
            book.Description = bookVM.Description;
            book.ModifiedOn = bookVM.ModifiedOn;
            book.CreatedOn = bookVM.CreatedOn;

            return book;
        }

        public static IList<Book> BookViewModelsToBooks(IList<BookViewModel> bookVMs)
        {
            return bookVMs.Select(e => BookViewModelToBook(e)).ToList();
        }

        #endregion

        #region authorbook

        public static AuthorBookViewModel AuthorBookToAuthorBookViewModel(AuthorBook authorBook)
        {
            return new AuthorBookViewModel(authorBook);
        }

        public static IList<AuthorBookViewModel> AuthorBooksToAuthorBookViewModels(IList<AuthorBook> authorBooks)
        {
            return authorBooks.Select(e => AuthorBookToAuthorBookViewModel(e)).ToList();
        }

        public static AuthorBook AuthorBookViewModelToAuthorBook(AuthorBookViewModel authorBookVM)
        {
           AuthorBook authorBook = new AuthorBook();

            return authorBook;
        }

        public static IList<AuthorBook> AuthorBookViewModelsToAuthorBooks(IList<AuthorBookViewModel> authorBookVMs)
        {
            return authorBookVMs.Select(e => AuthorBookViewModelToAuthorBook(e)).ToList();
        }

        #endregion

        #region client

        public static ClientViewModel ClientToClientViewModel(Client client)
        {
            return new ClientViewModel(client);
        }

        public static IList<ClientViewModel> ClientsToClientViewModels(IList<Client> clients)
        {
            return clients.Select(e => ClientToClientViewModel(e)).ToList();
        }

        public static Client ClientViewModelToClient(ClientViewModel clientVM)
        {
            Client client = new Client();

            client.Name = clientVM.Name;
            client.Surname = clientVM.SurName;

            return client;
        }

        public static IList<Client> ClientViewModelsToClients(IList<ClientViewModel> clientVMs)
        {
            return clientVMs.Select(e => ClientViewModelToClient(e)).ToList();
        }

        #endregion

        #region bookclient

        public static BookClientViewModel BookClientToBookClientViewModel(BookClient bookClient)
        {
            return new BookClientViewModel(bookClient);
        }

        public static IList<BookClientViewModel> BookClientsToBookClientViewModels(IList<BookClient> bookClients)
        {
            return bookClients.Select(e => BookClientToBookClientViewModel(e)).ToList();
        }

        public static BookClient BookClientViewModelToBookClient(BookClientViewModel bookClientVM)
        {
            BookClient bookClient = new BookClient();

            bookClient.UntilTo = bookClient.UntilTo;

            return bookClient;
        }

        public static IList<BookClient> BookClientViewModelsToBookClients(IList<BookClientViewModel> bookClientVMs)
        {
            return bookClientVMs.Select(e => BookClientViewModelToBookClient(e)).ToList();
        }

        #endregion

        #region bookclientarchive

        public static BookClientArchiveViewModel BookClientArchiveToBookClientArchiveViewModel(BookClientArchive bookClientArchive)
        {
            return new BookClientArchiveViewModel(bookClientArchive);
        }

        public static IList<BookClientArchiveViewModel> BookClientArchivesToBookClientArchiveViewModels(IList<BookClientArchive> bookClientArchives)
        {
            return bookClientArchives.Select(e => BookClientArchiveToBookClientArchiveViewModel(e)).ToList();
        }

        public static BookClientArchive BookClientArchiveViewModelToBookClientArchive(BookClientArchiveViewModel bookClientArchiveVM)
        {
            BookClientArchive bookClientArchive = new BookClientArchive();

            bookClientArchive.UntilTo = bookClientArchive.UntilTo;

            return bookClientArchive;
        }

        public static IList<BookClientArchive> BookClientArchiveViewModelsToBookClientArchives(IList<BookClientArchiveViewModel> bookClientArchiveVMs)
        {
            return bookClientArchiveVMs.Select(e => BookClientArchiveViewModelToBookClientArchive(e)).ToList();
        }

        #endregion

        #region report

        public static ReportViewModel ReportToReportViewModel(Report report)
        {
            return new ReportViewModel(report);
        }

        public static IList<ReportViewModel> ReportsToReportViewModels(IList<Report> reports)
        {
            return reports.Select(e => ReportToReportViewModel(e)).ToList();
        }

        public static Report ReportViewModelToReport(ReportViewModel reportVM)
        {
            Report report = new Report();

            report.CreatedOn = reportVM.CreatedOn;
            report.CountClients = reportVM.CountClients;
            report.CountSections = reportVM.CountSections;
            report.CountBooks = reportVM.CountBooks;
            report.CountBooksInUse = report.CountBooksInUse;
            report.CountBooksNotInUse = report.CountBooksNotInUse;

            return report;
        }

        public static IList<Report> ReportViewModelsToReports(IList<ReportViewModel> reportVMs)
        {
            return reportVMs.Select(e => ReportViewModelToReport(e)).ToList();
        }

        #endregion
    }
}
