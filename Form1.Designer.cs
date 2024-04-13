namespace mspaint
{
    partial class Form1
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
            this.gbxOptions = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nudThickness = new System.Windows.Forms.NumericUpDown();
            this.btnRGBSelect = new System.Windows.Forms.Button();
            this.btnText = new System.Windows.Forms.Button();
            this.btnLine = new System.Windows.Forms.Button();
            this.btnSquare = new System.Windows.Forms.Button();
            this.btnEllips = new System.Windows.Forms.Button();
            this.btnPen = new System.Windows.Forms.Button();
            this.btnEraser = new System.Windows.Forms.Button();
            this.btnRedo = new System.Windows.Forms.Button();
            this.btnUndo = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.pbxPaper = new System.Windows.Forms.PictureBox();
            this.nudRed = new System.Windows.Forms.NumericUpDown();
            this.nudGreen = new System.Windows.Forms.NumericUpDown();
            this.nudBlue = new System.Windows.Forms.NumericUpDown();
            this.gbxOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudThickness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxPaper)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBlue)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxOptions
            // 
            this.gbxOptions.BackColor = System.Drawing.Color.White;
            this.gbxOptions.Controls.Add(this.nudBlue);
            this.gbxOptions.Controls.Add(this.nudGreen);
            this.gbxOptions.Controls.Add(this.nudRed);
            this.gbxOptions.Controls.Add(this.label1);
            this.gbxOptions.Controls.Add(this.nudThickness);
            this.gbxOptions.Controls.Add(this.btnRGBSelect);
            this.gbxOptions.Controls.Add(this.btnText);
            this.gbxOptions.Controls.Add(this.btnLine);
            this.gbxOptions.Controls.Add(this.btnSquare);
            this.gbxOptions.Controls.Add(this.btnEllips);
            this.gbxOptions.Controls.Add(this.btnPen);
            this.gbxOptions.Controls.Add(this.btnEraser);
            this.gbxOptions.Controls.Add(this.btnRedo);
            this.gbxOptions.Controls.Add(this.btnUndo);
            this.gbxOptions.Controls.Add(this.btnSave);
            this.gbxOptions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbxOptions.Location = new System.Drawing.Point(-3, -20);
            this.gbxOptions.Name = "gbxOptions";
            this.gbxOptions.Size = new System.Drawing.Size(1005, 148);
            this.gbxOptions.TabIndex = 0;
            this.gbxOptions.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(445, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 16);
            this.label1.TabIndex = 16;
            this.label1.Text = "Thickness";
            // 
            // nudThickness
            // 
            this.nudThickness.Location = new System.Drawing.Point(436, 107);
            this.nudThickness.Name = "nudThickness";
            this.nudThickness.Size = new System.Drawing.Size(87, 22);
            this.nudThickness.TabIndex = 15;
            this.nudThickness.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.nudThickness.ValueChanged += new System.EventHandler(this.nudThickness_ValueChanged);
            // 
            // btnRGBSelect
            // 
            this.btnRGBSelect.Location = new System.Drawing.Point(887, 108);
            this.btnRGBSelect.Name = "btnRGBSelect";
            this.btnRGBSelect.Size = new System.Drawing.Size(100, 23);
            this.btnRGBSelect.TabIndex = 13;
            this.btnRGBSelect.Text = "Select";
            this.btnRGBSelect.UseVisualStyleBackColor = true;
            this.btnRGBSelect.Click += new System.EventHandler(this.btnRGBSelect_Click);
            // 
            // btnText
            // 
            this.btnText.Location = new System.Drawing.Point(354, 80);
            this.btnText.Name = "btnText";
            this.btnText.Size = new System.Drawing.Size(55, 50);
            this.btnText.TabIndex = 8;
            this.btnText.Text = "Text";
            this.btnText.UseVisualStyleBackColor = true;
            // 
            // btnLine
            // 
            this.btnLine.Location = new System.Drawing.Point(354, 21);
            this.btnLine.Name = "btnLine";
            this.btnLine.Size = new System.Drawing.Size(55, 50);
            this.btnLine.TabIndex = 7;
            this.btnLine.Text = "Line";
            this.btnLine.UseVisualStyleBackColor = true;
            // 
            // btnSquare
            // 
            this.btnSquare.Location = new System.Drawing.Point(293, 80);
            this.btnSquare.Name = "btnSquare";
            this.btnSquare.Size = new System.Drawing.Size(55, 50);
            this.btnSquare.TabIndex = 6;
            this.btnSquare.Text = "Square";
            this.btnSquare.UseVisualStyleBackColor = true;
            // 
            // btnEllips
            // 
            this.btnEllips.Location = new System.Drawing.Point(293, 21);
            this.btnEllips.Name = "btnEllips";
            this.btnEllips.Size = new System.Drawing.Size(55, 50);
            this.btnEllips.TabIndex = 5;
            this.btnEllips.Text = "Ellipse";
            this.btnEllips.UseVisualStyleBackColor = true;
            // 
            // btnPen
            // 
            this.btnPen.Location = new System.Drawing.Point(232, 80);
            this.btnPen.Name = "btnPen";
            this.btnPen.Size = new System.Drawing.Size(55, 50);
            this.btnPen.TabIndex = 4;
            this.btnPen.Text = "Pen";
            this.btnPen.UseVisualStyleBackColor = true;
            this.btnPen.Click += new System.EventHandler(this.btnPen_Click);
            // 
            // btnEraser
            // 
            this.btnEraser.Location = new System.Drawing.Point(232, 21);
            this.btnEraser.Name = "btnEraser";
            this.btnEraser.Size = new System.Drawing.Size(55, 50);
            this.btnEraser.TabIndex = 3;
            this.btnEraser.Text = "Eraser";
            this.btnEraser.UseVisualStyleBackColor = true;
            this.btnEraser.Click += new System.EventHandler(this.btnEraser_Click);
            // 
            // btnRedo
            // 
            this.btnRedo.Location = new System.Drawing.Point(149, 80);
            this.btnRedo.Name = "btnRedo";
            this.btnRedo.Size = new System.Drawing.Size(55, 50);
            this.btnRedo.TabIndex = 2;
            this.btnRedo.Text = "Redo";
            this.btnRedo.UseVisualStyleBackColor = true;
            // 
            // btnUndo
            // 
            this.btnUndo.Location = new System.Drawing.Point(149, 21);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(55, 50);
            this.btnUndo.TabIndex = 1;
            this.btnUndo.Text = "Undo";
            this.btnUndo.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(21, 21);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(122, 109);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // pbxPaper
            // 
            this.pbxPaper.BackColor = System.Drawing.Color.White;
            this.pbxPaper.Location = new System.Drawing.Point(62, 184);
            this.pbxPaper.Name = "pbxPaper";
            this.pbxPaper.Size = new System.Drawing.Size(879, 443);
            this.pbxPaper.TabIndex = 1;
            this.pbxPaper.TabStop = false;
            this.pbxPaper.Paint += new System.Windows.Forms.PaintEventHandler(this.pbxPaper_Paint);
            this.pbxPaper.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbxPaper_MouseDown);
            this.pbxPaper.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbxPaper_MouseMove);
            this.pbxPaper.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbxPaper_MouseUp);
            // 
            // nudRed
            // 
            this.nudRed.Location = new System.Drawing.Point(887, 21);
            this.nudRed.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudRed.Name = "nudRed";
            this.nudRed.Size = new System.Drawing.Size(100, 22);
            this.nudRed.TabIndex = 17;
            // 
            // nudGreen
            // 
            this.nudGreen.Location = new System.Drawing.Point(887, 49);
            this.nudGreen.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudGreen.Name = "nudGreen";
            this.nudGreen.Size = new System.Drawing.Size(100, 22);
            this.nudGreen.TabIndex = 18;
            // 
            // nudBlue
            // 
            this.nudBlue.Location = new System.Drawing.Point(887, 80);
            this.nudBlue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudBlue.Name = "nudBlue";
            this.nudBlue.Size = new System.Drawing.Size(100, 22);
            this.nudBlue.TabIndex = 19;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(996, 687);
            this.Controls.Add(this.pbxPaper);
            this.Controls.Add(this.gbxOptions);
            this.Name = "Form1";
            this.Text = "MS Paint";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gbxOptions.ResumeLayout(false);
            this.gbxOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudThickness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxPaper)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBlue)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxOptions;
        private System.Windows.Forms.PictureBox pbxPaper;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnRedo;
        private System.Windows.Forms.Button btnUndo;
        private System.Windows.Forms.Button btnEraser;
        private System.Windows.Forms.Button btnPen;
        private System.Windows.Forms.Button btnEllips;
        private System.Windows.Forms.Button btnSquare;
        private System.Windows.Forms.Button btnLine;
        private System.Windows.Forms.Button btnText;
        private System.Windows.Forms.Button btnRGBSelect;
        private System.Windows.Forms.NumericUpDown nudThickness;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudBlue;
        private System.Windows.Forms.NumericUpDown nudGreen;
        private System.Windows.Forms.NumericUpDown nudRed;
    }
}

