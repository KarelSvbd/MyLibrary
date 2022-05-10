namespace MyLibrary
{
    partial class frmCollectionLivres
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblRecherche = new System.Windows.Forms.Label();
            this.tbxRecherche = new System.Windows.Forms.TextBox();
            this.btnAjouter = new System.Windows.Forms.Button();
            this.btnModifier = new System.Windows.Forms.Button();
            this.btnSupprimer = new System.Windows.Forms.Button();
            this.lblAuteur = new System.Windows.Forms.Label();
            this.lblTitre = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxAuteur = new System.Windows.Forms.TextBox();
            this.tbxTitre = new System.Windows.Forms.TextBox();
            this.btnImporterImage = new System.Windows.Forms.Button();
            this.flpListCard = new System.Windows.Forms.FlowLayoutPanel();
            this.pbxImageAjouter = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbxImageAjouter)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRecherche
            // 
            this.lblRecherche.AutoSize = true;
            this.lblRecherche.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecherche.Location = new System.Drawing.Point(12, 9);
            this.lblRecherche.Name = "lblRecherche";
            this.lblRecherche.Size = new System.Drawing.Size(88, 20);
            this.lblRecherche.TabIndex = 1;
            this.lblRecherche.Text = "recherche :";
            // 
            // tbxRecherche
            // 
            this.tbxRecherche.Location = new System.Drawing.Point(106, 12);
            this.tbxRecherche.Name = "tbxRecherche";
            this.tbxRecherche.Size = new System.Drawing.Size(282, 20);
            this.tbxRecherche.TabIndex = 3;
            this.tbxRecherche.TextChanged += new System.EventHandler(this.tbxRecherche_TextChanged);
            // 
            // btnAjouter
            // 
            this.btnAjouter.Enabled = false;
            this.btnAjouter.Location = new System.Drawing.Point(954, 746);
            this.btnAjouter.Name = "btnAjouter";
            this.btnAjouter.Size = new System.Drawing.Size(337, 23);
            this.btnAjouter.TabIndex = 5;
            this.btnAjouter.Text = "Ajouter";
            this.btnAjouter.UseVisualStyleBackColor = true;
            this.btnAjouter.Click += new System.EventHandler(this.btnAjouter_Click);
            // 
            // btnModifier
            // 
            this.btnModifier.Enabled = false;
            this.btnModifier.Location = new System.Drawing.Point(954, 775);
            this.btnModifier.Name = "btnModifier";
            this.btnModifier.Size = new System.Drawing.Size(337, 23);
            this.btnModifier.TabIndex = 6;
            this.btnModifier.Text = "Modifier";
            this.btnModifier.UseVisualStyleBackColor = true;
            this.btnModifier.Click += new System.EventHandler(this.btnModifier_Click);
            // 
            // btnSupprimer
            // 
            this.btnSupprimer.Enabled = false;
            this.btnSupprimer.Location = new System.Drawing.Point(954, 833);
            this.btnSupprimer.Name = "btnSupprimer";
            this.btnSupprimer.Size = new System.Drawing.Size(337, 23);
            this.btnSupprimer.TabIndex = 7;
            this.btnSupprimer.Text = "Supprimer";
            this.btnSupprimer.UseVisualStyleBackColor = true;
            this.btnSupprimer.Click += new System.EventHandler(this.btnSupprimer_Click);
            // 
            // lblAuteur
            // 
            this.lblAuteur.AutoSize = true;
            this.lblAuteur.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAuteur.Location = new System.Drawing.Point(950, 47);
            this.lblAuteur.Name = "lblAuteur";
            this.lblAuteur.Size = new System.Drawing.Size(65, 20);
            this.lblAuteur.TabIndex = 8;
            this.lblAuteur.Text = "Auteur :";
            // 
            // lblTitre
            // 
            this.lblTitre.AutoSize = true;
            this.lblTitre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitre.Location = new System.Drawing.Point(950, 109);
            this.lblTitre.Name = "lblTitre";
            this.lblTitre.Size = new System.Drawing.Size(48, 20);
            this.lblTitre.TabIndex = 9;
            this.lblTitre.Text = "Titre :";
            this.lblTitre.Click += new System.EventHandler(this.lblTitre_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(950, 173);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Image :";
            // 
            // tbxAuteur
            // 
            this.tbxAuteur.Location = new System.Drawing.Point(954, 70);
            this.tbxAuteur.Name = "tbxAuteur";
            this.tbxAuteur.Size = new System.Drawing.Size(337, 20);
            this.tbxAuteur.TabIndex = 11;
            this.tbxAuteur.TextChanged += new System.EventHandler(this.tbxAuteur_TextChanged);
            // 
            // tbxTitre
            // 
            this.tbxTitre.Location = new System.Drawing.Point(954, 132);
            this.tbxTitre.Name = "tbxTitre";
            this.tbxTitre.Size = new System.Drawing.Size(337, 20);
            this.tbxTitre.TabIndex = 12;
            this.tbxTitre.TextChanged += new System.EventHandler(this.tbxTitre_TextChanged);
            // 
            // btnImporterImage
            // 
            this.btnImporterImage.Location = new System.Drawing.Point(954, 622);
            this.btnImporterImage.Name = "btnImporterImage";
            this.btnImporterImage.Size = new System.Drawing.Size(337, 23);
            this.btnImporterImage.TabIndex = 13;
            this.btnImporterImage.Text = "Importer";
            this.btnImporterImage.UseVisualStyleBackColor = true;
            this.btnImporterImage.Click += new System.EventHandler(this.btnImporterImage_Click);
            // 
            // flpListCard
            // 
            this.flpListCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpListCard.Location = new System.Drawing.Point(12, 47);
            this.flpListCard.Name = "flpListCard";
            this.flpListCard.Size = new System.Drawing.Size(936, 809);
            this.flpListCard.TabIndex = 15;
            this.flpListCard.Click += new System.EventHandler(this.flpListCard_Click);
            // 
            // pbxImageAjouter
            // 
            this.pbxImageAjouter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbxImageAjouter.Location = new System.Drawing.Point(954, 196);
            this.pbxImageAjouter.Name = "pbxImageAjouter";
            this.pbxImageAjouter.Size = new System.Drawing.Size(337, 420);
            this.pbxImageAjouter.TabIndex = 17;
            this.pbxImageAjouter.TabStop = false;
            this.pbxImageAjouter.Click += new System.EventHandler(this.pbxImageAjouter_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1070, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 20);
            this.label1.TabIndex = 18;
            this.label1.Text = "Modifications";
            // 
            // frmCollectionLivres
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1299, 878);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbxImageAjouter);
            this.Controls.Add(this.flpListCard);
            this.Controls.Add(this.btnImporterImage);
            this.Controls.Add(this.tbxTitre);
            this.Controls.Add(this.tbxAuteur);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblTitre);
            this.Controls.Add(this.lblAuteur);
            this.Controls.Add(this.btnSupprimer);
            this.Controls.Add(this.btnModifier);
            this.Controls.Add(this.btnAjouter);
            this.Controls.Add(this.tbxRecherche);
            this.Controls.Add(this.lblRecherche);
            this.Name = "frmCollectionLivres";
            this.Text = "Collection de livres";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmCollectionLivres_FormClosed);
            this.Load += new System.EventHandler(this.frmCollectionLivres_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbxImageAjouter)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblRecherche;
        private System.Windows.Forms.TextBox tbxRecherche;
        private System.Windows.Forms.Button btnAjouter;
        private System.Windows.Forms.Button btnModifier;
        private System.Windows.Forms.Button btnSupprimer;
        private System.Windows.Forms.Label lblAuteur;
        private System.Windows.Forms.Label lblTitre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxAuteur;
        private System.Windows.Forms.TextBox tbxTitre;
        private System.Windows.Forms.Button btnImporterImage;
        private System.Windows.Forms.FlowLayoutPanel flpListCard;
        private System.Windows.Forms.PictureBox pbxImageAjouter;
        private System.Windows.Forms.Label label1;
    }
}