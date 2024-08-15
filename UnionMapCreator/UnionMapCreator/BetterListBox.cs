using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;

namespace UnionMapCreator
{
    public partial class BetterListBox : UserControl
    {
        public List<BetterListItem> items = new List<BetterListItem>();
        private int selectedIndex = -1;
        public BetterListBox()
        {
            InitializeComponent();
        }

        public void addItem(string itemText)
        {
            BetterListItem itemControl = new BetterListItem
            {
                ItemText = itemText,
                Width = panel1.Width,
                Location = new Point(0, items.Count * 23), //Adjust height as needed
            };

            itemControl.ButtonClick += ItemControl_ButtonClick;

            items.Add(itemControl);
            panel1.Controls.Add(itemControl);

            this.Invalidate();
        }
        private void ItemControl_ButtonClick(object sender, EventArgs e)
        {
            BetterListItem clickedItem = sender as BetterListItem;
            int index = items.IndexOf(clickedItem);
            selectedIndex = index;

            removeItem(index);
        }
        public void removeItem(int index)
        {
            if (index >= 0 && index < items.Count)
            {
                BetterListItem item = items[index];
                panel1.Controls.Remove(item);
                items.RemoveAt(index);

                // Update positions of remaining items
                for (int i = index; i < items.Count; i++)
                {
                    items[i].Location = new Point(0, i * 40);
                }

                this.Invalidate();
            }
        }
    }
}
