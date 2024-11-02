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

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //���Ƹ�����Ϸ����
            //��������ҷɻ����ӵ�...
            SingleObject.GetSingle().DrawGameObject(e.Graphics);
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
    }
}
