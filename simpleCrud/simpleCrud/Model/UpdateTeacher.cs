using simpleCrud.Manager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace simpleCrud.Model
{
    public partial class UpdateTeacher : Form
    {
      
        Form1 form1;
        public UpdateTeacher(Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;
        }


        TeacherManager teacherManager = new TeacherManager();
        private void updateButton_Click(object sender, EventArgs e)
        {
            try
            {
                Teacher teacher = new Teacher();
                if (string.IsNullOrEmpty(textBox1.Text))
                {
                    MessageBox.Show("Name is missing", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox1.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(textBox2.Text))
                {
                    MessageBox.Show("Please fill the experience textbox", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox2.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(textBox1.Text))
                {
                    MessageBox.Show("College name is mandatory", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox3.Focus();
                    return;
                }
                teacher.Id = Convert.ToInt32(idLabel.Text);
                teacher.Name = textBox1.Text;
                teacher.Experience = textBox2.Text;
                teacher.College = textBox3.Text;
                if (teacherManager.Update(teacher))
                {
                    MessageBox.Show("Successfully updated details", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    form1.LoadData();
                    Close();

                }
                else
                {
                    MessageBox.Show("Failed to update details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error");
            }
        }

    }
}
