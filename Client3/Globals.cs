using Client3.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client3
{

    public static class Globals
    {
        public const String DELIMITER = "\r\n";
        /// <summary>
        /// send message to server
        /// </summary>
        /// <param name="msg">byte array to send</param> 
        /// <returns>int: 0 if send success, errorCode if fail</returns>
        public static int SendMessage(Socket client, byte[] msg)
        {
            try
            {
                int byteCount = client.Send(msg, 0, msg.Length, SocketFlags.None);
                Console.WriteLine("Sent {0} bytes.", byteCount);
            }
            catch (SocketException e)
            {
                Console.WriteLine("{0} Error code: {1}.", e.Message, e.ErrorCode);
                return (e.ErrorCode);
            }
            return 0;
        }


        /// <summary>
        /// receive message from server
        /// </summary>
        public static void ReceiveMessage(Socket client)
        {
            try
            {

                while (true)
                {
                    byte[] messageRcv = new byte[256];
                    // Get reply from the server.
                    int byteRcv = client.Receive(messageRcv, 0, client.Available,
                                               SocketFlags.None);
                    if (byteRcv > 0)
                    {
                        messageRcv[byteRcv] = 0;
                        string dataReceive = Encoding.UTF8.GetString(messageRcv);
                        Console.WriteLine(dataReceive);
                        string opcode = dataReceive.Substring(0, 3);
                        string payload = dataReceive.Substring(4);
                        Console.WriteLine(opcode);
                        Console.WriteLine(payload);
                        handleMessage(opcode, payload);
                    }
                }

            }
            catch (Exception)
            {
                Console.WriteLine("Cannot receive message.");
            }

        }

        public static void handleMessage(String opcode, String payload)
        {
            switch (opcode)
            {
                case "210":
                    //open main form
                    Client3.LoginForm.instance.Invoke((MethodInvoker)delegate
                    {
                        // close the form on the forms thread
                        Client3.LoginForm.instance.Hide();
                        var mainform1 = new Client3.MainForm();
                        mainform1.Closed += (s, args) => Client3.LoginForm.instance.Close();
                        mainform1.Show();
                    });
                    break;
                case "410":
                    //Username or password is incorrect
                    MessageBox.Show(payload);
                    break;
                case "411":
                    //Username or password is incorrect
                    MessageBox.Show(payload);
                    break;
                case "230":
                    string[] payloadData = payload.Split('\n');
                    string roomCode = payloadData[0];
                    string username = payloadData[2];
                    var labelRoomCode = Client3.PlayForm.instance.labelRoomCode;
                    Console.WriteLine(labelRoomCode);
                    labelRoomCode.Invoke((MethodInvoker)delegate
                    {
                        labelRoomCode.Text = roomCode;
                    });
                    var labelUsers = Client3.PlayForm.instance.labelUsers;
                    var labelUser1 = labelUsers[0];
                    //int lengthUser = Client3.PlayForm.instance.labelUsers.Length;
                    //for (int i = 0; i < lengthUser; i++)
                    //{
                    //    if(labelUsers[i] == null)
                    //    {
                    //        MessageBox.Show("this null " + i);
                    //        break;
                    //    }

                    //}
                    labelUser1.Invoke((MethodInvoker)delegate
                    {
                        labelUser1.Text = username;
                    });
                    var pictureBoxUsers = Client3.PlayForm.instance.pictureBoxUsers;
                    pictureBoxUsers[0].BackgroundImage = Resources.user;
                    pictureBoxUsers[0].BackgroundImageLayout = ImageLayout.Stretch;

                    break;
                case "240":
                    Console.WriteLine("Ok join room sucessful");
                    Console.WriteLine(payload);
                    break;

                default:
                    Console.WriteLine("test");
                    break;
            }
        }
    }
}
