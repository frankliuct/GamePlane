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
            //��ʼ����������
            SingleObject.GetSingle().AddGameObject(new Background(0, -850, 20));

            //��ʼ����ҷɻ�
            SingleObject.GetSingle().AddGameObject(new HeroPlane(200, 200, 20, 1, Direction.Up));

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitialGame();
        }

        bool isStart = false; //�����Ϸ�Ƿ�ʼ
        int playTime = 0; // ��Ϸ����ʱ��
        string result = string.Empty; // ��¼�ͻ��˽��
        bool isPaintResult = false; //�Ƿ���ƽ��

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            SingleObject.GetSingle().BG.Draw(e.Graphics);
            if (isStart)
            {
                //���Ƹ�����Ϸ����
                //��������ҷɻ����ӵ�...
                ipAddrTexBox.Hide();
                portTextBox.Hide();
                startGameBt.Hide();
                SingleObject.GetSingle().DrawGameObject(e.Graphics);
            }

            string s = SingleObject.GetSingle().Score.ToString();
            //������Ϸ�ķ���
            e.Graphics.DrawString(s, new Font("΢���ź�", 20, FontStyle.Bold), Brushes.Red,
                new Point(0, 0));

            if (isPaintResult)
            {
                //���ƽ��
                e.Graphics.DrawString(result, new Font("����", 20, FontStyle.Bold), Brushes.Red, new Point(0, 200));
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //��ͣ���ô����ػ��¼�
            this.Invalidate();

            //���л���������������·ɻ�
            if (SingleObject.GetSingle().listEnemyPlane.Count <= 2)
            {
                //�ٴ����³�ʼ���л�����
                InitialEnemyPlane();
            }

            //��ײ���
            SingleObject.GetSingle().PZJC();
        }
        private void InitialEnemyPlane()
        {
            //��ʼ�����˷ɻ�����
            for (int i = 0; i < 4; i++)
            {
                SingleObject.GetSingle().AddGameObject(
                    new EnemyPlane(r.Next(0, this.Width), -200, r.Next(0, 2)));
            }
            //�ɻ�Boss��10%�ļ��ʲ���
            if (r.Next(0, 101) > 90)
            {
                SingleObject.GetSingle().AddGameObject(
                    new EnemyPlane(r.Next(0, this.Width), -200, 2));
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            //���������긳ֵ����ҷɻ�������
            SingleObject.GetSingle().HP.MoveWithMouse(e);
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            //��ҷ����ӵ�
            SingleObject.GetSingle().HP.MouseDownLeft(e);
        }

        Socket socket;

        // �ͻ������ӷ���������ʼ��Ϸ
        private void startGameBt_Click(object sender, EventArgs e)
        {
            try
            {
                // ����Socket
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                // ��ȡIP��ַ�Ͷ˿ں�
                IPAddress ip = IPAddress.Parse(ipAddrTexBox.Text);
                // �˿ں�
                IPEndPoint point = new IPEndPoint(ip, int.Parse(portTextBox.Text));
                // ���ӵ�������
                socket.Connect(point);
                Console.WriteLine ("�ɹ����ӵ�������");

                // ���տ�ʼ��Ϸ����Ϣ
                Thread thread = new Thread(ReciveStartFlag);
                thread.IsBackground = true;
                thread.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine("���ӷ�����ʱ��������: " + ex.Message);
            }
        }

        // ��ͣ���տ�ʼ��Ϸ����Ϣ
        void ReciveStartFlag()
        {
            while (true)
            {
                byte[] buffer = new byte[1024 * 1024 * 5];
                int r = socket.Receive(buffer);
                if (buffer[0] == 1)
                {
                    // ���ÿ�ʼ��־
                    isStart = true;
                }
                else if (buffer[0] == 2)
                {
                    result = Encoding.Default.GetString(buffer, 1, r - 1);
                    // �ѽ����ʾ���ͻ���
                    isPaintResult = true;
                }
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if(isStart)
            {
                playTime++;
                Console.WriteLine("��ʱ��ʼ");
                if (playTime == 10)
                {
                    // ���������͸�������
                    byte[] buffer = Encoding.Default.GetBytes(SingleObject.GetSingle().Score.ToString());
                    socket.Send(buffer);
                    Console.WriteLine("�����ѷ���");
                    isStart =false; // ��ʱ����
                }
            }
        }
    }
}
