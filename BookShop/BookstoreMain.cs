using System;
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
using System.Net;
using System.Net.Sockets;


namespace BookShop
{
    public partial class Bookstore : Form
    {
        //Глобальные переменные в пределах класса
        public static string loguser; //Логин пользователя
        public string[] PickedBooksName = { }; //Массив Названий Выбранных книг
        public int[] PickedBooksAmount = { };//Массив количества Выбрынных книг
        public string[] PickedBooksOrder = new string[1];//Массив для вывода Корзины набранных книг
        public static string path = Path.GetFullPath(@"..\..\..\BookShopServer\bin\Debug\Data\base-islamov.mdf");
 
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
        public static string[] Send(string s)
        {
            IPHostEntry ipHost = Dns.GetHostEntry("localhost");
            int port = 11000;
            IPAddress ipAddr = ipHost.AddressList[0];
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, port);
            Socket sender1 = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            sender1.Connect(ipEndPoint);
            byte[] bytes = new byte[1024];            
            
            string message = s;
            bytes = Encoding.UTF8.GetBytes(message);
            sender1.Send(bytes);
            message = "";
            while(true)
            {
                int bytesRec = sender1.Receive(bytes);
                if (bytesRec == 0)
                    break;
                else
                {
                    message += Encoding.UTF8.GetString(bytes, 0, bytesRec);
                }

            }
            //MessageBox.Show(message);
            sender1.Shutdown(SocketShutdown.Both);
            sender1.Close();
            return message.Split(';');
        }
        private void Bookstore_Load(object sender, EventArgs e)
        {
            // Заголовок для Корзины
            PickedBooksOrder[0]= "Id \t Book \t \t Amount \n";
            PickedOrder.Text = PickedBooksOrder[0];

            // Соединение с базой и наполнение селектов
            string query = "select book_name from book";
            string[] mess= Send(query);
            for(int i=0;i<mess.Length;i++){
                BookSelector.Items.Add(mess[i]);
            }

            query = "select author_name from authors";
            mess = Send(query);
            for (int i = 0; i < mess.Length; i++){
                AuthorBookSelector.Items.Add(mess[i]);
            }

            query = "select genre_name from genres";
            mess = Send(query);
            for (int i = 0; i < mess.Length; i++){
                GenreBookSelector.Items.Add(mess[i]);
            }

            query = "select publisher_name from publishers";
            mess = Send(query);
            for (int i = 0; i < mess.Length; i++){
                PublisherBookSelector.Items.Add(mess[i]);
            }
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
            string query = "EXEC authorp @aut= '"+AuthorBookSelector.SelectedItem.ToString() +"'";
            string[] mess = Send(query);
            for (int i = 0; i < mess.Length; i++)
                CategoryBookSelector.Items.Add(mess[i]);
            GenreBookSelector.Text = "";
            PublisherBookSelector.Text = "";
        }

        private void GenreBookSelector_SelectedValueChanged(object sender, EventArgs e)// №2
        {
            CategoryBookSelector.Items.Clear();
            string query = "EXEC authorp @gen= '" + GenreBookSelector.SelectedItem.ToString() + "'";
            string[] mess = Send(query);
            for (int i = 0; i < mess.Length; i++)
                CategoryBookSelector.Items.Add(mess[i]);
            AuthorBookSelector.Text = "";
            PublisherBookSelector.Text = "";
        }

        private void PublisherBookSelector_SelectedValueChanged(object sender, EventArgs e)//№3
        {
            CategoryBookSelector.Items.Clear();
            string query = "EXEC authorp @pub= '" + PublisherBookSelector.SelectedItem.ToString() + "'";
            string[] mess = Send(query);
            for (int i = 0; i < mess.Length; i++)
                CategoryBookSelector.Items.Add(mess[i]);
            GenreBookSelector.Text = "";
            AuthorBookSelector.Text = "";
        }

        private void FileMenuExit_Click(object sender, EventArgs e)//Выход
        {
            //sender1.Close();
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
            if(BookSelector.Text!="")
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
            SqlParameter sqlParameter = new SqlParameter("@usr", SqlDbType.VarChar, 255)
            {
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

        private void SubmitOrder_Click(object sender, EventArgs e)// Совершение заказа
        {
            //Пробелы в массивах убираются в конец 
            PickedBooksName = PickedBooksName.Where(x => x != null).ToArray();
            PickedBooksAmount = PickedBooksAmount.Where(x => x != 0).ToArray();

            string query = "EXEC InsOrd @log= '" + loguser + "'";
            string[] mess = Send(query);
            // Затем в сущность shopping cart вставляются все выбранные книжки
            for(int i=0;i<PickedBooksAmount.Length;i++)
            {
                query = "EXEC InsShop @quan= '" + PickedBooksAmount[i] + "' , @bok= '"+ PickedBooksName[i] + "'";
                mess = Send(query);
            }
           // Очищение использованных ресурсов и вывод всех предыдущих заказов
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
            if(DeletePicked.SelectedIndex>-1)
            {
                PickedBooksOrder[Convert.ToInt32(DeletePicked.SelectedItem) + 1] = "";
                PickedOrder.Text = "";
                Array.Clear(PickedBooksName, Convert.ToInt32(DeletePicked.SelectedItem), 1);
                Array.Clear(PickedBooksAmount, Convert.ToInt32(DeletePicked.SelectedItem), 1);
                for(int i=0;i<PickedBooksOrder.Length;i++)
                {
                    PickedOrder.Text += PickedBooksOrder[i];
                }
                DeletePicked.Items.Remove(Convert.ToInt32(DeletePicked.SelectedItem));
                DeletePicked.ResetText();
            }
        }

        private void HelpMenuAbout_Click(object sender, EventArgs e)// Help->About. Простая About форма
        {
            using (AboutBox dialog = new AboutBox())
            {
                dialog.ShowDialog();
            }
        }

        private void HelpMenuContact_Click(object sender, EventArgs e)//Help-> Contact . Запуск клиента
        {
            System.Diagnostics.Process.Start(Path.GetFullPath(@"..\..\..\BookShopClient\bin\Debug\BookShopClient.exe"));
        }

    }
}
