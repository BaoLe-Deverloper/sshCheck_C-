namespace CheckLiveSSH
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
            this.btn_load = new System.Windows.Forms.Button();
            this.gv_data = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_url = new System.Windows.Forms.TextBox();
            this.btn_start = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gv_data)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_load
            // 
            this.btn_load.Location = new System.Drawing.Point(629, 4);
            this.btn_load.Name = "btn_load";
            this.btn_load.Size = new System.Drawing.Size(75, 23);
            this.btn_load.TabIndex = 0;
            this.btn_load.Text = "Browser...";
            this.btn_load.UseVisualStyleBackColor = true;
            this.btn_load.Click += new System.EventHandler(this.button1_Click);
            // 
            // gv_data
            // 
            this.gv_data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gv_data.Location = new System.Drawing.Point(12, 83);
            this.gv_data.Name = "gv_data";
            this.gv_data.Size = new System.Drawing.Size(962, 427);
            this.gv_data.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Chọn file SSH:";
            // 
            // txt_url
            // 
            this.txt_url.Location = new System.Drawing.Point(103, 6);
            this.txt_url.Name = "txt_url";
            this.txt_url.Size = new System.Drawing.Size(520, 20);
            this.txt_url.TabIndex = 3;
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(629, 54);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(75, 23);
            this.btn_start.TabIndex = 4;
            this.btn_start.Text = "Bắt đầu";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(986, 586);
            this.Controls.Add(this.btn_start);
            this.Controls.Add(this.txt_url);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gv_data);
            this.Controls.Add(this.btn_load);
            this.Name = "Form1";
            this.Text = "Tool check live SSH - http://laptrinhvb.net";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gv_data)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_load;
        private System.Windows.Forms.DataGridView gv_data;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_url;
        private System.Windows.Forms.Button btn_start;
    }
}

