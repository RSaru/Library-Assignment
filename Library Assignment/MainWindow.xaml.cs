using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Xml;
namespace Library_Assignment
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            InitializeComponent();
            //Creates an empty data set to recieve the xml data
            DataSet dataSet = new DataSet();
            //Reads the XML file into the data set
            dataSet.ReadXml(@"Books.xml");
            //Sets the data source for the data grid to the data set
            dgBooks.ItemsSource = dataSet.Tables[0].DefaultView;


        }

        private void dgBooks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Displays the clicked item as a text box over the data grid
            DataRowView row = dgBooks.SelectedItem as DataRowView;
            //Blue row is the making of that "variable", can be named whatever
            MessageBox.Show(row.Row.ItemArray[0].ToString());
            txtTitle.Text = row.Row.ItemArray[0].ToString();
            txtAuthor.Text = row.Row.ItemArray[1].ToString();
            txtYear.Text = row.Row.ItemArray[2].ToString();
            txtPublisher.Text = row.Row.ItemArray[3].ToString();
            txtIsbn.Text = row.Row.ItemArray[4].ToString();
            txtCategory.Text = row.Row.ItemArray[5].ToString();

        }

        private void btnRecordAdd_Click(object sender, RoutedEventArgs e)
        {
            xmlController xmlC = new xmlController();

            Book newBook = new Book();
            newBook.title = txtTitle.Text;
            newBook.author = txtAuthor.Text;
            newBook.year = txtYear.Text;
            newBook.publisher = txtPublisher.Text;
            newBook.isbn = txtIsbn.Text;
            newBook.category = txtCategory.Text;
            xmlC.addRecord(newBook);
            MessageBox.Show("Record Added");
        }

        private void btnLeave_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            LogIn logInPage = new LogIn();
            logInPage.Show();
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow mainW = new MainWindow();
            mainW.Show();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            xmlController xmlC = new xmlController();
            Book newBook = new Book();
            newBook.title = txtTitle.Text;
            newBook.author = txtAuthor.Text;
            newBook.year = txtYear.Text;
            newBook.publisher = txtPublisher.Text;
            newBook.isbn = txtIsbn.Text;
            newBook.category = txtCategory.Text;
            xmlC.updateVideo(txtTitle.Text, newBook);
            MessageBox.Show("Record Updated");
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            xmlController xmlC = new xmlController(); 
            xmlC.deleteBook(txtTitle.Text);
            MessageBox.Show("Record deleted");
        }
    }
}
