using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace PlayWithRegex
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (!Validator.ValidName(NameTextBox.Text))
            {
                MessageBox.Show("The name is invaid (only alphabetical characters are allowed)");
            } 
            if(!Validator.ValidPhoneNumber(PhoneTextBox.Text))
            {
                MessageBox.Show("The phone number is not a valid  US phone number");
                PhoneTextBox.Text = Validator.ReformatPhone(PhoneTextBox.Text);
            }
            if (!Validator.ValidEmail(EmailTextBox.Text))
            {
                MessageBox.Show("The e-mail address is not valid.");
            }
        }
    }
}
