using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForm
{
    public partial class ProductForm : Form
    {
        public ProductForm() => InitializeComponent();

        public ProductForm(string name, string country, decimal price)
        {
            InitializeComponent();

            textBox1.Text = name;
            textBox2.Text = country;
            numericUpDown1.Value = price;

        }

        private void ok_click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) | string.IsNullOrWhiteSpace(textBox2.Text) | numericUpDown1.Value.ToString() == "0")
                MessageBox.Show("Please enter product name,country,price!", "NOT!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            else DialogResult = DialogResult.OK;
        }

        private void cancel_click(object sender, EventArgs e) => DialogResult = DialogResult.Cancel;
    }
}
