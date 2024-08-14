using Microsoft.VisualBasic.Devices;
using System.Diagnostics;
using System.Reflection;
using System.Text.Json;
using System.Windows.Forms;

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
            Image image = Image.FromFile(@"UnionMap.png");

            pictureBox1.Image = image;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (NodeNameBox.Text != string.Empty)
            {
                if (nodes.Count == 0)
                {
                    addNode(e);
                }
                else
                {
                    if (!alreadyExists(NodeNameBox.Text))
                    {
                        addNode(e);
                    }
                }
            }
            else
                changeHintLabel("Please Name The Node Before Placing");
        }
        private void addNode(MouseEventArgs e)
        {
            Point point = e.Location;
            Point offset = new Point(point.X - 5, point.Y - 5);

            PictureBox pb = new PictureBox();
            pb.Location = offset;
            pb.Size = new Size(10, 10);
            pb.MouseDown += new MouseEventHandler(node_Click);
            pictureBox1.Controls.Add(pb);

            nodes.Add(new Node(NodeNameBox.Text, pb));
            Debug.WriteLine($"added Node: {nodes.Count}");
        }
        private void node_Click(object sender, MouseEventArgs e)
        {
            PictureBox pictureBox = sender as PictureBox;
            Node currentNode = getCurrentNode();

            Node clickedNode = getClickedNode(pictureBox);
     

            if (string.IsNullOrEmpty(currentNodeName))
            {
                currentNodeName = clickedNode.name;
                CurrentNodeLabel.Text = "Current Node: " + clickedNode.name;
                UpdateListBox();
                changeHintLabel("Select Another Node To Connect");
            }
            else if (hasCurrentNode())
            {
                if (currentNode == clickedNode)
                {
                    changeHintLabel("Cannot Add Current Node To Current Nodes Adjecent Nodes");
                }
                else
                {
                    if (!ClickedNodeIsConnected(clickedNode))
                    {
                        currentNode.adjecentList.Add(clickedNode.name);
                        UpdateListBox();
                        changeHintLabel("Nodes Connected Succesfully");
                    }
                }
            }
        }
        private bool ClickedNodeIsConnected(Node clickedNode)
        {
            Node currentNode = getCurrentNode();
            for (int i = 0; i < currentNode.adjecentList.Count; i++)
            {
                if (clickedNode.name == currentNode.adjecentList[i])
                {
                    changeHintLabel($"Selected Node {clickedNode.name} Is Already Connected To The Current Node");
                    return true;
                }
            }
            return false;
        }
        private Node getClickedNode(PictureBox pictureBox)
        {
            foreach (Node node in nodes)
            {
                if (node.pictureBox == pictureBox)
                {
                    return node;
                }
            }
            return null;
        }
        private void CurrentNodeLabel_TextChanged(object sender, EventArgs e)
        {
            UpdateListBox();
        }

        private void UpdateListBox()
        {
            AdjecentNodeList.Items.Clear();
            ConnectedContinentsList.Items.Clear();

            Node node = getCurrentNode();
            if (node != null)
            {
                for (int i = 0; i < node.adjecentList.Count; i++)
                {
                    AdjecentNodeList.Items.Add(node.adjecentList[i]);
                }
                for (int j = 0; j < node.continentList.Count; j++)
                {
                    ConnectedContinentsList.Items.Add(node.continentList[j]);
                }
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            deSelectCurrentNode();
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ContinentNameBox.Text))
            {
                changeHintLabel("Please Enter a Name");
            }
            else if (string.IsNullOrEmpty(ContinentTroopBox.Text))
            {
                changeHintLabel("Please Enter Troop Bonus Amount");
            }
            else
            {
                if (int.TryParse(ContinentTroopBox.Text, out int result))
                {
                    continents.Add(new Continent(ContinentNameBox.Text, int.Parse(ContinentTroopBox.Text)));
                    ContinentListBox.Items.Add(ContinentNameBox.Text);
                }
                else
                {
                    changeHintLabel("Troop Bonus Must Be Of Type Integer");
                }
            }
        }
        private void CreateFileButton_Click(object sender, EventArgs e)
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

        private void comboBox1_DropDown(object sender, EventArgs e)
        {

            if (hasCurrentNode())
            {
                if (continents.Count != 0)
                {
                    comboBox1.Items.Clear();
                    foreach (Continent continent in continents)
                    {
                        comboBox1.Items.Add(continent.name);
                    }
                }
                else
                {
                    changeHintLabel("There Are No Existing Continents");
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (hasCurrentNode())
            {
                if (!string.IsNullOrEmpty(comboBox1.SelectedIndex.ToString()))
                {
                    Node node = getCurrentNode();
                    node.continentList.Add(comboBox1.Text);
                    UpdateListBox();
                }
            }
        }
        private void changeHintLabel(string message)
        {
            HintLabel.Text = "Hint: " + message;
        }
        private Node getCurrentNode()
        {
            if (hasCurrentNode())
            {
                foreach (Node node in nodes)
                {
                    if (currentNodeName == node.name)
                    {
                        return node;
                    }
                }
                throw new Exception("Current Node Does Not Exist");
            }
            else
            {
                return null;
            }
        }
        private bool alreadyExists(string text)
        {
            for (int i = 0; i < nodes.Count; i++)
            {
                if (nodes[i].name == text)
                {
                    changeHintLabel("Node Already Exists");
                    return true;
                }
            }
            return false;
        }
        private bool hasCurrentNode()
        {
            if (string.IsNullOrEmpty(currentNodeName))
            {
                changeHintLabel("Please Select a Node");
                return false;
            }
            else { return true; }
        }
        private void deSelectCurrentNode()
        {
            currentNodeName = string.Empty;
            CurrentNodeLabel.Text = string.Empty;
        }
    }
}