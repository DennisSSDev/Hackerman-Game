namespace WindowsFormsApplication1
{
    partial class externalEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(externalEditor));
            this.mapPiece = new System.Windows.Forms.PictureBox();
            this.nextBtn = new System.Windows.Forms.Button();
            this.backBtn = new System.Windows.Forms.Button();
            this.title = new System.Windows.Forms.Label();
            this.TopLeft = new System.Windows.Forms.RadioButton();
            this.TopRight = new System.Windows.Forms.RadioButton();
            this.Center = new System.Windows.Forms.RadioButton();
            this.BottomLeft = new System.Windows.Forms.RadioButton();
            this.BottomRight = new System.Windows.Forms.RadioButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.mapPiece)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // mapPiece
            // 
            this.mapPiece.BackColor = System.Drawing.Color.Black;
            this.mapPiece.Location = new System.Drawing.Point(195, 64);
            this.mapPiece.Name = "mapPiece";
            this.mapPiece.Size = new System.Drawing.Size(311, 310);
            this.mapPiece.TabIndex = 0;
            this.mapPiece.TabStop = false;
            // 
            // nextBtn
            // 
            this.nextBtn.BackColor = System.Drawing.SystemColors.Desktop;
            this.nextBtn.Font = new System.Drawing.Font("Bauhaus 93", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nextBtn.ForeColor = System.Drawing.Color.Lime;
            this.nextBtn.Location = new System.Drawing.Point(533, 210);
            this.nextBtn.Name = "nextBtn";
            this.nextBtn.Size = new System.Drawing.Size(86, 36);
            this.nextBtn.TabIndex = 1;
            this.nextBtn.Text = "Save";
            this.nextBtn.UseVisualStyleBackColor = false;
            this.nextBtn.Click += new System.EventHandler(this.nextBtn_Click);
            // 
            // backBtn
            // 
            this.backBtn.BackColor = System.Drawing.SystemColors.Desktop;
            this.backBtn.Font = new System.Drawing.Font("Bauhaus 93", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backBtn.ForeColor = System.Drawing.Color.Lime;
            this.backBtn.Location = new System.Drawing.Point(75, 210);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(84, 36);
            this.backBtn.TabIndex = 2;
            this.backBtn.Text = "Exit";
            this.backBtn.UseVisualStyleBackColor = false;
            this.backBtn.Click += new System.EventHandler(this.Exit_Clicked);
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.BackColor = System.Drawing.SystemColors.Desktop;
            this.title.Font = new System.Drawing.Font("Bauhaus 93", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.ForeColor = System.Drawing.Color.Lime;
            this.title.Location = new System.Drawing.Point(255, 15);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(211, 36);
            this.title.TabIndex = 3;
            this.title.Text = "Code a piece";
            // 
            // TopLeft
            // 
            this.TopLeft.AutoSize = true;
            this.TopLeft.BackColor = System.Drawing.SystemColors.Desktop;
            this.TopLeft.Font = new System.Drawing.Font("Bauhaus 93", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TopLeft.ForeColor = System.Drawing.Color.Lime;
            this.TopLeft.Location = new System.Drawing.Point(50, 414);
            this.TopLeft.Name = "TopLeft";
            this.TopLeft.Size = new System.Drawing.Size(81, 22);
            this.TopLeft.TabIndex = 4;
            this.TopLeft.TabStop = true;
            this.TopLeft.Text = "Top Left";
            this.TopLeft.UseVisualStyleBackColor = false;
            this.TopLeft.CheckedChanged += new System.EventHandler(this.TopLeft_CheckedChanged);
            // 
            // TopRight
            // 
            this.TopRight.AutoSize = true;
            this.TopRight.BackColor = System.Drawing.SystemColors.ControlText;
            this.TopRight.Font = new System.Drawing.Font("Bauhaus 93", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TopRight.ForeColor = System.Drawing.Color.Lime;
            this.TopRight.Location = new System.Drawing.Point(410, 414);
            this.TopRight.Name = "TopRight";
            this.TopRight.Size = new System.Drawing.Size(94, 22);
            this.TopRight.TabIndex = 5;
            this.TopRight.TabStop = true;
            this.TopRight.Text = "Top Right";
            this.TopRight.UseVisualStyleBackColor = false;
            this.TopRight.CheckedChanged += new System.EventHandler(this.TopRight_CheckedChanged);
            // 
            // Center
            // 
            this.Center.AutoSize = true;
            this.Center.BackColor = System.Drawing.SystemColors.Desktop;
            this.Center.Font = new System.Drawing.Font("Bauhaus 93", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Center.ForeColor = System.Drawing.Color.Lime;
            this.Center.Location = new System.Drawing.Point(315, 414);
            this.Center.Name = "Center";
            this.Center.Size = new System.Drawing.Size(75, 22);
            this.Center.TabIndex = 6;
            this.Center.TabStop = true;
            this.Center.Text = "Center";
            this.Center.UseVisualStyleBackColor = false;
            this.Center.CheckedChanged += new System.EventHandler(this.Center_CheckedChanged);
            // 
            // BottomLeft
            // 
            this.BottomLeft.AutoSize = true;
            this.BottomLeft.BackColor = System.Drawing.SystemColors.Desktop;
            this.BottomLeft.Font = new System.Drawing.Font("Bauhaus 93", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BottomLeft.ForeColor = System.Drawing.Color.Lime;
            this.BottomLeft.Location = new System.Drawing.Point(166, 414);
            this.BottomLeft.Name = "BottomLeft";
            this.BottomLeft.Size = new System.Drawing.Size(104, 22);
            this.BottomLeft.TabIndex = 7;
            this.BottomLeft.TabStop = true;
            this.BottomLeft.Text = "Bottom Left";
            this.BottomLeft.UseVisualStyleBackColor = false;
            this.BottomLeft.CheckedChanged += new System.EventHandler(this.BottomLeft_CheckedChanged);
            // 
            // BottomRight
            // 
            this.BottomRight.AutoSize = true;
            this.BottomRight.BackColor = System.Drawing.SystemColors.Desktop;
            this.BottomRight.Font = new System.Drawing.Font("Bauhaus 93", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BottomRight.ForeColor = System.Drawing.Color.Lime;
            this.BottomRight.Location = new System.Drawing.Point(533, 414);
            this.BottomRight.Name = "BottomRight";
            this.BottomRight.Size = new System.Drawing.Size(117, 22);
            this.BottomRight.TabIndex = 8;
            this.BottomRight.TabStop = true;
            this.BottomRight.Text = "Bottom Right";
            this.BottomRight.UseVisualStyleBackColor = false;
            this.BottomRight.CheckedChanged += new System.EventHandler(this.BottomRight_CheckedChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Lime;
            this.pictureBox1.Location = new System.Drawing.Point(701, 586);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(51, 50);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // externalEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(706, 591);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.BottomRight);
            this.Controls.Add(this.BottomLeft);
            this.Controls.Add(this.Center);
            this.Controls.Add(this.TopRight);
            this.Controls.Add(this.TopLeft);
            this.Controls.Add(this.title);
            this.Controls.Add(this.backBtn);
            this.Controls.Add(this.nextBtn);
            this.Controls.Add(this.mapPiece);
            this.Name = "externalEditor";
            this.ShowIcon = false;
            this.Text = "Editor";
            this.Load += new System.EventHandler(this.externalEditor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mapPiece)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox mapPiece;
        private System.Windows.Forms.Button nextBtn;
        private System.Windows.Forms.Button backBtn;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.RadioButton TopLeft;
        private System.Windows.Forms.RadioButton TopRight;
        private System.Windows.Forms.RadioButton Center;
        private System.Windows.Forms.RadioButton BottomLeft;
        private System.Windows.Forms.RadioButton BottomRight;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

