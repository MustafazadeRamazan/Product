using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForm
{
    public partial class Form1 : Form
    {
        public Form1() => InitializeComponent();


        private void addproduct_btn(object sender, EventArgs e)
        {
            var pf = new ProductForm();

            var result = pf.ShowDialog();

            if (result == DialogResult.OK)
            {
                var product = new Product(pf.textBox1.Text, pf.textBox2.Text, pf.numericUpDown1.Value);
                listBox1.Items.Add(product);
                ProductSerialize();
            }
        }

        private void editproduct_btn(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem is not null)
            {
                foreach (Product item in listBox1.Items)
                {
                    if (item == listBox1.SelectedItem)
                    {
                        var productForm = new ProductForm(item.Name, item.Country, item.Price);
                        var result = productForm.ShowDialog();

                        if (result == DialogResult.OK)
                        {
                            var temp = (listBox1.SelectedItem as Product);

                            temp.Name = productForm.textBox1.Text;
                            temp.Country = productForm.textBox2.Text;
                            temp.Price = productForm.numericUpDown1.Value;

                            ProductSerialize();
                            return;
                        }
                    }
                }
            }

            else
            {
                MessageBox.Show("List is empty", "NOT!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void removeproduct_btn(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                listBox1.Items.Remove(listBox1.SelectedItem);
            }
        }

        private void clearlist_btn(object sender, EventArgs e) => listBox1.Items.Clear();

        private void ProductSerialize()
        {
            var pf = new BinaryFormatter();
            using var stream = new FileStream("products.bin", FileMode.Create);
            var products = new ArrayList();
            foreach (var item in listBox1.Items) products.Add(item);
            pf.Serialize(stream, products);
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists("products.bin"))
            {
                var pf = new BinaryFormatter();
                using var stream = new FileStream("products.bin", FileMode.Open);
                var products = pf.Deserialize(stream) as ArrayList;
                listBox1.Items.AddRange(products.ToArray());
            }
        }
    }
}
