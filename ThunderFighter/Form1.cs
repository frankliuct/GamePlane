namespace ThunderFighter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void InitialGame()
        {
            //��ʼ����������
            SingleObject.GetSingle().AddGameObject(new Background(0, -850, 20));

            //��ʼ�����
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
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            //���������긳ֵ����ҷɻ�������
            SingleObject.GetSingle().HP.MoveWithMouse(e);
        }
    }
}
