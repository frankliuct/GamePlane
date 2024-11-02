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
                AddLogMessage("------正在等待客户端与服务器连接------");

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

        Dictionary<string, Socket> dictionScoket = new Dictionary<string, Socket>();

        void Listen(Socket socketWatch)
        {
            while (true)
            {
                try
                {
                    // 接受与客户端连接
                    Socket socketSend = socketWatch.Accept();
                    // 将客户端的Socket存储在集合中
                    dictionScoket.Add(socketSend.ToString(), socketSend);
                    AddLogMessage(socketSend.RemoteEndPoint.ToString() + "------已经与服务器建立连接------");
                }
                catch (SocketException ex)
                {
                    AddLogMessage("SocketException in Listen: " + ex.Message);
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
            foreach(KeyValuePair<string, Socket> kv in dictionScoket)
            {
                kv.Value.Send(buffer);
            }
        }
    }
}
