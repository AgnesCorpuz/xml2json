namespace xml2json
{
    partial class frmXml2Json
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
            this.btnConvert = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.grpXmlFile = new System.Windows.Forms.GroupBox();
            this.grpXml = new System.Windows.Forms.GroupBox();
            this.txtXmlText = new System.Windows.Forms.TextBox();
            this.grpJSON = new System.Windows.Forms.GroupBox();
            this.txtJsonText = new System.Windows.Forms.TextBox();
            this.txtClose = new System.Windows.Forms.Button();
            this.txtClear = new System.Windows.Forms.Button();
            this.grpXmlFile.SuspendLayout();
            this.grpXml.SuspendLayout();
            this.grpJSON.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnConvert
            // 
            this.btnConvert.Location = new System.Drawing.Point(6, 21);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(75, 23);
            this.btnConvert.TabIndex = 0;
            this.btnConvert.Text = "Convert";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(87, 22);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(1376, 22);
            this.txtFilePath.TabIndex = 1;
            // 
            // grpXmlFile
            // 
            this.grpXmlFile.Controls.Add(this.btnConvert);
            this.grpXmlFile.Controls.Add(this.txtFilePath);
            this.grpXmlFile.Location = new System.Drawing.Point(12, 12);
            this.grpXmlFile.Name = "grpXmlFile";
            this.grpXmlFile.Size = new System.Drawing.Size(1469, 61);
            this.grpXmlFile.TabIndex = 2;
            this.grpXmlFile.TabStop = false;
            this.grpXmlFile.Text = "Upload XML File";
            // 
            // grpXml
            // 
            this.grpXml.Controls.Add(this.txtXmlText);
            this.grpXml.Location = new System.Drawing.Point(13, 80);
            this.grpXml.Name = "grpXml";
            this.grpXml.Size = new System.Drawing.Size(723, 530);
            this.grpXml.TabIndex = 3;
            this.grpXml.TabStop = false;
            this.grpXml.Text = "XML";
            // 
            // txtXmlText
            // 
            this.txtXmlText.Location = new System.Drawing.Point(7, 22);
            this.txtXmlText.Multiline = true;
            this.txtXmlText.Name = "txtXmlText";
            this.txtXmlText.ReadOnly = true;
            this.txtXmlText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtXmlText.Size = new System.Drawing.Size(710, 502);
            this.txtXmlText.TabIndex = 0;
            this.txtXmlText.WordWrap = false;
            // 
            // grpJSON
            // 
            this.grpJSON.Controls.Add(this.txtJsonText);
            this.grpJSON.Location = new System.Drawing.Point(742, 80);
            this.grpJSON.Name = "grpJSON";
            this.grpJSON.Size = new System.Drawing.Size(739, 530);
            this.grpJSON.TabIndex = 4;
            this.grpJSON.TabStop = false;
            this.grpJSON.Text = "JSON";
            // 
            // txtJsonText
            // 
            this.txtJsonText.Location = new System.Drawing.Point(6, 21);
            this.txtJsonText.Multiline = true;
            this.txtJsonText.Name = "txtJsonText";
            this.txtJsonText.ReadOnly = true;
            this.txtJsonText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtJsonText.Size = new System.Drawing.Size(727, 503);
            this.txtJsonText.TabIndex = 1;
            this.txtJsonText.WordWrap = false;
            // 
            // txtClose
            // 
            this.txtClose.Location = new System.Drawing.Point(1406, 627);
            this.txtClose.Name = "txtClose";
            this.txtClose.Size = new System.Drawing.Size(75, 23);
            this.txtClose.TabIndex = 5;
            this.txtClose.Text = "Close";
            this.txtClose.UseVisualStyleBackColor = true;
            this.txtClose.Click += new System.EventHandler(this.txtClose_Click);
            // 
            // txtClear
            // 
            this.txtClear.Location = new System.Drawing.Point(1325, 627);
            this.txtClear.Name = "txtClear";
            this.txtClear.Size = new System.Drawing.Size(75, 23);
            this.txtClear.TabIndex = 6;
            this.txtClear.Text = "Clear";
            this.txtClear.UseVisualStyleBackColor = true;
            this.txtClear.Click += new System.EventHandler(this.txtClear_Click);
            // 
            // frmXml2Json
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1493, 676);
            this.Controls.Add(this.txtClear);
            this.Controls.Add(this.txtClose);
            this.Controls.Add(this.grpJSON);
            this.Controls.Add(this.grpXml);
            this.Controls.Add(this.grpXmlFile);
            this.Name = "frmXml2Json";
            this.Text = "Convert XML to JSON";
            this.grpXmlFile.ResumeLayout(false);
            this.grpXmlFile.PerformLayout();
            this.grpXml.ResumeLayout(false);
            this.grpXml.PerformLayout();
            this.grpJSON.ResumeLayout(false);
            this.grpJSON.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.GroupBox grpXmlFile;
        private System.Windows.Forms.GroupBox grpXml;
        private System.Windows.Forms.TextBox txtXmlText;
        private System.Windows.Forms.GroupBox grpJSON;
        private System.Windows.Forms.TextBox txtJsonText;
        private System.Windows.Forms.Button txtClose;
        private System.Windows.Forms.Button txtClear;
    }
}

