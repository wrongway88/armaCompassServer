namespace CompassServer
{
    partial class Compass
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
            this.textBox_debugRotation = new System.Windows.Forms.TextBox();
            this.button_debugApply = new System.Windows.Forms.Button();
            this.textBox_debugOutput = new System.Windows.Forms.TextBox();
            this.button_clearDebugOutput = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox_debugRotation
            // 
            this.textBox_debugRotation.Location = new System.Drawing.Point(12, 12);
            this.textBox_debugRotation.Name = "textBox_debugRotation";
            this.textBox_debugRotation.Size = new System.Drawing.Size(268, 20);
            this.textBox_debugRotation.TabIndex = 0;
            this.textBox_debugRotation.TextChanged += new System.EventHandler(this.textBox_debugRotation_TextChanged);
            // 
            // button_debugApply
            // 
            this.button_debugApply.Location = new System.Drawing.Point(13, 39);
            this.button_debugApply.Name = "button_debugApply";
            this.button_debugApply.Size = new System.Drawing.Size(75, 23);
            this.button_debugApply.TabIndex = 1;
            this.button_debugApply.Text = "Apply";
            this.button_debugApply.UseVisualStyleBackColor = true;
            this.button_debugApply.Click += new System.EventHandler(this.button_debugApply_Click);
            // 
            // textBox_debugOutput
            // 
            this.textBox_debugOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_debugOutput.Location = new System.Drawing.Point(13, 69);
            this.textBox_debugOutput.Multiline = true;
            this.textBox_debugOutput.Name = "textBox_debugOutput";
            this.textBox_debugOutput.ReadOnly = true;
            this.textBox_debugOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_debugOutput.Size = new System.Drawing.Size(262, 123);
            this.textBox_debugOutput.TabIndex = 2;
            // 
            // button_clearDebugOutput
            // 
            this.button_clearDebugOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_clearDebugOutput.Location = new System.Drawing.Point(13, 198);
            this.button_clearDebugOutput.Name = "button_clearDebugOutput";
            this.button_clearDebugOutput.Size = new System.Drawing.Size(75, 23);
            this.button_clearDebugOutput.TabIndex = 3;
            this.button_clearDebugOutput.Text = "Clear";
            this.button_clearDebugOutput.UseVisualStyleBackColor = true;
            this.button_clearDebugOutput.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button_clearDebugOutput_MouseClick);
            // 
            // Compass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 233);
            this.Controls.Add(this.button_clearDebugOutput);
            this.Controls.Add(this.textBox_debugOutput);
            this.Controls.Add(this.button_debugApply);
            this.Controls.Add(this.textBox_debugRotation);
            this.Name = "Compass";
            this.Text = "Compass";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_debugRotation;
        private System.Windows.Forms.Button button_debugApply;
        private System.Windows.Forms.TextBox textBox_debugOutput;
        private System.Windows.Forms.Button button_clearDebugOutput;
    }
}

