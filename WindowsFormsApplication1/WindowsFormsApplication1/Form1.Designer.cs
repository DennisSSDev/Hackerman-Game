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
            ((System.ComponentModel.ISupportInitialize)(this.mapPiece)).BeginInit();
            this.SuspendLayout();
            // 
            // mapPiece
            // 
            this.mapPiece.Location = new System.Drawing.Point(260, 79);
            this.mapPiece.Margin = new System.Windows.Forms.Padding(4);
            this.mapPiece.Name = "mapPiece";
            this.mapPiece.Size = new System.Drawing.Size(415, 382);
            this.mapPiece.TabIndex = 0;
            this.mapPiece.TabStop = false;
            // 
            // nextBtn
            // 
            this.nextBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nextBtn.Location = new System.Drawing.Point(711, 258);
            this.nextBtn.Margin = new System.Windows.Forms.Padding(4);
            this.nextBtn.Name = "nextBtn";
            this.nextBtn.Size = new System.Drawing.Size(115, 44);
            this.nextBtn.TabIndex = 1;
            this.nextBtn.Text = "Save";
            this.nextBtn.UseVisualStyleBackColor = true;
            this.nextBtn.Click += new System.EventHandler(this.nextBtn_Click);
            // 
            // backBtn
            // 
            this.backBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backBtn.Location = new System.Drawing.Point(100, 258);
            this.backBtn.Margin = new System.Windows.Forms.Padding(4);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(112, 44);
            this.backBtn.TabIndex = 2;
            this.backBtn.Text = "Exit";
            this.backBtn.UseVisualStyleBackColor = true;
            this.backBtn.Click += new System.EventHandler(this.Exit_Clicked);
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.Location = new System.Drawing.Point(387, 36);
            this.title.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(140, 26);
            this.title.TabIndex = 3;
            this.title.Text = "Code a piece";
            // 
            // TopLeft
            // 
            this.TopLeft.AutoSize = true;
            this.TopLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TopLeft.Location = new System.Drawing.Point(67, 510);
            this.TopLeft.Margin = new System.Windows.Forms.Padding(4);
            this.TopLeft.Name = "TopLeft";
            this.TopLeft.Size = new System.Drawing.Size(105, 29);
            this.TopLeft.TabIndex = 4;
            this.TopLeft.TabStop = true;
            this.TopLeft.Text = "Top Left";
            this.TopLeft.UseVisualStyleBackColor = true;
            this.TopLeft.CheckedChanged += new System.EventHandler(this.TopLeft_CheckedChanged);
            // 
            // TopRight
            // 
            this.TopRight.AutoSize = true;
            this.TopRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TopRight.Location = new System.Drawing.Point(547, 510);
            this.TopRight.Margin = new System.Windows.Forms.Padding(4);
            this.TopRight.Name = "TopRight";
            this.TopRight.Size = new System.Drawing.Size(117, 29);
            this.TopRight.TabIndex = 5;
            this.TopRight.TabStop = true;
            this.TopRight.Text = "Top Right";
            this.TopRight.UseVisualStyleBackColor = true;
            this.TopRight.CheckedChanged += new System.EventHandler(this.TopRight_CheckedChanged);
            // 
            // Center
            // 
            this.Center.AutoSize = true;
            this.Center.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Center.Location = new System.Drawing.Point(420, 510);
            this.Center.Margin = new System.Windows.Forms.Padding(4);
            this.Center.Name = "Center";
            this.Center.Size = new System.Drawing.Size(92, 29);
            this.Center.TabIndex = 6;
            this.Center.TabStop = true;
            this.Center.Text = "Center";
            this.Center.UseVisualStyleBackColor = true;
            this.Center.CheckedChanged += new System.EventHandler(this.Center_CheckedChanged);
            // 
            // BottomLeft
            // 
            this.BottomLeft.AutoSize = true;
            this.BottomLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BottomLeft.Location = new System.Drawing.Point(221, 510);
            this.BottomLeft.Margin = new System.Windows.Forms.Padding(4);
            this.BottomLeft.Name = "BottomLeft";
            this.BottomLeft.Size = new System.Drawing.Size(131, 29);
            this.BottomLeft.TabIndex = 7;
            this.BottomLeft.TabStop = true;
            this.BottomLeft.Text = "Bottom Left";
            this.BottomLeft.UseVisualStyleBackColor = true;
            this.BottomLeft.CheckedChanged += new System.EventHandler(this.BottomLeft_CheckedChanged);
            // 
            // BottomRight
            // 
            this.BottomRight.AutoSize = true;
            this.BottomRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BottomRight.Location = new System.Drawing.Point(711, 510);
            this.BottomRight.Margin = new System.Windows.Forms.Padding(4);
            this.BottomRight.Name = "BottomRight";
            this.BottomRight.Size = new System.Drawing.Size(143, 29);
            this.BottomRight.TabIndex = 8;
            this.BottomRight.TabStop = true;
            this.BottomRight.Text = "Bottom Right";
            this.BottomRight.UseVisualStyleBackColor = true;
            this.BottomRight.CheckedChanged += new System.EventHandler(this.BottomRight_CheckedChanged);
            // 
            // externalEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 727);
            this.Controls.Add(this.BottomRight);
            this.Controls.Add(this.BottomLeft);
            this.Controls.Add(this.Center);
            this.Controls.Add(this.TopRight);
            this.Controls.Add(this.TopLeft);
            this.Controls.Add(this.title);
            this.Controls.Add(this.backBtn);
            this.Controls.Add(this.nextBtn);
            this.Controls.Add(this.mapPiece);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "externalEditor";
            this.ShowIcon = false;
            this.Text = "Editor";
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
    }
}

