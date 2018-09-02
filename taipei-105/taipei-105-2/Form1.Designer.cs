namespace taipei_105_2
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtbox_height = new System.Windows.Forms.TextBox();
            this.txtbox_width = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtbox_file = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtbox_data = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_obj = new System.Windows.Forms.Label();
            this.txtbox_obj = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 12F);
            this.label1.Location = new System.Drawing.Point(105, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "影像高度H=";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("新細明體", 12F);
            this.label2.Location = new System.Drawing.Point(341, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "影像寬度W=";
            // 
            // txtbox_height
            // 
            this.txtbox_height.Location = new System.Drawing.Point(225, 4);
            this.txtbox_height.Name = "txtbox_height";
            this.txtbox_height.Size = new System.Drawing.Size(100, 25);
            this.txtbox_height.TabIndex = 2;
            // 
            // txtbox_width
            // 
            this.txtbox_width.Location = new System.Drawing.Point(459, 4);
            this.txtbox_width.Name = "txtbox_width";
            this.txtbox_width.Size = new System.Drawing.Size(100, 25);
            this.txtbox_width.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 37);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "讀檔";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtbox_file
            // 
            this.txtbox_file.Location = new System.Drawing.Point(103, 37);
            this.txtbox_file.Name = "txtbox_file";
            this.txtbox_file.Size = new System.Drawing.Size(515, 25);
            this.txtbox_file.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("新細明體", 12F);
            this.label3.Location = new System.Drawing.Point(12, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "影像資料";
            // 
            // txtbox_data
            // 
            this.txtbox_data.Font = new System.Drawing.Font("新細明體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtbox_data.Location = new System.Drawing.Point(16, 88);
            this.txtbox_data.Multiline = true;
            this.txtbox_data.Name = "txtbox_data";
            this.txtbox_data.Size = new System.Drawing.Size(602, 244);
            this.txtbox_data.TabIndex = 7;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 338);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "物件連通";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("新細明體", 12F);
            this.label4.Location = new System.Drawing.Point(225, 338);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "物件個數=";
            // 
            // lbl_obj
            // 
            this.lbl_obj.AutoSize = true;
            this.lbl_obj.Font = new System.Drawing.Font("新細明體", 12F);
            this.lbl_obj.Location = new System.Drawing.Point(325, 318);
            this.lbl_obj.Name = "lbl_obj";
            this.lbl_obj.Size = new System.Drawing.Size(0, 20);
            this.lbl_obj.TabIndex = 10;
            // 
            // txtbox_obj
            // 
            this.txtbox_obj.Font = new System.Drawing.Font("新細明體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtbox_obj.Location = new System.Drawing.Point(16, 375);
            this.txtbox_obj.Multiline = true;
            this.txtbox_obj.Name = "txtbox_obj";
            this.txtbox_obj.Size = new System.Drawing.Size(602, 247);
            this.txtbox_obj.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 634);
            this.Controls.Add(this.txtbox_obj);
            this.Controls.Add(this.lbl_obj);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtbox_data);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtbox_file);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtbox_width);
            this.Controls.Add(this.txtbox_height);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtbox_height;
        private System.Windows.Forms.TextBox txtbox_width;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtbox_file;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtbox_data;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_obj;
        private System.Windows.Forms.TextBox txtbox_obj;
    }
}

