using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.IO;


namespace BookShop
{
    public partial class Bookstore : Form
    {
        //Global variables
        public static string loguser;//Login
        public string[] PickedBooksName = { }; //Bookname for chosen books
        public int[] PickedBooksAmount = { };//Bookcount for chosen books
        public string[] PickedBooksOrder = new string[1];//All chosen books
        public static string path = Path.GetFullPath(@".\Data\base-bookstore.mdf");
        public Bookstore()
        {
            InitializeComponent();
        }
        public void LogStatusChange()// Пользователь вошёл и с Login.cs выполняется эта функция
        {
            LoginStatus.Text = "You are logged in as "+loguser;
            FileMenuLogin.Text = "Change Login";
            OrderMenuMake.Enabled = true;
            OrderMenuMyOrders.Enabled = true;
        }
        private void Bookstore_Load(object sender, EventArgs e)
        {
            // Заголовок для Корзины
            PickedBooksOrder[0]= "Id \t Book \t \t Amount \n";
            PickedOrder.Text = PickedBooksOrder[0];

            // Соединение с базой и наполнение селектов
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
            {
                DataSource = @"(LocalDB)\MSSQLLocalDB",
                AttachDBFilename = path,
                IntegratedSecurity = true
            };
            IDbConnection connection = new SqlConnection(builder.ConnectionString);
            connection.Open();

            string query = "select book_name from book";
            IDbCommand command = new SqlCommand(query);
            command.Connection = connection;
            IDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                object book = reader.GetValue(0);
                BookSelector.Items.Add(book);
            }
            reader.Close();

            query = "select author_name from authors";
            command = new SqlCommand(query);
            command.Connection = connection;
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                object obj = reader.GetValue(0);
                AuthorBookSelector.Items.Add(obj);
            }
            reader.Close();
            
