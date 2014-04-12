namespace TestApp
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemNewGame = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemReset = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSolve = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemNewGame,
            this.menuItemReset,
            this.menuItemSolve,
            this.menuItemExit});
            this.contextMenuStrip.Name = "contextMenuStrip1";
            this.contextMenuStrip.Size = new System.Drawing.Size(153, 114);
            // 
            // menuItemNewGame
            // 
            this.menuItemNewGame.Name = "menuItemNewGame";
            this.menuItemNewGame.Size = new System.Drawing.Size(152, 22);
            this.menuItemNewGame.Text = "New Game";
            this.menuItemNewGame.Click += new System.EventHandler(this.MenuItemNewGameClick);
            // 
            // menuItemReset
            // 
            this.menuItemReset.Name = "menuItemReset";
            this.menuItemReset.Size = new System.Drawing.Size(152, 22);
            this.menuItemReset.Text = "Reset";
            this.menuItemReset.Click += new System.EventHandler(this.MenuItemResetClick);
            // 
            // menuItemSolve
            // 
            this.menuItemSolve.Name = "menuItemSolve";
            this.menuItemSolve.Size = new System.Drawing.Size(152, 22);
            this.menuItemSolve.Text = "Solve";
            this.menuItemSolve.Click += new System.EventHandler(this.MenuItemSolve_Click);
            // 
            // menuItemExit
            // 
            this.menuItemExit.Name = "menuItemExit";
            this.menuItemExit.Size = new System.Drawing.Size(152, 22);
            this.menuItemExit.Text = "Exit";
            this.menuItemExit.Click += new System.EventHandler(this.MenuItemExitClick);
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.AutoSize = true;
            this.flowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(144, 122);
            this.flowLayoutPanel.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(144, 122);
            this.ContextMenuStrip = this.contextMenuStrip;
            this.ControlBox = false;
            this.Controls.Add(this.flowLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Open Fiver";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuItemNewGame;
        private System.Windows.Forms.ToolStripMenuItem menuItemReset;
        private System.Windows.Forms.ToolStripMenuItem menuItemSolve;
        private System.Windows.Forms.ToolStripMenuItem menuItemExit;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
    }
}

