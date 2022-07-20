using simpleCrud.Manager;
using simpleCrud.Model;

namespace simpleCrud
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

       // AppDbContext _dbContext = new AppDbContext();
        TeacherManager teacherManager = new TeacherManager();


        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void saveButton_Click(object sender, EventArgs e)
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
                teacher.Name = textBox1.Text;
                teacher.Experience = textBox2.Text;
                teacher.College = textBox3.Text;
               if (teacherManager.Add(teacher))
                {
                    MessageBox.Show("Successfully saved details", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    reset();
                }else
                {
                    MessageBox.Show("Failed to save the details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Unexpected Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            

        }
        public void reset()
        {
            textBox1.Text = String.Empty;
            textBox2.Text = String.Empty;
            textBox3.Text = String.Empty;
            LoadData();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                LoadData();
            }catch(Exception ex)
            {
                MessageBox.Show("Error viewing data");
            }
        }
        public void LoadData()
        {
            var teachers = teacherManager.getAll();
            dataGridView1.Rows.Clear();
            foreach (var teacher in teachers)
            {
                dataGridView1.Rows.Add(teacher.Id, teacher.Name, teacher.College, teacher.Experience);
            }
        }

        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow dataGridViewRow = dataGridView1.SelectedRows[0];
            UpdateTeacher updateTeacher = new UpdateTeacher(this);
            updateTeacher.idLabel.Text = dataGridViewRow.Cells[0].Value.ToString();
            updateTeacher.textBox1.Text = dataGridViewRow.Cells[1].Value.ToString();
            updateTeacher.textBox2.Text = dataGridViewRow.Cells[3].Value.ToString();
            updateTeacher.textBox3.Text = dataGridViewRow.Cells[2].Value.ToString();
            updateTeacher.ShowDialog();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow dr = dataGridView1.SelectedRows[0];
                if (MessageBox.Show("Delete the selected the teacher", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id = (int)dr.Cells[0].Value;
                    bool isDelete = teacherManager.Delete(id);
                    if (isDelete)
                    {
                        MessageBox.Show("Successfully Deleted");
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete");
                    }
                }
            }catch(Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow dataGridViewRow = dataGridView1.SelectedRows[0];
            UpdateTeacher updateTeacher = new UpdateTeacher(this);
            updateTeacher.idLabel.Text = dataGridViewRow.Cells[0].Value.ToString();
            updateTeacher.textBox1.Text = dataGridViewRow.Cells[1].Value.ToString();
            updateTeacher.textBox2.Text = dataGridViewRow.Cells[3].Value.ToString();
            updateTeacher.textBox3.Text = dataGridViewRow.Cells[2].Value.ToString();
            updateTeacher.ShowDialog();
        }
    }
}