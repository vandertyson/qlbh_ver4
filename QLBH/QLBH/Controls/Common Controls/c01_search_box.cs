using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBH.Controls
{
    public partial class c01_search_box : UserControl
    {
        enum Mode
        {
            None,
            Holder
        }
        Mode mode;
        public delegate void DelSearch(string key);
        public DelSearch Search;
        public Color SearchBackColor
        {
            get
            {
                return BackColor;
            }
            set
            {
                BackColor = value;
                txtKeyWord.BackColor = value;
            }
        }
        public string SearchText
        {
            get
            {
                return txtKeyWord.Text;
            }
            set
            {
                txtKeyWord.Text = value;
            }
        }
        Color searchForceColor;
        public Color SearchForceColor
        {
            get
            {
                return searchForceColor;
            }
            set
            {
                searchForceColor = value;
                txtKeyWord.ForeColor = value;
            }
        }
        public string SearchPlaceHolder { get; set; }
        public Color SearchPlaceHolderColor { get; set; }
        public c01_search_box()
        {
            InitializeComponent();
            
            txtKeyWord.TextChanged += textChange;
            txtKeyWord.GotFocus += gotFocus;
            txtKeyWord.LostFocus += lostFocus;
        }

        private void gotFocus(object sender, EventArgs e)
        {
            if (mode == Mode.Holder)
            {
                txtKeyWord.ForeColor = SearchForceColor;
                txtKeyWord.Text = "";
                mode = Mode.None;
            }
        }

        private void textChange(object sender, EventArgs e)
        {
            
        }

        public void SetPlaceHolder()
        {
            lostFocus(null, null);
        }

        private void lostFocus(object sender, EventArgs e)
        {
            if (txtKeyWord.Text == "")
            {
                txtKeyWord.ForeColor = SearchPlaceHolderColor;
                txtKeyWord.Text = SearchPlaceHolder;
                mode = Mode.Holder;
            }
        }

        private void m_btn_search_Click(object sender, EventArgs e)
        {
            Search?.Invoke(txtKeyWord.Text);
        }

        private void txtKeyWord_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Search?.Invoke(txtKeyWord.Text);
            }
        }
    }
}
