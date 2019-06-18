using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Data.SqlClient;
using System.IO;
using System.Data;
using System.Linq;

namespace BookShopServer
{
    class Program
    {
        public static IPHostEntry ipHost = Dns.GetHostEntry("localhost");
        public static IPAddress ipAddr = ipHost.AddressList[0];
        public static int port = 11000;
        public static IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, port);
        public static Socket sender = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        public static string path = Path.GetFullPath(@".\Data\base-islamov.mdf");
        static void Main(string[] args)
        {
            // конфигурация
            // создаем сокет Tcp/Ip
            Socket sListener = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
            {
                DataSource = @"(LocalDB)\MSSQLLocalDB",
                AttachDBFilename = path,
                IntegratedSecurity = true
            };
            IDbConnection connection = new SqlConnection(builder.ConnectionString);

            // назначаем сокет и слушаем входящие сокеты
            try
            {
                sListener.Bind(ipEndPoint);
                sListener.Listen(10);
                while (true)
                {
                    // программа приостанавливается, ожидая входящее соединение
                    Socket handler = sListener.Accept();
                    string data = "";
                    string reply = "";
                    byte[] bytes = new byte[1024];
                    int bytesRec = handler.Receive(bytes);
                    data += Encoding.UTF8.GetString(bytes, 0, bytesRec);
                    Console.Write("Received Data: " + data + "\n");
                    connection.Open();
                    IDbCommand command = new SqlCommand(data);
                    command.Connection = connection;
                    IDataReader reader = command.ExecuteReader();
                    if (reader.FieldCount != 0)
                    {
                        while (reader.Read())
                        {
                            if (reader.FieldCount == 1)
                                reply += reader.GetValue(0) + ";";
                            else
                            {
                                for (int i = 0; i < reader.FieldCount; i++)
                                    reply += reader.GetValue(i) + ",";
                                reply += ";";
                            }
                            //for(int i)
                        }
                        reply.Trim();
                        if (reply.Contains(";"))
                            reply = reply.Remove(reply.LastIndexOf(';'), 1);
                    }
                    reader.Close();
                    command.Dispose();
                    connection.Close();
                    Console.WriteLine(reply);
                    byte[] msg = Encoding.UTF8.GetBytes(reply);
                    handler.Send(msg);
                    if (data.IndexOf("<TheEnd>") > -1)
                    {
                        Console.WriteLine("Server disconnected from client.");
                        break;
                    }
                    handler.Shutdown(SocketShutdown.Both);
                    handler.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                Console.ReadLine();
            }
        }
    }
}
