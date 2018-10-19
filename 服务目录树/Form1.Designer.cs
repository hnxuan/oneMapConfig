namespace 生成服务目录树
{
    partial class Form1
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.richTextBox3 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.serverIdOne = new System.Windows.Forms.CheckBox();
            this.configJsonUrl = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.muluIdCheck = new System.Windows.Forms.Button();
            this.serverIdCheck = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.zhengxu = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(4, 90);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(370, 522);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(430, 90);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(446, 522);
            this.richTextBox2.TabIndex = 1;
            this.richTextBox2.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(380, 317);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(44, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "→";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // richTextBox3
            // 
            this.richTextBox3.Location = new System.Drawing.Point(883, 90);
            this.richTextBox3.Name = "richTextBox3";
            this.richTextBox3.Size = new System.Drawing.Size(431, 522);
            this.richTextBox3.TabIndex = 3;
            this.richTextBox3.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(430, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "layerlist节点JSON";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(883, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(389, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "operationallayers节点JSON(type字段为空说明地址有误或者加了token)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(431, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "填写说明：#name~id(①#个数代表级别数②服务节点后接,url③如有@后接勿删) ";
            // 
            // serverIdOne
            // 
            this.serverIdOne.AutoSize = true;
            this.serverIdOne.Location = new System.Drawing.Point(12, 39);
            this.serverIdOne.Name = "serverIdOne";
            this.serverIdOne.Size = new System.Drawing.Size(108, 16);
            this.serverIdOne.TabIndex = 7;
            this.serverIdOne.Text = "服务节点id唯一";
            this.serverIdOne.UseVisualStyleBackColor = true;
            // 
            // configJsonUrl
            // 
            this.configJsonUrl.Location = new System.Drawing.Point(156, 6);
            this.configJsonUrl.Name = "configJsonUrl";
            this.configJsonUrl.Size = new System.Drawing.Size(379, 21);
            this.configJsonUrl.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "根目录config.json地址";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(554, 6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "获取";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // muluIdCheck
            // 
            this.muluIdCheck.Location = new System.Drawing.Point(137, 33);
            this.muluIdCheck.Name = "muluIdCheck";
            this.muluIdCheck.Size = new System.Drawing.Size(103, 23);
            this.muluIdCheck.TabIndex = 11;
            this.muluIdCheck.Text = "重要!目录id校验";
            this.muluIdCheck.UseVisualStyleBackColor = true;
            this.muluIdCheck.Click += new System.EventHandler(this.muluIdCheck_Click);
            // 
            // serverIdCheck
            // 
            this.serverIdCheck.Location = new System.Drawing.Point(246, 33);
            this.serverIdCheck.Name = "serverIdCheck";
            this.serverIdCheck.Size = new System.Drawing.Size(75, 23);
            this.serverIdCheck.TabIndex = 12;
            this.serverIdCheck.Text = "服务id校验";
            this.serverIdCheck.UseVisualStyleBackColor = true;
            this.serverIdCheck.Click += new System.EventHandler(this.serverIdCheck_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(883, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(227, 12);
            this.label5.TabIndex = 13;
            this.label5.Text = "operationallayers节点正序目录逗号分隔";
            // 
            // zhengxu
            // 
            this.zhengxu.Location = new System.Drawing.Point(1116, 37);
            this.zhengxu.Name = "zhengxu";
            this.zhengxu.Size = new System.Drawing.Size(100, 21);
            this.zhengxu.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(885, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(179, 12);
            this.label6.TabIndex = 15;
            this.label6.Text = "注意:该结点顺序即叠加服务顺序";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1318, 615);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.zhengxu);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.serverIdCheck);
            this.Controls.Add(this.muluIdCheck);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.configJsonUrl);
            this.Controls.Add(this.serverIdOne);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.richTextBox1);
            this.Name = "Form1";
            this.Text = "服务目录树相关配置";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox richTextBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox serverIdOne;
        private System.Windows.Forms.TextBox configJsonUrl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button muluIdCheck;
        private System.Windows.Forms.Button serverIdCheck;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox zhengxu;
        private System.Windows.Forms.Label label6;
    }
}

