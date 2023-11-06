using System.ComponentModel;

namespace View
{
    partial class ParameterUserControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ParameterNameLabel = new System.Windows.Forms.Label();
            this.ParameterBordersLabel = new System.Windows.Forms.Label();
            this.ParameterTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ParameterNameLabel
            // 
            this.ParameterNameLabel.Location = new System.Drawing.Point(3, 6);
            this.ParameterNameLabel.Name = "ParameterNameLabel";
            this.ParameterNameLabel.Size = new System.Drawing.Size(55, 13);
            this.ParameterNameLabel.TabIndex = 0;
            this.ParameterNameLabel.Text = "Name";
            // 
            // ParameterBordersLabel
            // 
            this.ParameterBordersLabel.Location = new System.Drawing.Point(182, 6);
            this.ParameterBordersLabel.Name = "ParameterBordersLabel";
            this.ParameterBordersLabel.Size = new System.Drawing.Size(43, 13);
            this.ParameterBordersLabel.TabIndex = 1;
            this.ParameterBordersLabel.Text = "Borders";
            // 
            // ParameterTextBox
            // 
            this.ParameterTextBox.Location = new System.Drawing.Point(76, 3);
            this.ParameterTextBox.Name = "ParameterTextBox";
            this.ParameterTextBox.Size = new System.Drawing.Size(100, 20);
            this.ParameterTextBox.TabIndex = 2;
            // 
            // ParameterUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ParameterTextBox);
            this.Controls.Add(this.ParameterBordersLabel);
            this.Controls.Add(this.ParameterNameLabel);
            this.Name = "ParameterUserControl";
            this.Size = new System.Drawing.Size(274, 26);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label ParameterNameLabel;
        private System.Windows.Forms.Label ParameterBordersLabel;
        private System.Windows.Forms.TextBox ParameterTextBox;

        #endregion
    }
}