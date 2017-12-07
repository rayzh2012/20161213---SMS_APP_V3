namespace Twilio_win_1108
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
            this.btnSubmit1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.btnSubmit2 = new System.Windows.Forms.Button();
            this.btnSubmit3 = new System.Windows.Forms.Button();
            this.btnSubmit4 = new System.Windows.Forms.Button();
            this.btnSubmit5 = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtPreview = new System.Windows.Forms.RichTextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.lblSuccessMsg = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSubmit1
            // 
            this.btnSubmit1.Location = new System.Drawing.Point(19, 128);
            this.btnSubmit1.Name = "btnSubmit1";
            this.btnSubmit1.Size = new System.Drawing.Size(100, 44);
            this.btnSubmit1.TabIndex = 0;
            this.btnSubmit1.UseVisualStyleBackColor = true;
            this.btnSubmit1.Click += new System.EventHandler(this.btnSubmit1_Onclick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(149, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "PhoneNumber";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(141, 77);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(100, 20);
            this.txtPhone.TabIndex = 4;
            this.txtPhone.Text = "4166299386";
            this.txtPhone.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // btnSubmit2
            // 
            this.btnSubmit2.Location = new System.Drawing.Point(141, 128);
            this.btnSubmit2.Name = "btnSubmit2";
            this.btnSubmit2.Size = new System.Drawing.Size(100, 44);
            this.btnSubmit2.TabIndex = 5;
            this.btnSubmit2.UseVisualStyleBackColor = true;
            this.btnSubmit2.Click += new System.EventHandler(this.btnSubmit2_Onclick);
            // 
            // btnSubmit3
            // 
            this.btnSubmit3.Location = new System.Drawing.Point(266, 128);
            this.btnSubmit3.Name = "btnSubmit3";
            this.btnSubmit3.Size = new System.Drawing.Size(100, 44);
            this.btnSubmit3.TabIndex = 6;
            this.btnSubmit3.UseVisualStyleBackColor = true;
            this.btnSubmit3.Click += new System.EventHandler(this.btnSubmit3_OnClick);
            // 
            // btnSubmit4
            // 
            this.btnSubmit4.Location = new System.Drawing.Point(387, 128);
            this.btnSubmit4.Name = "btnSubmit4";
            this.btnSubmit4.Size = new System.Drawing.Size(100, 44);
            this.btnSubmit4.TabIndex = 7;
            this.btnSubmit4.UseVisualStyleBackColor = true;
            this.btnSubmit4.Click += new System.EventHandler(this.btnSubmit4_OnClick);
            // 
            // btnSubmit5
            // 
            this.btnSubmit5.Location = new System.Drawing.Point(512, 128);
            this.btnSubmit5.Name = "btnSubmit5";
            this.btnSubmit5.Size = new System.Drawing.Size(100, 44);
            this.btnSubmit5.TabIndex = 8;
            this.btnSubmit5.UseVisualStyleBackColor = true;
            this.btnSubmit5.Click += new System.EventHandler(this.btnSubmit5_OnClick);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(299, 77);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 20);
            this.txtName.TabIndex = 10;
            this.txtName.Text = "John Smith";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(331, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Name";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(19, 362);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(593, 151);
            this.dataGridView1.TabIndex = 11;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // txtPreview
            // 
            this.txtPreview.Location = new System.Drawing.Point(19, 188);
            this.txtPreview.Name = "txtPreview";
            this.txtPreview.Size = new System.Drawing.Size(593, 75);
            this.txtPreview.TabIndex = 13;
            this.txtPreview.Text = "";
            this.txtPreview.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(73, 298);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(480, 36);
            this.btnSend.TabIndex = 14;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_OnClick);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(73, 537);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(480, 36);
            this.btnExport.TabIndex = 15;
            this.btnExport.Text = "Export History";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // lblSuccessMsg
            // 
            this.lblSuccessMsg.AutoSize = true;
            this.lblSuccessMsg.Location = new System.Drawing.Point(12, 579);
            this.lblSuccessMsg.Name = "lblSuccessMsg";
            this.lblSuccessMsg.Size = new System.Drawing.Size(0, 13);
            this.lblSuccessMsg.TabIndex = 16;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 601);
            this.Controls.Add(this.lblSuccessMsg);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtPreview);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSubmit5);
            this.Controls.Add(this.btnSubmit4);
            this.Controls.Add(this.btnSubmit3);
            this.Controls.Add(this.btnSubmit2);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSubmit1);
            this.Name = "Form1";
            this.Text = "Send Text to Phone";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSubmit1;
        //  private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Button btnSubmit2;
        private System.Windows.Forms.Button btnSubmit3;
        private System.Windows.Forms.Button btnSubmit4;
        private System.Windows.Forms.Button btnSubmit5;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.RichTextBox txtPreview;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Label lblSuccessMsg;
    }
}

