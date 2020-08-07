using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_Project1
{
    public partial class Login : Form
    {
        private bool check;
        public string username;
        public static string strRadioBtn;

        public Login()
        {
            InitializeComponent();
        }
        private void Login_Load(object sender, EventArgs e)
        {
            progressBar1.Hide();
            System.Threading.Thread thread = new System.Threading.Thread(new System.Threading.ThreadStart(Show))
            {
                IsBackground = true
            };
            thread.Start();
            RadBtnUser.Checked = true;
            txtUsername.Cursor = Cursors.IBeam;
        }
        public new void Show()
        {
            System.Threading.Thread.Sleep(100);
            label4.Text = "ELECTRONIC GADGETS";
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            progressBar1.Hide();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            username = txtUsername.Text;
            UserWindow.username = username;
            //AdminWindow.username = username;
            Connection1 conn = new Connection1();
            if (RadBtnAdmin.Checked == true)
            {
                UserWindow.strRadioBtn_Check2 = true;
                UserWindow.strRadioBtn2 = RadBtnAdmin.Text;
                check = conn.AdminLogin(txtUsername.Text, txtPassword.Text);
                try
                {
                    if (check == true)
                    {
                        progressBar1.Show();
                        progressBar1.Maximum = 100;
                        progressBar1.Minimum = 0;
                        for (int progressBar = 0; progressBar < 100; progressBar++)
                        {
                            progressBar1.Value = progressBar;
                        }
                        this.Visible = false;
                        UserWindow userWin = new UserWindow();
                        userWin.Show();
                    }
                    else if (txtUsername.Text == "")
                    {
                        errorProvider1.SetError(txtUsername, "Username is Missing");
                    }
                    else if (txtPassword.Text == "")
                    {
                        errorProvider1.SetError(txtPassword, "Password is Missing");
                    }
                    else
                    {
                        MessageBox.Show("Invalid Username and (or) Password");
                        txtUsername.Clear();
                        txtPassword.Clear();
                    }
                }
                catch
                {
                    MessageBox.Show("Something went Wrong");
                }
            }
            else if (RadBtnUser.Checked == true)
            {
                strRadioBtn = RadBtnUser.Text;
                UserWindow.strRadioBtn_Check1 = true;
                UserWindow.strRadioBtn1 = RadBtnUser.Text;
                check = conn.UserLogin(txtUsername.Text, txtPassword.Text);
                //try
                //{
                if (check == true)
                {
                    progressBar1.Show();
                    progressBar1.Maximum = 100;
                    progressBar1.Minimum = 0;
                    for (int progressBar = 0; progressBar < 100; progressBar++)
                    {
                        progressBar1.Value = progressBar;
                    }
                    this.Visible = false;
                    UserWindow userWin = new UserWindow();
                    userWin.Show();
                }
                else if (txtUsername.Text == "")
                {
                    errorProvider1.SetError(txtUsername, "Username is Missing");
                }
                else if (txtPassword.Text == "")
                {
                    errorProvider1.SetError(txtPassword, "Password is Missing");
                }
                else
                {
                    MessageBox.Show("Invalid Username and (or) Password");
                    txtUsername.Clear();
                    txtPassword.Clear();
                }
                //}
               // catch { }
               
            }
            else
            {
                MessageBox.Show("Invalid User");
                txtPassword.Clear();
                txtUsername.Clear();
            }
        }

        private void RadBtnUser_CheckedChanged(object sender, EventArgs e)
        {
            lblUser.Text = "Worker Name";
        }

        private void RadBtnAdmin_CheckedChanged(object sender, EventArgs e)
        {
            lblUser.Text = "Admin Name";
        }

        private void btnReset_MouseHover(object sender, EventArgs e)
        {
            btnReset.BackColor = Color.SteelBlue;
        }

        private void btnReset_MouseLeave(object sender, EventArgs e)
        {
            btnReset.BackColor = Color.DodgerBlue;
        }

        private void btnLogin_MouseHover(object sender, EventArgs e)
        {
            btnLogin.BackColor = Color.SteelBlue;
        }

        private void btnLogin_MouseLeave(object sender, EventArgs e)
        {
            btnLogin.BackColor = Color.DodgerBlue;
        }
    }
}


