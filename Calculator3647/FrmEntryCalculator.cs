using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator3647
{
    public partial class FrmEntryCalculator : Form
    {
        public delegate void CalculateEventHandler(Calculator cal);

        public event CalculateEventHandler OnCreate;

        public event CalculateEventHandler OnUpdate;

        private bool isNewData = true;

        private Calculator cal;

        public FrmEntryCalculator()
        {
            InitializeComponent();
        }

        public FrmEntryCalculator(string title)
            : this()
        {
            this.Text = title;
        }

        public FrmEntryCalculator(string title, Calculator obj)
            : this()
        {
            this.Text = title;

            isNewData = false;
            cal = obj;

            txtNilaiA.Text = cal.NilaiA;
            txtNilaiB.Text = cal.NilaiB;
            txtHasil.Text = cal.Hasil;
        }

        private bool NumericOnly(KeyPressEventArgs e)
        {
            var strValid = "0123456789";
            if (!(e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                // inputan selain angka
                if (strValid.IndexOf(e.KeyChar) < 0)
                {
                    return true;
                }
                return false;
            }
            else
                return false;
        }

        private void FrmEntryCalculator_Load(object sender, EventArgs e)
        {

        }

        private void btnProses_Click(object sender, EventArgs e)
        {
            double a, b, hasil;
            var matematika = cmbOperasi.Text;
            var nilai_a = txtNilaiA.Text;
            var nilai_b = txtNilaiB.Text;

            if (cmbOperasi.SelectedIndex == 0)
            {
                a = Double.Parse(txtNilaiA.Text);
                b = Double.Parse(txtNilaiB.Text);
                hasil = a + b;
                txtHasil.Text = string.Format("Hasil penjumlahan {0} + {1} = {2}", a, b, hasil);
            }
            else if (cmbOperasi.SelectedIndex == 1)
            {
                a = Double.Parse(txtNilaiA.Text);
                b = Double.Parse(txtNilaiB.Text);
                hasil = a - b;
                txtHasil.Text = string.Format("Hasil pengurangan {0} - {1} = {2}", a, b, hasil);
            }
            else if (cmbOperasi.SelectedIndex == 2)
            {
                a = Double.Parse(txtNilaiA.Text);
                b = Double.Parse(txtNilaiB.Text);
                hasil = a * b;
                txtHasil.Text = string.Format("Hasil perkalian {0} * {1} = {2}", a, b, hasil);
            }
            else if (cmbOperasi.SelectedIndex == 3)
            {
                a = Double.Parse(txtNilaiA.Text);
                b = Double.Parse(txtNilaiB.Text);
                hasil = a / b;
                txtHasil.Text = string.Format("Hasil pembagian {0} / {1} = {2}", a, b, hasil);
            }

            if (isNewData) cal = new Calculator();

            cal.NilaiA = txtNilaiA.Text;
            cal.NilaiB = txtNilaiB.Text;
            cal.Hasil = txtHasil.Text;

            if (isNewData)
            {
                OnCreate(cal);
            }
            else
            {
                OnUpdate(cal);
                this.Close();
            }
            

            
        }

        private void txtNilaiA_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = NumericOnly(e);
        }

        private void txtNilaiB_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = NumericOnly(e);
        }

        private void txtHasil_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
