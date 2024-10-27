using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.Devices;
using System.Diagnostics;
using System.Drawing.Text;
using System.Reflection;
using System.Text.Json;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;

namespace UnionMapCreator
{
    public partial class MainWindowForm : Form
    {
        List<Continent> continents = new List<Continent>();
        List<Node> nodes = new List<Node>();

        public Image image;
        private float _zoomFactor = 1f;
        private const float ZoomStep = 0.1f;
        private float _initialScale = 1;
        private int _mouseX = 0;
        private int _mouseY = 0;
        private int _imageOffsetX = 0;
        private int _imageOffsetY = 0;

        string currentNodeName = string.Empty;
        public MainWindowForm()
        {
            InitializeComponent();
            _zoomFactor = 1.0f; // Start with no zoom
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            image = Image.FromFile(@"D:\Github Repositories\UnionMapJsonCreator\UnionMapCreator\UnionMapCreator\Simple_world_map.svg.png");

            pictureBox1.Paint += PictureBox1_Paint;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            pictureBox1.MouseWheel += PictureBox1_MouseWheel;
        }
        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (image == null)
                return;

            var (offsetX, offsetY, newWidth, newHeight, scaleFactor) = CalculateOffset();

            // Draw the image with the calculated dimensions and offset
            e.Graphics.DrawImage(image, offsetX, offsetY, newWidth, newHeight);

            foreach (Node node in nodes)
            {
                int nodeX = (int)(node.position.X * image.Width * scaleFactor) + offsetX;
                int nodeY = (int)(node.position.Y * image.Height * scaleFactor) + offsetY;

                e.Graphics.FillEllipse(Brushes.Red, nodeX, nodeY, 10, 10);
                Debug.WriteLine($"Drawing Node at: ({nodeX}, {nodeY})");
            }
        }
        private void PictureBox1_MouseWheel(object sender, MouseEventArgs e)
        {
            // Save the previous zoom factor
            float previousZoomFactor = _zoomFactor;

            // Update the zoom factor based on mouse wheel scroll
            if (e.Delta > 0)
                _zoomFactor += ZoomStep; // Zoom in
            else if (e.Delta < 0)
                _zoomFactor = Math.Max(0.1f, _zoomFactor - ZoomStep); // Zoom out

            // Calculate the change in zoom factor
            float zoomChange = _zoomFactor / previousZoomFactor;

            // Adjust the image offset to keep zoom centered on the mouse position
            int mouseX = e.X;
            int mouseY = e.Y;

            // Convert mouse coordinates to image coordinates
            float imageX = (mouseX - pictureBox1.ClientSize.Width / 2) / _initialScale;
            float imageY = (mouseY - pictureBox1.ClientSize.Height / 2) / _initialScale;

            // Calculate the new offset
            _imageOffsetX -= (int)((imageX - (_imageOffsetX / _zoomFactor)) * (zoomChange - 1));
            _imageOffsetY -= (int)((imageY - (_imageOffsetY / _zoomFactor)) * (zoomChange - 1));

            // Trigger redraw
            pictureBox1.Invalidate();
        }
        private (int offsetX, int offsetY, int newWidth, int newHeight, float scaleFactor) CalculateOffset()
        {
            // Calculate the aspect ratios
            float imageAspect = (float)image.Width / image.Height;
            float boxAspect = (float)pictureBox1.ClientSize.Width / pictureBox1.ClientSize.Height;

            // Determine the initial scaling factor to fit the image in the PictureBox
            if (imageAspect > boxAspect)
                _initialScale = (float)pictureBox1.ClientSize.Width / image.Width;
            else
                _initialScale = (float)pictureBox1.ClientSize.Height / image.Height;

            // Apply zoom factor to the initial scale
            float scaleFactor = _initialScale * _zoomFactor;

            // Calculate the new dimensions of the image
            int newWidth = (int)(image.Width * scaleFactor);
            int newHeight = (int)(image.Height * scaleFactor);

            // Calculate the offset to center the image
            int offsetX = ((pictureBox1.ClientSize.Width - newWidth) / 2) + _imageOffsetX;
            int offsetY = ((pictureBox1.ClientSize.Height - newHeight) / 2) + _imageOffsetY;

            return (offsetX, offsetY, newWidth, newHeight, scaleFactor);
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            foreach (Node node in nodes)
            {
                int nodeX = (int)(node.position.X * image.Width * _zoomFactor) + _imageOffsetX;
                int nodeY = (int)(node.position.Y * image.Height * _zoomFactor) + _imageOffsetY;

                Rectangle nodeBounds = new Rectangle(nodeX - 5, nodeY - 5, 10, 10);
                if (nodeBounds.Contains(e.Location))
                {
                    currentNodeName = node.Name;
                    CurrentNodeLabel.Text = currentNodeName;
                    return;
                }
            }
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
            Debug.WriteLine($"Mouse Position: ({e.X}, {e.Y})");
            var (offsetX, offsetY, newWidth, newHeight, scaleFactor) = CalculateOffset();
            float relativeX = (e.X - offsetX) / (image.Width * scaleFactor);
            float relativeY = (e.Y - offsetY) / (image.Height * scaleFactor);
            PointF relativePosition = new PointF(relativeX, relativeY);

            nodes.Add(new Node(NodeNameBox.Text, relativePosition));

            pictureBox1.Invalidate();

            Debug.WriteLine($"Added Node: {nodes.Count} at ({relativeX}, {relativeY})");
        }
        private bool ClickedNodeIsConnected(Node clickedNode)
        {
            Node currentNode = getCurrentNode();
            for (int i = 0; i < currentNode.adjecentList.Count; i++)
            {
                if (clickedNode.Name == currentNode.adjecentList[i])
                {
                    changeHintLabel($"Selected Node {clickedNode.Name} Is Already Connected To The Current Node");
                    return true;
                }
            }
            return false;
        }
        private void CurrentNodeLabel_TextChanged(object sender, EventArgs e)
        {
            UpdateListBox();
        }

