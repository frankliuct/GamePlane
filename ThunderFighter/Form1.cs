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
            //初始化背景对象
            SingleObject.GetSingle().AddGameObject(new Background(0, -850, 20));

            //初始化玩家
            SingleObject.GetSingle().AddGameObject(new HeroPlane(200, 200, 20, 1, Direction.Up));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitialGame();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //绘制各种游戏对象
            //背景，玩家飞机，子弹...
            SingleObject.GetSingle().DrawGameObject(e.Graphics);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //不停的让窗体重绘事件
            this.Invalidate();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            //将鼠标的坐标赋值给玩家飞机的坐标
            SingleObject.GetSingle().HP.MoveWithMouse(e);
        }
    }
}
