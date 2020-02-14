namespace SpeechToText
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.startRecordingBtn = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.fileSelectedLabel = new System.Windows.Forms.Label();
            this.saveTranscriptBtn = new System.Windows.Forms.Button();
            this.voiceModelDropdown = new System.Windows.Forms.ComboBox();
            this.transcribeBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.enableAutoPunctuationDropdown = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.stopRecordingBtn = new System.Windows.Forms.Button();
            this.labelRecording = new System.Windows.Forms.Label();
            this.processingLabel = new System.Windows.Forms.Label();
            this.addUriBtn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.addURIText = new System.Windows.Forms.RichTextBox();
            this.languageCodeBox = new System.Windows.Forms.RichTextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.White;
            this.richTextBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.richTextBox1.Location = new System.Drawing.Point(675, 42);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(375, 273);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(671, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(251, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Transcribed text will be displayed here";
            // 
            // startRecordingBtn
            // 
            this.startRecordingBtn.Location = new System.Drawing.Point(21, 42);
            this.startRecordingBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.startRecordingBtn.Name = "startRecordingBtn";
            this.startRecordingBtn.Size = new System.Drawing.Size(187, 30);
            this.startRecordingBtn.TabIndex = 3;
            this.startRecordingBtn.Text = "Start recording";
            this.startRecordingBtn.UseVisualStyleBackColor = true;
            this.startRecordingBtn.Click += new System.EventHandler(this.startRecordingBtn_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(248, 43);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(187, 30);
            this.button2.TabIndex = 4;
            this.button2.Text = "Add Local File";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 280);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Selected: ";
            // 
            // fileSelectedLabel
            // 
            this.fileSelectedLabel.AutoSize = true;
            this.fileSelectedLabel.Location = new System.Drawing.Point(107, 280);
            this.fileSelectedLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.fileSelectedLabel.Name = "fileSelectedLabel";
            this.fileSelectedLabel.Size = new System.Drawing.Size(31, 17);
            this.fileSelectedLabel.TabIndex = 6;
            this.fileSelectedLabel.Text = "test";
            // 
            // saveTranscriptBtn
            // 
            this.saveTranscriptBtn.Enabled = false;
            this.saveTranscriptBtn.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveTranscriptBtn.Location = new System.Drawing.Point(248, 81);
            this.saveTranscriptBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.saveTranscriptBtn.Name = "saveTranscriptBtn";
            this.saveTranscriptBtn.Size = new System.Drawing.Size(187, 30);
            this.saveTranscriptBtn.TabIndex = 7;
            this.saveTranscriptBtn.Text = "Save Transcript";
            this.saveTranscriptBtn.UseVisualStyleBackColor = true;
            this.saveTranscriptBtn.Click += new System.EventHandler(this.saveTranscriptBtn_Click);
            // 
            // voiceModelDropdown
            // 
            this.voiceModelDropdown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.voiceModelDropdown.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.voiceModelDropdown.FormattingEnabled = true;
            this.voiceModelDropdown.Items.AddRange(new object[] {
            "default",
            "command_and_search",
            "phone_call",
            "video"});
            this.voiceModelDropdown.Location = new System.Drawing.Point(248, 153);
            this.voiceModelDropdown.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.voiceModelDropdown.Name = "voiceModelDropdown";
            this.voiceModelDropdown.Size = new System.Drawing.Size(187, 25);
            this.voiceModelDropdown.TabIndex = 8;
            // 
            // transcribeBtn
            // 
            this.transcribeBtn.Enabled = false;
            this.transcribeBtn.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.transcribeBtn.Location = new System.Drawing.Point(23, 80);
            this.transcribeBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.transcribeBtn.Name = "transcribeBtn";
            this.transcribeBtn.Size = new System.Drawing.Size(187, 30);
            this.transcribeBtn.TabIndex = 9;
            this.transcribeBtn.Text = "Transcribe";
            this.transcribeBtn.UseVisualStyleBackColor = true;
            this.transcribeBtn.Click += new System.EventHandler(this.transcribeBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(20, 156);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(189, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "Voice Recognition Model *: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(19, 189);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(217, 17);
            this.label4.TabIndex = 11;
            this.label4.Text = "Enable automatic punctuation: ";
            // 
            // enableAutoPunctuationDropdown
            // 
            this.enableAutoPunctuationDropdown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.enableAutoPunctuationDropdown.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enableAutoPunctuationDropdown.FormattingEnabled = true;
            this.enableAutoPunctuationDropdown.Items.AddRange(new object[] {
            "Yes",
            "No"});
            this.enableAutoPunctuationDropdown.Location = new System.Drawing.Point(249, 186);
            this.enableAutoPunctuationDropdown.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.enableAutoPunctuationDropdown.Name = "enableAutoPunctuationDropdown";
            this.enableAutoPunctuationDropdown.Size = new System.Drawing.Size(186, 25);
            this.enableAutoPunctuationDropdown.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 228);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 17);
            this.label5.TabIndex = 13;
            this.label5.Text = "Language code:";
            // 
            // stopRecordingBtn
            // 
            this.stopRecordingBtn.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stopRecordingBtn.Location = new System.Drawing.Point(22, 43);
            this.stopRecordingBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.stopRecordingBtn.Name = "stopRecordingBtn";
            this.stopRecordingBtn.Size = new System.Drawing.Size(187, 30);
            this.stopRecordingBtn.TabIndex = 15;
            this.stopRecordingBtn.Text = "Stop Recording";
            this.stopRecordingBtn.UseVisualStyleBackColor = true;
            this.stopRecordingBtn.Visible = false;
            this.stopRecordingBtn.Click += new System.EventHandler(this.stopRecordingBtn_Click);
            // 
            // labelRecording
            // 
            this.labelRecording.AutoSize = true;
            this.labelRecording.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRecording.Location = new System.Drawing.Point(15, 350);
            this.labelRecording.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelRecording.Name = "labelRecording";
            this.labelRecording.Size = new System.Drawing.Size(157, 30);
            this.labelRecording.TabIndex = 16;
            this.labelRecording.Text = "Recording...";
            this.labelRecording.Visible = false;
            // 
            // processingLabel
            // 
            this.processingLabel.AutoSize = true;
            this.processingLabel.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.processingLabel.Location = new System.Drawing.Point(17, 395);
            this.processingLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.processingLabel.Name = "processingLabel";
            this.processingLabel.Size = new System.Drawing.Size(160, 30);
            this.processingLabel.TabIndex = 17;
            this.processingLabel.Text = "Processing...";
            this.processingLabel.Visible = false;
            // 
            // addUriBtn
            // 
            this.addUriBtn.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addUriBtn.Location = new System.Drawing.Point(160, -1);
            this.addUriBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.addUriBtn.Name = "addUriBtn";
            this.addUriBtn.Size = new System.Drawing.Size(25, 25);
            this.addUriBtn.TabIndex = 18;
            this.addUriBtn.Text = "+";
            this.addUriBtn.UseVisualStyleBackColor = true;
            this.addUriBtn.Click += new System.EventHandler(this.addUriBtn_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(20, 120);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(118, 17);
            this.label6.TabIndex = 20;
            this.label6.Text = "Add File From URI";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.addURIText);
            this.panel1.Controls.Add(this.addUriBtn);
            this.panel1.Location = new System.Drawing.Point(249, 119);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(186, 25);
            this.panel1.TabIndex = 21;
            // 
            // addURIText
            // 
            this.addURIText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.addURIText.Location = new System.Drawing.Point(-1, -2);
            this.addURIText.Multiline = false;
            this.addURIText.Name = "addURIText";
            this.addURIText.Size = new System.Drawing.Size(161, 25);
            this.addURIText.TabIndex = 22;
            this.addURIText.Text = "";
            // 
            // languageCodeBox
            // 
            this.languageCodeBox.Location = new System.Drawing.Point(248, 225);
            this.languageCodeBox.Multiline = false;
            this.languageCodeBox.Name = "languageCodeBox";
            this.languageCodeBox.Size = new System.Drawing.Size(187, 25);
            this.languageCodeBox.TabIndex = 22;
            this.languageCodeBox.Text = "en-US";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1067, 588);
            this.Controls.Add(this.languageCodeBox);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.processingLabel);
            this.Controls.Add(this.labelRecording);
            this.Controls.Add(this.stopRecordingBtn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.enableAutoPunctuationDropdown);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.transcribeBtn);
            this.Controls.Add(this.voiceModelDropdown);
            this.Controls.Add(this.saveTranscriptBtn);
            this.Controls.Add(this.fileSelectedLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.startRecordingBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox1);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button startRecordingBtn;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label fileSelectedLabel;
        private System.Windows.Forms.Button saveTranscriptBtn;
        private System.Windows.Forms.ComboBox voiceModelDropdown;
        private System.Windows.Forms.Button transcribeBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox enableAutoPunctuationDropdown;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button stopRecordingBtn;
        private System.Windows.Forms.Label labelRecording;
        private System.Windows.Forms.Label processingLabel;
        private System.Windows.Forms.Button addUriBtn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox addURIText;
        private System.Windows.Forms.RichTextBox languageCodeBox;
    }
}

