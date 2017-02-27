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
                StreamWriter writer = new StreamWriter("savegame.txt");
                SaveQuestion(writer, root);
                writer.Flush();
                writer.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Yikes, I can't save.\n" + ex.Message);
            }
        }

        private void SaveQuestion(StreamWriter writer, Question q)
        {
            if (q == null)
                writer.WriteLine(" #");
            else
            {
                if (q.no == null)
                    throw new Exception("node is half leaf");
                writer.WriteLine(q.text);
                SaveQuestion(writer, q.yes);
                SaveQuestion(writer, q.no);
            }
        }

        private Question LoadTree()
        {
            StreamReader reader;
            try
            {
                reader = new StreamReader("savegame.txt");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                using (File.Create("savegame.txt"));
                reader = new StreamReader("savegame.txt");
            }
            root = LoadQuestion(reader, root);
            reader.Close();
            DumpTree();
            return root;
            // load the tree
        }

        private Question LoadQuestion(StreamReader reader, Question current)
        {
            string text = reader.ReadLine();
            if (text == null || text.StartsWith(" #"))
                return null;
            current = new Question(text);
            current.yes = LoadQuestion(reader, current.yes);
            current.no = LoadQuestion(reader, current.no);
            return current;
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
            if (pathToCurrent == "yes")
                parent.yes = userQuestion;
            else
                parent.no = userQuestion;
            userQuestion.yes = new Question(item.Text);
            SaveTree();
            Close();
        }
    }
}
