using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hw_Student_StructForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Student student;

        int chi;
        int eng;
        int math;


        protected void SetStudent()
        {
            if (string.IsNullOrEmpty(student.Name))
            {
                student = new Student();
                student.Name = txtName.Text;
                student.subjects = new Subject[]{
                new Subject{ SubName = "國文", Score = 0},
                new Subject{ SubName = "英文", Score = 0},
                new Subject{ SubName = "數學", Score = 0},
            };
            }
        }

        public void btnSave_Click(object sender, EventArgs e)
        {
            SetStudent();

            int chi, eng, mat;
            
            if (int.TryParse(txtChinese.Text, out chi)) {
                student.subjects[0].Score = chi;
            }
            else
            {
                MessageBox.Show("請輸入數值");
                txtChinese.Text = "";
                return;
            }
            if (int.TryParse(txtEnglish.Text, out eng)) {
                student.subjects[1].Score = eng;
            }
            else
            {
                MessageBox.Show("請輸入數值");
                txtEnglish.Text = "";
                return;
            }
            if (int.TryParse(txtMath.Text, out mat)) {
                student.subjects[2].Score = mat;
            }
            else
            {
                MessageBox.Show("請輸入數值");
                txtMath.Text = "";
                return;
            }
            
        }

        
        private void btnShow_Click(object sender, EventArgs e)
        {
            SetStudent();
            string result = string.Format(@"姓名：{0} {1}國文：{2} {3}英文：{4} {5}數學：{6} ",   student.Name, Environment.NewLine,
                                                    student.subjects[0].Score, Environment.NewLine,
                                                    student.subjects[1].Score, Environment.NewLine,
                                                    student.subjects[2].Score);
            txtScore.Text = result;
        }

        private void btnStats_Click(object sender, EventArgs e)
        {
            var sortedScores = student.subjects.OrderBy(item => item.Score);

            string result = string.Format(@"最高分為{0}：{1} {2}最低分為{3}：{4} ",
                                                    sortedScores.ElementAt(student.subjects.Length-1).SubName, sortedScores.ElementAt(student.subjects.Length - 1).Score, Environment.NewLine,
                                                    sortedScores.ElementAt(0).SubName, sortedScores.ElementAt(0).Score);
            txtStats.Text = result;
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
