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
        string pathToCurrent;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            root = LoadTree();
            if (root == null)
            {
                root = new Question("Is it electronic?");
                root.yes = new Question("Is it a clock?");
                root.no = new Question("Is it an eraser?");
            }
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
                StreamWriter writer = new StreamWriter("savegame2.txt");
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
            if (!q.IsLeaf())
            {
                if (q.no == null)
                    throw new Exception("node is half leaf");
                writer.WriteLine(q.text);
                SaveQuestion(writer, q.yes, "yes");
                SaveQuestion(writer, q.no, "no");
            }
        }

        private Question LoadTree()
        {
            StreamReader reader = new StreamReader("savegame2.txt");
            string text = reader.ReadLine();
            if (text == "")
            {
                reader.Close();
                return null;
            }
            root = new Question(text);
            LoadQuestion(reader, root);
            reader.Close();
            DumpTree();
            return root;
            // load the tree
        }

        private void LoadQuestion(StreamReader reader, Question current)
        {
            string text = reader.ReadLine();
            if (text == null)
                return;
            Question next = new Question(text);
            if (text.Split(' ').First() == "yes")
            {
                current.yes = next;
                LoadQuestion(reader, next);
            }
                
            else if (text.Split(' ').First() =="no")
            {
                current.no = next;
                LoadQuestion(reader, next);
            }
        }

        private void UpdateCurrent(Question newCurrent)
        {
            parent = current;
            if (current != null && current.no == newCurrent)
                pathToCurrent = "no";
            else if (current != null)
                pathToCurrent = "yes";
            current = newCurrent;
            UpdateText();
        }

        private void UpdateText()
        {
            questionText.Text = current.text;
        }

        private void DumpTree()
        {
            Log(root, "");
        }

        private void Log(Question q, string indent)
        {
            if (q == null) return;
            Console.WriteLine(indent + q.text);
            if (q.yes != null) Log(q.yes, indent + "  ");
            if (q.no != null) Log(q.no, indent + "  ");
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
                    Close();
            }
            else // branch case
                UpdateCurrent(current.yes);
        }

        private void noButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine(current.text + "==============text");
            Console.WriteLine(current.IsLeaf() + "====== is Leaf");
            if (current.IsLeaf())
            {
                UserItem.Text = "Please enter a question that would\n"
                    + "allow me to differentiate your item from a/n " + current.text.Split(' ').Last();
                AddQuestionGroup.Show();
            }
            else
            {
                Console.WriteLine("ccurrent.no", current.no);
                UpdateCurrent(current.no);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Question userQuestion = new Question(question.Text);
            userQuestion.no = current;
            if (pathToCurrent == "yes")
                parent.yes = userQuestion;
            else parent.no = userQuestion;
            userQuestion.yes = new Question(item.Text);
            SaveTree();
            Close();
        }
    }
}
