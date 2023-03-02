using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Library_Assignment
{
    class xmlController
    {
        string path = "Books.xml";

        public void addRecord(Book newBook)
        {
            //Creates a new xml document and loads the data to it
            XmlDocument doc = new XmlDocument();
            doc.Load(path);

            //All 3 chunks below this allows the user to add records to the file
            XmlNode ROOT = doc.SelectSingleNode("/library");
            XmlNode Book = doc.CreateElement("book");
            XmlNode Title = doc.CreateElement("title");
            XmlNode Author = doc.CreateElement("author");
            XmlNode Year = doc.CreateElement("year");
            XmlNode Publisher = doc.CreateElement("publisher");
            XmlNode Isbn = doc.CreateElement("isbn");
            XmlNode Category = doc.CreateElement("category");

            Title.InnerText = newBook.title;
            Author.InnerText = newBook.author;
            Year.InnerText = newBook.year;
            Publisher.InnerText = newBook.publisher;
            Isbn.InnerText = newBook.isbn.ToString();
            Category.InnerText = newBook.category;

            Book.AppendChild(Title);
            Book.AppendChild(Author);
            Book.AppendChild(Year);
            Book.AppendChild(Publisher);
            Book.AppendChild(Isbn);
            Book.AppendChild(Category);

            ROOT.AppendChild(Book);
            doc.Save(path);
        }

        public void updateVideo(string title, Book newBook)
        {
            string path = "Books.xml";

            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlNode oldBook = doc.SelectSingleNode("//book[title='" + title + "']");
            oldBook.ChildNodes.Item(0).InnerText = newBook.title;
            oldBook.ChildNodes.Item(1).InnerText = newBook.author;
            oldBook.ChildNodes.Item(2).InnerText = newBook.year;
            oldBook.ChildNodes.Item(3).InnerText = newBook.publisher;
            oldBook.ChildNodes.Item(4).InnerText = newBook.isbn;
            oldBook.ChildNodes.Item(5).InnerText = newBook.category;
            doc.Save(path);
        }

        public void deleteBook(string title)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlNode nodes = doc.SelectSingleNode("//book[title='" + title + "']");
            nodes.ParentNode.RemoveChild(nodes);
            doc.Save(path);
        }
    }
}
