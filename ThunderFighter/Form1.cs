using System.Net.Sockets;
using System.Net;
using System.Text;

namespace ThunderFighter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        Random r = new Random();
        private void InitialGame()
        {
            //初始化背景对象
            SingleObject.GetSingle().AddGameObject(new Background(0, -850, 20));

            //初始化玩家飞机
            SingleObject.GetSingle().AddGameObject(new HeroPlane(200, 200, 20, 1, Direction.Up));

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitialGame();
        }

        bool isStart = false; //标记游戏是否开始
        int playTime = 0; // 游戏运行时间
        string result = string.Empty; // 记录客户端结果
        bool isPaintResult = false; //是否绘制结果

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            SingleObject.GetSingle().BG.Draw(e.Graphics);
            if (isStart)
            {
                //绘制各种游戏对象
                //背景，玩家飞机，子弹...
                ipAddrTexBox.Hide();
                portTextBox.Hide();
                startGameBt.Hide();
                SingleObject.GetSingle().DrawGameObject(e.Graphics);
            }

            string s = SingleObject.GetSingle().Score.ToString();
            //绘制游戏的分数
            e.Graphics.DrawString(s, new Font("微软雅黑", 20, FontStyle.Bold), Brushes.Red,
                new Point(0, 0));

            if (isPaintResult)
            {
                //绘制结果
                e.Graphics.DrawString(result, new Font("宋体", 20, FontStyle.Bold), Brushes.Red, new Point(0, 200));
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //不停的让窗体重绘事件
            this.Invalidate();

            //当敌机数量较少则加入新飞机
            if (SingleObject.GetSingle().listEnemyPlane.Count <= 2)
            {
                //再次重新初始化敌机数量
                InitialEnemyPlane();
            }

            //碰撞检测
            SingleObject.GetSingle().PZJC();
        }
        private void InitialEnemyPlane()
        {
            //初始化敌人飞机对象
            for (int i = 0; i < 4; i++)
            {
                SingleObject.GetSingle().AddGameObject(
                    new EnemyPlane(r.Next(0, this.Width), -200, r.Next(0, 2)));
            }
            //飞机Boss有10%的几率产生
            if (r.Next(0, 101) > 90)
            {
                SingleObject.GetSingle().AddGameObject(
                    new EnemyPlane(r.Next(0, this.Width), -200, 2));
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            //将鼠标的坐标赋值给玩家飞机的坐标
            SingleObject.GetSingle().HP.MoveWithMouse(e);
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            //玩家发射子弹
            SingleObject.GetSingle().HP.MouseDownLeft(e);
        }

        Socket socket;

        // 客户端连接服务器，开始游戏
        private void startGameBt_Click(object sender, EventArgs e)
        {
            try
            {
                // 创建Socket
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                // 获取IP地址和端口号
                IPAddress ip = IPAddress.Parse(ipAddrTexBox.Text);
                // 端口号
                IPEndPoint point = new IPEndPoint(ip, int.Parse(portTextBox.Text));
                // 连接到服务器
                socket.Connect(point);
                Console.WriteLine ("成功连接到服务器");

                // 接收开始游戏的消息
                Thread thread = new Thread(ReciveStartFlag);
                thread.IsBackground = true;
                thread.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine("连接服务器时发生错误: " + ex.Message);
            }
        }

        // 不停接收开始游戏的消息
        void ReciveStartFlag()
        {
            while (true)
            {
                byte[] buffer = new byte[1024 * 1024 * 5];
                int r = socket.Receive(buffer);
                if (buffer[0] == 1)
                {
                    // 设置开始标志
                    isStart = true;
                }
                else if (buffer[0] == 2)
                {
                    result = Encoding.Default.GetString(buffer, 1, r - 1);
                    // 把结果显示到客户端
                    isPaintResult = true;
                }
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if(isStart)
            {
                playTime++;
                Console.WriteLine("计时开始");
                if (playTime == 10)
                {
                    // 将分数发送给服务器
                    byte[] buffer = Encoding.Default.GetBytes(SingleObject.GetSingle().Score.ToString());
                    socket.Send(buffer);
                    Console.WriteLine("分数已发送");
                    isStart =false; // 计时结束
                }
            }
        }
    }
}
