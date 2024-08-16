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

        public void addItem(BetterListItem item)
        {
            items.Add(item);
            panel1.Controls.Add(item);

            this.Invalidate();
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
        public void clear()
        {
            items.Clear();
            panel1.Controls.Clear();
        }
    }
}
