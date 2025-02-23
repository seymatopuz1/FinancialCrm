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
    public partial class Categories : Form
    {
        public Categories()
        {
            InitializeComponent();
        }
        FinancialCrmDbEntities db = new FinancialCrmDbEntities();

        private void Categories_Load(object sender, EventArgs e)
        {
            var values = db.Categories.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnCategoriesList_Click(object sender, EventArgs e)
        {
            var values = db.Categories.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnCreateCategories_Click(object sender, EventArgs e)
        {
            //string categoryName = txtCategoryName.Text;
            //int spends = int.Parse(txtSpend.Text);
             

            //Categories ct = new Categories();
            //ct.CategoryName = categoryName;
            //ct.Spendings = spends;
            //db.Categories.Add(categories);
            
            //db.SaveChanges();
            //MessageBox.Show("Kategori Başarılı Bir şekilde sisteme eklendi", "Kategoriler", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //var values = db.Categories.ToList();
            //dataGridView1.DataSource = values;
        }

        private void btnRemoveCategory_Click(object sender, EventArgs e)
        {

            int id = int.Parse(txtCategoryId.Text);
            var removeValue = db.Categories.Find(id);
            db.Categories.Remove(removeValue);
            db.SaveChanges();
            MessageBox.Show("Silme Başarılı Bir Şekilde Sistemden Silindi", "Kategoriler", MessageBoxButtons.OK, MessageBoxIcon.Information);

            var values = db.Categories.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnUpdateCategory_Click(object sender, EventArgs e)
        {
            string name = txtCategoryName.Text;
            
            int id = int.Parse(txtCategoryId.Text);
            var updateValues = db.Categories.Find(id);

            updateValues.CategoryName = name;
            

            db.SaveChanges();
            MessageBox.Show("Güncelleme Başarılı Bir şekilde Sisteme Entegre Edildi", "Kategoriler", MessageBoxButtons.OK, MessageBoxIcon.Information);

            var values = db.Categories.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnBillForm_Click(object sender, EventArgs e)
        {
            FrmBilling frm = new FrmBilling();
            frm.Show();
            this.Hide();
        }

        private void btnDashboardForm_Click(object sender, EventArgs e)
        {
            FrmDashboard frm = new FrmDashboard();
            frm.Show(); 
            this.Hide();
        }

        private void btnBanksForm_Click(object sender, EventArgs e)
        {
            FrmBanks frm = new FrmBanks();
            frm.Show();
            this.Hide();
        }

        private void btnCategoriesForm_Click(object sender, EventArgs e)
        {
            Categories frm = new Categories();
            frm.Show();
            this.Hide();
        }

        private void btnSpendingsForm_Click(object sender, EventArgs e)
        {

        }

        private void btnBankProcessForm_Click(object sender, EventArgs e)
        {

        }

        private void btnLoginForm_Click(object sender, EventArgs e)
        {

        }

        private void btnOutputForm_Click(object sender, EventArgs e)
        {

        }
    }
}
