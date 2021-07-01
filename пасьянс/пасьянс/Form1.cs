using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace пасьянс
{
   

    public partial class Form1 : Form
    {
        int[,] coord = { { 4, 4 },
                         { 20, 4 }, 
                         { 17, 6 }, 
                         { 23, 6 },
                         { 14,10 },
                         { 20,10 },
                         { 26,10 },
                         { 17,14 },
                         { 23,14 },
                         { 20,16 }
        };
    
        
        const int high = 22;
        const int weight = 32;
        const int CARD_WIDTH = 72;    // ширина карты
        const int CARD_HEIGHT = 100;  // высота карты
        const int emptyCard = 53;   // индекс изображения пустой карты
        const int backCard = 52;    // индекс изображения рубашки карты
        const int empCard = 54;   // индекс изображения пустой колоды
        //const int a = 30;
        int b = 1;
        private bool newGame;
        private Deck deck;      // колода
        private Undo undoList;

        private bool drag;      // флаги выполнения drag & drop
        private bool view;
        private Graphics grf;
        private SolidBrush backBrush;
        private int dragX, dragY;   // координаты перемещаемой карты
        private int deltaX, deltaY; // разница между координатами перемещаемой карты и координатами курсора на ней



        public Form1()
        { 
            InitializeComponent();
            int a = 800/32;
            Size = new Size(32*a, 25*a);
            //b = Form1.

            button1.Size = new Size (CARD_WIDTH, CARD_HEIGHT);
            button1.Location = new Point(coord[0,0] * a, coord[0, 1] * a);
            pictureBox2.Location = new Point(coord[1, 0] * a, coord[1, 1] * a);
            pictureBox3.Location = new Point(coord[2, 0] * a, coord[2, 1] * a);
            pictureBox4.Location = new Point(coord[3, 0] * a, coord[3, 1] * a);
            pictureBox5.Location = new Point(coord[4, 0] * a, coord[4, 1] * a);
            pictureBox6.Location = new Point(coord[5, 0] * a, coord[5, 1] * a);
            pictureBox7.Location = new Point(coord[6, 0] * a, coord[6, 1] * a);
            pictureBox8.Location = new Point(coord[7, 0] * a, coord[7, 1] * a);
            pictureBox9.Location = new Point(coord[8, 0] * a, coord[8, 1] * a);
            pictureBox10.Location = new Point(coord[9, 0] * a, coord[9, 1] * a);


            ToolStripMenuItem file = new ToolStripMenuItem("Файл");
            file.DropDownItems.Add("Новая игра", new Bitmap(10, 10), NewGame);
            file.DropDownItems.Add("Отмена хода");

             menuStrip1.Items.Add(file);

            ToolStripMenuItem about = new ToolStripMenuItem("О программe");
            about.DropDownItems.Add("Правила Игры", new Bitmap(10, 10), rules_Click);
            about.DropDownItems.Add("Создатели", new Bitmap(10, 10), autors_Click);
            menuStrip1.Items.Add(about);
        }

        void rules_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Задача: собрать  четыре  масти  в  их  последовательном порядке. Карты снимают с колоды пока появиться  двойка.Все  остальные  карты выкладываются в талон.Двойки выкладываются вокруг талона: две черных - справа  и  слева от талона, две красных - сверху и снизу.Далее на двойки выкладываются карты в восходящем порядке  в  масть  до  тузов. Когда  колода  окажется  исчерпанной, то снятие карт  повторяют, но теперь уже из талона. Так как  в каждом углу  нельзя выкладывать более одной карты, то предпочтительно, чтобы  по  углам  находились  карты  разной  масти. Правила не требуют, чтобы резервный отряд обязательно создавался. Его употребляют  лишь  в  трудных  случаях.");
        }
        void autors_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Герасименко Виктория, Галуц Дмитрий");
        }


        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        void NewGame(object sender, EventArgs e)
        {
            newGame = false;
            grf = this.CreateGraphics();
            this.Refresh();

            // создаем список ходов для возможности отмены 
            undoList = new Undo();

            // создаем колоду 
            deck = new Deck();
            // перемешиваем колоду
            deck.Shuffle();

          

        }


    }
}
