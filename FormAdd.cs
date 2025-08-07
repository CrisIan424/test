using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestCrud;

namespace TestCrud
{
    public partial class FormAdd : Form
    {
        public string Id
        {
            get { return txtId.Text; }
            set { txtId.Text = value; }
        }

        public string FirstName
        {
            get { return txtFirstName.Text; }
            set { txtFirstName.Text = value; }
        }

        public string LastName
        {
            get { return txtLastName.Text; }
            set { txtLastName.Text = value; }
        }

        public string Gender
        {
            get { return txtGender.Text; }
            set { txtGender.Text = value; }
        }

        public string Address
        {
            get { return txtAddress.Text; }
            set { txtAddress.Text = value; }
        }

        public string Number
        {
            get { return txtNumber.Text; }
            set { txtNumber.Text = value; }
        }


        public FormAdd()
        {
            InitializeComponent();
            txtId.ReadOnly = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            string filePath = @"C:\Users\ADMIN TRAINEE 11\source\datagrid.txt";

            int newId = FileHelper.GetNextID(filePath);
            FileHelper.SortFileByID(filePath);

            // Validate required fields
            if (string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                string.IsNullOrWhiteSpace(txtLastName.Text) ||
                string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                MessageBox.Show("ID, First Name, Last Name, and Address are required!",
                                "Validation Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            if (!txtFirstName.Text.All(char.IsLetter))
            {
                MessageBox.Show("First Name must contain only letters.", "Validation Error)",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (!txtLastName.Text.All(char.IsLetter))
            {
                MessageBox.Show("Last Name must contain only letters.", "Validation Error)",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (!txtGender.Text.All(char.IsLetter) || txtGender.Text.Length != 1)
            {
                MessageBox.Show("Gender must be either Male (M) or Female (F) only.", "Validation Error)",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (txtAddress.Text.Length > 100)
            {
                MessageBox.Show("Address is too long (max 100 characters).", "Validation Error)",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
               
            }

            if(!txtNumber.Text.All(char.IsNumber) || txtNumber.Text.Length !=11)
            {
                MessageBox.Show("Cellphone number must be 11 digit.", "Validation Error)",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            string newLine = $"{txtId.Text.Trim()},{txtFirstName.Text.Trim()},{txtLastName.Text.Trim()},{txtGender.Text.Trim()},{txtAddress.Text.Trim()},{Number}";

            try
            {
                // Make sure folder exists
                string folder = Path.GetDirectoryName(filePath);
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                // Save data
                File.AppendAllText(filePath, newLine + Environment.NewLine);
                FileHelper.SortFileByID(filePath);

                MessageBox.Show("Data saved successfully!", "Save",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK; // closes form and signals success
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving file: " + ex.Message,
                                "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
