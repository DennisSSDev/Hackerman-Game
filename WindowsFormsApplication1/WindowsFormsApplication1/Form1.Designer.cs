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
            this.mapPiece = new System.Windows.Forms.PictureBox();
            this.nextBtn = new System.Windows.Forms.Button();
            this.backBtn = new System.Windows.Forms.Button();
            this.title = new System.Windows.Forms.Label();
            this.TopLeft = new System.Windows.Forms.RadioButton();
            this.TopRight = new System.Windows.Forms.RadioButton();
            this.Center = new System.Windows.Forms.RadioButton();
            this.BottomLeft = new System.Windows.Forms.RadioButton();
            this.BottomRight = new System.Windows.Forms.RadioButton();
            this.SaveBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.mapPiece)).BeginInit();
            this.SuspendLayout();
            // 
            // mapPiece
            // 
            this.mapPiece.Location = new System.Drawing.Point(195, 64);
            this.mapPiece.Name = "mapPiece";
            this.mapPiece.Size = new System.Drawing.Size(311, 310);
            this.mapPiece.TabIndex = 0;
            this.mapPiece.TabStop = false;
            // 
            // nextBtn
            // 
            this.nextBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nextBtn.Location = new System.Drawing.Point(533, 210);
            this.nextBtn.Name = "nextBtn";
            this.nextBtn.Size = new System.Drawing.Size(86, 36);
            this.nextBtn.TabIndex = 1;
            this.nextBtn.Text = "Next";
            this.nextBtn.UseVisualStyleBackColor = true;
            // 
            // backBtn
            // 
            this.backBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backBtn.Location = new System.Drawing.Point(75, 210);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(84, 36);
            this.backBtn.TabIndex = 2;
            this.backBtn.Text = "Prev";
            this.backBtn.UseVisualStyleBackColor = true;
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.Location = new System.Drawing.Point(290, 29);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(116, 22);
            this.title.TabIndex = 3;
            this.title.Text = "Code a piece";
            // 
            // TopLeft
            // 
            this.TopLeft.AutoSize = true;
            this.TopLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TopLeft.Location = new System.Drawing.Point(50, 414);
            this.TopLeft.Name = "TopLeft";
            this.TopLeft.Size = new System.Drawing.Size(86, 24);
            this.TopLeft.TabIndex = 4;
            this.TopLeft.TabStop = true;
            this.TopLeft.Text = "Top Left";
            this.TopLeft.UseVisualStyleBackColor = true;
            this.TopLeft.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // TopRight
            // 
            this.TopRight.AutoSize = true;
            this.TopRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TopRight.Location = new System.Drawing.Point(410, 414);
            this.TopRight.Name = "TopRight";
            this.TopRight.Size = new System.Drawing.Size(96, 24);
            this.TopRight.TabIndex = 5;
            this.TopRight.TabStop = true;
            this.TopRight.Text = "Top Right";
            this.TopRight.UseVisualStyleBackColor = true;
            this.TopRight.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // Center
            // 
            this.Center.AutoSize = true;
            this.Center.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Center.Location = new System.Drawing.Point(315, 414);
            this.Center.Name = "Center";
            this.Center.Size = new System.Drawing.Size(75, 24);
            this.Center.TabIndex = 6;
            this.Center.TabStop = true;
            this.Center.Text = "Center";
            this.Center.UseVisualStyleBackColor = true;
            this.Center.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // BottomLeft
            // 
            this.BottomLeft.AutoSize = true;
            this.BottomLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BottomLeft.Location = new System.Drawing.Point(166, 414);
            this.BottomLeft.Name = "BottomLeft";
            this.BottomLeft.Size = new System.Drawing.Size(111, 24);
            this.BottomLeft.TabIndex = 7;
            this.BottomLeft.TabStop = true;
            this.BottomLeft.Text = "Bottom Left";
            this.BottomLeft.UseVisualStyleBackColor = true;
            this.BottomLeft.CheckedChanged += new System.EventHandler(this.radioButton4_CheckedChanged);
            // 
            // BottomRight
            // 
            this.BottomRight.AutoSize = true;
            this.BottomRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BottomRight.Location = new System.Drawing.Point(533, 414);
            this.BottomRight.Name = "BottomRight";
            this.BottomRight.Size = new System.Drawing.Size(121, 24);
            this.BottomRight.TabIndex = 8;
            this.BottomRight.TabStop = true;
            this.BottomRight.Text = "Bottom Right";
            this.BottomRight.UseVisualStyleBackColor = true;
            this.BottomRight.CheckedChanged += new System.EventHandler(this.radioButton5_CheckedChanged);
            // 
            // SaveBtn
            // 
            this.SaveBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveBtn.Location = new System.Drawing.Point(299, 489);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(91, 41);
            this.SaveBtn.TabIndex = 9;
            this.SaveBtn.Text = "Save";
            this.SaveBtn.UseVisualStyleBackColor = true;
            // 
            // externalEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 591);
            this.Controls.Add(this.SaveBtn);
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
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.externalEditor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mapPiece)).EndInit();
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
        private System.Windows.Forms.Button SaveBtn;
    }
}

