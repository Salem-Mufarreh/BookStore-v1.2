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
    public partial class Users : System.Web.UI.Page
    {
        protected readonly ApplicationDbContext dbContext = new ApplicationDbContext();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Lock_Click(object sender, EventArgs e)
        {

        }

        protected void Unlock_Click(object sender, EventArgs e)
        {

        }

        protected void UserGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Button Lock = (Button)(e.Row.FindControl("Lock"));
                Button UnLock = (Button)(e.Row.FindControl("Unlock"));
                if (e.Row.Cells[7].Text == SD.UnLocked)
                {
                    UnLock.Visible = false;
                }
                else
                {
                    Lock.Visible = false;
                }
            }
        }
    }
}