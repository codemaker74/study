
namespace WindowsFormsApp1
{
    partial class Form9
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.파일ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuReset = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRestore = new System.Windows.Forms.ToolStripMenuItem();
            this.menuClose = new System.Windows.Forms.ToolStripMenuItem();
            this.보기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDraw = new System.Windows.Forms.ToolStripMenuItem();
            this.menuImage = new System.Windows.Forms.ToolStripMenuItem();
            this.수순ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuVisible = new System.Windows.Forms.ToolStripMenuItem();
            this.menuInvisible = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(512, 426);
            this.panel1.TabIndex = 3;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.파일ToolStripMenuItem,
            this.보기ToolStripMenuItem,
            this.수순ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(512, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 파일ToolStripMenuItem
            // 
            this.파일ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuReset,
            this.menuRestore,
            this.menuClose});
            this.파일ToolStripMenuItem.Name = "파일ToolStripMenuItem";
            this.파일ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.파일ToolStripMenuItem.Text = "파일";
            // 
            // menuReset
            // 
            this.menuReset.Name = "menuReset";
            this.menuReset.Size = new System.Drawing.Size(126, 22);
            this.menuReset.Text = "다시 시작";
            this.menuReset.Click += new System.EventHandler(this.menuReset_Click);
            // 
            // menuRestore
            // 
            this.menuRestore.Name = "menuRestore";
            this.menuRestore.Size = new System.Drawing.Size(126, 22);
            this.menuRestore.Text = "복기";
            this.menuRestore.Click += new System.EventHandler(this.menuRestore_Click);
            // 
            // menuClose
            // 
            this.menuClose.Name = "menuClose";
            this.menuClose.Size = new System.Drawing.Size(126, 22);
            this.menuClose.Text = "끝내기";
            this.menuClose.Click += new System.EventHandler(this.menuClose_Click);
            // 
            // 보기ToolStripMenuItem
            // 
            this.보기ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuDraw,
            this.menuImage});
            this.보기ToolStripMenuItem.Name = "보기ToolStripMenuItem";
            this.보기ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.보기ToolStripMenuItem.Text = "보기";
            // 
            // menuDraw
            // 
            this.menuDraw.Name = "menuDraw";
            this.menuDraw.Size = new System.Drawing.Size(110, 22);
            this.menuDraw.Text = "그리기";
            this.menuDraw.Click += new System.EventHandler(this.menuDraw_Click);
            // 
            // menuImage
            // 
            this.menuImage.Name = "menuImage";
            this.menuImage.Size = new System.Drawing.Size(110, 22);
            this.menuImage.Text = "이미지";
            this.menuImage.Click += new System.EventHandler(this.menuImage_Click);
            // 
            // 수순ToolStripMenuItem
            // 
            this.수순ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuVisible,
            this.menuInvisible});
            this.수순ToolStripMenuItem.Name = "수순ToolStripMenuItem";
            this.수순ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.수순ToolStripMenuItem.Text = "수순";
            // 
            // menuVisible
            // 
            this.menuVisible.Name = "menuVisible";
            this.menuVisible.Size = new System.Drawing.Size(180, 22);
            this.menuVisible.Text = "수순표시";
            this.menuVisible.Click += new System.EventHandler(this.menuVisible_Click);
            // 
            // menuInvisible
            // 
            this.menuInvisible.Name = "menuInvisible";
            this.menuInvisible.Size = new System.Drawing.Size(180, 22);
            this.menuInvisible.Text = "수순표시 안함";
            this.menuInvisible.Click += new System.EventHandler(this.menuInvisible_Click);
            // 
            // Form9
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Form9";
            this.Text = "Form9";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 파일ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuReset;
        private System.Windows.Forms.ToolStripMenuItem menuRestore;
        private System.Windows.Forms.ToolStripMenuItem menuClose;
        private System.Windows.Forms.ToolStripMenuItem 보기ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuDraw;
        private System.Windows.Forms.ToolStripMenuItem menuImage;
        private System.Windows.Forms.ToolStripMenuItem 수순ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuVisible;
        private System.Windows.Forms.ToolStripMenuItem menuInvisible;
    }
}