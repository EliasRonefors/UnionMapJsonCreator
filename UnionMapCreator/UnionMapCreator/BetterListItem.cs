using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UnionMapCreator
{
    public partial class BetterListItem : UserControl
    {
        public EventHandler ButtonClick;
        public BetterListItem()
        {
            InitializeComponent();
            button1.Click += Button_Click;
        }
        public string ItemText
        {
            get => label1.Text;
            set => label1.Text = value;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            ButtonClick?.Invoke(this, e);
        }
    }
}