            query = "select genre_name from genres";
            command = new SqlCommand(query);
            command.Connection = connection;
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                object obj = reader.GetValue(0);
                GenreBookSelector.Items.Add(obj);
            }
            reader.Close();
            
            query = "select publisher_name from publishers";
            command = new SqlCommand(query);
            command.Connection = connection;
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                object obj = reader.GetValue(0);
                PublisherBookSelector.Items.Add(obj);
            }
            reader.Close();

            command.Dispose();
            connection.Close();
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)// При нажатии на Логин в Меню File->Login
        {
            Login LoginSequence = new Login
            {
                Owner = this
            };
            LoginSequence.Show();
        }

        private void AuthorBookSelector_SelectedValueChanged(object sender, EventArgs e)//№1 При выборе в меню Автора. Таких методов будет ещё 2 и работают они одинаково
        {
            //Очищается заголовок вывода книжнки по категории
            CategoryBookSelector.Items.Clear();
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
            {
                DataSource = @"(LocalDB)\MSSQLLocalDB",
                AttachDBFilename = path,
                IntegratedSecurity = true
            };
            IDbConnection connection = new SqlConnection(builder.ConnectionString);
            connection.Open();

            SqlParameter sqlParameter = new SqlParameter("@aut", SqlDbType.VarChar, 255)
            {
                Value = AuthorBookSelector.SelectedItem.ToString()
            };
            IDbCommand command = new SqlCommand("authorp");
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = connection;
            command.Parameters.Add(sqlParameter);
            command.Prepare();
            IDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                object book = reader.GetValue(0);
                CategoryBookSelector.Items.Add(book);
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            GenreBookSelector.Text = "";
            PublisherBookSelector.Text = "";
        }

        private void GenreBookSelector_SelectedValueChanged(object sender, EventArgs e)// №2
        {
            CategoryBookSelector.Items.Clear();
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
            {
                DataSource = @"(LocalDB)\MSSQLLocalDB",
                AttachDBFilename = path,
                IntegratedSecurity = true
            };
            IDbConnection connection = new SqlConnection(builder.ConnectionString);
            connection.Open();

            SqlParameter sqlParameter = new SqlParameter("@gen", SqlDbType.VarChar, 255)
            {
                Value = GenreBookSelector.SelectedItem.ToString()
            };
            IDbCommand command = new SqlCommand("genrep");
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = connection;
            command.Parameters.Add(sqlParameter);
            command.Prepare();
            IDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                object book = reader.GetValue(0);
                CategoryBookSelector.Items.Add(book);
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            AuthorBookSelector.Text = "";
            PublisherBookSelector.Text = "";
        }

        private void PublisherBookSelector_SelectedValueChanged(object sender, EventArgs e)//№3
        {
            CategoryBookSelector.Items.Clear();
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
            {
                DataSource = @"(LocalDB)\MSSQLLocalDB",
                AttachDBFilename = path,
                IntegratedSecurity = true
            };
            IDbConnection connection = new SqlConnection(builder.ConnectionString);
            connection.Open();

            SqlParameter sqlParameter = new SqlParameter("@pub", SqlDbType.VarChar, 255)
            {
                Value = PublisherBookSelector.SelectedItem.ToString()
            };
            IDbCommand command = new SqlCommand("publishp");
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = connection;
            command.Parameters.Add(sqlParameter);
            command.Prepare();
            IDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                object book = reader.GetValue(0);
                CategoryBookSelector.Items.Add(book);
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            GenreBookSelector.Text = "";
            AuthorBookSelector.Text = "";
        }

        private void FileMenuExit_Click(object sender, EventArgs e)//Выход
        {
            Close();
        }

        private void SubmitBook_Click(object sender, EventArgs e)//Добавление в Корзину книг
        {
            if (AmountBox.Text != "")
            {
                if ((Convert.ToInt32(AmountBox.Text) != Convert.ToDouble(AmountBox.Text)) || (Convert.ToInt32(AmountBox.Text) <= 0))
                {
                    MessageBox.Show("The Amount of Books must be a Natural Number");
                    return;
                }
            }
            else
            {
                MessageBox.Show("The Amount of Books must be filled");
                return;
            }
            if(BookSelector.SelectedIndex>-1)
            {
                // Каждый раз когда добавляется новая книга в массив, последний расширяется
                //Заносятся в глобальные массивы данные, плюс в селектор удаления книги
                Array.Resize(ref PickedBooksAmount, PickedBooksAmount.Length + 1);
                Array.Resize(ref PickedBooksName, PickedBooksName.Length + 1);
                Array.Resize(ref PickedBooksOrder, PickedBooksOrder.Length + 1);
                PickedBooksName[PickedBooksName.Length - 1] = BookSelector.SelectedItem.ToString();
                BookSelector.Text = "";
                PickedBooksAmount[PickedBooksAmount.Length - 1] = Convert.ToInt32(AmountBox.Text.ToString());
                AmountBox.Text = "";
                PickedBooksOrder[PickedBooksName.Length] = (PickedBooksName.Length - 1) + " " + PickedBooksName[PickedBooksName.Length - 1] + " " + PickedBooksAmount[PickedBooksAmount.Length - 1] + "\n";
                PickedOrder.Text += PickedBooksOrder[PickedBooksName.Length];
                DeletePicked.Items.Add(PickedBooksName.Length - 1);
            }
            else
            {
                if (CategoryBookSelector.SelectedIndex>-1)
                {
                    // Тоже самое что и выше только при добавлении не из обычного, а от категории
                    Array.Resize(ref PickedBooksAmount, PickedBooksAmount.Length + 1);
                    Array.Resize(ref PickedBooksName, PickedBooksName.Length + 1);
                    Array.Resize(ref PickedBooksOrder, PickedBooksOrder.Length + 1);
                    PickedBooksName[PickedBooksName.Length - 1] = CategoryBookSelector.SelectedItem.ToString();
                    CategoryBookSelector.Text = "";
                    PickedBooksAmount[PickedBooksAmount.Length - 1] = Convert.ToInt32(AmountBox.Text.ToString());
                    AmountBox.Text = "";
                    PickedBooksOrder[PickedBooksName.Length] = (PickedBooksName.Length - 1) + " " + PickedBooksName[PickedBooksName.Length - 1] + " " + PickedBooksAmount[PickedBooksAmount.Length - 1] + "\n";
                    PickedOrder.Text += PickedBooksOrder[PickedBooksName.Length];
                    DeletePicked.Items.Add(PickedBooksName.Length - 1);
                }
                else
                {
                    MessageBox.Show("You must choose a book to add to order");
                    return;
                }
            }
        }

        private void OrderMenuMake_Click(object sender, EventArgs e)//Нажатие на меню Orders->Make Order
        {
            BookChoicePanel.Visible = true;
            PickedBooksPanel.Visible = true;
        }

        private void OrderMenuMyOrders_Click(object sender, EventArgs e)//Нажатие на меню Orders->My Orders
        {
            //Кроме отрисовки панели, загружаются данные в DataGridView
            MyOrdersPanel.Visible = true;
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
            {
                DataSource = @"(LocalDB)\MSSQLLocalDB",
                AttachDBFilename = path,
                IntegratedSecurity = true
            };
            SqlConnection connection = new SqlConnection(builder.ConnectionString);
            connection.Open();
            SqlParameter sqlParameter = new SqlParameter("@usr", SqlDbType.VarChar, 255){
                Value = loguser
            };
            SqlCommand command = new SqlCommand("user_orders");           
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = connection;
            command.Parameters.Add(sqlParameter);
            command.Prepare();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            MyOrdersDGV.DataSource = table;
            command.Dispose();
            connection.Close();
        }

        private void SubmitOrder_Click(object sender, EventArgs e){
            //Пробелы в массивах убираются в конец 
            PickedBooksName = PickedBooksName.Where(x => x != null).ToArray();
            PickedBooksAmount = PickedBooksAmount.Where(x => x != 0).ToArray();

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder{
                DataSource = @"(LocalDB)\MSSQLLocalDB",
                AttachDBFilename = path,
                IntegratedSecurity = true
            };

            IDbConnection connection = new SqlConnection(builder.ConnectionString);
            connection.Open();

            SqlParameter sqlParameter = new SqlParameter("@log", SqlDbType.VarChar, 255){
                Value = loguser
            };
            IDbCommand command = new SqlCommand("InsOrd");
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = connection;
            command.Parameters.Add(sqlParameter);
            command.Prepare();
            // В сущность order вставляется заказ
            command.ExecuteNonQuery();
            SqlParameter parameter;
            // Затем в сущность shopping cart вставляются все выбранные книжки
            for(int i=0;i<PickedBooksAmount.Length;i++){
                sqlParameter = new SqlParameter("@quan", SqlDbType.VarChar, 255);
                sqlParameter.Value = PickedBooksAmount[i];
                parameter =  new SqlParameter("@bok", SqlDbType.VarChar, 255);
                parameter.Value = PickedBooksName[i];
                command = new SqlCommand("InsShop");
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = connection;
                command.Parameters.Add(sqlParameter);
                command.Parameters.Add(parameter);
                command.Prepare();
                command.ExecuteNonQuery();
            }
           // Очищение использованных ресурсов и вывод всех предыдущих заказов
            command.Dispose();
            connection.Close();
            MessageBox.Show("Order Accepted");
            Array.Clear(PickedBooksName, 0, PickedBooksName.Length);
            Array.Clear(PickedBooksAmount, 0, PickedBooksAmount.Length);
            Array.Clear(PickedBooksOrder, 0, PickedBooksOrder.Length);
            PickedBooksOrder[0] = "Id \t Book \t \t Amount \n";
            PickedOrder.Text = PickedBooksOrder[0];
            OrderMenuMyOrders_Click(sender,e);
        }

        private void DeletePickedSubmit_Click(object sender, EventArgs e)// Удаление из корзины выбранного в селекте заказа
        {
            if(DeletePicked.SelectedIndex>-1){
                PickedBooksOrder[Convert.ToInt32(DeletePicked.SelectedItem) + 1] = "";
                PickedOrder.Text = "";
                Array.Clear(PickedBooksName, Convert.ToInt32(DeletePicked.SelectedItem), 1);
                Array.Clear(PickedBooksAmount, Convert.ToInt32(DeletePicked.SelectedItem), 1);
                for(int i=0;i<PickedBooksOrder.Length;i++){
                    PickedOrder.Text += PickedBooksOrder[i];
                }
                DeletePicked.Items.Remove(Convert.ToInt32(DeletePicked.SelectedItem));
                DeletePicked.ResetText();
            }
        }

        private void HelpMenuAbout_Click(object sender, EventArgs e)// Help->About
        {
            using (AboutBox dialog = new AboutBox()){
                dialog.ShowDialog();
            }
        }

        private void HelpMenuContact_Click(object sender, EventArgs e)//Help-> Contact. Client start
        {
            System.Diagnostics.Process.Start(Path.GetFullPath(@"..\..\..\BookShopClient\bin\Debug\BookShopClient.exe"));
        }
    }
}
