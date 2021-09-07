using Client3.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
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
                        // quy1
                        messageRcv[byteRcv] = 0;
                        string dataReceive = Encoding.UTF8.GetString(messageRcv);
                        Console.WriteLine(dataReceive);
                        string opcode = dataReceive.Substring(0, 3);
                        string payload = dataReceive.Substring(4);
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
                //Sign up successfully
                case "200":
                    MessageBox.Show(payload);
                    break;

                //Sign up fail: Account already exists
                case "400":
                    MessageBox.Show(payload);
                    break;

                //Sign in successfully
                case "210":
                    //open main form
                    Client3.LoginForm.instance.Invoke((MethodInvoker)delegate
                    {
                        // close the form on the forms thread
                        Client3.LoginForm.instance.Hide();
                        var mainform1 = new Client3.MainForm();
                        mainform1.Closed += (s, args) => Client3.LoginForm.instance.Close();
                        mainform1.Show();
                        mainform1.labelUsername.Text = payload;
                    });
                    break;

                //Sign in fail
                case "410":
                    //Username or password is incorrect
                    MessageBox.Show(payload);
                    break;
                //Sign in fail
                case "411":
                    //Logged in from a different locatione
                    MessageBox.Show(payload);
                    break;
                //Logout
                case "220":
                    MainForm.instance.Invoke((MethodInvoker)delegate
                    {
                        MainForm.instance.Hide();
                        LoginForm.instance.Show();
                    });
                    break;
                //Create Room
                case "230":
                    MainForm.instance.Invoke((MethodInvoker)delegate
                    {
                        // close the form on the forms thread
                        MainForm.instance.Hide();
                        var playform1 = new PlayForm();
                        playform1.Closed += (s, args) => MainForm.instance.Close();
                        playform1.Show();
                        string[] payloadData = payload.Split('\n');
                        string roomCode = payloadData[0];
                        string username = payloadData[2];
                        var labelRoomCode = playform1.labelRoomCode;
                        labelRoomCode.Invoke((MethodInvoker)delegate
                        {
                            labelRoomCode.Text = roomCode;
                        });
                        var labelUsers = playform1.labelUsers;
                        var labelUser1 = labelUsers[0];
                        labelUser1.Invoke((MethodInvoker)delegate
                        {
                            labelUser1.Text = username;
                        });
                        playform1.labelUsername.Text = username;
                        var pictureBoxUsers = playform1.pictureBoxUsers;
                        pictureBoxUsers[0].BackgroundImage = Resources.user;
                        pictureBoxUsers[0].BackgroundImageLayout = ImageLayout.Stretch;

                    });
                    break;

                //Go into room
                case "240":
                    string[] payloadData1 = payload.Split('\n');
                    string roomId = payloadData1[0];
                    string[] usernames = payloadData1[1].Split('*');
                    //Update UI
                    MainForm.instance.Invoke((MethodInvoker)delegate
                    {
                        // close the form on the forms thread
                        MainForm.instance.Hide();
                        var playform1 = new PlayForm();
                     
                       
                        playform1.Closed += (s, args) => MainForm.instance.Close();
                        playform1.Show();

                        playform1.labelUsername.Text = MainForm.instance.labelUsername.Text;
                        var labelUsers1 = playform1.labelUsers;
                        var pictureBoxUsers1 = Client3.PlayForm.instance.pictureBoxUsers;
                        for (int i = 0; i < usernames.Length; i++)
                        {
                            labelUsers1[i].Invoke((MethodInvoker)delegate
                            {
                                labelUsers1[i].Text = usernames[i];
                            });
                            pictureBoxUsers1[i].BackgroundImage = Resources.user;
                            pictureBoxUsers1[i].BackgroundImageLayout = ImageLayout.Stretch;
                        }
                        playform1.labelRoomCode.Invoke((MethodInvoker)delegate
                        {
                            playform1.labelRoomCode.Text = roomId;
                        });

                        playform1.buttonStartGame.Visible = false;
                    });
                    
                    break;
                    
                //notify another players in room know that new player join room
                case "241":
                    //Listen new player go into room
                    string[] usernames2 = payload.Split('*');

                    //Update UI
                    var labelUsers2 = PlayForm.instance.labelUsers;
                    var pictureBoxUsers2 = PlayForm.instance.pictureBoxUsers;
                    for (int i = 0; i < usernames2.Length; i++)
                    {
                        labelUsers2[i].Invoke((MethodInvoker)delegate
                        {
                            labelUsers2[i].Text = usernames2[i];
                        });
                        pictureBoxUsers2[i].BackgroundImage = Resources.user;
                        pictureBoxUsers2[i].BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    break;

                //leave room
                case "280":
                    PlayForm.instance.Invoke((MethodInvoker)delegate
                    {
                        PlayForm.instance.Hide();
                        MainForm.instance.Show();
                    });
                    var position = payload;
                    Console.WriteLine(position);
                    break;

                //notify another players in room know this player leave room
                case "281":
                    string[] payloadData281 = payload.Split('\n');
                    int position281 = int.Parse(payloadData281[0]);
                    int isNewMaster = int.Parse(payloadData281[1]);
                    var labelUsers281 = PlayForm.instance.labelUsers;
                    var labelUser281 = labelUsers281[position281];
                    var buttonStart281 = PlayForm.instance.buttonStartGame;
                    labelUser281.Invoke((MethodInvoker)delegate
                    {
                        labelUser281.Text = null;
                    });
                    
                    var pictureBoxUsers281 = PlayForm.instance.pictureBoxUsers;
                    pictureBoxUsers281[position281].BackgroundImage = null;

                    if(isNewMaster == 1)
                    {
                        buttonStart281.Invoke((MethodInvoker)delegate
                        {
                            buttonStart281.Visible = true;
                        });
                    }
                    break;

                //Start game
                case "250":
                    var pnlStartGame = Client3.PlayForm.instance.panelStartGame;
                    var countDownTimeWait = Client3.PlayForm.instance.countDownTimeWait;
                    pnlStartGame.Invoke((MethodInvoker)delegate
                    {
                        pnlStartGame.Visible = false;
                        countDownTimeWait.Enabled = true;
                    });
                   
                    break;

                // get answer and score
                case "260":
                    try
                    {
                        //if (payload == "") break;
                        var labelAnswers = Client3.PlayForm.instance.labelAnswers;
                        var tableScore = Client3.PlayForm.instance.tableScore;
                        var labelResult = Client3.PlayForm.instance.lblResult;
                        tableScore.Invoke((MethodInvoker)delegate
                        {
                            tableScore.Rows.Clear();
                        });
                        string[] listUser = payload.Split('\n');
                        for (int i = 0; i < 4; ++i)
                        {
                            if (listUser[i] == "") continue;
                            Console.WriteLine(listUser[i]);
                            string[] listData = listUser[i].Split(' ');
                            //for (int j = 0; j < listData.Length; ++j)
                            //{
                            //    Console.WriteLine(listData[j] + "\n");
                            //}
                            var labelAnswerI = labelAnswers[i];
                            string[] row = { listData[0], listData[2] };
                            labelAnswerI.Invoke((MethodInvoker)delegate
                            {
                                labelAnswerI.Text = listData[1];
                                tableScore.Rows.Add(row);
                                labelResult.Text = listData[3];
                            });
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Cannot receive message.");
                    }
                    break;

                //get quiz
                case "290":
                    var labelQuestion = Client3.PlayForm.instance.labelQues;
                    //var countDownTimePlay = Client3.PlayForm.instance.countDownTimePlay;
                    labelQuestion.Invoke((MethodInvoker)delegate
                    {
                        labelQuestion.Text = payload;
                        //countDownTimePlay.Enabled = true;
                    });
                    break;

                //End game
                case "291":
                    Console.WriteLine(payload);
                    labelQuestion = Client3.PlayForm.instance.labelQues;
                    var countDownTimePlay = Client3.PlayForm.instance.countDownTimePlay;
                    countDownTimeWait = Client3.PlayForm.instance.countDownTimeWait;
                    var numberTime = Client3.PlayForm.instance.i;
                    pnlStartGame = Client3.PlayForm.instance.panelStartGame;
                    var labelAnswers291 = Client3.PlayForm.instance.labelAnswers;
                    var tableScore291 = Client3.PlayForm.instance.tableScore;
                    labelQuestion.Invoke((MethodInvoker)delegate
                    {
                        labelQuestion.Text = payload;
                        countDownTimePlay.Enabled = false;
                        countDownTimeWait.Enabled = false;
                        numberTime = 5;
                    });
                    pnlStartGame.Invoke((MethodInvoker)delegate
                    {
                        pnlStartGame.Visible = true;
                    });
                    for (int i = 0; i < 4; ++i)
                    {
                        var labelAnswerI = labelAnswers291[i];
                        labelAnswerI.Invoke((MethodInvoker)delegate
                        {
                            labelAnswerI.Text = "0";
                        });
                    }
                    tableScore291.Invoke((MethodInvoker)delegate
                    {
                        tableScore291.Rows.Clear();
                    });
                    break;

                //player is not room master
                case "451":
                    MessageBox.Show(payload);
                    break;

                //not enough people to start
                case "450":
                    MessageBox.Show(payload);
                    break;
                //Room doesn't exist
                case "440":
                    MessageBox.Show(payload);
                    break;
                //Full players in room
                case "441":
                    MessageBox.Show(payload);
                    break;
                //Game is being played
                case "442":
                    MessageBox.Show(payload);
                    break;
                //Don't have available rooms
                case "443":
                    MessageBox.Show(payload);
                    break;
                default:
                    break;
            }
        }
    }
}
