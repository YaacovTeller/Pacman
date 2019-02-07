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
using PacLibrary_WinForm;

namespace Pacman_new
{
    public partial class Form1 : Form, IMessageFilter
    {
        Timer t;
        string compassPoint = "E";
        string oldCompassPoint = "";
        const int speed = 10;
        bool flagDown = false;
        bool flagUp = false;
        bool flagLeft = false;
        bool flagRight = false;
        bool randomise = true;
        public static Ghost[] ghostArray = new Ghost[10];
        public static int ghostNumber = 5;
        Pacman pac;
        Ghost bad;

        public Form1()
        {
            InitializeComponent();
            //attempt arrowKeyUp override...
            Application.AddMessageFilter(this);
            this.FormClosed += (s, e) => Application.RemoveMessageFilter(this);

     //     this.FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
     //       KeyDown += Form1_KeyDown;
     //       KeyUp += Form1_KeyUp;
            addTimer();
            pac = new Pacman();
            pac.speed = speed;
            this.Controls.Add(pac.pacmanImage);
            createGhosts(ghostNumber);
       //     button1.Click += new EventHandler(button1_Click);
            //  pictureBox1.BackColor = Color.Transparent;
        }
        public void addTimer()
        {
            t = new Timer();
            t.Interval = 10;
            t.Tick += picChange;
            t.Tick += moveCheck_pac;
            t.Tick += crashCheckDisplay;
            t.Tick += chaser;
            t.Tick += screenCross;
            t.Start();
        }
        public void createGhosts(int ghostNumber)
        {
            for (var i = 0; i < ghostNumber; i++)
            {
                bad = new Ghost();
                //           label1.Text += bad.name + " ";
                ghostArray[i] = bad;
                if (randomise == true)
                {
                    Ghost.randLoc();
                    ghostArray[i].setRandLoc(Ghost.randomX, Ghost.randomY);
                }
                this.Controls.Add(bad.ghostImage);
            }
        }
        public void chaser(object sender, EventArgs e)
        {
            for (var i = 0; i < ghostNumber; i++)
            {
                if (pac.X > ghostArray[i].X)
                {
                    GameHelper.MoveRight(ghostArray[i]);
                }
                if (pac.Y > ghostArray[i].Y)
                {
                    GameHelper.MoveDown(ghostArray[i]);
                }
                if (pac.X < ghostArray[i].X)
                {
                    GameHelper.MoveLeft(ghostArray[i]);
                }
                if (pac.Y < ghostArray[i].Y)
                {
                    GameHelper.MoveUp(ghostArray[i]);
                }
            }
        }
        BinaryFormatter formatter = new BinaryFormatter();
        protected void save()
        {
            Ghost[] x;
            x = ghostArray;
            FileStream fs = new FileStream("C:/Users/Rivka and Yaacov/source/repos/C#/Pacman_new/Pacman_new/bin/GhostArray.bin", FileMode.Create);
            // SoapFormatter formatter = new SoapFormatter();
            formatter.Serialize(fs, x);
            fs.Close();
        }
        protected void load()
        {
            FileStream fs = new FileStream("C:/Users/Rivka and Yaacov/source/repos/C#/Pacman_new/Pacman_new/bin/GhostArray.bin", FileMode.Open);
            var y = (Ghost[])formatter.Deserialize(fs);
            fs.Close();
            ghostArray = y;
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
        //private void button1_Click(object sender, EventArgs e)
        //{
        //    save();
        //}
        //private void button2_Click(object sender, EventArgs e)
        //{
        //    load();
        //}
        protected void crashCheckDisplay(object sender, EventArgs e)
        {
            bool crashed = false;
            for (var i = 0; i <= ghostNumber - 1; i++) //Use ghostArray or turn to List!
            {
                crashed = GameHelper.IsCrashedTwoElement(ghostArray[i], pac);
                if (crashed == true) { break; };
            }
            // string str = crashed ? "מערכת זיהתה פגיעה" : "מערכת לא זיהתה פגיעה";
            string str = crashed ? "CRASH!" : "No collision detected";
            label1.Text = str;
        //    t.Tick -= moveCheck_pac;
            pac.die();
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
        // Override -- allows buttons -- KeyUp needs work!

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
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
                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg == 0x101) { flagRight = false; flagUp = false; flagLeft = false; }
            return false;
        }

        //KEYUP doesn't work here:

        //protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        //{
        //    const int WM_KEYDOWN = 0x100;
        //    const int WM_SYSKEYDOWN = 0x104;
        //    const int WM_KEYUP = 0x101;
        //    const int WM_SYSKEYUP = 0x105;

        //    if ((msg.Msg == WM_KEYDOWN) || (msg.Msg == WM_SYSKEYDOWN))
        //    {
        //        switch (keyData)
        //        {
        //            case Keys.Down:
        //                flagDown = true;
        //                break;
        //            case Keys.Up:
        //                flagUp = true;
        //                break;
        //            case Keys.Left:
        //                flagLeft = true;
        //                break;
        //            case Keys.Right:
        //                flagRight = true;
        //                break;
        //            default:
        //                return base.ProcessCmdKey(ref msg, keyData);
        //        }
        //    }
        //    if ((msg.Msg == WM_KEYUP) || (msg.Msg == WM_SYSKEYUP))
        //    {
        //        switch (keyData)
        //        {
        //            case Keys.Down:
        //                flagDown = false;
        //                break;
        //            case Keys.Up:
        //                flagUp = false;
        //                break;
        //            case Keys.Left:
        //                flagLeft = false;
        //                break;
        //            case Keys.Right:
        //                flagRight = false;
        //                break;
        //            default:
        //                return base.ProcessCmdKey(ref msg, keyData);
        //        }
        //    }
        //    return true;
        //}

        //NORMAL -- Without overrides -- Doesn't allow for buttons:

        //private void Form1_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Down)
        //    {
        //        flagDown = true;
        ////        e.Handled = true;
        //    }
        //    else if (e.KeyCode == Keys.Up)
        //    {
        //        flagUp = true;
        //    }
        //    if (e.KeyCode == Keys.Left)
        //    {
        //        flagLeft = true;
        //    }
        //    else if (e.KeyCode == Keys.Right)
        //    {
        //        flagRight = true;
        //    }
        //    e.SuppressKeyPress = true;
        //}
        //private void Form1_KeyUp(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Down)
        //    {
        //        flagDown = false;
        //    }
        //    else if (e.KeyCode == Keys.Up)
        //    {
        //        flagUp = false;
        //    }
        //    if (e.KeyCode == Keys.Left)
        //    {
        //        flagLeft = false;
        //    }
        //    else if (e.KeyCode == Keys.Right)
        //    {
        //        flagRight = false;
        //    }
        //    e.SuppressKeyPress = true;
        //}
    }
}
