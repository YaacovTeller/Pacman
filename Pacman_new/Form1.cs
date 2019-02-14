using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Pac_Library;

namespace Pacman_new
{
    public partial class Form1 : Form /*IMessageFilter*/
    {
        Timer t;
        Button saveButton = new Button();
        Button loadButton = new Button();
        string compassPoint = "E";
        string oldCompassPoint = "";
        const int speed = 10;
        bool flagDown = false;
        bool flagUp = false;
        bool flagLeft = false;
        bool flagRight = false;
        bool running = true;
        bool crashed = false;
        bool alreadyCrashed = false;
        bool chasing = true;
        int score = 0;
        int timeCap = 1000;
        public static List<Ghost> ghostList = new List<Ghost>();
        public static int ghostNumber = 5;
        Pacman pac;
        Ghost bad;
        Food food;
        System.Media.SoundPlayer foodCollect = new System.Media.SoundPlayer(@"../../assets/pacman_sound/05.wav");
        System.Media.SoundPlayer pacNoise = new System.Media.SoundPlayer(@"../../assets/pacman_sound/06.wav");
        int time = 0;

        public Form1()
        {
            InitializeComponent();

            //saveButton.Text = "Save";
            //this.Controls.Add(saveButton);
            //saveButton.Visible = false;
            //loadButton.Text = "Load";
            //this.Controls.Add(loadButton);
            //loadButton.Visible = false;
            //saveButton.Click += new EventHandler(button1_Click);
            //saveButton.Top = 20;
            //saveButton.Left = 350;
            //loadButton.Click += new EventHandler(button2_Click);
            //loadButton.Top = 20;
            //loadButton.Left = 430;
            //attempt arrowKeyUp override...
            //       Application.AddMessageFilter(this);
            //       this.FormClosed += (s, e) => Application.RemoveMessageFilter(this);

            //     this.FormBorderStyle = FormBorderStyle.None;
            Pause.Visible = false;
            WindowState = FormWindowState.Maximized;
            KeyDown += Form1_KeyDown;
            KeyUp += Form1_KeyUp;
            addTimer();
            pac = new Pacman();
            pac.speed = speed;
            this.Controls.Add(pac.pacmanImage);
            createGhosts(ghostNumber);
            //     button1.Click += new EventHandler(button1_Click);
            //  pictureBox1.BackColor = Color.Transparent;
            food = new Food();
            this.Controls.Add(food.FoodImage);
        }
        public void counter(object s, EventArgs e)
        { time++;
            Timer.Text = "Time:" + time;
        }
        public void addTimer()
        {
            t = new Timer();
            t.Interval = 10;
            t.Tick += counter;
            t.Tick += picChange;
            t.Tick += moveCheck_pac;
            t.Tick += crashCheckDisplay;
            t.Tick += chase;
            t.Tick += screenCross;
            t.Tick += foodCheck;
            t.Tick += addGhostForTime;
            t.Start();
        }
        public void createGhosts(int ghostNumber)
        {
            for (var i = 0; i < ghostNumber; i++)
            {
                createGhost();
            }
        }
        public void createGhost()
        {
            bad = new Ghost();
            ghostList.Add(bad);
            bad.ghostImage.Location = Randomizer.setRandLoc();
            this.Controls.Add(bad.ghostImage);
        }
        private void upDown(object sender, EventArgs e, Ghost g)
        {
            bool reverseY = false;
            if (reverseY == false)
            {
                if (g.Y <= 200) { reverseY = true; }
                GameHelper.MoveUp(g);
            }
            else if (reverseY == true)
            {
                if (g.Y >= 400) { reverseY = false; }
                GameHelper.MoveDown(g);
            }
        }
        public void chase(object s, EventArgs e)
        {
            for (var i = 0; i < ghostList.Count; i++)
            {
                if (pac.X > ghostList[i].X)
                {
   //                 upDown(s, e, ghostList[i]);
                    GameHelper.MoveRight(ghostList[i]);
                    //if (ghostList[i].compass != "E")
                    //{
                    //    ghostList[i].setGhostDirectionImage("E");
                    //}
                }
                if (pac.Y > ghostList[i].Y)
                {
                    GameHelper.MoveDown(ghostList[i]);
                    //if (ghostList[i].compass != "S")
                    //{
                    //    ghostList[i].setGhostDirectionImage("S");
                    //}
                }
                if (pac.X < ghostList[i].X)
                {
                    GameHelper.MoveLeft(ghostList[i]);
                    //if (ghostList[i].compass != "W")
                    //{
                    //    ghostList[i].setGhostDirectionImage("W");
                    //}
                }
                if (pac.Y < ghostList[i].Y)
                {
                    GameHelper.MoveUp(ghostList[i]);
                    //if (ghostList[i].compass != "N")
                    //{
                    //    ghostList[i].setGhostDirectionImage("N");
                    //}
                }
            }
        }
        public void flee(object s, EventArgs e)
        {
            for (var i = 0; i < ghostList.Count; i++)
            {
                if (chasing == false && ghostList[i].compass != "flee")
                {
                    ghostList[i].ghostImage.ImageLocation = "../../assets/ghosts/flee.gif";
                    ghostList[i].compass = "flee";
                }
                //             if (ghostList[i].speed == 2) { }
                if (pac.X > ghostList[i].X)
                {
                    //                 upDown(s, e, ghostList[i]);
                    GameHelper.MoveLeft(ghostList[i]);
                }
                if (pac.Y > ghostList[i].Y)
                {
                    GameHelper.MoveUp(ghostList[i]);
                }
                if (pac.X < ghostList[i].X)
                {
                    GameHelper.MoveRight(ghostList[i]);
                }
                if (pac.Y < ghostList[i].Y)
                {
                    GameHelper.MoveDown(ghostList[i]);
                }
            }
        }
        BinaryFormatter formatter = new BinaryFormatter();
        protected void save()
        {
            List<Ghost> x;
            x = ghostList;
            FileStream fs = new FileStream("C:/Users/Rivka and Yaacov/source/repos/C#/Pacman_new/Pacman_new/bin/GhostArray.bin", FileMode.Create);
            // SoapFormatter formatter = new SoapFormatter();
            formatter.Serialize(fs, x);
            fs.Close();
        }
        protected void load()
        {
            FileStream fs = new FileStream("C:/Users/Rivka and Yaacov/source/repos/C#/Pacman_new/Pacman_new/bin/GhostArray.bin", FileMode.Open);
            var y = (List<Ghost>)formatter.Deserialize(fs);
            fs.Close();
            for (var i = 0; i < y.Count; i++)
            {
                y[i].ghostImage = new PictureBox();
                y[i].ghostImage.ImageLocation = "../../assets/ghost_" + Ghost.ghostIndex + ".png";
            }
                ghostList = y;
            for (var i = 0; i < ghostList.Count; i++) {
                this.Controls.Add(ghostList[i].ghostImage);
            }
                
        } 
        //private void upDown(object sender, EventArgs e)
        //{
        //    if (reverseY == false)
        //    {
        //        if (pictureBox1.Top <= 200) { reverseY = true; }
        //        pictureBox1.Top-=10;
        //    }
        //    else if (reverseY == true)
        //    {
        //        if (pictureBox1.Top >= 400) { reverseY = false; }
        //        pictureBox1.Top+=1;
        //    }
        //    if (reverseX == false)
        //    {
        //        if (pictureBox1.Left <= 20) { reverseX = true; }
        //        pictureBox1.Left -= 2;
        //    }
        //    else if (reverseX == true)
        //    {
        //        if (pictureBox1.Left >= 500) { reverseX = false; }
        //        pictureBox1.Left += 2;
        //    }
        //}
        private void screenCross(object sender, EventArgs e)
        {
            if (pac.X < 0 - pac.Width) { pac.pacmanImage.Left = 1400; }
            if (pac.Y < 0 - pac.Height) { pac.pacmanImage.Top = 770; }
            if (pac.X > 1400 ) { pac.pacmanImage.Left = 0 - pac.Width; }
            if (pac.Y > 770 ) { pac.pacmanImage.Top = 0 - pac.Height; }
        }

