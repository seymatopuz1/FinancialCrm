using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinancialCrm.Models;

namespace FinancialCrm
{
    public partial class FrmBankProcesses : Form
    {
        public FrmBankProcesses()
        {
            InitializeComponent();
        }
        FinancialCrmDbEntities db = new FinancialCrmDbEntities();

        private void btnCategoriesForm_Click(object sender, EventArgs e)
        {
            Categories categories = new Categories();
            categories.Show();
            this.Hide();
        }

        private void btnBanksForm_Click(object sender, EventArgs e)
        {
            FrmBanks banks = new FrmBanks();
            banks.Show();
            this.Hide();
        }

        private void btnSpendingsForm_Click(object sender, EventArgs e)
        {
            FrmSpendings  frm = new FrmSpendings();
            frm.Show();
            this.Hide();
        }

        private void btnBillForm_Click(object sender, EventArgs e)
        {
            FrmBilling billing = new FrmBilling();
            billing.Show();
            this.Hide();
        }

        private void btnBankProcessForm_Click(object sender, EventArgs e)
        {
            FrmBankProcesses bankProcesses = new FrmBankProcesses();    
            bankProcesses.Show();
            this.Hide();
        }

        private void btnDashboardForm_Click(object sender, EventArgs e)
        {
            FrmDashboard frm = new FrmDashboard();
            frm.Show();
            this.Hide();
        }

        private void btnBankProcessesList_Click(object sender, EventArgs e)
        {
            var values = db.BankProcesses.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnBankProcessesCreate_Click(object sender, EventArgs e)
        {
            string description = txtBankProcessesDescription.Text;
            string type = txtBankProcessesType.Text;
            decimal amount = decimal.Parse(txtBankProcessesAmount.Text);
            DateTime period = DateTime.Parse(txtBankProcessPeriod.Text);

            BankProcesses processes = new BankProcesses();
            processes.Description = description;
            processes.Amount = amount;
            processes.ProcessType = type;
            processes.ProcessDate = period;
            db.BankProcesses.Add(processes);
            db.SaveChanges();
            MessageBox.Show("Transfer Başarılı Bir şekilde sisteme eklendi", "Banka Transferleri", MessageBoxButtons.OK, MessageBoxIcon.Information);

            var values = db.BankProcesses.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnBankProcessesDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtBankProcessesId.Text);
            var removeValue = db.BankProcesses.Find(id);
            db.BankProcesses.Remove(removeValue);
            db.SaveChanges();
            MessageBox.Show("Silme Başarılı Bir Şekilde Sistemden Silindi", "Banka Transferleri", MessageBoxButtons.OK, MessageBoxIcon.Information);

            var values = db.BankProcesses.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnBankProcessesUpdate_Click(object sender, EventArgs e)
        {
            string description = txtBankProcessesDescription.Text;
            string type = txtBankProcessesType.Text;
            decimal amount = decimal.Parse(txtBankProcessesAmount.Text);
            DateTime period = DateTime.Parse(txtBankProcessPeriod.Text);

            int id = int.Parse(txtBankProcessesId.Text);
            var updateValues = db.BankProcesses.Find(id);

            updateValues.Description = description;
            updateValues.Amount = amount;
            updateValues.ProcessType = type;
            updateValues.ProcessDate = period;

            db.SaveChanges();
            MessageBox.Show("Güncelleme Başarılı Bir şekilde Sisteme Entegre Edildi", "Banka Transferleri", MessageBoxButtons.OK, MessageBoxIcon.Information);

            var values = db.BankProcesses.ToList();
            dataGridView1.DataSource = values;
        }
    }
}
