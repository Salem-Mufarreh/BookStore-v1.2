using BookStore.App_Start;
using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookStore
{
    public partial class Cart : System.Web.UI.Page
    {
        protected readonly ApplicationDbContext dbContext = new ApplicationDbContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInUser loggedIn = (LoggedInUser)Session["LoggedInUser"];
            List<Cart_Item> carts = dbContext.Carts_Items.Where(x => x.Id == loggedIn.Id).ToList();
            Repeater1.DataSource= carts;
            Repeater1.DataBind();
        }
    }
}