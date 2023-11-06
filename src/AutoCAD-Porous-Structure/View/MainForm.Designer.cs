using System.ComponentModel;

namespace View
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.parameterUserControl1 = new View.ParameterUserControl();
            this.parameterUserControl2 = new View.ParameterUserControl();
            this.parameterUserControl3 = new View.ParameterUserControl();
            this.parameterUserControl4 = new View.ParameterUserControl();
            this.parameterUserControl5 = new View.ParameterUserControl();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // parameterUserControl1
            // 
            this.parameterUserControl1.Location = new System.Drawing.Point(12, 12);
            this.parameterUserControl1.Name = "parameterUserControl1";
            this.parameterUserControl1.Size = new System.Drawing.Size(274, 26);
            this.parameterUserControl1.TabIndex = 0;
            // 
            // parameterUserControl2
            // 
            this.parameterUserControl2.Location = new System.Drawing.Point(12, 44);
            this.parameterUserControl2.Name = "parameterUserControl2";
            this.parameterUserControl2.Size = new System.Drawing.Size(274, 26);
            this.parameterUserControl2.TabIndex = 1;
            // 
            // parameterUserControl3
            // 
            this.parameterUserControl3.Location = new System.Drawing.Point(12, 76);
            this.parameterUserControl3.Name = "parameterUserControl3";
            this.parameterUserControl3.Size = new System.Drawing.Size(274, 26);
            this.parameterUserControl3.TabIndex = 2;
            // 
            // parameterUserControl4
            // 
            this.parameterUserControl4.Location = new System.Drawing.Point(12, 108);
            this.parameterUserControl4.Name = "parameterUserControl4";
            this.parameterUserControl4.Size = new System.Drawing.Size(274, 26);
            this.parameterUserControl4.TabIndex = 3;
            // 
            // parameterUserControl5
            // 
            this.parameterUserControl5.Location = new System.Drawing.Point(12, 140);
            this.parameterUserControl5.Name = "parameterUserControl5";
            this.parameterUserControl5.Size = new System.Drawing.Size(274, 26);
            this.parameterUserControl5.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(117, 211);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Построить";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 246);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.parameterUserControl5);
            this.Controls.Add(this.parameterUserControl4);
            this.Controls.Add(this.parameterUserControl3);
            this.Controls.Add(this.parameterUserControl2);
            this.Controls.Add(this.parameterUserControl1);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button button1;

        private View.ParameterUserControl parameterUserControl1;
        private View.ParameterUserControl parameterUserControl2;
        private View.ParameterUserControl parameterUserControl3;
        private View.ParameterUserControl parameterUserControl4;
        private View.ParameterUserControl parameterUserControl5;

        #endregion
    }
}