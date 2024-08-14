using Microsoft.VisualBasic.Devices;
using System.Diagnostics;
using System.Reflection;
using System.Text.Json;

namespace UnionMapCreator
{
    public partial class Form1 : Form
    {
        List<Continent> continents = new List<Continent>();
        List<Node> nodes = new List<Node>();

        string currentNodeName = string.Empty;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Image image = Image.FromFile(@"C:\Users\aldin\Documents\UnionMapCreator\UnionMapCreator\UnionMap.png");

            pictureBox1.Image = image;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            bool alreadyExists = false;
            bool continentExist = false;
            if (textBox1.Text != string.Empty && textBox3.Text != string.Empty)
            {
                if (continents.Count != 0)
                {
                    for (int i = 0; i < continents.Count; i++)
                    {
                        if (continents[i].name == textBox3.Text)
                        {
                            continentExist = true; break;
                        }
                    }
                }
                if (continentExist)
                {
                    if (nodes.Count == 0)
                    {
                        addNode(e, textBox3.Text);
                    }
                    else
                    {
                        for (int i = 0; i < nodes.Count; i++)
                        {
                            if (nodes[i].name == textBox1.Text)
                            {
                                alreadyExists = true;
                            }
                        }
                        if (alreadyExists)
                        {
                            throw new Exception("Name Already Exists");
                        }
                        else
                        {
                            addNode(e, textBox3.Text);
                        }
                    }
                }
                else
                {
                    throw new Exception("continent does not exist");
                }
            }
            else
                throw new Exception("Text Box Cannot Be Empty");
        }
        private void addNode(MouseEventArgs e, string continent)
        {
            Point point = e.Location;
            PictureBox pb = new PictureBox();
            pb.Location = point;
            pb.Size = new Size(10, 10);
            pb.MouseDown += new MouseEventHandler(node_Click);
            pictureBox1.Controls.Add(pb);

            nodes.Add(new Node(textBox1.Text, pb, continent));
            Debug.WriteLine($"added Node: {nodes.Count}");
        }
        private void node_Click(object sender, MouseEventArgs e)
        {
            PictureBox pictureBox = sender as PictureBox;

            if (string.IsNullOrEmpty(currentNodeName))
            {
                foreach (Node node in nodes)
                {
                    if (node.pictureBox == pictureBox)
                    {
                        currentNodeName = node.name;
                        label3.Text = "Current Node: " + node.name;
                        UpdateListBox();
                    }
                }
            }
            else if (!string.IsNullOrEmpty(currentNodeName))
            {
                foreach (Node node in nodes)
                {
                    if (node.pictureBox == pictureBox)
                    {
                        if (currentNodeName == node.name)
                        {
                            throw new Exception("Cannot Add Current Node To Adjecent Nodes");
                        }
                    }
                }

                Node currentNode = nodes.FirstOrDefault(node => node.name == currentNodeName);
                foreach (Node node in nodes)
                {
                    if (node.pictureBox == pictureBox)
                    {
                        currentNode.adjecentList.Add(node.name);
                        UpdateListBox();
                    }
                }
            }
        }

        private void label3_TextChanged(object sender, EventArgs e)
        {
            UpdateListBox();
        }

        private void UpdateListBox()
        {
            listBox1.Items.Clear();
            listBox3.Items.Clear();
            foreach (Node node in nodes)
            {
                if (node.name == currentNodeName)
                {
                    for (int i = 0; i < node.adjecentList.Count; i++)
                    {
                        listBox1.Items.Add(node.adjecentList[i]);
                    }
                    for (int j = 0; j < node.continentList.Count; j++)
                    {
                        listBox3.Items.Add(node.continentList[j]);
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            currentNodeName = string.Empty;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                throw new Exception("please enter name");
            }
            else if (string.IsNullOrEmpty(textBox5.Text))
            {
                throw new Exception("please enter troop bonus");
            }
            else
            {
                continents.Add(new Continent(textBox2.Text, int.Parse(textBox5.Text)));
                listBox2.Items.Add(textBox2.Text);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(currentNodeName))
            {
                if (!string.IsNullOrEmpty(textBox4.Text))
                {
                    foreach (Node node in nodes)
                    {
                        if (node.name == currentNodeName)
                        {
                            node.continentList.Add(textBox4.Text);
                            UpdateListBox();
                        }
                    }
                }
                else
                {
                    throw new Exception("Text Box Cannot Be Empty");
                }
            }
            else
                throw new Exception("Current Node Cannot Be Empty");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            foreach (Node node in nodes)
            {
                node.adjecentNames = node.adjecentList.ToArray();
                node.continentNames = node.continentList.ToArray();
            }


            Map map = new Map(continents, nodes);

            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;

            string fileName = "map.json";
            string filePath = Path.Combine(currentDirectory, fileName);

            string jsonString = JsonSerializer.Serialize(map);
            Debug.WriteLine(jsonString);
            File.WriteAllText(filePath, jsonString);

            MessageBox.Show("File saved successfully at " + filePath);
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }
    }
}