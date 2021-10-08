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

        bool goLeft, goRight, goUp, goDown, gameOver = false;
        string facing = "up";
        int playerHealth = 100;
        int speed = 10;
        int ammo = 10;
        int zombieSpeed = 3;
        Random randNum = new Random();
        int score = 0;
        List<PictureBox> zombieList = new List<PictureBox>();


        public Form1()
        {
            InitializeComponent();
            RestartGame();
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
            {
                gameOver = true;
                img_joueur.Image = Properties.Resources.dead;
                GameTimer.Stop();
            }
                
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
            if(goUp == true && img_joueur.Top > 48)// idem avec le haut du form
            {
                img_joueur.Top -= speed;
            }
            if (goDown == true && img_joueur.Top + img_joueur.Height < this.ClientSize.Height) 
            {
                img_joueur.Top += speed; //idem droite
            }

            foreach(Control x in this.Controls) // parcours tous les controls du control cleint (cad tous ce qui est visuel sur la fenetre client principale)
            {
                if(x is PictureBox && (string)x.Tag == "ammo") // si ce control est une picturebox et que son tag est ammo
                {
                    if (img_joueur.Bounds.IntersectsWith(x.Bounds)) // quand la picbox du joueur intersecte avec celle de l'ammo
                    {
                        this.Controls.Remove(x); // la picbox ammo est virée (ce qui signifie que le joueur l'a prise)
                        ((PictureBox)x).Dispose(); // on caste en picbox au cas ou x n'en est pas une, car dispose only works with picbox
                        ammo += 10; // recharge !
                    }
                }

                if(x is PictureBox && (string)x.Tag == "zombie")
                {
                    //des conditions comparant les coords de chaque zombie avec celles du joueur, pour que le zombie puisse suivre le joueur
                    if(x.Left > img_joueur.Left)
                    {
                        x.Left -= zombieSpeed;
                        ((PictureBox)x).Image = Properties.Resources.zleft;
                    }
                    if (x.Left < img_joueur.Left)
                    {
                        x.Left += zombieSpeed;
                        ((PictureBox)x).Image = Properties.Resources.zright;
                    }
                    if (x.Top > img_joueur.Top)
                    {
                        x.Top -= zombieSpeed;
                        ((PictureBox)x).Image = Properties.Resources.zdown;
                    }
                    if (x.Top < img_joueur.Top)
                    {
                        x.Top += zombieSpeed;
                        ((PictureBox)x).Image = Properties.Resources.zup;
                    }
                }


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
                facing = "right";
                img_joueur.Image = Properties.Resources.right;
            }
            if (e.KeyCode == Keys.Up)
            {
                
                facing = "up";
                goUp = true;
                img_joueur.Image = Properties.Resources.up;
            }
            if (e.KeyCode == Keys.Down)
            {
                
                facing = "down";
                goDown = true;
                img_joueur.Image = Properties.Resources.down;
            }
        }

        private void img_joueur_Click(object sender, EventArgs e)
        {

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
            if(e.KeyCode == Keys.Space && ammo > 0)
            {
                ammo--;
                ShootBullet(facing);

                if(ammo < 1)
                {
                    DropAmmo();
                }
                
            }
        }
        private void ShootBullet(string direction)
        {
            Bullet shootBullet = new Bullet();
            shootBullet.direction = direction;
            shootBullet.bulletLeft = img_joueur.Left + (img_joueur.Width / 2); // abscisse apparition de la bullet en pixels = dist avec extremite gauche + demi largeur de l'image du joueur
            shootBullet.bulletTop = img_joueur.Top + (img_joueur.Height / 2); // ordonnée
            shootBullet.MakeBullet(this); // une meth de la classe bullet qui necissite un form en params !!
        }
        private void MakeZombies()
        {
            PictureBox zombie = new PictureBox();
            zombie.Tag = "zombie";
            zombie.Image = Properties.Resources.zdown;
            zombie.Left = randNum.Next(0, 900);
            zombie.Top = randNum.Next(0, 800);
            zombie.SizeMode = PictureBoxSizeMode.AutoSize;
            zombieList.Add(zombie);
            this.Controls.Add(zombie);
            img_joueur.BringToFront();

        }

        private void DropAmmo()
        {
            PictureBox ammo = new PictureBox();
            ammo.Image = Properties.Resources.ammo_Image;
            ammo.SizeMode = PictureBoxSizeMode.AutoSize;
            ammo.Left = randNum.Next(10, this.ClientSize.Width - ammo.Width); // abscisse de pos aleatoire de l'ammo contenu dans la fenetre client en prenant compte de la largeur de l'image ammo 
            ammo.Top = randNum.Next(10, this.ClientSize.Height - ammo.Height); // ordonnée de pos aleatoire de l'ammo contenu dans la fenetre client en prenant compte de la longueur de l'image ammo
            ammo.Tag = "ammo";
            this.Controls.Add(ammo); // ajouter l img ammo au client (form, fenetre, winform)
            ammo.BringToFront();
            img_joueur.BringToFront();// quand joueur passe sur ammo, il passe au 1er plan
        }

        private void RestartGame()
        {
            img_joueur.Image = Properties.Resources.up;
            foreach(PictureBox i in zombieList)
            {
                this.Controls.Remove(i);
            }
            zombieList.Clear();
            for(int i=0; i<3; i++)
            {
                MakeZombies();
            }
            goUp = false;
            goDown = false;
            goLeft = false;
            goRight = false;

            playerHealth = 100;
            score = 0;
            ammo = 10;
        }
    }
}
