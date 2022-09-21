namespace Jatkanshakki
{
    partial class Ui
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ui));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.valikkoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scoreClickToolStripMenuNow = new System.Windows.Forms.ToolStripMenuItem();
            this.resetScoreToolStripMenuNow = new System.Windows.Forms.ToolStripMenuItem();
            this.blueScoreToolStripMenuNow = new System.Windows.Forms.ToolStripMenuItem();
            this.redScoreToolStripMenuNow = new System.Windows.Forms.ToolStripMenuItem();
            this.lopetaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.valikkoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(560, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";


            // 
            // valikkoToolStripMenuItem
            // 
            this.valikkoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resetGameToolStripMenuItem,
            this.scoreClickToolStripMenuNow,
            this.lopetaToolStripMenuItem});
            this.valikkoToolStripMenuItem.Name = "valikkoToolStripMenuItem";
            this.valikkoToolStripMenuItem.Size = new System.Drawing.Size(56, 22);
            this.valikkoToolStripMenuItem.Text = "Valikko";
            // 
            // yksinPeliToolStripMenuItem
            // 
            this.resetGameToolStripMenuItem.Name = "yksinPeliToolStripMenuItem";
            this.resetGameToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.resetGameToolStripMenuItem.Text = "Aloita alusta";
            this.resetGameToolStripMenuItem.Click += new System.EventHandler(this.StartOver);
            // 
            // scoreClickToolStripMenuNow
            // 
            this.scoreClickToolStripMenuNow.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resetScoreToolStripMenuNow,
            this.blueScoreToolStripMenuNow,
            this.redScoreToolStripMenuNow});
            this.scoreClickToolStripMenuNow.Name = "scoreClickToolStripMenuNow";
            this.scoreClickToolStripMenuNow.Size = new System.Drawing.Size(180, 22);
            this.scoreClickToolStripMenuNow.Text = "Pisteet";
            this.scoreClickToolStripMenuNow.MouseHover += new System.EventHandler(this.ScoreClickToolStripMenuNow_MouseHover);
            // 
            // resetScoreToolStripMenuNow
            // 
            this.resetScoreToolStripMenuNow.Name = "resetScoreToolStripMenuNow";
            this.resetScoreToolStripMenuNow.Size = new System.Drawing.Size(180, 22);
            this.resetScoreToolStripMenuNow.Text = "Nollaa pisteet";
            this.resetScoreToolStripMenuNow.Click += new System.EventHandler(this.ResetPlayersScores);
            // 
            // blueScoreToolStripMenuNow
            // 
            this.blueScoreToolStripMenuNow.Name = "blueScoreToolStripMenuNow";
            this.blueScoreToolStripMenuNow.Size = new System.Drawing.Size(180, 22);
            this.blueScoreToolStripMenuNow.Text = "Sininen pisteet";
            this.blueScoreToolStripMenuNow.MouseHover += new System.EventHandler(this.ScoreUpdate);
            // 
            // redScoreToolStripMenuNow
            // 
            this.redScoreToolStripMenuNow.Name = "redScoreToolStripMenuNow";
            this.redScoreToolStripMenuNow.Size = new System.Drawing.Size(180, 22);
            this.redScoreToolStripMenuNow.Text = "Punainen pisteet";
            this.redScoreToolStripMenuNow.MouseHover += new System.EventHandler(this.ScoreUpdate);
            // 
            // lopetaToolStripMenuItem
            // 
            this.lopetaToolStripMenuItem.Name = "lopetaToolStripMenuItem";
            this.lopetaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.lopetaToolStripMenuItem.Text = "Lopeta";
            this.lopetaToolStripMenuItem.Click += new System.EventHandler(this.CloseGame);
            // 
            // Ui
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 270);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Ui";
            this.Text = "Jatkanshakki";
            this.Load += new System.EventHandler(this.StartScreen);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        
        #endregion

        private ContextMenuStrip contextMenuStrip1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem valikkoToolStripMenuItem;
        private ToolStripMenuItem resetGameToolStripMenuItem;
        private ToolStripMenuItem scoreClickToolStripMenuNow;
        private ToolStripMenuItem lopetaToolStripMenuItem;
        private ToolStripMenuItem resetScoreToolStripMenuNow;
        private ToolStripMenuItem redScoreToolStripMenuNow;
        private ToolStripMenuItem blueScoreToolStripMenuNow;
    }
}