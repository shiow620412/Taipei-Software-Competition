namespace taipei_106_1
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_load = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtbox_width = new System.Windows.Forms.TextBox();
            this.txtbox_distance = new System.Windows.Forms.TextBox();
            this.txtbox_col = new System.Windows.Forms.TextBox();
            this.btn_generate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_load
            // 
            this.btn_load.Location = new System.Drawing.Point(16, 12);
            this.btn_load.Name = "btn_load";
            this.btn_load.Size = new System.Drawing.Size(274, 114);
            this.btn_load.TabIndex = 0;
            this.btn_load.Text = "載入欲轉成HTML的文字檔";
            this.btn_load.UseVisualStyleBackColor = true;
            this.btn_load.Click += new System.EventHandler(this.btn_load_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 12F);
            this.label1.Location = new System.Drawing.Point(12, 129);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(209, 140);
            this.label1.TabIndex = 1;
            this.label1.Text = "網頁外框選項，請修改\r\n\r\n表格邊框寬度(0~9)\r\n\r\n表格內格距(0~9)\r\n\r\n表格每列項數(1~5)";
            // 
            // txtbox_width
            // 
            this.txtbox_width.Location = new System.Drawing.Point(227, 163);
            this.txtbox_width.Name = "txtbox_width";
            this.txtbox_width.Size = new System.Drawing.Size(56, 25);
            this.txtbox_width.TabIndex = 2;
            // 
            // txtbox_distance
            // 
            this.txtbox_distance.Location = new System.Drawing.Point(227, 203);
            this.txtbox_distance.Name = "txtbox_distance";
            this.txtbox_distance.Size = new System.Drawing.Size(56, 25);
            this.txtbox_distance.TabIndex = 3;
            // 
            // txtbox_col
            // 
            this.txtbox_col.Location = new System.Drawing.Point(227, 244);
            this.txtbox_col.Name = "txtbox_col";
            this.txtbox_col.Size = new System.Drawing.Size(56, 25);
            this.txtbox_col.TabIndex = 4;
            // 
            // btn_generate
            // 
            this.btn_generate.Location = new System.Drawing.Point(16, 284);
            this.btn_generate.Name = "btn_generate";
            this.btn_generate.Size = new System.Drawing.Size(274, 57);
            this.btn_generate.TabIndex = 5;
            this.btn_generate.Text = "產生HTML檔案";
            this.btn_generate.UseVisualStyleBackColor = true;
            this.btn_generate.Click += new System.EventHandler(this.btn_generate_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 353);
            this.Controls.Add(this.btn_generate);
            this.Controls.Add(this.txtbox_col);
            this.Controls.Add(this.txtbox_distance);
            this.Controls.Add(this.txtbox_width);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_load);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_load;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtbox_width;
        private System.Windows.Forms.TextBox txtbox_distance;
        private System.Windows.Forms.TextBox txtbox_col;
        private System.Windows.Forms.Button btn_generate;
    }
}

