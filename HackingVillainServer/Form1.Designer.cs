﻿namespace HackingVillainServer
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.보기VToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.키보드KToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.제어CToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.키보드잠금KToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.활성화EToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.비활성화DToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listView1.ContextMenuStrip = this.contextMenuStrip1;
            this.listView1.Location = new System.Drawing.Point(12, 12);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(494, 337);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.보기VToolStripMenuItem,
            this.제어CToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 70);
            // 
            // 보기VToolStripMenuItem
            // 
            this.보기VToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.키보드KToolStripMenuItem});
            this.보기VToolStripMenuItem.Name = "보기VToolStripMenuItem";
            this.보기VToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.보기VToolStripMenuItem.Text = "보기(&V)";
            // 
            // 키보드KToolStripMenuItem
            // 
            this.키보드KToolStripMenuItem.Name = "키보드KToolStripMenuItem";
            this.키보드KToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.키보드KToolStripMenuItem.Text = "키보드(&K)";
            this.키보드KToolStripMenuItem.Click += new System.EventHandler(this.키보드KToolStripMenuItem_Click);
            // 
            // 제어CToolStripMenuItem
            // 
            this.제어CToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.키보드잠금KToolStripMenuItem});
            this.제어CToolStripMenuItem.Name = "제어CToolStripMenuItem";
            this.제어CToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.제어CToolStripMenuItem.Text = "제어(&C)";
            // 
            // 키보드잠금KToolStripMenuItem
            // 
            this.키보드잠금KToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.활성화EToolStripMenuItem,
            this.비활성화DToolStripMenuItem});
            this.키보드잠금KToolStripMenuItem.Name = "키보드잠금KToolStripMenuItem";
            this.키보드잠금KToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.키보드잠금KToolStripMenuItem.Text = "키보드(&K)";
            // 
            // 활성화EToolStripMenuItem
            // 
            this.활성화EToolStripMenuItem.Name = "활성화EToolStripMenuItem";
            this.활성화EToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.활성화EToolStripMenuItem.Text = "활성화(&E)";
            this.활성화EToolStripMenuItem.Click += new System.EventHandler(this.활성화EToolStripMenuItem_Click);
            // 
            // 비활성화DToolStripMenuItem
            // 
            this.비활성화DToolStripMenuItem.Name = "비활성화DToolStripMenuItem";
            this.비활성화DToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.비활성화DToolStripMenuItem.Text = "비활성화(&D)";
            this.비활성화DToolStripMenuItem.Click += new System.EventHandler(this.비활성화DToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 361);
            this.Controls.Add(this.listView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 보기VToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 키보드KToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 제어CToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 키보드잠금KToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 활성화EToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 비활성화DToolStripMenuItem;
    }
}