        private void UpdateListBox()
        {
            BetterListItem itemControl;
            betterListBox2.clear();
            betterListBox3.clear();
            Node node = getCurrentNode();
            if (node != null)
            {
                for (int i = 0; i < node.adjecentList.Count; i++)
                {
                    itemControl = CreateListItem(node.adjecentList[i], ref betterListBox2);
                    itemControl.ButtonClick += NodeListItemClick;
                    betterListBox2.addItem(itemControl);
                }
                for (int j = 0; j < node.ContinentList.Count; j++)
                {
                    itemControl = CreateListItem(node.ContinentList[j], ref betterListBox3);
                    itemControl.ButtonClick += ConnectedContinentListItemClick;
                    betterListBox3.addItem(itemControl);
                }
            }
        }
        private void ContinentListItemClick(object sender, EventArgs e)
        {
            BetterListItem clickedItem = sender as BetterListItem;
            RemoveItemFromLists(clickedItem, betterListBox1);
        }
        private void NodeListItemClick(object sender, EventArgs e)
        {
            BetterListItem clickedItem = sender as BetterListItem;
            RemoveItemFromLists(clickedItem, betterListBox2);
        }
        private void ConnectedContinentListItemClick(object sender, EventArgs e)
        {
            BetterListItem clickedItem = sender as BetterListItem;
            RemoveItemFromLists(clickedItem, betterListBox3);
        }
        private void CancelButton_Click(object sender, EventArgs e)
        {
            deSelectCurrentNode();
        }
        private BetterListItem CreateListItem(string text, ref BetterListBox box)
        {
            BetterListItem itemControl = new BetterListItem
            {
                ItemText = text,
                Width = box.Width - 2,
                Location = new Point(0, box.items.Count * 24), //Adjust height as needed
            };

            return itemControl;
        }

        private void RemoveItemFromLists(BetterListItem clickedItem, BetterListBox box)
        {
            int index = box.items.IndexOf(clickedItem);
            box.removeItem(index);

            string boxName = box.Name;

            if (boxName == "betterListBox1")
            {
                for (int i = 0; i < continents.Count; i++)
                {
                    if (clickedItem.ItemText == continents[i].name)
                    {
                        RemoveContinentInOtherBox(continents[i]);
                        continents.Remove(continents[i]);
                    }
                }
            }
            if (boxName == "betterListBox2")
            {
                Node currentNode = getCurrentNode();
                for (int i = 0; i < currentNode.adjecentList.Count; i++)
                {
                    if (clickedItem.ItemText == currentNode.adjecentList[i])
                    {
                        changeHintLabel($"Connection Between {currentNode.Name} And {currentNode.adjecentList[i]} Removed Succesfully");
                        currentNode.adjecentList.Remove(currentNode.adjecentList[i]);
                    }
                }
            }
            if (boxName == "betterListBox3")
            {
                Node currentNode = getCurrentNode();
                for (int i = 0; i < currentNode.ContinentList.Count; i++)
                {
                    changeHintLabel($"Removed {currentNode.ContinentList[i]} From {currentNode.Name}");
                    currentNode.ContinentList.Remove(currentNode.ContinentList[i]);
                }
            }
        }
        private void RemoveContinentInOtherBox(Continent continent)
        {
            for (int i = 0; i < betterListBox3.items.Count; i++)
            {
                if (continent.name == betterListBox3.items[i].ItemText)
                {
                    BetterListItem item = betterListBox3.items[i];
                    int index = betterListBox3.items.IndexOf(item);
                    betterListBox3.removeItem(index);
                    RemoveItemFromLists(item, betterListBox3);
                }
            }
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
                    if (node.ContinentList.Count == 0)
                    {
                        node.ContinentList.Add(comboBox1.Text);
                        UpdateListBox();
                    }
                    else
                    {
                        for (int i = 0; i < node.ContinentList.Count; i++)
                        {
                            if (node.ContinentList[i] == comboBox1.Text)
                            {
                                changeHintLabel("Cannot Add The Same Continent Twice");
                            }
                            else
                            {
                                node.ContinentList.Add(comboBox1.Text);
                                UpdateListBox();
                            }
                        }
                    }
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
                    if (currentNodeName == node.Name)
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
                if (nodes[i].Name == text)
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

        private void continentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form createContintentForm = new CreateContinentForm(ref continents);

            DialogResult result = createContintentForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                BetterListItem itemControl = CreateListItem(continents[continents.Count - 1].name, ref betterListBox1);
                itemControl.ButtonClick += ContinentListItemClick;
                betterListBox1.addItem(itemControl);
            }
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Node node in nodes)
            {
                node.adjecentNames = node.adjecentList.ToArray();
                node.continentNames = node.ContinentList.ToArray();
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
    }
}