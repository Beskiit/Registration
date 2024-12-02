using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Registration
{
    public partial class FrmClubRegistration : Form
    {
        public FrmClubRegistration()
        {
            InitializeComponent();
        }
        private ClubRegistrationQuery crq = new ClubRegistrationQuery();
        private int ID, age, count;
        private string FirstName, MiddleName, LastName, Gender, Program;
        private long StudentId;


        private void regisBtn_Click(object sender, EventArgs e)
        {
            StudentId = (long)Convert.ToDouble(stuIdTxtBox.Text);
            age = Convert.ToInt32(ageBox.Text.ToString());
            FirstName = firstNameBox.Text;
            MiddleName = middleNameBox.Text;
            LastName = lastNameBox.Text;
            Gender = genderComboBox.Text.ToString();
            Program = progComboBox.Text.ToString();
            crq.RegisterStudent(StudentId, FirstName, MiddleName, LastName, age, Gender, Program);
            RefreshListOfClubMembers(); 
        }

        private void FrmClubRegistration_Load(object sender, EventArgs e)
        {
            string[] programList = { "BS in Information Technology", "BS in Computer Engineering", "BS in Computer Science" };
            string[] genderList = { "Male", "Female"};

            foreach(string program in programList)
            {
                progComboBox.Items.Add(program);
            }

            foreach(string gender in genderList)
            {
                genderComboBox.Items.Add(gender);
            }
            RefreshListOfClubMembers();
        }
        public void RefreshListOfClubMembers()
        {
            crq.DisplayList();
            dataGridView1.DataSource = crq.bindingSource;
        }

        public int RegistrationID(int num1)
        {
            return num1 + 1;
        }
    }
}