            private void moveCheck_pac(object sender, EventArgs e)
        {
            if (flagDown == true) { GameHelper.MoveDown(pac);  }
            if (flagUp == true) { GameHelper.MoveUp(pac);  }
            if (flagLeft == true) { GameHelper.MoveLeft(pac); }
            if (flagRight == true) { GameHelper.MoveRight(pac); }
        }
        private void picChange(object sender, EventArgs e)
        {
            oldCompassPoint = compassPoint;
            setCompassPoint();
            if (compassPoint != oldCompassPoint)
            {
                pac.pacmanImage.ImageLocation =
            "../../assets/pacman_gifs/pac_" + compassPoint + ".gif";
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            save();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            load();
        }
        protected void foodCheck(object sender, EventArgs e)
        {
            bool crashed = false;
                crashed = GameHelper.IsCrashedTwoElement(pac, food);
                if (crashed == true)
            {
                foodCollect.Play();
                this.Controls.Remove(food.FoodImage);
                score+=100;
                if (Food.foodCounter == 5)
                {
                    chasing = false;
                    t.Tick -= chase;
                    t.Tick += flee;
                }
                else if (chasing == false)
                {
                    t.Tick -= flee;
                    t.Tick += chase;
                    chasing = true;
                    for (var i = 0; i < ghostList.Count; i++)
                    {
                        ghostList[i].setGhostDirectionImage("E");
                      
                    }
                }
                food = new Food();
                this.Controls.Add(food.FoodImage);
                label2.Text = "Score: "+ score;
               if (ghostList.Count <= ghostNumber)
                {
                    createGhost();
                }
            };
        }
        protected void addGhostForTime(object sender, EventArgs e)
        {
            if (time > timeCap && ghostList.Count <= ghostNumber)
            {
                createGhost();
                ghostNumber++;
                timeCap += 1000;
            }
        }
        protected void crashCheckDisplay(object sender, EventArgs e)
        {
            for (var i = 0; i <= ghostList.Count - 1; i++)
            {
                crashed = GameHelper.IsCrashedTwoElement(ghostList[i], pac);
                if (crashed == true)
                {
                    if (chasing == true)
                    {
                        if (alreadyCrashed == false) { pacNoise.Play(); }
                        score -= ghostList[i].damage;
                        label2.Text = "Score: " + score;
                        alreadyCrashed = true;
                        break;
                    }
                    else
                    {
                        score += ghostList[i].speed * 200;
                        this.Controls.Remove(ghostList[i].ghostImage);
                        ghostList.Remove(ghostList[i]);
                        foodCollect.Play();
                        label2.Text = "Score: " + score;
                    }
                };
            }
            // string str = crashed ? "מערכת זיהתה פגיעה" : "מערכת לא זיהתה פגיעה";
            if (crashed == false) { alreadyCrashed = false;  }
            string str = crashed ? "CRASH!" : "No collision detected";
            label1.Text = str;
     //       pac.die();
        }
        void setCompassPoint()
        {
        //    compassPoint = "";
            if (flagLeft == true)
            {
                if (flagUp == true) { compassPoint = "NW"; }
                else if (flagDown == true) { compassPoint = "SW"; }
                else compassPoint = "W";
            }
            if (flagUp == true)
            {
                if (flagLeft == true) { compassPoint = "NW"; }
                else if (flagRight == true) { compassPoint = "NE"; }
                else compassPoint = "N";
            }
            if (flagRight == true)
            {
                if (flagUp == true) { compassPoint = "NE"; }
                else if (flagDown == true) { compassPoint = "SE"; }
                else compassPoint = "E";
            }
            if (flagDown == true)
            {
                if (flagLeft == true) { compassPoint = "SW"; }
                else if (flagRight == true) { compassPoint = "SE"; }
                else compassPoint = "S";
            }
        }
        //NORMAL CONTROL SET -- Without overrides -- Doesn't allow for buttons, arrowkeys tab between buttons:

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Down:
                    flagDown = true;
                    break;
                case Keys.Up:
                    flagUp = true;
                    break;
                case Keys.Left:
                    flagLeft = true;
                    break;
                case Keys.Right:
                    flagRight = true;
                    break;
                case Keys.S:
                    save();
                    break;
                case Keys.L:
                    load();
                    break;
                case Keys.Escape:
                    if (running == true)
                    {
                        running = false;
                        //saveButton.Visible = true;
                        //loadButton.Visible = true;
                        t.Stop();
                        Pause.Visible = true;
                    }
                    else
                    {
                        running = true;
                        Pause.Visible = false;
                        //saveButton.Visible = false;
                        //loadButton.Visible = false;
                        t.Start();
                    }
                    break;
                //default:
                //    return base.ProcessCmdKey(ref msg, keyData);
            }
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                flagDown = false;
            }
            else if (e.KeyCode == Keys.Up)
            {
                flagUp = false;
            }
            if (e.KeyCode == Keys.Left)
            {
                flagLeft = false;
            }
            else if (e.KeyCode == Keys.Right)
            {
                flagRight = false;
            }
            e.SuppressKeyPress = true;
        }
    }
}
