namespace CatchnUpload
{
    partial class frm_main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_main));
            this.label1 = new System.Windows.Forms.Label();
            this.btn_catch = new System.Windows.Forms.Button();
            this.btn_upload = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.rtxb_files = new System.Windows.Forms.RichTextBox();
            this.txb_path = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txb_id = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(75, 178);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 35);
            this.label1.TabIndex = 0;
            this.label1.Text = "抓取目录：";
            // 
            // btn_catch
            // 
            this.btn_catch.Location = new System.Drawing.Point(114, 427);
            this.btn_catch.Name = "btn_catch";
            this.btn_catch.Size = new System.Drawing.Size(188, 73);
            this.btn_catch.TabIndex = 1;
            this.btn_catch.Text = "【1】抓取";
            this.btn_catch.UseVisualStyleBackColor = true;
            this.btn_catch.Click += new System.EventHandler(this.btn_catch_Click);
            // 
            // btn_upload
            // 
            this.btn_upload.Location = new System.Drawing.Point(463, 427);
            this.btn_upload.Name = "btn_upload";
            this.btn_upload.Size = new System.Drawing.Size(188, 73);
            this.btn_upload.TabIndex = 1;
            this.btn_upload.Text = "【2】上传";
            this.btn_upload.UseVisualStyleBackColor = true;
            this.btn_upload.Click += new System.EventHandler(this.btn_upload_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(75, 269);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(190, 35);
            this.label2.TabIndex = 0;
            this.label2.Text = "抓取文件：";
            // 
            // rtxb_files
            // 
            this.rtxb_files.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rtxb_files.Location = new System.Drawing.Point(271, 266);
            this.rtxb_files.Name = "rtxb_files";
            this.rtxb_files.Size = new System.Drawing.Size(436, 96);
            this.rtxb_files.TabIndex = 3;
            this.rtxb_files.Text = "";
            // 
            // txb_path
            // 
            this.txb_path.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txb_path.Location = new System.Drawing.Point(271, 175);
            this.txb_path.Name = "txb_path";
            this.txb_path.Size = new System.Drawing.Size(436, 47);
            this.txb_path.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(75, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(190, 35);
            this.label3.TabIndex = 0;
            this.label3.Text = "用户标识：";
            // 
            // txb_id
            // 
            this.txb_id.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txb_id.Location = new System.Drawing.Point(271, 84);
            this.txb_id.Name = "txb_id";
            this.txb_id.Size = new System.Drawing.Size(436, 47);
            this.txb_id.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.rtxb_files);
            this.panel1.Controls.Add(this.txb_id);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txb_path);
            this.panel1.Controls.Add(this.btn_catch);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btn_upload);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(781, 582);
            this.panel1.TabIndex = 5;
            // 
            // frm_main
            // 
            this.AcceptButton = this.btn_catch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(809, 605);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "医保异常文件抓取上传";
            this.Load += new System.EventHandler(this.frm_main_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_catch;
        private System.Windows.Forms.Button btn_upload;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox rtxb_files;
        private System.Windows.Forms.TextBox txb_path;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txb_id;
        private System.Windows.Forms.Panel panel1;
    }
}

