using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Logg
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string[] usernames = { "username1", "username2" };
        string[] passwords = { "password1", "password2" };
        List<string> users = new List<string>();
        List<string> pass = new List<string>();

        private void Form1_Load(object sender, EventArgs e)
        {
            StreamReader streamReader = new StreamReader("vars.txt");
            string line = "";
            while((line=streamReader.ReadLine()) != null)
            {
                string[] components = line.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                users.Add(components[0]);
                pass.Add(components[1]);
            }
            streamReader.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (usernames.Contains(txtUserName.Text) && passwords.Contains(txtPassword.Text) 
                && Array.IndexOf(usernames,txtUserName.Text) == Array.IndexOf(passwords,txtPassword.Text)) 
            {
                //new Form1().Show();
                //this.Hide();
                Form1 f2 = new Form1();
                f2.ShowDialog();
            }
            else if(users.Contains(txtUserName.Text) && pass.Contains(txtPassword.Text) &&
                Array.IndexOf(users.ToArray(), txtUserName.Text) == Array.IndexOf(pass.ToArray(), txtPassword.Text))
            {
                //new Form1().Show();
                //this.Hide();
                Form1 f2 = new Form1();
                f2.ShowDialog();
            }
            else
            {
                MessageBox.Show("Zly Login lub haslo!");
                txtUserName.Clear();
                txtPassword.Clear();
                txtUserName.Focus();
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
