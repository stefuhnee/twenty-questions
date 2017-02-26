using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TwentyQs
{
    public partial class Form1 : Form
    {
        Question root;
        Question current;
        Question parent;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //root = LoadTree();
            //if (root == null)
            //{
                root = new Question();
                root.text = "Is it electronic?";
                root.yes = new Question();
                root.yes.text = "Is it a clock?";
                root.no = new Question();
                root.no.text = "Is it an eraser?";
            //}
            UpdateCurrent(root);
        }

        private void SaveTree()
        {
            try
            {
                // Create a file
                // Write root as 1 line
                // recurse on yes branch
                // recurse on no branch
                StreamWriter writer = new StreamWriter("savegame.txt");
                SaveQuestion(writer, root, null);
                writer.Flush();
                writer.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Yikes, I can't save.\n" + ex.Message);
            }
        }

        private void SaveQuestion(StreamWriter writer, Question q, string yesOrNo)
        {
            if (yesOrNo != null)
                writer.WriteLine(yesOrNo + " " + q.text);
            else if (q.IsLeaf())
                writer.WriteLine("Leaf: " + q.text);
            else writer.WriteLine(q.text);
            if (!q.IsLeaf())
            {
                if (q.no == null)
                    throw new Exception("node is half leaf");
                SaveQuestion(writer, q.yes, "yes");
                SaveQuestion(writer, q.no, "no");
            }
        }

        //private Question LoadTree()
        //{
        //    // load the tree
        //}

        private void UpdateCurrent(Question newCurrent)
        {
            parent = current;
            current = newCurrent;
            UpdateText();
        }

        private void UpdateText()
        {
            questionText.Text = current.text;
        }

        private void yesButton_Click(object sender, EventArgs e)
        {
            if (current.IsLeaf())
            {
                if (MessageBox.Show("I rock!\nWould you like to play again?", "Twenty Questions", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    parent = null;
                    current = root;
                    UpdateText();
                }
                else
                {
                    SaveTree();
                    Close();
                }
            }
            else // branch case
                UpdateCurrent(current.yes);
        }

        private void noButton_Click(object sender, EventArgs e)
        {
            if (current.IsLeaf())
            {
                UserItem.Text = "Please enter a question that would\n"
                    + "allow me to differentiate your item from a/n " + current.text.Split(' ').Last();
                AddQuestionGroup.Show();
            }
            else
                UpdateCurrent(current.no);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Question userQuestion = new Question(question.Text);
            userQuestion.no = current;
            parent.yes = userQuestion;
            userQuestion.yes = new Question(item.Text);
            SaveTree();
            Close();
        }
    }
}
