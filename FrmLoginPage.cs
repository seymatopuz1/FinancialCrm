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
    public partial class FrmLoginPage : Form
    {
        public FrmLoginPage()
        {
            InitializeComponent();


        }
        FrmDashboard frm = new FrmDashboard();
        FinancialCrmDbEntities db = new FinancialCrmDbEntities();
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Kullanıcı Adı ve Şifre Boş bırakılamaz", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            using (var context = new FinancialCrmDbEntities())
            {
                var user = context.Users.FirstOrDefault(x => x.Username == username && x.Password == password);

                if (user != null)
                {
                    MessageBox.Show("Giriş Onaylandı");
                    frm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Giriş Bilgileri Hatalı Lütfen Tekrar Deneyiniz");
                }
            }

        }
    }
}
