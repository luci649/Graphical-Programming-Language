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
            ((System.ComponentModel.ISupportInitialize)OutputDisplay).BeginInit();
            SuspendLayout();
            // 
            // RunButton
            // 
            RunButton.Location = new Point(470, 72);
            RunButton.Name = "RunButton";
            RunButton.Size = new Size(112, 34);
            RunButton.TabIndex = 0;
            RunButton.Text = "Run";
            RunButton.UseVisualStyleBackColor = true;
            RunButton.Click += RunButton_keyDown;
            // 
            // SingleCommand
            // 
            SingleCommand.Location = new Point(132, 74);
            SingleCommand.Name = "SingleCommand";
            SingleCommand.Size = new Size(241, 31);
            SingleCommand.TabIndex = 1;
            SingleCommand.KeyDown += SingleCommand_KeyDown;
            // 
            // OutputDisplay
            // 
            OutputDisplay.BackColor = SystemColors.Window;
            OutputDisplay.Location = new Point(132, 129);
            OutputDisplay.Name = "OutputDisplay";
            OutputDisplay.Size = new Size(241, 186);
            OutputDisplay.TabIndex = 2;
            OutputDisplay.TabStop = false;
            OutputDisplay.Paint += OutputDisplay_Paint;
            // 
            // MultiCommand
            // 
            MultiCommand.Location = new Point(470, 129);
            MultiCommand.Name = "MultiCommand";
            MultiCommand.Size = new Size(249, 186);
            MultiCommand.TabIndex = 3;
            MultiCommand.Text = "";
            // 
            // SyntxButton
            // 
            SyntxButton.Location = new Point(607, 71);
            SyntxButton.Name = "SyntxButton";
            SyntxButton.Size = new Size(112, 34);
            SyntxButton.TabIndex = 4;
            SyntxButton.Text = "Syntax";
            SyntxButton.UseVisualStyleBackColor = true;
            SyntxButton.Click += SyntxButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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
    }
}