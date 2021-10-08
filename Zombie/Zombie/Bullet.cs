using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;


namespace Zombie
{
    class Bullet
    {
        public string direction;
        public int bulletTop, bulletLeft;

        private int speed = 20;
        private PictureBox img_bullet= new PictureBox();
        private Timer bulletTimer = new Timer();

        public void MakeBullet(Form form)
        { 
            img_bullet.BackColor = Color.White;
            img_bullet.Size = new Size(5, 5);
            img_bullet.Tag = "bullet";
            img_bullet.Left = bulletLeft;
            img_bullet.Top = bulletTop;
            img_bullet.BringToFront();

            form.Controls.Add(img_bullet);
            bulletTimer.Interval = speed;
            bulletTimer.Tick += new EventHandler(BulletTimerEvent);
            bulletTimer.Start();
        }


        private void BulletTimerEvent(object sender, EventArgs e)
        {
            if(direction == "left")
            {
                img_bullet.Left -= speed;
            }
            if (direction == "right")
            {
                img_bullet.Left += speed;
            }
            if (direction == "up")
            {
                img_bullet.Top -= speed;
            }
            if (direction == "down")
            {
                img_bullet.Top += speed;
            }

            if(img_bullet.Left < 12 || img_bullet.Left > 909 || img_bullet.Top < 12 || img_bullet.Top > 700)
            {
                bulletTimer.Stop();
                bulletTimer.Dispose();
                img_bullet.Dispose();
                bulletTimer = null;
                img_bullet = null;
            }




        }


    }
}
