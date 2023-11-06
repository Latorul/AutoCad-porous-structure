using System.Collections.Generic;
using System.Windows.Forms;
using Model;
using Autodesk.AutoCAD.DatabaseServices;


namespace View
{
    public partial class MainForm : Form
    {
        private List<ParameterUserControl> _parameterUserControls; 
        
        public MainForm()
        {
            InitializeComponent();
        }

        public PorousParameter Parameters { get; set; }

        private void OnParameterUserControlChanged(object obj)
        {
            
        }

        private void UpdateParameters()
        {
            
        }

        public void BuildPorousStructure(PorousParameter parameters, Transaction transaction)
        {
            
        }
    }
}