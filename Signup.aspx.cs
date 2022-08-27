using BookStore.App_Start;
using System;
using BookStore.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookStore
{
    public partial class Signup : System.Web.UI.Page
    {
        protected readonly ApplicationDbContext dbContext = new ApplicationDbContext();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void signup_btn_Click(object sender, EventArgs e)
        {
            if (IsvalidUser(email_txt.Text))
            {
                User user = new User();
                user.Email = email_txt.Text;
                user.Name = name_txt.Text;
                user.Address = address_txt.Text;
                user.PhoneNumber = phoneNumber_txt.Text;
                user.password = password_txt.Text;
                user.Role = SD.Customer;
                user.Active = SD.UnLocked;

                try
                {
                    dbContext.Users.Add(user);
                    dbContext.SaveChanges();
                    
                    ToastrNotifications toastr = new ToastrNotifications("Entery was Successfull","success");
                    Session["Message"] = toastr;
                }
                catch (Exception)
                {

                    throw;
                }
                name_txt.Text = String.Empty;
                email_txt.Text = String.Empty;
                address_txt.Text = String.Empty;
                phoneNumber_txt.Text = String.Empty;
                password_txt.Text = String.Empty;
                Response.Redirect(nameof(Login));

            }
            else
            {
                name_txt.Text = String.Empty;
                email_txt.Text = String.Empty;
                address_txt.Text = String.Empty;
                phoneNumber_txt.Text = String.Empty;
                password_txt.Text = String.Empty;
                ToastrNotifications toastr = new ToastrNotifications("Email Already Exits", "error");
                Session["Message"] = toastr;
            }

        }

        private bool IsvalidUser(string userName)
        {
            BookStore.Models.User user = dbContext.Users.Where(x => x.Email == userName).FirstOrDefault();
            return user == null;
            
        }
    }
}