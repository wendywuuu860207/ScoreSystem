using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace _1053332_HW08
{
    public partial class Form1 : Form
    {
        Image level = Properties.Resources.Apple;
        Point startApple;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: 這行程式碼會將資料載入 'studentsDataSet.Students' 資料表。您可以視需要進行移動或移除。
            this.studentsTableAdapter.Fill(this.studentsDataSet.Students);
            float finScore = ((float.Parse(textBox3.Text) + float.Parse(textBox4.Text)) / 2);
            label8.Text = finScore.ToString();
            startApple = label7.Location;
            startApple.X += 80;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((this.studentsBindingSource.Find("StudentID", textBox1.Text)) != -1)
            {
                MessageBox.Show("This ID exists!");
            }
            else
            {
                this.studentsTableAdapter.Insert(textBox1.Text, textBox2.Text, comboBox1.Text, int.Parse(textBox3.Text), int.Parse(textBox4.Text));
                this.studentsTableAdapter.Fill(this.studentsDataSet.Students);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.studentsBindingSource.EndEdit();
            this.studentsTableAdapter.Update(this.studentsDataSet);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.studentsTableAdapter.Delete(textBox1.Text, textBox2.Text, comboBox1.Text, int.Parse(textBox3.Text), int.Parse(textBox4.Text));
            this.studentsTableAdapter.Fill(this.studentsDataSet.Students);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int i = -1;
            switch (comboBox2.Text)
            {
                case "ID":
                    i = this.studentsBindingSource.Find("StudentID", textBox5.Text);
                    break;
                case "Name":
                    i = this.studentsBindingSource.Find("StudentName", textBox5.Text);
                    break;
                case "Gender":
                    i = this.studentsBindingSource.Find("Gender", textBox5.Text);
                    break;
                case "MidExam":
                    i = this.studentsBindingSource.Find("MidExam", int.Parse(textBox5.Text));
                    break;
                case "FinalExam":
                    i = this.studentsBindingSource.Find("FinalExam", int.Parse(textBox5.Text));
                    break;
            }
            if (i != -1)
                this.studentsBindingSource.Position = i;
            else
                MessageBox.Show("Not found!");
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if(textBox3.Text != "")
            {
                string checkNegetive = textBox3.Text;
                if(checkNegetive[0] != '-')
                {
                    int checkNum;
                    checkNum = int.Parse(textBox3.Text);
                    if (checkNum > 100 || checkNum < 0)
                        MessageBox.Show("Incorrect MidExam Score !");
                    else if (textBox4.Text != "" && textBox3.Text != "")
                    {
                        float finScore = ((float.Parse(textBox3.Text) + float.Parse(textBox4.Text)) / 2);
                        label8.Text = finScore.ToString();
                        this.Invalidate();
                    }
                }
                else
                    MessageBox.Show("Incorrect MidExam Score !");
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if(textBox4.Text != "")
            {
                string checkNegetive = textBox4.Text;
                if (checkNegetive[0] != '-')
                {
                    int checkNum;
                    checkNum = int.Parse(textBox4.Text);
                    if (checkNum > 100 || checkNum < 0)
                        MessageBox.Show("Incorrect FinalExam Score !");
                    else if (textBox4.Text != "" && textBox3.Text != "")
                    {
                        float finScore = ((float.Parse(textBox3.Text) + float.Parse(textBox4.Text)) / 2);
                        label8.Text = finScore.ToString();
                        this.Invalidate();
                    }
                }
                else
                    MessageBox.Show("Incorrect FinalExam Score !");
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            float finScore = ((float.Parse(textBox3.Text) + float.Parse(textBox4.Text))/2);
            label8.Text = finScore.ToString();
            this.Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Point appX = startApple;
            float finSco = float.Parse(label8.Text);
            if(finSco >= 90)
            {
                for(int i = 0; i < 4; ++i)
                {
                    e.Graphics.DrawImage(level, appX);
                    appX.X += level.Width;
                    appX.X += 20;
                }
            }
            else if (finSco >= 80)
            {
                for (int i = 0; i < 3; ++i)
                {
                    e.Graphics.DrawImage(level, appX);
                    appX.X += level.Width;
                    appX.X += 20;
                }
            }
            else if (finSco >= 70)
            {
                for (int i = 0; i < 2; ++i)
                {
                    e.Graphics.DrawImage(level, appX);
                    appX.X += level.Width;
                    appX.X += 20;
                }
            }
            else if (finSco >= 60)
            {
                    e.Graphics.DrawImage(level, appX);
            }
        }
    }
}
