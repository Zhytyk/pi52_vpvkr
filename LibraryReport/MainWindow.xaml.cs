using LibraryReport.Authentication;
using LibraryReport.Controllers;
using LibraryReport.IOC;
using LibraryReport.Models;
using LibraryReport.Utils;
using LibraryReport.Views.AuthorBooks;
using LibraryReport.Views.Authors;
using LibraryReport.Views.BookClients;
using LibraryReport.Views.Books;
using LibraryReport.Views.Clients;
using LibraryReport.Views.Libraries;
using LibraryReport.Views.Publishers;
using LibraryReport.Views.Reports;
using LibraryReport.Views.Sections;
using LibraryReport.Views.Users;
using LibraryReport.Views.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LibraryReport
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string nameOfCurrentTable = Constants.LIBRARIES;

        private AuthProvider authProvider;

        private LibraryController libraryController;
        private SectionController sectionController;
        private AuthorController authorController;
        private PublisherController publisherController;
        private AuthorBookController authorBookController;
        private BookController bookController;
        private ClientController clientController;
        private BookClientController bookClientController;
        private BookClientArchiveController bookClientArchiveController;
        private UserController userController;
        private ReportController reportController;

        private ObservableCollection<LibraryViewModel> libraryItems;
        private ObservableCollection<SectionViewModel> sectionItems;
        private ObservableCollection<AuthorViewModel> authorItems;
        private ObservableCollection<PublisherViewModel> publisherItems;
        private ObservableCollection<AuthorBookViewModel> authorBookItems;
        private ObservableCollection<BookViewModel> bookItems;
        private ObservableCollection<ClientViewModel> clientItems;
        private ObservableCollection<BookClientViewModel> bookClientItems;
        private ObservableCollection<BookClientArchiveViewModel> bookClientArchiveItems;
        private ObservableCollection<UserViewModel> userItems;
        private ObservableCollection<ReportViewModel> reportItems;


        public MainWindow()
        {
            AuthForm();
            InitializeComponent();

            libraryController = IOCContainer.Injector.Inject(typeof(LibraryController)) as LibraryController;
            sectionController = IOCContainer.Injector.Inject(typeof(SectionController)) as SectionController;
            authorController = IOCContainer.Injector.Inject(typeof(AuthorController)) as AuthorController;
            publisherController = IOCContainer.Injector.Inject(typeof(PublisherController)) as PublisherController;
            authorBookController = IOCContainer.Injector.Inject(typeof(AuthorBookController)) as AuthorBookController;
            bookController = IOCContainer.Injector.Inject(typeof(BookController)) as BookController;
            clientController = IOCContainer.Injector.Inject(typeof(ClientController)) as ClientController;
            bookClientController = IOCContainer.Injector.Inject(typeof(BookClientController)) as BookClientController;
            bookClientArchiveController = IOCContainer.Injector.Inject(typeof(BookClientArchiveController)) as BookClientArchiveController;
            userController = IOCContainer.Injector.Inject(typeof(UserController)) as UserController;
            reportController = IOCContainer.Injector.Inject(typeof(ReportController)) as ReportController;

            SetRights();

            ReadLibraries();
        }

        #region libraries
        private void ReadLibraries()
        {
            if (libraryController == null)
            {
                return;
            }

            InitDataSource(ref libraryItems, Mapper.LibrariesToLibraryViewModels, libraryController.Get);

            UnregisterButtonEvents();

            RegisterButtonEvents(Constants.LIBRARIES);
        }

        private void AddLibraryBtn_Click(object sender, RoutedEventArgs e)
        {
            InitDataSource(ref libraryItems, Mapper.LibrariesToLibraryViewModels, libraryController.Get);

            AddLibrary addLibrary = new AddLibrary();
            if (addLibrary.ShowDialog().Value)
            {
                string name = addLibrary.Name.Text;
                string description = addLibrary.Description.Text;

                if (name != null)
                {
                    Library library = new Library(name, description);
                    libraryController.Add(library);
                    libraryItems.Add(Mapper.LibraryToLibraryViewModel(library));
                    return;
                }
            }
        }

        private void EditLibraryBtn_Click(object sender, RoutedEventArgs e)
        {
            LibraryViewModel libraryVM = dataGrid.SelectedItem as LibraryViewModel;

            AddLibrary editLibrary = new AddLibrary(libraryVM.Name, libraryVM.Description);
            if (editLibrary.ShowDialog().Value)
            {
                string name = editLibrary.Name.Text;
                string description = editLibrary.Description.Text;

                if (libraryVM != null && name != null)
                {
                    Library library = libraryController.GetById(libraryVM.Id);
                    library.Name = libraryVM.Name = name;
                    library.Description = libraryVM.Description = description;
                    library.ModifiedOn = libraryVM.ModifiedOn = DateTime.Now;
                    libraryController.Edit(library);
                }
            }
        }

        private void RemoveLibraryBtn_Click(object sender, RoutedEventArgs e)
        {
            InitDataSource(ref libraryItems, Mapper.LibrariesToLibraryViewModels, libraryController.Get);

            LibraryViewModel library = dataGrid.SelectedItem as LibraryViewModel;

            if (library != null)
            {
                libraryController.Remove(library.Id);
                libraryItems.Remove(library);
            }
        }
        #endregion



        #region sections

        private void ReadSections()
        {
            InitDataSource(ref sectionItems, Mapper.SectionsToSectionViewModels, sectionController.Get);

            UnregisterButtonEvents();

            RegisterButtonEvents(Constants.SECTIONS);
        }

        private void AddSectionBtn_Click(object sender, RoutedEventArgs e)
        {
            InitDataSource(ref sectionItems, Mapper.SectionsToSectionViewModels, sectionController.Get);

            AddSection addSection = new AddSection(libraryItems);
            if (addSection.ShowDialog().Value)
            {
                string name = addSection.Name.Text;
                string description = addSection.Description.Text;
                LibraryViewModel model = addSection.SelectedItem;

                if (name != null && model != null)
                {
                    Library library = libraryController.GetById(model.Id);
                    Models.Section section = new Models.Section(name, description, library);
                    sectionController.Add(section);
                    sectionItems.Add(Mapper.SectionToSectionViewModel(section));
                    return;
                }
            }
        }

        private void EditSectionBtn_Click(object sender, RoutedEventArgs e)
        {
            SectionViewModel sectionVM = dataGrid.SelectedItem as SectionViewModel;

            AddSection editSection = new AddSection(libraryItems, sectionVM.Name, sectionVM.Description, libraryItems.First(i => i.Id == sectionVM.LibraryId));

            if (editSection.ShowDialog().Value)
            {
                string name = editSection.Name.Text;
                string description = editSection.Description.Text;
                LibraryViewModel model = editSection.SelectedItem;

                if (sectionVM != null && name != null && model != null)
                {
                    Models.Section section = sectionController.GetById(sectionVM.Id);
                    Library library = libraryController.GetById(model.Id);
                    section.Name = sectionVM.Name = name;
                    sectionVM.LibraryId = library.Id;
                    section.Library = library;
                    section.Description = sectionVM.Description = description;
                    section.ModifiedOn = sectionVM.ModifiedOn = DateTime.Now;
                    sectionController.Edit(section);
                }
            }
        }

        private void RemoveSectionBtn_Click(object sender, RoutedEventArgs e)
        {
            InitDataSource(ref sectionItems, Mapper.SectionsToSectionViewModels, sectionController.Get);

            SectionViewModel section = dataGrid.SelectedItem as SectionViewModel;

            if (section != null)
            {
                sectionController.Remove(section.Id);
                sectionItems.Remove(section);
            }
        }
        #endregion



        #region authors

        private void ReadAuthors()
        {
            InitDataSource(ref authorItems, Mapper.AuthorsToAuthorViewModels, authorController.Get);

            UnregisterButtonEvents();

            RegisterButtonEvents(Constants.AUTHORS);
        }

        private void AddAuthorBtn_Click(object sender, RoutedEventArgs e)
        {
            InitDataSource(ref authorItems, Mapper.AuthorsToAuthorViewModels, authorController.Get);

            AddAuthor addAuthor = new AddAuthor();
            if (addAuthor.ShowDialog().Value)
            {
                string name = addAuthor.Name.Text;
                string surname = addAuthor.Surname.Text;

                if (name != null && surname != null)
                {
                    Author author = new Author(name, surname);
                    authorController.Add(author);
                    authorItems.Add(Mapper.AuthorToAuthorViewModel(author));
                    return;
                }
            }
        }

        private void EditAuthorBtn_Click(object sender, RoutedEventArgs e)
        {
            AuthorViewModel authorVM = dataGrid.SelectedItem as AuthorViewModel;

            AddAuthor editAuthor = new AddAuthor(authorVM.Name, authorVM.SurName);

            if (editAuthor.ShowDialog().Value)
            {
                string name = editAuthor.Name.Text;
                string surname = editAuthor.Surname.Text;

                if (authorVM != null && name != null && surname != null)
                {
                    Author author = authorController.GetById(authorVM.Id);
                    author.Name = authorVM.Name = name;
                    author.SurName = authorVM.SurName = surname;
                    authorController.Edit(author);
                }
            }
        }

        private void RemoveAuthorBtn_Click(object sender, RoutedEventArgs e)
        {
            InitDataSource(ref authorItems, Mapper.AuthorsToAuthorViewModels, authorController.Get);

            AuthorViewModel author = dataGrid.SelectedItem as AuthorViewModel;

            if (author != null)
            {
                authorController.Remove(author.Id);
                authorItems.Remove(author);
            }
        }

        #endregion



        #region publisher

        private void ReadPublishers()
        {
            InitDataSource(ref publisherItems, Mapper.PublishersToPublisherViewModels, publisherController.Get);

            UnregisterButtonEvents();

            RegisterButtonEvents(Constants.PUBLISHERS);
        }

        private void AddPublisherBtn_Click(object sender, RoutedEventArgs e)
        {
            InitDataSource(ref publisherItems, Mapper.PublishersToPublisherViewModels, publisherController.Get);

            AddPublisher addPublisher = new AddPublisher();
            if (addPublisher.ShowDialog().Value)
            {
                string name = addPublisher.Name.Text;
                string description = addPublisher.Description.Text;

                if (name != null && description != null)
                {
                    Publisher publisher = new Publisher(name, description);
                    publisherController.Add(publisher);
                    publisherItems.Add(Mapper.PublisherToPublisherViewModel(publisher));
                    return;
                }
            }
        }

        private void EditPublisherBtn_Click(object sender, RoutedEventArgs e)
        {
            PublisherViewModel publisherVM = dataGrid.SelectedItem as PublisherViewModel;

            AddPublisher editPublisher = new AddPublisher(publisherVM.Name, publisherVM.Description);

            if (editPublisher.ShowDialog().Value)
            {
                string name = editPublisher.Name.Text;
                string description = editPublisher.Description.Text;

                if (publisherVM != null && name != null && description != null)
                {
                    Publisher publisher = publisherController.GetById(publisherVM.Id);
                    publisher.Name = publisherVM.Name = name;
                    publisher.Description = publisherVM.Description = description;
                    publisherController.Edit(publisher);
                }
            }
        }

        private void RemovePublisherBtn_Click(object sender, RoutedEventArgs e)
        {
            InitDataSource(ref publisherItems, Mapper.PublishersToPublisherViewModels, publisherController.Get);

            PublisherViewModel publisher = dataGrid.SelectedItem as PublisherViewModel;

            if (publisher != null)
            {
                publisherController.Remove(publisher.Id);
                publisherItems.Remove(publisher);
            }
        }

        #endregion



        #region user
        private void ReadUsers()
        {
            InitDataSource(ref userItems, Mapper.UsersToUserViewModels, userController.Get);

            UnregisterButtonEvents();

            RegisterButtonEvents(Constants.USERS);
        }

        private void AddUserBtn_Click(object sender, RoutedEventArgs e)
        {
            InitDataSource(ref userItems, Mapper.UsersToUserViewModels, userController.Get);

            AddUser addUser = new AddUser();
            if (addUser.ShowDialog().Value)
            {
                string login = addUser.Login.Text;
                string email = addUser.Email.Text;
                string password = addUser.Password.Text;
                string role = addUser.Role.Text;

                if (login != null && email != null && password != null && role != null)
                {
                    User user = new User(login, email, password, role);
                    userController.Add(user);
                    userItems.Add(Mapper.UserToUserViewModel(user));
                    return;
                }
            }
        }

        private void EditUserBtn_Click(object sender, RoutedEventArgs e)
        {
            UserViewModel userVM = dataGrid.SelectedItem as UserViewModel;

            AddUser editUser = new AddUser(userVM.Login, userVM.Email, userVM.Password, userVM.Role.ToString());

            if (editUser.ShowDialog().Value)
            {
                string login = editUser.Login.Text;
                string email = editUser.Email.Text;
                string password = editUser.Password.Text;
                string role = editUser.Role.Text;

                if (userVM != null && login != null && email != null && password != null && role != null)
                {
                    User user = userController.GetById(userVM.Id);
                    user.Login = userVM.Login = login;
                    user.Email = userVM.Email = email;
                    user.Password = userVM.Password = password;
                    user.Role = userVM.Role = (Role)Enum.Parse(typeof(Role), role);
                    userController.Edit(user);
                }
            }
        }

        private void RemoveUserBtn_Click(object sender, RoutedEventArgs e)
        {
            InitDataSource(ref userItems, Mapper.UsersToUserViewModels, userController.Get);

            UserViewModel user = dataGrid.SelectedItem as UserViewModel;

            if (user != null)
            {
                userController.Remove(user.Id);
                userItems.Remove(user);
            }
        }

        #endregion



        #region book

        private void ReadBooks()
        {
            InitDataSource(ref bookItems, Mapper.BooksToBookViewModels, bookController.Get);

            UnregisterButtonEvents();

            RegisterButtonEvents(Constants.BOOKS);
        }

        private void AddBookBtn_Click(object sender, RoutedEventArgs e)
        {
            InitDataSource(ref bookItems, Mapper.BooksToBookViewModels, bookController.Get);

            AddBook addBook = new AddBook(
                sectionItems = InitItems(ref sectionItems, Mapper.SectionsToSectionViewModels, sectionController.Get),
                publisherItems = InitItems(ref publisherItems, Mapper.PublishersToPublisherViewModels, publisherController.Get)
            );

            if (addBook.ShowDialog().Value)
            {
                string name = addBook.Name.Text;
                string description = addBook.Description.Text;
                Models.Condition condition = (Models.Condition)Enum.Parse(typeof(Models.Condition), addBook.Condition.Text);
                SectionViewModel sectionVM = addBook.SelectedSectionItem;
                PublisherViewModel publisherVM = addBook.SelectedPublisherItem;

                if (name != null && sectionVM != null && publisherVM != null)
                {
                    Models.Section section = sectionController.GetById(sectionVM.Id);
                    Publisher publisher = publisherController.GetById(publisherVM.Id);
                    Book book = new Book(name, description, condition, section, publisher);
                    bookController.Add(book);
                    bookItems.Add(Mapper.BookToBookViewModel(book));
                    return;
                }
            }
        }

        private void EditBookBtn_Click(object sender, RoutedEventArgs e)
        {
            BookViewModel bookVM = dataGrid.SelectedItem as BookViewModel;

            AddBook editBook = new AddBook(
                sectionItems = InitItems(ref sectionItems, Mapper.SectionsToSectionViewModels, sectionController.Get),
                publisherItems = InitItems(ref publisherItems, Mapper.PublishersToPublisherViewModels, publisherController.Get),
                bookVM.Name,
                bookVM.Description,
                bookVM.Condition,
                sectionItems.First(i => i.Id == bookVM.SectionId), publisherItems.First(i => i.Id == bookVM.PublisherId)
            );

            if (editBook.ShowDialog().Value)
            {
                string name = editBook.Name.Text;
                string description = editBook.Description.Text;
                Models.Condition condition = (Models.Condition)Enum.Parse(typeof(Models.Condition), editBook.Condition.Text);
                SectionViewModel sectionVM = editBook.SelectedSectionItem;
                PublisherViewModel publisherVM = editBook.SelectedPublisherItem;

                if (bookVM != null && name != null && sectionVM != null && publisherVM != null)
                {
                    Book book = bookController.GetById(bookVM.Id);
                    Models.Section section = sectionController.GetById(sectionVM.Id);
                    Publisher publisher = publisherController.GetById(publisherVM.Id);
                    book.Name = bookVM.Name = name;
                    bookVM.SectionId = section.Id;
                    bookVM.PublisherId = publisher.Id;
                    book.Section = section;
                    book.Publisher = publisher;
                    book.Condition = bookVM.Condition = condition;
                    book.Description = bookVM.Description = description;
                    book.ModifiedOn = bookVM.ModifiedOn = DateTime.Now;
                    bookController.Edit(book);
                }
            }
        }

        private void RemoveBookBtn_Click(object sender, RoutedEventArgs e)
        {
            InitDataSource(ref bookItems, Mapper.BooksToBookViewModels, bookController.Get);
            BookViewModel book = dataGrid.SelectedItem as BookViewModel;

            if (book != null)
            {
                bookController.Remove(book.Id);
                bookItems.Remove(book);
            }
        }

        #endregion



        #region authorbook
        private void ReadAuthorBooks()
        {
            InitDataSource(ref authorBookItems, Mapper.AuthorBooksToAuthorBookViewModels, authorBookController.Get);

            UnregisterButtonEvents();

            RegisterButtonEvents(Constants.AUTHORS_BOOKS);
        }

        private void AddAuthorBookBtn_Click(object sender, RoutedEventArgs e)
        {
            InitDataSource(ref authorBookItems, Mapper.AuthorBooksToAuthorBookViewModels, authorBookController.Get);

            AddAuthorBook addAuthorBook = new AddAuthorBook(
                bookItems = InitItems(ref bookItems, Mapper.BooksToBookViewModels, bookController.Get),
                authorItems = InitItems(ref authorItems, Mapper.AuthorsToAuthorViewModels, authorController.Get)
            );

            if (addAuthorBook.ShowDialog().Value)
            {
                BookViewModel bookVM = addAuthorBook.SelectedBookItem;
                AuthorViewModel authorVM = addAuthorBook.SelectedAuthorItem;

                if (bookVM != null && authorVM != null)
                {
                    Book book = bookController.GetById(bookVM.Id);
                    Author author = authorController.GetById(authorVM.Id);

                    AuthorBook authorBook = new AuthorBook(book, author);
                    authorBookController.Add(authorBook);
                    authorBookItems.Add(Mapper.AuthorBookToAuthorBookViewModel(authorBook));
                    return;
                }
            }
        }

        private void EditAuthorBookBtn_Click(object sender, RoutedEventArgs e)
        {
            AuthorBookViewModel authorBookVM = dataGrid.SelectedItem as AuthorBookViewModel;

            AddAuthorBook editAuthorBook = new AddAuthorBook(
                bookItems = InitItems(ref bookItems, Mapper.BooksToBookViewModels, bookController.Get),
                authorItems = InitItems(ref authorItems, Mapper.AuthorsToAuthorViewModels, authorController.Get),
                bookItems.First(i => i.Id == authorBookVM.BookId),
                authorItems.First(i => i.Id == authorBookVM.AuthorId)
            );

            if (editAuthorBook.ShowDialog().Value)
            {
                BookViewModel bookVM = editAuthorBook.SelectedBookItem;
                AuthorViewModel authorVM = editAuthorBook.SelectedAuthorItem;

                if (bookVM != null && authorVM != null)
                {
                    AuthorBook authorBook = authorBookController.GetById(authorBookVM.Id);
                    Book book = bookController.GetById(bookVM.Id);
                    Author author = authorController.GetById(authorVM.Id);
                    authorBookVM.BookId = book.Id;
                    authorBookVM.AuthorId = author.Id;
                    authorBook.Book = book;
                    authorBook.Author = author;
                    authorBookController.Edit(authorBook);
                }
            }
        }

        private void RemoveAuthorBookBtn_Click(object sender, RoutedEventArgs e)
        {
            InitDataSource(ref authorBookItems, Mapper.AuthorBooksToAuthorBookViewModels, authorBookController.Get);

            AuthorBookViewModel authorBook = dataGrid.SelectedItem as AuthorBookViewModel;

            if (authorBook != null)
            {
                authorBookController.Remove(authorBook.Id);
                authorBookItems.Remove(authorBook);
            }
        }


        #endregion



        #region client


        private void ReadClients()
        {
            InitDataSource(ref clientItems, Mapper.ClientsToClientViewModels, clientController.Get);

            UnregisterButtonEvents();

            RegisterButtonEvents(Constants.CLIENTS);
        }

        private void AddClientBtn_Click(object sender, RoutedEventArgs e)
        {
            InitDataSource(ref clientItems, Mapper.ClientsToClientViewModels, clientController.Get);

            AddClient addClient = new AddClient(libraryItems);
            if (addClient.ShowDialog().Value)
            {

                string name = addClient.Name.Text;
                string surname = addClient.Surname.Text;
                LibraryViewModel model = addClient.SelectedItem;

                if (model != null)
                {
                    Library library = libraryController.GetById(model.Id);
                    Client client = new Client(name, surname, library);
                    clientController.Add(client);
                    clientItems.Add(Mapper.ClientToClientViewModel(client));
                    return;
                }
            }
        }

        private void EditClientBtn_Click(object sender, RoutedEventArgs e)
        {
            ClientViewModel clientVM = dataGrid.SelectedItem as ClientViewModel;

            AddClient editClient = new AddClient(libraryItems, clientVM.Name, clientVM.SurName, libraryItems.First(i => i.Id == clientVM.LibraryId));

            if (editClient.ShowDialog().Value)
            {
                string name = editClient.Name.Text;
                string surname = editClient.Surname.Text;
                LibraryViewModel model = editClient.SelectedItem;

                if (clientVM != null && name != null && model != null)
                {
                    Client clien = clientController.GetById(clientVM.Id);
                    Library library = libraryController.GetById(model.Id);
                    clien.Name = clientVM.Name = name;
                    clientVM.LibraryId = library.Id;
                    clien.Library = library;
                    clien.Surname = clientVM.SurName = surname;
                    clientController.Edit(clien);
                }
            }
        }

        private void RemoveClientBtn_Click(object sender, RoutedEventArgs e)
        {
            InitDataSource(ref clientItems, Mapper.ClientsToClientViewModels, clientController.Get);

            ClientViewModel client = dataGrid.SelectedItem as ClientViewModel;

            if (client != null)
            {
                clientController.Remove(client.Id);
                clientItems.Remove(client);
            }
        }

        #endregion



        #region bookclient

        private void ReadBookClients()
        {
            InitDataSource(ref bookClientItems, Mapper.BookClientsToBookClientViewModels, bookClientController.Get);

            UnregisterButtonEvents();

            RegisterButtonEvents(Constants.BOOKS_CLIENTS);
        }

        private void AddBookClientBtn_Click(object sender, RoutedEventArgs e)
        {
            InitItems(ref bookClientItems, Mapper.BookClientsToBookClientViewModels, bookClientController.Get);

            AddBookClient addBookClient = new AddBookClient(
                bookItems = InitItems(ref bookItems, Mapper.BooksToBookViewModels, bookController.Get),
                clientItems = InitItems(ref clientItems, Mapper.ClientsToClientViewModels, clientController.Get)
            );

            if (addBookClient.ShowDialog().Value)
            {
                BookViewModel bookVM = addBookClient.SelectedBookItem;
                ClientViewModel clientVM = addBookClient.SelectedClientItem;
                string untilToStr = addBookClient.UntilTo.Text;

                if (bookVM != null && clientVM != null)
                {
                    Book book = bookController.GetById(bookVM.Id);
                    Client client = clientController.GetById(clientVM.Id);
                    DateTime untilTo = DateTime.Parse(untilToStr);

                    BookClient bookClient = new BookClient(book, client, untilTo);
                    bookClientController.Add(bookClient);
                    bookClientItems.Add(Mapper.BookClientToBookClientViewModel(bookClient));
                    return;
                }
            }
        }

        private void EditBookClientBtn_Click(object sender, RoutedEventArgs e)
        {
            BookClientViewModel bookClientVM = dataGrid.SelectedItem as BookClientViewModel;

            AddBookClient editBookClient = new AddBookClient(
                bookItems = InitItems(ref bookItems, Mapper.BooksToBookViewModels, bookController.Get),
                clientItems = InitItems(ref clientItems, Mapper.ClientsToClientViewModels, clientController.Get),
                bookClientVM.UntilTo,
                bookItems.First(i => i.Id == bookClientVM.BookId),
                clientItems.First(i => i.Id == bookClientVM.ClientId)
            );

            if (editBookClient.ShowDialog().Value)
            {
                BookViewModel bookVM = editBookClient.SelectedBookItem;
                ClientViewModel clientVM = editBookClient.SelectedClientItem;
                DateTime untilTo = DateTime.Parse(editBookClient.UntilTo.Text);

                if (bookVM != null && clientVM != null)
                {
                    BookClient bookClient = bookClientController.GetById(bookClientVM.Id);
                    Book book = bookController.GetById(bookVM.Id);
                    Client client = clientController.GetById(clientVM.Id);
                    bookClientVM.BookId = book.Id;
                    bookClientVM.ClientId = client.Id;
                    bookClient.Book = book;
                    bookClient.Client = client;
                    bookClient.UntilTo = bookClientVM.UntilTo = untilTo;
                    bookClientController.Edit(bookClient);
                }
            }
        }

        private void RemoveBookClientBtn_Click(object sender, RoutedEventArgs e)
        {
            InitItems(ref bookClientItems, Mapper.BookClientsToBookClientViewModels, bookClientController.Get);

            BookClientViewModel bookClient = dataGrid.SelectedItem as BookClientViewModel;

            if (bookClient != null)
            {
                bookClientController.Remove(bookClient.Id);
                bookClientItems.Remove(bookClient);
            }
        }


        #endregion



        #region bookclientarchive

        private void ReadBookClientArchives()
        {
            InitDataSource(ref bookClientArchiveItems, Mapper.BookClientArchivesToBookClientArchiveViewModels, bookClientArchiveController.Get);

            UnregisterButtonEvents();

            RegisterButtonEvents(Constants.BOOKS_CLIENTS_ARCHIVE);
        }

        private void AddBookClientArchiveBtn_Click(object sender, RoutedEventArgs e)
        {
            InitDataSource(ref bookClientArchiveItems, Mapper.BookClientArchivesToBookClientArchiveViewModels, bookClientArchiveController.Get);

            AddBookClient addBookClient = new AddBookClient(
                bookItems = InitItems(ref bookItems, Mapper.BooksToBookViewModels, bookController.Get),
                clientItems = InitItems(ref clientItems, Mapper.ClientsToClientViewModels, clientController.Get)
            );

            if (addBookClient.ShowDialog().Value)
            {
                BookViewModel bookVM = addBookClient.SelectedBookItem;
                ClientViewModel clientVM = addBookClient.SelectedClientItem;
                string untilToStr = addBookClient.UntilTo.Text;

                if (bookVM != null && clientVM != null)
                {
                    Book book = bookController.GetById(bookVM.Id);
                    Client client = clientController.GetById(clientVM.Id);
                    DateTime untilTo = DateTime.Parse(untilToStr);

                    BookClientArchive bookClientArchive = new BookClientArchive(book, client, untilTo);
                    bookClientArchiveController.Add(bookClientArchive);
                    bookClientArchiveItems.Add(Mapper.BookClientArchiveToBookClientArchiveViewModel(bookClientArchive));
                    return;
                }
            }
        }

        private void EditBookClientArchiveBtn_Click(object sender, RoutedEventArgs e)
        {
            BookClientArchiveViewModel bookClientArchiveVM = dataGrid.SelectedItem as BookClientArchiveViewModel;

            AddBookClient editBookClient = new AddBookClient(
                bookItems = InitItems(ref bookItems, Mapper.BooksToBookViewModels, bookController.Get),
                clientItems = InitItems(ref clientItems, Mapper.ClientsToClientViewModels, clientController.Get),
                bookClientArchiveVM.UntilTo,
                bookItems.First(i => i.Id == bookClientArchiveVM.BookId),
                clientItems.First(i => i.Id == bookClientArchiveVM.ClientId)
            );

            if (editBookClient.ShowDialog().Value)
            {
                BookViewModel bookVM = editBookClient.SelectedBookItem;
                ClientViewModel clientVM = editBookClient.SelectedClientItem;
                DateTime untilTo = DateTime.Parse(editBookClient.UntilTo.Text);

                if (bookVM != null && clientVM != null)
                {
                    BookClientArchive bookClientArchive = bookClientArchiveController.GetById(bookClientArchiveVM.Id);

                    Book book = bookController.GetById(bookVM.Id);
                    Client client = clientController.GetById(clientVM.Id);
                    bookClientArchiveVM.BookId = book.Id;
                    bookClientArchiveVM.ClientId = client.Id;
                    bookClientArchive.Book = book;
                    bookClientArchive.Client = client;
                    bookClientArchive.UntilTo = bookClientArchiveVM.UntilTo = untilTo;
                    bookClientArchiveController.Edit(bookClientArchive);
                }
            }
        }

        private void RemoveBookClientArchiveBtn_Click(object sender, RoutedEventArgs e)
        {
            InitDataSource(ref bookClientArchiveItems, Mapper.BookClientArchivesToBookClientArchiveViewModels, bookClientArchiveController.Get);

            BookClientArchiveViewModel bookClientArchive = dataGrid.SelectedItem as BookClientArchiveViewModel;

            if (bookClientArchive != null)
            {
                bookClientArchiveController.Remove(bookClientArchive.Id);
                bookClientArchiveItems.Remove(bookClientArchive);
            }
        }


        #endregion



        #region report

        private void ReadReports()
        {
            InitDataSource(ref reportItems, Mapper.ReportsToReportViewModels, reportController.Get);

            UnregisterButtonEvents();

            RegisterButtonEvents(Constants.REPORTS);
        }

        private void AddReportBtn_Click(object sender, RoutedEventArgs e)
        {
            InitDataSource(ref reportItems, Mapper.ReportsToReportViewModels, reportController.Get);

            AddReport addReport = new AddReport(libraryItems);
            if (addReport.ShowDialog().Value)
            {
                LibraryViewModel model = addReport.SelectedItem;

                if (model != null)
                {
                    Library library = libraryController.GetById(model.Id);
                    Report report = new Report(library);
                    report.CountClients = clientController.CountByLibraryId(library.Id);
                    report.CountSections = sectionController.CountByLibraryId(library.Id);
                    report.CountBooks = bookController.CountByLibraryId(library.Id);
                    report.CountBooksInUse = bookClientController.CountInUseByLibraryId(library.Id);
                    report.CountBooksNotInUse = report.CountBooks - report.CountBooksInUse;

                    reportController.Add(report);
                    reportItems.Add(Mapper.ReportToReportViewModel(report));
                    return;
                }
            }
        }

        private void EditReportBtn_Click(object sender, RoutedEventArgs e)
        {
            ReportViewModel reportVM = dataGrid.SelectedItem as ReportViewModel;

            AddReport editReport = new AddReport(libraryItems, libraryItems.First(i => i.Id == reportVM.LibraryId));

            if (editReport.ShowDialog().Value)
            {
                LibraryViewModel model = editReport.SelectedItem;

                if (reportVM != null && model != null)
                {
                    Report report = reportController.GetById(reportVM.Id);
                    Library library = libraryController.GetById(model.Id);
                    reportVM.LibraryId = library.Id;
                    report.Library = library;
                    report.CountClients = clientController.CountByLibraryId(library.Id);
                    report.CountSections = sectionController.CountByLibraryId(library.Id);
                    report.CountBooks = bookController.CountByLibraryId(library.Id);
                    report.CountBooksInUse = bookClientController.CountInUseByLibraryId(library.Id);
                    report.CountBooksNotInUse = report.CountBooks - report.CountBooksInUse;

                    reportController.Edit(report);
                }
            }
        }

        private void RemoveReportBtn_Click(object sender, RoutedEventArgs e)
        {
            InitDataSource(ref reportItems, Mapper.ReportsToReportViewModels, reportController.Get);

            ReportViewModel report = dataGrid.SelectedItem as ReportViewModel;

            if (report != null)
            {
                reportController.Remove(report.Id);
                reportItems.Remove(report);
            }
        }

        #endregion


        private void InitDataSource<TViewModel, TModel>(ref ObservableCollection<TViewModel> items, Func<IList<TModel>, IList<TViewModel>> Mapper, Func<IList<TModel>> controllerGet)
        {
            dataGrid.ItemsSource = InitItems(ref items, Mapper, controllerGet);
        }

        private ObservableCollection<TViewModel> InitItems<TViewModel, TModel>(ref ObservableCollection<TViewModel> items, Func<IList<TModel>, IList<TViewModel>> Mapper, Func<IList<TModel>> controllerGet)
        {
            if (items == null)
            {
                items = new ObservableCollection<TViewModel>(Mapper(controllerGet()));
            }

            return items;
        }

        private void OnSelectionChanged(object sender, EventArgs e)
        {
            nameOfCurrentTable = (currentTable.SelectedValue as ComboBoxItem).Content as string ?? Constants.LIBRARIES;

            if (printBtn != null)
            {
                printBtn.Visibility = Visibility.Hidden;
            }

            switch (nameOfCurrentTable)
            {
                case Constants.LIBRARIES:
                    ReadLibraries();
                    break;
                case Constants.SECTIONS:
                    ReadSections();
                    break;
                case Constants.AUTHORS:
                    ReadAuthors();
                    break;
                case Constants.PUBLISHERS:
                    ReadPublishers();
                    break;
                case Constants.AUTHORS_BOOKS:
                    ReadAuthorBooks();
                    break;
                case Constants.BOOKS:
                    ReadBooks();
                    break;
                case Constants.CLIENTS:
                    ReadClients();
                    break;
                case Constants.BOOKS_CLIENTS:
                    ReadBookClients();
                    break;
                case Constants.BOOKS_CLIENTS_ARCHIVE:
                    ReadBookClientArchives();
                    break;
                case Constants.USERS:
                    ReadUsers();
                    break;
                case Constants.REPORTS:
                    ReadReports();
                    printBtn.Visibility = Visibility.Visible;
                    break;
            }
        }


        private void UnregisterButtonEvents()
        {
            var addBtnHandlers = Utils.Utils.GetRoutedEventHandlers(addBtn, ButtonBase.ClickEvent);
            var editBtnHandlers = Utils.Utils.GetRoutedEventHandlers(editBtn, ButtonBase.ClickEvent);
            var removeBtnHandlers = Utils.Utils.GetRoutedEventHandlers(removeBtn, ButtonBase.ClickEvent);

            for (int i = 0; i < addBtnHandlers.Length; i++)
            {
                addBtn.Click -= (RoutedEventHandler)addBtnHandlers[i].Handler;
                editBtn.Click -= (RoutedEventHandler)editBtnHandlers[i].Handler;
                removeBtn.Click -= (RoutedEventHandler)removeBtnHandlers[i].Handler;
            }
        }

        private void RegisterButtonEvents(string table)
        {
            switch (table)
            {
                case Constants.LIBRARIES:
                    addBtn.Click += AddLibraryBtn_Click;
                    editBtn.Click += EditLibraryBtn_Click;
                    removeBtn.Click += RemoveLibraryBtn_Click;
                    break;
                case Constants.SECTIONS:
                    addBtn.Click += AddSectionBtn_Click;
                    editBtn.Click += EditSectionBtn_Click;
                    removeBtn.Click += RemoveSectionBtn_Click;
                    break;
                case Constants.AUTHORS:
                    addBtn.Click += AddAuthorBtn_Click;
                    editBtn.Click += EditAuthorBtn_Click;
                    removeBtn.Click += RemoveAuthorBtn_Click;
                    break;
                case Constants.PUBLISHERS:
                    addBtn.Click += AddPublisherBtn_Click;
                    editBtn.Click += EditPublisherBtn_Click;
                    removeBtn.Click += RemovePublisherBtn_Click;
                    break;
                case Constants.AUTHORS_BOOKS:
                    addBtn.Click += AddAuthorBookBtn_Click;
                    editBtn.Click += EditAuthorBookBtn_Click;
                    removeBtn.Click += RemoveAuthorBookBtn_Click;
                    break;
                case Constants.BOOKS:
                    addBtn.Click += AddBookBtn_Click;
                    editBtn.Click += EditBookBtn_Click;
                    removeBtn.Click += RemoveBookBtn_Click;
                    break;
                case Constants.CLIENTS:
                    addBtn.Click += AddClientBtn_Click;
                    editBtn.Click += EditClientBtn_Click;
                    removeBtn.Click += RemoveClientBtn_Click;
                    break;
                case Constants.BOOKS_CLIENTS:
                    addBtn.Click += AddBookClientBtn_Click;
                    editBtn.Click += EditBookClientBtn_Click;
                    removeBtn.Click += RemoveBookClientBtn_Click;
                    break;
                case Constants.BOOKS_CLIENTS_ARCHIVE:
                    addBtn.Click += AddBookClientArchiveBtn_Click;
                    editBtn.Click += EditBookClientArchiveBtn_Click;
                    removeBtn.Click += RemoveBookClientArchiveBtn_Click;
                    break;
                case Constants.USERS:
                    addBtn.Click += AddUserBtn_Click;
                    editBtn.Click += EditUserBtn_Click;
                    removeBtn.Click += RemoveUserBtn_Click;
                    break;
                case Constants.REPORTS:
                    addBtn.Click += AddReportBtn_Click;
                    editBtn.Click += EditReportBtn_Click;
                    removeBtn.Click += RemoveReportBtn_Click;
                    break;

            }
        }

        private void OnPrintBtn_Click(object sender, RoutedEventArgs e)
        {
            ReportViewModel reportVM = dataGrid.SelectedItem as ReportViewModel;
            PrintDialog printDialog = new PrintDialog();

            if (reportVM != null)
            {
                StringBuilder contentOfTemplate = new StringBuilder(System.IO.File.ReadAllText(Constants.REPORT_VIEW_MODEL_TEMPLATE_PATH));

                Library library = libraryController.GetById(reportVM.LibraryId);

                contentOfTemplate
                    .Replace(Constants.ToTemplateVar(Constants.CREATED_ON), reportVM.CreatedOn.ToString())
                    .Replace(Constants.ToTemplateVar(Constants.LIBRARY_NAME), library.Name)
                    .Replace(Constants.ToTemplateVar(Constants.ID), reportVM.Id.ToString())
                    .Replace(Constants.ToTemplateVar(Constants.COUNT_CLIENTS), reportVM.CountClients.ToString())
                    .Replace(Constants.ToTemplateVar(Constants.COUNT_SECTIONS), reportVM.CountSections.ToString())
                    .Replace(Constants.ToTemplateVar(Constants.COUNT_BOOKS), reportVM.CountBooks.ToString())
                    .Replace(Constants.ToTemplateVar(Constants.COUNT_BOOKS_IN_USE), reportVM.CountBooksInUse.ToString())
                    .Replace(Constants.ToTemplateVar(Constants.COUNT_BOOKS_NOT_IN_USE), reportVM.CountBooksNotInUse.ToString());

                FlowDocument doc = new FlowDocument(new Paragraph(new Run(contentOfTemplate.ToString())));


                printDialog.PrintDocument(((IDocumentPaginatorSource) doc).DocumentPaginator, "The document is being printing...");
            }
            else
            {
                printDialog.PrintVisual(dataGrid, "The document is being printing...");
            }
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            SearchPredicate.searchPredicate = search.Text;

            switch (nameOfCurrentTable)
            {
                case Constants.LIBRARIES:
                    dataGrid.ItemsSource = libraryItems
                        .Where(LibraryViewModel.GetSearchPredicate);
                    break;
                case Constants.SECTIONS:
                    dataGrid.ItemsSource = sectionItems
                        .Where(SectionViewModel.GetSearchPredicate);
                    break;
                case Constants.AUTHORS:
                    dataGrid.ItemsSource = authorItems
                        .Where(AuthorViewModel.GetSearchPredicate);
                    break;
                case Constants.PUBLISHERS:
                    dataGrid.ItemsSource = authorItems
                        .Where(AuthorViewModel.GetSearchPredicate);
                    break;
                case Constants.AUTHORS_BOOKS:
                    dataGrid.ItemsSource = authorBookItems
                        .Where(AuthorBookViewModel.GetSearchPredicate);
                    break;
                case Constants.BOOKS:
                    dataGrid.ItemsSource = bookItems
                        .Where(BookViewModel.GetSearchPredicate);
                    break;
                case Constants.CLIENTS:
                    dataGrid.ItemsSource = clientItems
                        .Where(ClientViewModel.GetSearchPredicate);
                    break;
                case Constants.BOOKS_CLIENTS:
                    dataGrid.ItemsSource = bookClientItems
                        .Where(BookClientViewModel.GetSearchPredicate);
                    break;
                case Constants.BOOKS_CLIENTS_ARCHIVE:
                    dataGrid.ItemsSource = bookClientArchiveItems
                        .Where(BookClientArchiveViewModel.GetSearchPredicate);
                    break;
                case Constants.USERS:
                    dataGrid.ItemsSource = userItems
                        .Where(UserViewModel.GetSearchPredicate);
                    break;
                case Constants.REPORTS:
                    dataGrid.ItemsSource = reportItems
                       .Where(ReportViewModel.GetSearchPredicate);
                    break;

            }
        }

        private void AuthForm()
        {
            Login login = new Login();

            if (!login.ShowDialog().Value)
            {
                throw new Exception("Authorized exception has been occured.");
            }

            authProvider = login.AuthProvider;
        }

        private void SetRights()
        {
            foreach (object item in currentTable.Items)
            {
                ComboBoxItem boxItem = item as ComboBoxItem;

                if ((string)boxItem.Content == Constants.USERS)
                {
                    boxItem.Visibility = 
                        authProvider.UserRole == Role.Admin ?
                        Visibility.Visible : Visibility.Collapsed;
                }
            }
        }

        private void LogoutBtn_Click(object sender, RoutedEventArgs e)
        {
            Visibility = Visibility.Collapsed;

            AuthForm();
            SetRights();

            Visibility = Visibility.Visible;
        }
    }
}
