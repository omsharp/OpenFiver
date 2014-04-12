using System;
using System.Windows.Forms;

namespace TestApp
{
    public partial class SizeForm : Form
    {
        public int GridSize;

        public SizeForm()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            GridSize = (int)numericUpDown1.Value;
        }

        private void btnCncl_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}