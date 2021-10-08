using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zombie
{
    public partial class Form1 : Form
    {

        bool goLeft, goRight, goUp, goDown, gameOver;
        string facing = "up";
        int playerHealth = 100;
        int speed = 10;
        int ammo = 10;
        int zombieSpeed = 3;
        Random randNum = new Random();
        int score;
        List<PictureBox> zombieLisr = new List<PictureBox>();


        public Form1()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void MainTimerEvent(object sender, EventArgs e)
        {
            if (playerHealth > 0)
            {
                bar_prog.Value = playerHealth;
            }
            else
                gameOver = true;
            lab_ammo.Text = "Ammo: " + ammo;
            lab_kills.Text = "Kills: " + score;
            
            if(goLeft == true && img_joueur.Left > 0) //img_joueur.Left obtient la distance en pixels entre l'extremite gauche du Form et celle de la pictureBox
            {
                img_joueur.Left -= speed; // se dirige vers la gauche tant que l 'extremite de la fenetre n'est pas atteinte en avançant de "speed" pîxels
            }
            if(goRight == true && img_joueur.Left + img_joueur.Width < this.ClientSize.Width) //cad : joueur se dirige a droite et que la distance entre l'extremite gauche du Form et celle de la pictureBox + la largeur de la pictureBox < la largeur totale du Form (aka extremite droite non atteinte) 
            {
                img_joueur.Left += speed; //en se dirigeant vers la droite, la distance entre la picbox et l extremite gauche augmente de "speed" pixels
            }
            if(goUp == true && img_joueur.Top > 45)// idem avec le haut du form
            {
                img_joueur.Top -= speed;
            }
            if (goDown == true && img_joueur.Top + img_joueur.Height < this.ClientSize.Height) 
            {
                img_joueur.Top += speed; //idem droite
            }
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (gameOver) return;
            if(e.KeyCode == Keys.Left)
            {
                goLeft = true;
                facing = "left";
                img_joueur.Image = Properties.Resources.left; 
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = true;
                facing = "Right";
                img_joueur.Image = Properties.Resources.right;
            }
            if (e.KeyCode == Keys.Up)
            {
                
                facing = "Up";
                goUp = true;
                img_joueur.Image = Properties.Resources.up;
            }
            if (e.KeyCode == Keys.Down)
            {
                
                facing = "Down";
                goDown = true;
                img_joueur.Image = Properties.Resources.down;
            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;              
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = false;          
            }
            if (e.KeyCode == Keys.Up)
            {
                goUp = false;          
            }
            if (e.KeyCode == Keys.Down)
            {
                goDown = false;        
            }
            ShootBullet(facing);
        }
        private void ShootBullet(string Direction)
        {
            Bullet shootBullet = new Bullet();
            shootBullet.direction = Direction;
            shootBullet.bulletLeft = img_joueur.Left + (img_joueur.Width / 2); // abscisse apparition de la bullet en pixels = dist avec extremite gauche + demi largeur de l'image du joueur
            shootBullet.bulletTop = img_joueur.Top + (img_joueur.Height / 2); // ordonnée
            shootBullet.MakeBullet(this); // une meth de la classe bullet qui necissite un form en params !!
        }
        private void MakeZombies()
        {

        }
        private void RestartGame()
        {

        }
    }
}
