using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThunderFighter_Server
{
    public partial class ConsoleWindow : Form
    {
        public ConsoleWindow()
        {
            InitializeComponent();
        }

        // 开启服务器监听事件
        private void startListenBt_Click(object sender, EventArgs e)
        {
            try
            {
                // 创建Socket
                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                // 获取IP地址和端口号
                IPAddress ip = IPAddress.Parse(ipAddrTexBox.Text);
                // 端口号
                int port = int.Parse(portTextBox.Text);
                IPEndPoint point = new IPEndPoint(ip, port);

                // 绑定端口
                socket.Bind(point);
                // 监听
                socket.Listen(9);
                AddLogMessage("正在等待客户端与服务器连接");

                Thread thread = new Thread(() => Listen(socket)); // 修改这里，确保传递的是创建的 socket
                thread.IsBackground = true;
                thread.Start();
            }
            catch (SocketException ex)
            {
                AddLogMessage("SocketException: " + ex.Message);
            }
            catch (Exception ex)
            {
                AddLogMessage("Exception: " + ex.Message);
            }
        }

        // 存储客户端socket
        Dictionary<string, Socket> dictionSocket = new Dictionary<string, Socket>();

        // 存储客户端ip地址和分数
        Dictionary<string, int> dictionScore = new Dictionary<string, int>();

        // 接收客户端连接
        void Listen(object o)
        {
            Socket socketWatch = o as Socket;
            while (true)
            {
                try
                {
                    // 接受与客户端连接
                    Socket socketSend = socketWatch.Accept();
                    string clientKey = socketSend.RemoteEndPoint.ToString();
                    // 将客户端的Socket存储在集合中
                    dictionSocket[clientKey] = socketSend; // 使用 clientKey 作为键
                    AddLogMessage(clientKey + "已经与服务器建立连接");
                    // 接收客户端发送的信息
                    Thread thread2 = new Thread(ReceiveScoreRecords);
                    thread2.IsBackground = true;
                    thread2.Start(socketSend);
                }
                catch (SocketException ex)
                {
                    AddLogMessage("SocketException in Listen: " + ex.Message);
                }
            }
        }

        // 接收分数记录
        void ReceiveScoreRecords(Object o)
        {
            Socket socketSend = o as Socket;
            while (true)
            {
                byte[] buffer = new byte[1024 * 1024 * 3];
                int r = socketSend.Receive(buffer);
                string strScore  = Encoding.Default.GetString(buffer, 0, r); 
                int score = Convert.ToInt32(strScore);
                // 把分数添加到集合中
                dictionScore.Add(socketSend.RemoteEndPoint.ToString(), score);
                // 排序
                Compare();
            }
        }

        // 排序函数
        void Compare()
        {
            List<KeyValuePair<string, int>> list = dictionScore.OrderByDescending(n => n.Value).ToList();
            for (int i = 0; i < list.Count; i++)
            {
                string clientKey = list[i].Key;
                // 确保字典中存在客户端的键
                if (dictionSocket.ContainsKey(clientKey))
                {
                    string result = "您是本次飞机大战中的第" + (i + 1) + "名\n您的总成绩是" + list[i].Value;
                    byte[] buffer = Encoding.Default.GetBytes(result);
                    List<byte> listByte = new List<byte>();
                    listByte.Add(2);
                    listByte.AddRange(buffer);
                    byte[] newBuffer = listByte.ToArray();

                    // 向客户端发送排名和成绩
                    dictionSocket[clientKey].Send(newBuffer);
                    Console.WriteLine(result);
                }
                else
                {
                    // 若找不到客户端，记录日志信息
                    AddLogMessage("无法找到客户端 " + clientKey + " 的 Socket，跳过发送信息。");
                }
            }
        }



        // 添加日志信息
        void AddLogMessage(string message)
        {
            if (logListBox.InvokeRequired)
            {
                // 如果需要跨线程调用，使用 Invoke 方法
                logListBox.Invoke(new Action<string>(AddLogMessage), message);
            }
            else
            {
                // 直接更新控件
                logListBox.Items.Add(message);
            }
        }

        // 给每个客户端发送开始游戏的信息
        private void startGameBt_Click(object sender, EventArgs e)
        {
            byte[] buffer = new byte[1];
            buffer[0] = 1;
            foreach(KeyValuePair<string, Socket> kv in dictionSocket)
            {
                kv.Value.Send(buffer);
            }
        }
    }
}
