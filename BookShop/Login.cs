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
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
            {
                DataSource = @"(LocalDB)\MSSQLLocalDB",
                AttachDBFilename = Bookstore.path,
                IntegratedSecurity = true
            };
            IDbConnection connection = new SqlConnection(builder.ConnectionString);
            connection.Open();

            string query = "select login,password from registry";
            IDbCommand command = new SqlCommand(query);
            command.Connection = connection;
            IDataReader reader = command.ExecuteReader();
            string[] log =new string[10];
            string[] pas = new string[10];
            byte a = 0;
            while (reader.Read())
            {
                object login = reader.GetValue(0);
                object pass = reader.GetValue(1);
                log[a] = login.ToString();
                pas[a] = pass.ToString();
                a++;
            }
            reader.Close();
            command.Dispose();
            connection.Close();
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
