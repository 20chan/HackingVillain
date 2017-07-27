namespace HackingVillainServer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.보기VToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.키보드KToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.프로ㅔㅅ스ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.화면SToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.제어CToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.키보드잠금KToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.활성화EToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.비활성화DToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.화면SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.활성화EToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.비활성화DToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.종료KToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.전송SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.메시지ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.파일FToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listView1.ContextMenuStrip = this.contextMenuStrip1;
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(518, 361);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.보기VToolStripMenuItem,
            this.제어CToolStripMenuItem,
            this.전송SToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(115, 70);
            // 
            // 보기VToolStripMenuItem
            // 
            this.보기VToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.키보드KToolStripMenuItem,
            this.프로ㅔㅅ스ToolStripMenuItem,
            this.화면SToolStripMenuItem1});
            this.보기VToolStripMenuItem.Name = "보기VToolStripMenuItem";
            this.보기VToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.보기VToolStripMenuItem.Text = "보기(&V)";
            // 
            // 키보드KToolStripMenuItem
            // 
            this.키보드KToolStripMenuItem.Name = "키보드KToolStripMenuItem";
            this.키보드KToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.키보드KToolStripMenuItem.Text = "키보드(&K)";
            this.키보드KToolStripMenuItem.Click += new System.EventHandler(this.키보드KToolStripMenuItem_Click);
            // 
            // 프로ㅔㅅ스ToolStripMenuItem
            // 
            this.프로ㅔㅅ스ToolStripMenuItem.Name = "프로ㅔㅅ스ToolStripMenuItem";
            this.프로ㅔㅅ스ToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.프로ㅔㅅ스ToolStripMenuItem.Text = "프로세스(&P)";
            this.프로ㅔㅅ스ToolStripMenuItem.Click += new System.EventHandler(this.프로세스ToolStripMenuItem_Click);
            // 
            // 화면SToolStripMenuItem1
            // 
            this.화면SToolStripMenuItem1.Name = "화면SToolStripMenuItem1";
            this.화면SToolStripMenuItem1.Size = new System.Drawing.Size(137, 22);
            this.화면SToolStripMenuItem1.Text = "화면(&S)";
            this.화면SToolStripMenuItem1.Click += new System.EventHandler(this.화면SToolStripMenuItem1_Click);
            // 
            // 제어CToolStripMenuItem
            // 
            this.제어CToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.키보드잠금KToolStripMenuItem,
            this.화면SToolStripMenuItem,
            this.종료KToolStripMenuItem});
            this.제어CToolStripMenuItem.Name = "제어CToolStripMenuItem";
            this.제어CToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.제어CToolStripMenuItem.Text = "제어(&C)";
            // 
            // 키보드잠금KToolStripMenuItem
            // 
            this.키보드잠금KToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.활성화EToolStripMenuItem,
            this.비활성화DToolStripMenuItem});
            this.키보드잠금KToolStripMenuItem.Name = "키보드잠금KToolStripMenuItem";
            this.키보드잠금KToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.키보드잠금KToolStripMenuItem.Text = "키보드(&K)";
            // 
            // 활성화EToolStripMenuItem
            // 
            this.활성화EToolStripMenuItem.Name = "활성화EToolStripMenuItem";
            this.활성화EToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.활성화EToolStripMenuItem.Text = "활성화(&E)";
            this.활성화EToolStripMenuItem.Click += new System.EventHandler(this.활성화EToolStripMenuItem_Click);
            // 
            // 비활성화DToolStripMenuItem
            // 
            this.비활성화DToolStripMenuItem.Name = "비활성화DToolStripMenuItem";
            this.비활성화DToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.비활성화DToolStripMenuItem.Text = "비활성화(&D)";
            this.비활성화DToolStripMenuItem.Click += new System.EventHandler(this.비활성화DToolStripMenuItem_Click);
            // 
            // 화면SToolStripMenuItem
            // 
            this.화면SToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.활성화EToolStripMenuItem1,
            this.비활성화DToolStripMenuItem1});
            this.화면SToolStripMenuItem.Name = "화면SToolStripMenuItem";
            this.화면SToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.화면SToolStripMenuItem.Text = "화면(&S)";
            // 
            // 활성화EToolStripMenuItem1
            // 
            this.활성화EToolStripMenuItem1.Name = "활성화EToolStripMenuItem1";
            this.활성화EToolStripMenuItem1.Size = new System.Drawing.Size(139, 22);
            this.활성화EToolStripMenuItem1.Text = "활성화(&E)";
            this.활성화EToolStripMenuItem1.Click += new System.EventHandler(this.활성화EToolStripMenuItem1_Click);
            // 
            // 비활성화DToolStripMenuItem1
            // 
            this.비활성화DToolStripMenuItem1.Name = "비활성화DToolStripMenuItem1";
            this.비활성화DToolStripMenuItem1.Size = new System.Drawing.Size(139, 22);
            this.비활성화DToolStripMenuItem1.Text = "비활성화(&D)";
            this.비활성화DToolStripMenuItem1.Click += new System.EventHandler(this.비활성화DToolStripMenuItem1_Click);
            // 
            // 종료KToolStripMenuItem
            // 
            this.종료KToolStripMenuItem.Name = "종료KToolStripMenuItem";
            this.종료KToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.종료KToolStripMenuItem.Text = "종료(&K)";
            this.종료KToolStripMenuItem.Click += new System.EventHandler(this.종료KToolStripMenuItem_Click);
            // 
            // 전송SToolStripMenuItem
            // 
            this.전송SToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.메시지ToolStripMenuItem,
            this.파일FToolStripMenuItem});
            this.전송SToolStripMenuItem.Name = "전송SToolStripMenuItem";
            this.전송SToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.전송SToolStripMenuItem.Text = "전송(&S)";
            // 
            // 메시지ToolStripMenuItem
            // 
            this.메시지ToolStripMenuItem.Name = "메시지ToolStripMenuItem";
            this.메시지ToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.메시지ToolStripMenuItem.Text = "메시지(&M)";
            this.메시지ToolStripMenuItem.Click += new System.EventHandler(this.메시지ToolStripMenuItem_Click);
            // 
            // 파일FToolStripMenuItem
            // 
            this.파일FToolStripMenuItem.Name = "파일FToolStripMenuItem";
            this.파일FToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.파일FToolStripMenuItem.Text = "파일(&F)";
            this.파일FToolStripMenuItem.Click += new System.EventHandler(this.파일FToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 361);
            this.Controls.Add(this.listView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Yekki";
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
        private System.Windows.Forms.ToolStripMenuItem 화면SToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 활성화EToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 비활성화DToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 프로ㅔㅅ스ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 화면SToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 종료KToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 전송SToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 메시지ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 파일FToolStripMenuItem;
    }
}

