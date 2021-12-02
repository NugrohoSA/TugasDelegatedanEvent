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
    public partial class FrmCalculator : Form
    {
        private IList<Calculator> listOfCalculator = new List<Calculator>();
        
        public FrmCalculator()
        {
            InitializeComponent();
            InisialisasiListView();
        }

        private void InisialisasiListView()
        {
            lvwCalculator.View = View.Details;
            lvwCalculator.FullRowSelect = true;
        }

        private void FrmEntry_OnCreate(Calculator cal)
        {
            listOfCalculator.Add(cal);

            ListViewItem item = new ListViewItem();
            item.SubItems.Add(cal.Hasil);

            lvwCalculator.Items.Add(item);
        }

        private void FrmEntry_OnUpdate(Calculator cal)
        {
            int row = lvwCalculator.SelectedIndices[0];

            ListViewItem itemRow = lvwCalculator.Items[row];
            
        }

        private void FrmCalculator_Load(object sender, EventArgs e)
        {

        }

        private void btnHitung_Click(object sender, EventArgs e)
        {
            FrmEntryCalculator frmEntry = new FrmEntryCalculator();

            frmEntry.OnCreate += FrmEntry_OnCreate;

            frmEntry.ShowDialog();
        }

        private void lvwCalculator_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
