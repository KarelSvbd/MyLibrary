namespace WindowsFormsApp1
{
    partial class frmCollectionReferences
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
            this.lblTitreLivre = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAjouter = new System.Windows.Forms.Button();
            this.lblTxtReference = new System.Windows.Forms.Label();
            this.btnModifier = new System.Windows.Forms.Button();
            this.btnSupprimer = new System.Windows.Forms.Button();
            this.pbxImage = new System.Windows.Forms.PictureBox();
            this.btnImporterImage = new System.Windows.Forms.Button();
            this.tbxTitre = new System.Windows.Forms.TextBox();
            this.tbxAuteur = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTitre = new System.Windows.Forms.Label();
            this.lblAuteur = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxDescription = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxLivre = new System.Windows.Forms.ComboBox();
            this.cbxType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbxImage)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitreLivre
            // 
            this.lblTitreLivre.AutoSize = true;
            this.lblTitreLivre.Font = new System.Drawing.Font("MV Boli", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitreLivre.ForeColor = System.Drawing.Color.Firebrick;
            this.lblTitreLivre.Location = new System.Drawing.Point(361, 9);
            this.lblTitreLivre.Name = "lblTitreLivre";
            this.lblTitreLivre.Size = new System.Drawing.Size(128, 31);
            this.lblTitreLivre.TabIndex = 0;
            this.lblTitreLivre.Text = "Titre livre";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 60);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(888, 645);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // btnAjouter
            // 
            this.btnAjouter.Enabled = false;
            this.btnAjouter.Location = new System.Drawing.Point(962, 609);
            this.btnAjouter.Name = "btnAjouter";
            this.btnAjouter.Size = new System.Drawing.Size(255, 23);
            this.btnAjouter.TabIndex = 4;
            this.btnAjouter.Text = "Ajouter";
            this.btnAjouter.UseVisualStyleBackColor = true;
            this.btnAjouter.Click += new System.EventHandler(this.btnAjouter_Click);
            // 
            // lblTxtReference
            // 
            this.lblTxtReference.AutoSize = true;
            this.lblTxtReference.Font = new System.Drawing.Font("MV Boli", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTxtReference.Location = new System.Drawing.Point(950, 9);
            this.lblTxtReference.Name = "lblTxtReference";
            this.lblTxtReference.Size = new System.Drawing.Size(267, 31);
            this.lblTxtReference.TabIndex = 5;
            this.lblTxtReference.Text = "Gestion des références";
            this.lblTxtReference.Click += new System.EventHandler(this.lblTxtReference_Click);
            // 
            // btnModifier
            // 
            this.btnModifier.Enabled = false;
            this.btnModifier.Location = new System.Drawing.Point(962, 638);
            this.btnModifier.Name = "btnModifier";
            this.btnModifier.Size = new System.Drawing.Size(255, 23);
            this.btnModifier.TabIndex = 6;
            this.btnModifier.Text = "Modifier";
            this.btnModifier.UseVisualStyleBackColor = true;
            // 
            // btnSupprimer
            // 
            this.btnSupprimer.Enabled = false;
            this.btnSupprimer.Location = new System.Drawing.Point(962, 682);
            this.btnSupprimer.Name = "btnSupprimer";
            this.btnSupprimer.Size = new System.Drawing.Size(255, 23);
            this.btnSupprimer.TabIndex = 7;
            this.btnSupprimer.Text = "Supprimer";
            this.btnSupprimer.UseVisualStyleBackColor = true;
            this.btnSupprimer.Click += new System.EventHandler(this.btnSupprimer_Click);
            // 
            // pbxImage
            // 
            this.pbxImage.Location = new System.Drawing.Point(962, 236);
            this.pbxImage.Name = "pbxImage";
            this.pbxImage.Size = new System.Drawing.Size(255, 125);
            this.pbxImage.TabIndex = 24;
            this.pbxImage.TabStop = false;
            this.pbxImage.Click += new System.EventHandler(this.pbxImageMusique_Click);
            // 
            // btnImporterImage
            // 
            this.btnImporterImage.Enabled = false;
            this.btnImporterImage.Location = new System.Drawing.Point(962, 379);
            this.btnImporterImage.Name = "btnImporterImage";
            this.btnImporterImage.Size = new System.Drawing.Size(255, 23);
            this.btnImporterImage.TabIndex = 23;
            this.btnImporterImage.Text = "Importer";
            this.btnImporterImage.UseVisualStyleBackColor = true;
            this.btnImporterImage.Click += new System.EventHandler(this.btnImporterImage_Click);
            // 
            // tbxTitre
            // 
            this.tbxTitre.Enabled = false;
            this.tbxTitre.Location = new System.Drawing.Point(962, 191);
            this.tbxTitre.Name = "tbxTitre";
            this.tbxTitre.Size = new System.Drawing.Size(255, 20);
            this.tbxTitre.TabIndex = 22;
            this.tbxTitre.TextChanged += new System.EventHandler(this.tbxTitreMusique_TextChanged);
            // 
            // tbxAuteur
            // 
            this.tbxAuteur.Enabled = false;
            this.tbxAuteur.Location = new System.Drawing.Point(962, 146);
            this.tbxAuteur.Name = "tbxAuteur";
            this.tbxAuteur.Size = new System.Drawing.Size(255, 20);
            this.tbxAuteur.TabIndex = 21;
            this.tbxAuteur.TextChanged += new System.EventHandler(this.tbxAuteurMusique_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(958, 214);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 20);
            this.label2.TabIndex = 20;
            this.label2.Text = "Image :";
            // 
            // lblTitre
            // 
            this.lblTitre.AutoSize = true;
            this.lblTitre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitre.Location = new System.Drawing.Point(958, 169);
            this.lblTitre.Name = "lblTitre";
            this.lblTitre.Size = new System.Drawing.Size(48, 20);
            this.lblTitre.TabIndex = 19;
            this.lblTitre.Text = "Titre :";
            // 
            // lblAuteur
            // 
            this.lblAuteur.AutoSize = true;
            this.lblAuteur.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAuteur.Location = new System.Drawing.Point(958, 123);
            this.lblAuteur.Name = "lblAuteur";
            this.lblAuteur.Size = new System.Drawing.Size(65, 20);
            this.lblAuteur.TabIndex = 18;
            this.lblAuteur.Text = "Auteur :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(958, 466);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 20);
            this.label1.TabIndex = 25;
            this.label1.Text = "Description :";
            // 
            // tbxDescription
            // 
            this.tbxDescription.Enabled = false;
            this.tbxDescription.Location = new System.Drawing.Point(962, 489);
            this.tbxDescription.Multiline = true;
            this.tbxDescription.Name = "tbxDescription";
            this.tbxDescription.Size = new System.Drawing.Size(252, 78);
            this.tbxDescription.TabIndex = 26;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(958, 414);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 20);
            this.label3.TabIndex = 27;
            this.label3.Text = "Livre :";
            // 
            // cbxLivre
            // 
            this.cbxLivre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxLivre.Enabled = false;
            this.cbxLivre.FormattingEnabled = true;
            this.cbxLivre.Location = new System.Drawing.Point(962, 438);
            this.cbxLivre.Name = "cbxLivre";
            this.cbxLivre.Size = new System.Drawing.Size(255, 21);
            this.cbxLivre.TabIndex = 28;
            // 
            // cbxType
            // 
            this.cbxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxType.FormattingEnabled = true;
            this.cbxType.Location = new System.Drawing.Point(962, 86);
            this.cbxType.Name = "cbxType";
            this.cbxType.Size = new System.Drawing.Size(255, 21);
            this.cbxType.TabIndex = 30;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(958, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 20);
            this.label4.TabIndex = 29;
            this.label4.Text = "Type :";
            // 
            // frmCollectionReferences
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1243, 717);
            this.Controls.Add(this.cbxType);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbxLivre);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbxDescription);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbxImage);
            this.Controls.Add(this.btnImporterImage);
            this.Controls.Add(this.tbxTitre);
            this.Controls.Add(this.tbxAuteur);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblTitre);
            this.Controls.Add(this.lblAuteur);
            this.Controls.Add(this.btnSupprimer);
            this.Controls.Add(this.btnModifier);
            this.Controls.Add(this.lblTxtReference);
            this.Controls.Add(this.btnAjouter);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.lblTitreLivre);
            this.Name = "frmCollectionReferences";
            this.Text = "Références ";
            ((System.ComponentModel.ISupportInitialize)(this.pbxImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitreLivre;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnAjouter;
        private System.Windows.Forms.Label lblTxtReference;
        private System.Windows.Forms.Button btnModifier;
        private System.Windows.Forms.Button btnSupprimer;
        private System.Windows.Forms.PictureBox pbxImage;
        private System.Windows.Forms.Button btnImporterImage;
        private System.Windows.Forms.TextBox tbxTitre;
        private System.Windows.Forms.TextBox tbxAuteur;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTitre;
        private System.Windows.Forms.Label lblAuteur;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxDescription;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxLivre;
        private System.Windows.Forms.ComboBox cbxType;
        private System.Windows.Forms.Label label4;
    }
}