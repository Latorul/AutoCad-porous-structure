using System.ComponentModel;
using System.Windows.Forms;

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
            this.BuildButton = new System.Windows.Forms.Button();
            this.PoreSizeParameterUserControl = new View.ParameterUserControl();
            this.PorosityParameterUserControl = new View.ParameterUserControl();
            this.HeightParameterUserControl = new View.ParameterUserControl();
            this.WidthParameterUserControl = new View.ParameterUserControl();
            this.LengthParameterUserControl = new View.ParameterUserControl();
            this.SuspendLayout();
            // 
            // BuildButton
            // 
            this.BuildButton.Location = new System.Drawing.Point(117, 211);
            this.BuildButton.Name = "BuildButton";
            this.BuildButton.Size = new System.Drawing.Size(80, 23);
            this.BuildButton.TabIndex = 5;
            this.BuildButton.Text = "Построить";
            this.BuildButton.UseVisualStyleBackColor = true;
            this.BuildButton.Click += new System.EventHandler(this.BuildButton_Click);
            // 
            // PoreSizeParameterUserControl
            // 
            this.PoreSizeParameterUserControl.HasError = false;
            this.PoreSizeParameterUserControl.Location = new System.Drawing.Point(12, 140);
            this.PoreSizeParameterUserControl.Name = "PoreSizeParameterUserControl";
            this.PoreSizeParameterUserControl.ParameterText = "";
            this.PoreSizeParameterUserControl.ParameterType = Model.ParameterType.PoreSize;
            this.PoreSizeParameterUserControl.Size = new System.Drawing.Size(274, 26);
            this.PoreSizeParameterUserControl.TabIndex = 4;
            // 
            // PorosityParameterUserControl
            // 
            this.PorosityParameterUserControl.HasError = false;
            this.PorosityParameterUserControl.Location = new System.Drawing.Point(12, 108);
            this.PorosityParameterUserControl.Name = "PorosityParameterUserControl";
            this.PorosityParameterUserControl.ParameterText = "";
            this.PorosityParameterUserControl.ParameterType = Model.ParameterType.Porosity;
            this.PorosityParameterUserControl.Size = new System.Drawing.Size(274, 26);
            this.PorosityParameterUserControl.TabIndex = 3;
            // 
            // HeightParameterUserControl
            // 
            this.HeightParameterUserControl.HasError = false;
            this.HeightParameterUserControl.Location = new System.Drawing.Point(12, 76);
            this.HeightParameterUserControl.Name = "HeightParameterUserControl";
            this.HeightParameterUserControl.ParameterText = "";
            this.HeightParameterUserControl.ParameterType = Model.ParameterType.Height;
            this.HeightParameterUserControl.Size = new System.Drawing.Size(274, 26);
            this.HeightParameterUserControl.TabIndex = 2;
            // 
            // WidthParameterUserControl
            // 
            this.WidthParameterUserControl.HasError = false;
            this.WidthParameterUserControl.Location = new System.Drawing.Point(12, 44);
            this.WidthParameterUserControl.Name = "WidthParameterUserControl";
            this.WidthParameterUserControl.ParameterText = "";
            this.WidthParameterUserControl.ParameterType = Model.ParameterType.Width;
            this.WidthParameterUserControl.Size = new System.Drawing.Size(274, 26);
            this.WidthParameterUserControl.TabIndex = 1;
            // 
            // LengthParameterUserControl
            // 
            this.LengthParameterUserControl.HasError = false;
            this.LengthParameterUserControl.Location = new System.Drawing.Point(12, 12);
            this.LengthParameterUserControl.Name = "LengthParameterUserControl";
            this.LengthParameterUserControl.ParameterText = "";
            this.LengthParameterUserControl.ParameterType = Model.ParameterType.Length;
            this.LengthParameterUserControl.Size = new System.Drawing.Size(274, 26);
            this.LengthParameterUserControl.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(298, 246);
            this.Controls.Add(this.BuildButton);
            this.Controls.Add(this.PoreSizeParameterUserControl);
            this.Controls.Add(this.PorosityParameterUserControl);
            this.Controls.Add(this.HeightParameterUserControl);
            this.Controls.Add(this.WidthParameterUserControl);
            this.Controls.Add(this.LengthParameterUserControl);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Button BuildButton;

        private View.ParameterUserControl LengthParameterUserControl;
        private View.ParameterUserControl WidthParameterUserControl;
        private View.ParameterUserControl HeightParameterUserControl;
        private View.ParameterUserControl PorosityParameterUserControl;
        private View.ParameterUserControl PoreSizeParameterUserControl;

        #endregion
    }
}