using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GoogleDrive;

namespace QLBH.Forms
{
    public partial class Test2 : Form
    {
        public Test2()
        {
            InitializeComponent();
            txtBox.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
           var listString = new string[]
            {
                "Dương Tuấn Đạt",
                "Dương Tuấn Sơn",
                "Dư Lê Hoàng",
                "Dương Thanh Sơn",
                "Dương Tuấn Sơ",
                "Dung"
            };
            var autoComplete = new AutoCompleteStringCollection();
            foreach (var item in listString)
            {
                autoComplete.Add(item);
            }
            txtBox.AutoCompleteCustomSource = autoComplete;

            
            
        }

        private void Test2_Load(object sender, EventArgs e)
        {
            picture.Load(@"https://docs.google.com/uc?id=0B378gFDdDF1UNWdnTTNsX25XTFU&export=download");
        }
    }
}
