using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BookShop
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            LoginBox.Select();// AutoFocus on Login
        }

        private void LoginSubmit_Click(object sender, EventArgs e)
        {            
            if ((LoginBox.Text.Trim() == string.Empty)||(PasswordBox.Text.Trim() == string.Empty))
            {
                MessageBox.Show("Please Enter Login and Password");
                return;
            }

            string[] log = new string[10];
            string[] pas = new string[10];
            string query = "select login,password from registry";
            string[] mess = Bookstore.Send(query);

            for (int i = 0; i < mess.Length; i++)
            {

                mess[i]=mess[i].Remove(mess[i].LastIndexOf(','), 1);
                log[i] = mess[i].Substring(0, mess[i].IndexOf(','));
                pas[i] = mess[i].Substring((mess[i].IndexOf(',')+1));
            }
            byte a;

            for (a=0; a < log.Length; a++)
            {
                if ((LoginBox.Text.Trim()==log[a])&& (PasswordBox.Text.Trim() == pas[a])){goto Success;}
            }
            MessageBox.Show("Incorrect Login/Password");
            return;
            Success:
            MessageBox.Show("You are logged in");
            Bookstore.loguser = log[a].ToString();
            Bookstore bookstore = this.Owner as Bookstore;
            bookstore.LogStatusChange();
            Close();
            return;
        }
    }
}
