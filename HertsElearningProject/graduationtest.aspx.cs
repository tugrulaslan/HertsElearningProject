using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HertsElearningProject
{
    public partial class graduationtest : System.Web.UI.Page
    {
        protected void timer1_tick(object sender, EventArgs e)
        {
            if (0 > DateTime.Compare(DateTime.Now,
            DateTime.Parse(Session["timeout"].ToString())))
            {
                lblTimer.Text = "Number of Minutes Left: " +
                ((Int32)DateTime.Parse(Session["timeout"].
                ToString()).Subtract(DateTime.Now).TotalMinutes).ToString();
            }
        }  
        public void saveDB(String username, String question, String answer, String studentAnswer, String correct)
        {
            var conn = ConfigurationManager.ConnectionStrings["HertsOnlineEntities"].ConnectionString;
           
            SqlConnection objsqlconn = new SqlConnection(conn);
            objsqlconn.Open();
            SqlCommand objcmd = new SqlCommand("insert into [dbta13aby].[dbo].[StudentExam] ([StudentName],[Question],[Answer],[StudentAnswer],[Correct]) VALUES('" + username + "','" + question + "','" + answer + "','" + studentAnswer + "','" + correct + "')", objsqlconn);
            objcmd.ExecuteNonQuery();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            String userName = HttpContext.Current.Request["userName"].ToString();

            if (userName.Equals("") || userName == null)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Close", "window.close()", true);
            }

            if (!SM1.IsInAsyncPostBack)
                Session["timeout"] = DateTime.Now.AddMinutes(120).ToString();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String userName = HttpContext.Current.Request["userName"].ToString();
            if (userName.Equals("") || userName == null)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You are not authorized!')", true);
            }
            //check question 1
            if(RadioButtonList1.SelectedValue.Equals(""))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You have not answered Q1!')", true);
            }

            //check question 2
            if (RadioButtonList2.SelectedValue.Equals(""))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You have not answered Q2!')", true);
            }

            //check question 3
            if (RadioButtonList3.SelectedValue.Equals(""))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You have not answered Q3!')", true);
            }

            //check question 4
            if (RadioButtonList4.SelectedValue.Equals(""))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You have not answered Q4!')", true);
            }

            //check question 4
            if (RadioButtonList5.SelectedValue.Equals(""))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You have not answered Q5!')", true);
            }

           

            //Answers
            String q1 = "ASPX";
            String q2 = "WINDOWS";
            String q3 = "MSACCESS";
            String q4 = "VS";
            String q5 = ".NET";

            //StudentAnswers
            String q1a = RadioButtonList1.SelectedValue.ToString();
            String q2a = RadioButtonList2.SelectedValue.ToString();
            String q3a = RadioButtonList3.SelectedValue.ToString();
            String q4a = RadioButtonList4.SelectedValue.ToString();
            String q5a = RadioButtonList5.SelectedValue.ToString();

            //StudentAnswerResults
            String q1sa = "";
            String q2sa = "";
            String q3sa = "";
            String q4sa = "";
            String q5sa = "";

            //Check answers
            if (q1.Equals(q1a))
            {
                q1sa = "Correct";
            }
            else
            {
                q1sa = "Incorrect";
            }

            if (q2.Equals(q2a))
            {
                q2sa = "Correct";
            }
            else
            {
                q2sa = "Incorrect";
            }

            if (q3.Equals(q3a))
            {
                q3sa = "Correct";
            }
            else
            {
                q3sa = "Incorrect";
            }

            if (q4.Equals(q4a))
            {
                q4sa = "Correct";
            }
            else
            {
                q4sa = "Incorrect";
            }

            if (q5.Equals(q5a))
            {
                q5sa = "Correct";
            }
            else
            {
                q5sa = "Incorrect";
            }

           //insert data to db
           //q1
           saveDB(userName, "1", q1 ,q1a, q1sa);
           //q2
           saveDB(userName, "2", q2, q2a, q2sa);
           //q3
           saveDB(userName, "3", q3, q3a, q3sa);
           //q4
           saveDB(userName, "4", q4, q4a, q4sa);
           //q5
           saveDB(userName, "5", q5, q5a, q5sa);

           ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You have successfully finished the test!')", true);
           ClientScript.RegisterClientScriptBlock(this.GetType(), "Close", "window.close()", true);
        }
    }
}