using System;
using System.Drawing;
using System.Windows.Forms;
using Model;

namespace View
{
    public partial class ParameterUserControl : UserControl
    {
        
        private delegate void ParameterChanged(object sender);

        private event ParameterChanged ParameterUserControlChanged;
        
        public string Text { get; set; }
        
        public Color BackColor { get; set; }
        
        public ParameterType ParameterType { get; set; }
        
        public ParameterUserControl()
        {
            InitializeComponent();
        }


        private void ParameterTextBox_TextChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}