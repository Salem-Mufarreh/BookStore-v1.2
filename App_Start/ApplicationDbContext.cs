using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BookStore.App_Start
{
    public class ApplicationDbContext :DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Cart_Item> Carts_Items { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Shoping_Session> Shoping_Sessions { get; set; }
    }
}