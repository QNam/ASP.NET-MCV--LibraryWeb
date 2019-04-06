using LibraryWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryWeb.Lib
{
    public class Common
    {
        libraryEntities entities = new libraryEntities();

        public int quantityOfAuthors()
        {
            return entities.authors.Count();
        }

        public int quantityOfBooks()
        {
            return entities.books.Count();
        }

        public int quantityOfVendor()
        {
            return entities.vendors.Count();
        }

        public int quantityOfCategories()
        {
            return entities.categories.Count();
        }

        public int quantityOfOrders()
        {
            return entities.orders.Count();
        }

    }
}