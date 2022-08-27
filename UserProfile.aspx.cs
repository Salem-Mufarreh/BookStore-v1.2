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
    public partial class UserProfile : System.Web.UI.Page
    {
        protected readonly ApplicationDbContext dbContext = new ApplicationDbContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoggedInUser user = (LoggedInUser)Session["LoggedInUser"];

                if (user != null)
                {

                    name_txt.Text = user.UserName;
                    email_txt.Text = user.Email;
                    phone_txt.Text = user.phoneNumber;
                    address_txt.Text = user.Address;
                }
                else
                {
                    ToastrNotifications notifications = new ToastrNotifications();
                    notifications.Message = " Please Log In to enter your Profile ";
                    notifications.Type = "error";
                    Session.Add("Message", notifications);
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            name_txt.ReadOnly = false;
            phone_txt.ReadOnly = false;
            address_txt.ReadOnly = false;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            User user = dbContext.Users.Where(x=> x.Email == email_txt.Text).FirstOrDefault();
            LoggedInUser loggedIn = new LoggedInUser();
            user.Name = name_txt.Text;
            loggedIn.UserName = name_txt.Text;
            user.PhoneNumber = phone_txt.Text;
            loggedIn.phoneNumber = phone_txt.Text;
            user.Address = address_txt.Text;
            loggedIn.Address=address_txt.Text;
            loggedIn.Email=email_txt.Text;

            try
            {
                dbContext.SaveChanges();
                Session.Add("LoggedInUser", loggedIn);
                ToastrNotifications toastrNotifications = new ToastrNotifications("Update was succesffull","success");
                Session["Message"] = toastrNotifications;
            }
            catch (Exception)
            {

                throw;
            }
            name_txt.ReadOnly = true;
            email_txt.ReadOnly = true;
            phone_txt.ReadOnly = true;
            address_txt.ReadOnly = true;
        }
    }
}