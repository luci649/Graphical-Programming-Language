namespace GraphicalProgrammingLanguage
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            RunButton = new Button();
            SingleCommand = new TextBox();
            OutputDisplay = new PictureBox();
            MultiCommand = new RichTextBox();
            SyntxButton = new Button();
            MultiCommand2 = new RichTextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)OutputDisplay).BeginInit();
            SuspendLayout();
            // 
            // RunButton
            // 
            RunButton.Location = new Point(132, 353);
            RunButton.Name = "RunButton";
            RunButton.Size = new Size(112, 34);
            RunButton.TabIndex = 0;
            RunButton.Text = "Run";
            RunButton.UseVisualStyleBackColor = true;
            RunButton.Click += RunButton_keyDown;
            // 
            // SingleCommand
            // 
            SingleCommand.Location = new Point(132, 284);
            SingleCommand.Name = "SingleCommand";
            SingleCommand.Size = new Size(241, 31);
            SingleCommand.TabIndex = 1;
            SingleCommand.KeyDown += SingleCommand_KeyDown;
            // 
            // OutputDisplay
            // 
            OutputDisplay.BackColor = SystemColors.Window;
            OutputDisplay.Location = new Point(132, 56);
            OutputDisplay.Name = "OutputDisplay";
            OutputDisplay.Size = new Size(241, 186);
            OutputDisplay.TabIndex = 2;
            OutputDisplay.TabStop = false;
            OutputDisplay.Paint += OutputDisplay_Paint;
            // 
            // MultiCommand
            // 
            MultiCommand.Location = new Point(476, 56);
            MultiCommand.Name = "MultiCommand";
            MultiCommand.Size = new Size(249, 186);
            MultiCommand.TabIndex = 3;
            MultiCommand.Text = "";
            // 
            // SyntxButton
            // 
            SyntxButton.Location = new Point(261, 353);
            SyntxButton.Name = "SyntxButton";
            SyntxButton.Size = new Size(112, 34);
            SyntxButton.TabIndex = 4;
            SyntxButton.Text = "Syntax";
            SyntxButton.UseVisualStyleBackColor = true;
            SyntxButton.Click += SyntxButton_Click;
            // 
            // MultiCommand2
            // 
            MultiCommand2.Location = new Point(476, 284);
            MultiCommand2.Name = "MultiCommand2";
            MultiCommand2.Size = new Size(249, 186);
            MultiCommand2.TabIndex = 5;
            MultiCommand2.Text = "";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(476, 256);
            label1.Name = "label1";
            label1.Size = new Size(161, 25);
            label1.TabIndex = 6;
            label1.Text = "Program Textbox 2";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(476, 28);
            label2.Name = "label2";
            label2.Size = new Size(161, 25);
            label2.TabIndex = 7;
            label2.Text = "Program Textbox 1";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(132, 28);
            label3.Name = "label3";
            label3.Size = new Size(68, 25);
            label3.TabIndex = 8;
            label3.Text = "Canvas";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 494);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(MultiCommand2);
            Controls.Add(SyntxButton);
            Controls.Add(MultiCommand);
            Controls.Add(OutputDisplay);
            Controls.Add(SingleCommand);
            Controls.Add(RunButton);
            Name = "Form1";
            Text = "Graphical Programming Language";
            ((System.ComponentModel.ISupportInitialize)OutputDisplay).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button RunButton;
        private TextBox SingleCommand;
        private PictureBox OutputDisplay;
        private RichTextBox MultiCommand;
        private Button SyntxButton;
        private RichTextBox MultiCommand2;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}