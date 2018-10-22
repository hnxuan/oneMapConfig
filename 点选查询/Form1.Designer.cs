namespace 点选查询
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.servicesText = new System.Windows.Forms.RichTextBox();
            this.okButton = new System.Windows.Forms.Button();
            this.configText = new System.Windows.Forms.RichTextBox();
            this.keyWord = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.unitKeyWord = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.layerNameKeyWord = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tokenValue = new System.Windows.Forms.TextBox();
            this.isEnglish = new System.Windows.Forms.CheckBox();
            this.isKeyField = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.configJsonUrl = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.checkConfigJsonUrl = new System.Windows.Forms.TextBox();
            this.idKeyWord = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.check_Btn = new System.Windows.Forms.Button();
            this.chineseLayerName = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // servicesText
            // 
            this.servicesText.Location = new System.Drawing.Point(2, 214);
            this.servicesText.Name = "servicesText";
            this.servicesText.Size = new System.Drawing.Size(371, 473);
            this.servicesText.TabIndex = 0;
            this.servicesText.Text = "";
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(379, 266);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(38, 23);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "→";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // configText
            // 
            this.configText.Location = new System.Drawing.Point(423, 214);
            this.configText.Name = "configText";
            this.configText.Size = new System.Drawing.Size(619, 473);
            this.configText.TabIndex = 2;
            this.configText.Text = "";
            // 
            // keyWord
            // 
            this.keyWord.Location = new System.Drawing.Point(423, 90);
            this.keyWord.Name = "keyWord";
            this.keyWord.Size = new System.Drawing.Size(609, 42);
            this.keyWord.TabIndex = 3;
            this.keyWord.Text = "OBJECTID,Shape,Shape_Length,Shape_Area,Shape_Leng,OBJECTID_1,FID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(423, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "字段过滤关键词(以,分隔开)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 190);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(311, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "服务地址输入(换行分隔) 如需指定id，输入格式为id@url";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(421, 190);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "生成Json结果";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(155, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "单位关键字提取(以,分隔开)";
            // 
            // unitKeyWord
            // 
            this.unitKeyWord.Location = new System.Drawing.Point(4, 90);
            this.unitKeyWord.Name = "unitKeyWord";
            this.unitKeyWord.Size = new System.Drawing.Size(369, 23);
            this.unitKeyWord.TabIndex = 8;
            this.unitKeyWord.Text = "亩,平方米,公顷,米";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "图层名过滤(以,分隔开)";
            // 
            // layerNameKeyWord
            // 
            this.layerNameKeyWord.Location = new System.Drawing.Point(4, 136);
            this.layerNameKeyWord.Name = "layerNameKeyWord";
            this.layerNameKeyWord.Size = new System.Drawing.Size(369, 36);
            this.layerNameKeyWord.TabIndex = 10;
            this.layerNameKeyWord.Text = "底,等深面,政区面";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(401, 12);
            this.label6.TabIndex = 11;
            this.label6.Text = "Token（确认该token允许该本机IP直接访问,访问无需token的服务请清空）";
            // 
            // tokenValue
            // 
            this.tokenValue.Location = new System.Drawing.Point(403, 48);
            this.tokenValue.Name = "tokenValue";
            this.tokenValue.Size = new System.Drawing.Size(629, 21);
            this.tokenValue.TabIndex = 12;
            // 
            // isEnglish
            // 
            this.isEnglish.AutoSize = true;
            this.isEnglish.Checked = true;
            this.isEnglish.CheckState = System.Windows.Forms.CheckState.Checked;
            this.isEnglish.Location = new System.Drawing.Point(425, 139);
            this.isEnglish.Name = "isEnglish";
            this.isEnglish.Size = new System.Drawing.Size(144, 16);
            this.isEnglish.TabIndex = 13;
            this.isEnglish.Text = "只显示包含中文的字段";
            this.isEnglish.UseVisualStyleBackColor = true;
            // 
            // isKeyField
            // 
            this.isKeyField.AutoSize = true;
            this.isKeyField.Location = new System.Drawing.Point(588, 139);
            this.isKeyField.Name = "isKeyField";
            this.isKeyField.Size = new System.Drawing.Size(96, 16);
            this.isKeyField.TabIndex = 14;
            this.isKeyField.Text = "生成keyField";
            this.isKeyField.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(2, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(113, 12);
            this.label7.TabIndex = 15;
            this.label7.Text = "根目录配置文件地址";
            // 
            // configJsonUrl
            // 
            this.configJsonUrl.Location = new System.Drawing.Point(112, 11);
            this.configJsonUrl.Name = "configJsonUrl";
            this.configJsonUrl.Size = new System.Drawing.Size(201, 21);
            this.configJsonUrl.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(313, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(125, 12);
            this.label8.TabIndex = 17;
            this.label8.Text = "点选查询配置文件地址";
            // 
            // checkConfigJsonUrl
            // 
            this.checkConfigJsonUrl.Location = new System.Drawing.Point(441, 11);
            this.checkConfigJsonUrl.Name = "checkConfigJsonUrl";
            this.checkConfigJsonUrl.Size = new System.Drawing.Size(195, 21);
            this.checkConfigJsonUrl.TabIndex = 18;
            // 
            // idKeyWord
            // 
            this.idKeyWord.Location = new System.Drawing.Point(683, 11);
            this.idKeyWord.Name = "idKeyWord";
            this.idKeyWord.Size = new System.Drawing.Size(217, 21);
            this.idKeyWord.TabIndex = 19;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(642, 18);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 20;
            this.label9.Text = "忽略Id";
            // 
            // check_Btn
            // 
            this.check_Btn.Location = new System.Drawing.Point(906, 11);
            this.check_Btn.Name = "check_Btn";
            this.check_Btn.Size = new System.Drawing.Size(61, 23);
            this.check_Btn.TabIndex = 21;
            this.check_Btn.Text = "未配服务";
            this.check_Btn.UseVisualStyleBackColor = true;
            this.check_Btn.Click += new System.EventHandler(this.check_Btn_Click);
            // 
            // chineseLayerName
            // 
            this.chineseLayerName.AutoSize = true;
            this.chineseLayerName.Location = new System.Drawing.Point(702, 139);
            this.chineseLayerName.Name = "chineseLayerName";
            this.chineseLayerName.Size = new System.Drawing.Size(156, 16);
            this.chineseLayerName.TabIndex = 22;
            this.chineseLayerName.Text = "只显示包含中文的图层名";
            this.chineseLayerName.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(973, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(69, 23);
            this.button1.TabIndex = 23;
            this.button1.Text = "已配比较";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1045, 689);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.chineseLayerName);
            this.Controls.Add(this.check_Btn);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.idKeyWord);
            this.Controls.Add(this.checkConfigJsonUrl);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.configJsonUrl);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.isKeyField);
            this.Controls.Add(this.isEnglish);
            this.Controls.Add(this.tokenValue);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.layerNameKeyWord);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.unitKeyWord);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.keyWord);
            this.Controls.Add(this.configText);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.servicesText);
            this.Name = "Form1";
            this.Text = "点选查询相关配置";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox servicesText;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.RichTextBox configText;
        private System.Windows.Forms.RichTextBox keyWord;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox unitKeyWord;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox layerNameKeyWord;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tokenValue;
        private System.Windows.Forms.CheckBox isEnglish;
        private System.Windows.Forms.CheckBox isKeyField;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox configJsonUrl;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox checkConfigJsonUrl;
        private System.Windows.Forms.TextBox idKeyWord;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button check_Btn;
        private System.Windows.Forms.CheckBox chineseLayerName;
        private System.Windows.Forms.Button button1;
    }
}

