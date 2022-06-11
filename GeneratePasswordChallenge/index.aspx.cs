using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication4
{
    public partial class index : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void Button_Click(object sender, EventArgs e)
        {
            Random rand1 = new Random();
            int len = rand1.Next(6, 12);
            const string ValidChar = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            StringBuilder result = new StringBuilder();
            Random rand2 = new Random();
            var btn = (Button)sender;

            if (TextBox1.Text == "" || TextBox1.Text == "Enter User!!!")
            {

                TextBox1.Text = "Enter User!!!";
            }
            else
            {
                while (0 < len--)
                {
                    result.Append(ValidChar[rand2.Next(ValidChar.Length)]);
                }
                l1.Text = result.ToString();
                this.LTimer.Text = "Password valid for 30 seconds ";

                if (Session["InputTime"] == null)
                {
                    Session["InputTime"] = "";
                }

                var newTime = Session["InputTime"].ToString() + "30";

                Session["InputTime"] = newTime;

                var currentTimeMinutes = (newTime.Length > 2) ?
                    int.Parse(newTime.Substring(0, newTime.Length - 2)) :
                    0;

                var currentTimeSeconds = (newTime.Length > 2) ?
                    int.Parse(newTime.Substring(newTime.Length - 2)) :
                int.Parse(newTime);

                Session["MinutesLeft"] = currentTimeMinutes;
                Session["SecondsLeft"] = currentTimeSeconds;

                DisplayTextMinutes.Text = String.Format("{0:00}", currentTimeMinutes);
                DisplayTextSeconds.Text = String.Format("{0:00}", currentTimeSeconds);
            }


            Timer.Enabled = true;
            Session["InputTime"] = null;
            Session["testing"] = "SomeValue";
            Session["MinutesLeft"] = 0;
            Session["SecondsLeft"] = 30;

        }

        protected void Timer_Tick(object sender, EventArgs e)
        {
            var currentTimeMinutes = int.Parse(Session["MinutesLeft"].ToString());
            var currentTimeSeconds = int.Parse(Session["SecondsLeft"].ToString());

            currentTimeSeconds--;
            if (currentTimeSeconds == 0 && currentTimeMinutes == 0)
            {
                Timer.Enabled = false;
            }
            else if (currentTimeSeconds < 0)
            {
                currentTimeMinutes--;
                currentTimeSeconds = 59;
            }

            DisplayTextMinutes.Text = String.Format("{0:00}", currentTimeMinutes);
            DisplayTextSeconds.Text = String.Format("{0:00}", currentTimeSeconds);
            Session["MinutesLeft"] = currentTimeMinutes;
            Session["SecondsLeft"] = currentTimeSeconds;
            l1.Text = "Expired password!!!";
            this.LTimer.Text = "Password invalid after 30 seconds!!!";
        }
    }
}