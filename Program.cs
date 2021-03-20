using Renci.SshNet;
using System;

namespace Test
{
    class Program
    {
        static string host = "11.73.4.81";
        static string username = "yourusername";
        static string password = "yourpassword";
        static void Main(string[] args)
        {
            using (SftpClient sftpClient = new SftpClient(host, username, password))
            {
                try
                {
                    sftpClient.Connect();
                    sftpClient.DeleteFile("./variables.txt");
                    sftpClient.Create("./variables.txt");
                    sftpClient.ReadAllText("./variables.txt");
                    sftpClient.WriteAllText("./variables.txt", "testwrite");
                    sftpClient.Disconnect();
                }
                catch (Exception e)
                {
                    Console.WriteLine("An exception has been caught " + e.ToString());
                }
            }
        }
    }
}
