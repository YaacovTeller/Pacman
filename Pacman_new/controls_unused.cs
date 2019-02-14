using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pacman_new
{
    class controls_unused
    {
        // Override -- allows buttons -- KeyUp needs work!

        //protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        //{
        //    switch (keyData)
        //    {
        //        case Keys.Down:
        //            flagDown = true;
        //            break;
        //        case Keys.Up:
        //            flagUp = true;
        //            break;
        //        case Keys.Left:
        //            flagLeft = true;
        //            break;
        //        case Keys.Right:
        //            flagRight = true;
        //            break;
        //        case Keys.Escape:
        //            if (running == true)
        //            {
        //                running = false;
        //                saveButton.Visible = true;
        //                loadButton.Visible = true;
        //                t.Stop();
        //            }
        //            else
        //            {
        //                running = true;
        //                saveButton.Visible = false;
        //                loadButton.Visible = false;
        //                t.Start();
        //            }
        //            break;
        //        default:
        //            return base.ProcessCmdKey(ref msg, keyData);
        //    }
        //    return base.ProcessCmdKey(ref msg, keyData);
        //}
        //This filter thing seems to detect the KEYUP code:
        //I make it cut all four movement flags, which works after a fashion, but results in awkward movement.
        //It really needs to detect WHICH key went up, but the function can only recieve one arg, the message data:

        //public bool PreFilterMessage(ref Message m)
        //{
        //    if (m.Msg == 0x101) { flagRight = false; flagUp = false; flagLeft = false; flagDown = false; }
        //    return false;
        //}

        //OVERRIDING KEYS w/o IMessageFilter - KEYUP doesn't work here, don't know why:

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

        //NORMAL CONTROL SET -- Without overrides -- Doesn't allow for buttons, arrowkeys tab between buttons:

        //private void Form1_KeyDown(object sender, KeyEventArgs e)
        //{
        //    switch (e.KeyCode)
        //    {
        //        case Keys.Down:
        //            Form1.flagDown = true;
        //            break;
        //        case Keys.Up:
        //            Form1.flagUp = true;
        //            break;
        //        case Keys.Left:
        //            Form1.flagLeft = true;
        //            break;
        //        case Keys.Right:
        //            Form1.flagRight = true;
        //            break;
        //        case Keys.S:
        //            Form1.save();
        //            break;
        //        case Keys.L:
        //            Form1.load();
        //            break;
        //        case Keys.Escape:
        //            if (Form1.running == true)
        //            {
        //                Form1.running = false;
        //                Form1.saveButton.Visible = true;
        //                Form1.loadButton.Visible = true;
        //                Form1.t.Stop();
        //            }
        //            else
        //            {
        //                Form1.running = true;
        //                Form1.saveButton.Visible = false;
        //                Form1.loadButton.Visible = false;
        //                Form1.t.Start();
        //            }
        //            break;
        //            //default:
        //            //    return base.ProcessCmdKey(ref msg, keyData);
        //    }
        //}
        //private void Form1_KeyUp(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Down)
        //    {
        //        Form1.flagDown = false;
        //    }
        //    else if (e.KeyCode == Keys.Up)
        //    {
        //        Form1.flagUp = false;
        //    }
        //    if (e.KeyCode == Keys.Left)
        //    {
        //        Form1.flagLeft = false;
        //    }
        //    else if (e.KeyCode == Keys.Right)
        //    {
        //        Form1.flagRight = false;
        //    }
        //    e.SuppressKeyPress = true;
//        }
//    }
    }
}