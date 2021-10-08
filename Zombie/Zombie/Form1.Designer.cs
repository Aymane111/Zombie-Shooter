namespace Zombie
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lab_ammo = new System.Windows.Forms.Label();
            this.lab_kills = new System.Windows.Forms.Label();
            this.lab_health = new System.Windows.Forms.Label();
            this.bar_prog = new System.Windows.Forms.ProgressBar();
            this.img_joueur = new System.Windows.Forms.PictureBox();
            this.GameTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.img_joueur)).BeginInit();
            this.SuspendLayout();
            // 
            // lab_ammo
            // 
            this.lab_ammo.AutoSize = true;
            this.lab_ammo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_ammo.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lab_ammo.Location = new System.Drawing.Point(12, 18);
            this.lab_ammo.Name = "lab_ammo";
            this.lab_ammo.Size = new System.Drawing.Size(97, 24);
            this.lab_ammo.TabIndex = 2;
            this.lab_ammo.Text = "AMMO: 0";
            // 
            // lab_kills
            // 
            this.lab_kills.AutoSize = true;
            this.lab_kills.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_kills.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lab_kills.Location = new System.Drawing.Point(376, 18);
            this.lab_kills.Name = "lab_kills";
            this.lab_kills.Size = new System.Drawing.Size(86, 24);
            this.lab_kills.TabIndex = 3;
            this.lab_kills.Text = "KILLS: 0";
            // 
            // lab_health
            // 
            this.lab_health.AutoSize = true;
            this.lab_health.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_health.ForeColor = System.Drawing.Color.AliceBlue;
            this.lab_health.Location = new System.Drawing.Point(687, 18);
            this.lab_health.Name = "lab_health";
            this.lab_health.Size = new System.Drawing.Size(98, 24);
            this.lab_health.TabIndex = 4;
            this.lab_health.Text = "HEALTH:";
            this.lab_health.Click += new System.EventHandler(this.label3_Click);
            // 
            // bar_prog
            // 
            this.bar_prog.BackColor = System.Drawing.SystemColors.Window;
            this.bar_prog.Location = new System.Drawing.Point(791, 18);
            this.bar_prog.Name = "bar_prog";
            this.bar_prog.Size = new System.Drawing.Size(121, 24);
            this.bar_prog.TabIndex = 5;
            this.bar_prog.Value = 100;
            // 
            // img_joueur
            // 
            this.img_joueur.Image = global::Zombie.Properties.Resources.up;
            this.img_joueur.Location = new System.Drawing.Point(391, 549);
            this.img_joueur.Name = "img_joueur";
            this.img_joueur.Size = new System.Drawing.Size(71, 100);
            this.img_joueur.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.img_joueur.TabIndex = 6;
            this.img_joueur.TabStop = false;
            // 
            // GameTimer
            // 
            this.GameTimer.Enabled = true;
            this.GameTimer.Interval = 20;
            this.GameTimer.Tick += new System.EventHandler(this.MainTimerEvent);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(924, 661);
            this.Controls.Add(this.img_joueur);
            this.Controls.Add(this.bar_prog);
            this.Controls.Add(this.lab_health);
            this.Controls.Add(this.lab_kills);
            this.Controls.Add(this.lab_ammo);
            this.Name = "Form1";
            this.Text = "Zombie Shooter";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyIsDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyIsUp);
            ((System.ComponentModel.ISupportInitialize)(this.img_joueur)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lab_ammo;
        private System.Windows.Forms.Label lab_kills;
        private System.Windows.Forms.Label lab_health;
        private System.Windows.Forms.ProgressBar bar_prog;
        private System.Windows.Forms.PictureBox img_joueur;
        private System.Windows.Forms.Timer GameTimer;
    }
}

