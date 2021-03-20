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
            string _result = string.Empty;
            using (var sshClient = new SshClient(host, username, password))
            {
                sshClient.Connect();
                var runCommand = sshClient.RunCommand("./deploy.sh");
                //use thread sleep in casse you command taking to much time
                 System.Threading.Thread.Sleep(8 * 60 * 1000);
                if (runCommand.ExitStatus == 0) _result = "Success||" + runCommand.Result;
                else _result = "Error||" + runCommand.Error;

                //Disconnect from SSH client
                sshClient.Disconnect();

            }
            Console.WriteLine(_result);
        }
       
    }
}
