namespace SimplePaint
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblAppName = new Label();
            groupBox1 = new GroupBox();
            btnCircle = new Button();
            btnRectangle = new Button();
            btnLine = new Button();
            groupBox2 = new GroupBox();
            cmbColor = new ComboBox();
            groupBox3 = new GroupBox();
            trbLineWidth = new TrackBar();
            btnOpenFile = new Button();
            btnSaveFile = new Button();
            picCanvas = new PictureBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trbLineWidth).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picCanvas).BeginInit();
            SuspendLayout();
            // 
            // lblAppName
            // 
            lblAppName.AutoSize = true;
            lblAppName.Font = new Font("맑은 고딕", 35.25F, FontStyle.Bold, GraphicsUnit.Point, 129);
            lblAppName.ForeColor = SystemColors.ActiveCaption;
            lblAppName.Location = new Point(12, 9);
            lblAppName.Name = "lblAppName";
            lblAppName.Size = new Size(310, 62);
            lblAppName.TabIndex = 0;
            lblAppName.Text = "Simple Paint";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnCircle);
            groupBox1.Controls.Add(btnRectangle);
            groupBox1.Controls.Add(btnLine);
            groupBox1.Location = new Point(33, 96);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(252, 101);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "도형선택";
            // 
            // btnCircle
            // 
            btnCircle.Image = Properties.Resources.IMG_9997;
            btnCircle.Location = new Point(168, 22);
            btnCircle.Name = "btnCircle";
            btnCircle.Size = new Size(75, 66);
            btnCircle.TabIndex = 0;
            btnCircle.Text = "원";
            btnCircle.TextAlign = ContentAlignment.BottomCenter;
            btnCircle.UseVisualStyleBackColor = true;
            // 
            // btnRectangle
            // 
            btnRectangle.Image = Properties.Resources.IMG_9996;
            btnRectangle.Location = new Point(87, 22);
            btnRectangle.Name = "btnRectangle";
            btnRectangle.Size = new Size(75, 66);
            btnRectangle.TabIndex = 0;
            btnRectangle.Text = "사각형";
            btnRectangle.TextAlign = ContentAlignment.BottomCenter;
            btnRectangle.UseVisualStyleBackColor = true;
            // 
            // btnLine
            // 
            btnLine.Image = Properties.Resources.IMG_9998;
            btnLine.Location = new Point(6, 22);
            btnLine.Name = "btnLine";
            btnLine.Size = new Size(75, 66);
            btnLine.TabIndex = 0;
            btnLine.Text = "직선";
            btnLine.TextAlign = ContentAlignment.BottomCenter;
            btnLine.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(cmbColor);
            groupBox2.Location = new Point(291, 96);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(125, 101);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "색 선택";
            // 
            // cmbColor
            // 
            cmbColor.FormattingEnabled = true;
            cmbColor.Items.AddRange(new object[] { "Black 검정", "Red 빨강", "Blue 파랑", "Green 녹색" });
            cmbColor.Location = new Point(0, 42);
            cmbColor.Name = "cmbColor";
            cmbColor.Size = new Size(121, 23);
            cmbColor.TabIndex = 0;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(trbLineWidth);
            groupBox3.Location = new Point(422, 96);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(166, 101);
            groupBox3.TabIndex = 1;
            groupBox3.TabStop = false;
            groupBox3.Text = "선 두께";
            // 
            // trbLineWidth
            // 
            trbLineWidth.Location = new Point(2, 42);
            trbLineWidth.Name = "trbLineWidth";
            trbLineWidth.Size = new Size(164, 45);
            trbLineWidth.TabIndex = 0;
            // 
            // btnOpenFile
            // 
            btnOpenFile.BackColor = Color.FromArgb(255, 255, 192);
            btnOpenFile.Font = new Font("맑은 고딕", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 129);
            btnOpenFile.Location = new Point(602, 96);
            btnOpenFile.Name = "btnOpenFile";
            btnOpenFile.Size = new Size(75, 101);
            btnOpenFile.TabIndex = 2;
            btnOpenFile.Text = "열기";
            btnOpenFile.UseVisualStyleBackColor = false;
            // 
            // btnSaveFile
            // 
            btnSaveFile.BackColor = Color.FromArgb(192, 255, 255);
            btnSaveFile.Font = new Font("맑은 고딕", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 129);
            btnSaveFile.Location = new Point(683, 96);
            btnSaveFile.Name = "btnSaveFile";
            btnSaveFile.Size = new Size(75, 101);
            btnSaveFile.TabIndex = 2;
            btnSaveFile.Text = "저장";
            btnSaveFile.UseVisualStyleBackColor = false;
            // 
            // picCanvas
            // 
            picCanvas.BorderStyle = BorderStyle.FixedSingle;
            picCanvas.Location = new Point(33, 203);
            picCanvas.Name = "picCanvas";
            picCanvas.Size = new Size(725, 375);
            picCanvas.TabIndex = 3;
            picCanvas.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 590);
            Controls.Add(picCanvas);
            Controls.Add(btnSaveFile);
            Controls.Add(btnOpenFile);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(lblAppName);
            Name = "Form1";
            Text = "SimplePaint v2.0";
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trbLineWidth).EndInit();
            ((System.ComponentModel.ISupportInitialize)picCanvas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblAppName;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private Button btnCircle;
        private Button btnRectangle;
        private Button btnLine;
        private ComboBox cmbColor;
        private TrackBar trbLineWidth;
        private Button btnOpenFile;
        private Button btnSaveFile;
        private PictureBox picCanvas;
    }
}
