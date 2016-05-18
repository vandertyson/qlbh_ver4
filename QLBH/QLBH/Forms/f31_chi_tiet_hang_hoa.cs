using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibraryApi;
using GoogleDrive;
using System.IO;

namespace QLBH.Forms
{
    public partial class f31_chi_tiet_hang_hoa : Form
    {
        #region Member
        QuanLyDanhMucHangHoa.ThemHangHoa m_data;
        List<QuanLyDanhMucHangHoa.NhaCungCapV2> m_list_nha_cung_cap;
        List<QuanLyTagHangHoa.Tag> m_list_tag;
        List<int> listLinkAnhDaChon = new List<int>();
        #endregion
        public f31_chi_tiet_hang_hoa()
        {
            InitializeComponent();
            defineEvent();
            
        }

        //public void LoadTagVaNhaCungCap(List<QuanLyTagHangHoa.Tag> tag, List<QuanLyDanhMucHangHoa.NhaCungCapV2> ncc)
        //{
        //    m_list_nha_cung_cap = ncc;
        //    m_list_tag = tag;
        //}
        private void load_tag_va_nha_cung_cap()
        {
            QuanLyDanhMucHangHoa.LayDanhSachNhaCungCap(this, data =>
            {
                if (data.Success)
                {
                    m_list_nha_cung_cap = data.Data;
                    m_comb_nha_cung_cap.DataSource = m_list_nha_cung_cap;
                    m_comb_nha_cung_cap.DisplayMember = "ten_nha_cung_cap";
                    m_comb_nha_cung_cap.ValueMember = "ma_nha_cung_cap";
                    if (!string.IsNullOrEmpty(m_data.ma_nha_cung_cap))
                    {
                        m_comb_nha_cung_cap.SelectedValue = m_data.ma_nha_cung_cap;
                    }
                    else
                    {
                        m_comb_nha_cung_cap.SelectedIndex = 0;
                        //m_data.ma_nha_cung_cap = m_comb_nha_cung_cap.SelectedValue.ToString();
                        //m_data.ten_nha_cung_cap = m_comb_nha_cung_cap.SelectedText;
                    }
                }
            });
            QuanLyTagHangHoa.LayDanhSachTag(this, data =>
            {
                if (data.Success)
                {
                    m_list_tag = data.Data;
                    txt_them_tag.AutoCompleteMode = AutoCompleteMode.Suggest;
                    txt_them_tag.AutoCompleteSource = AutoCompleteSource.CustomSource;

                    var autoComplete = new AutoCompleteStringCollection();
                    foreach (var item in m_list_tag)
                    {
                        autoComplete.Add(item.ten_tag);
                    }
                    txt_them_tag.AutoCompleteCustomSource = autoComplete;
                }
            });
        }
        private void defineEvent()
        {
            Load += F31_chi_tiet_hang_hoa_Load;
            txt_them_tag.KeyDown += Txt_them_tag_KeyDown;
            m_btn_go_tag.Click += M_btn_go_tag_Click;
            m_txt_ten_hang.TextChanged += M_txt_ten_hang_TextChanged;
            m_txt_ma_tra_cuu.TextChanged += M_txt_ma_tra_cuu_TextChanged;
            m_comb_nha_cung_cap.SelectedIndexChanged += M_comb_nha_cung_cap_SelectedIndexChanged;
        }

        private void M_comb_nha_cung_cap_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            var ten = (QuanLyDanhMucHangHoa.NhaCungCapV2)m_comb_nha_cung_cap.SelectedItem;
            m_data.ten_nha_cung_cap = ten.ten_nha_cung_cap;
            m_data.ma_nha_cung_cap = ten.ma_nha_cung_cap;
        }

        private void M_txt_ma_tra_cuu_TextChanged(object sender, EventArgs e)
        {
            m_data.ma_tra_cuu = m_txt_ma_tra_cuu.Text;
        }

        private void M_txt_ten_hang_TextChanged(object sender, EventArgs e)
        {
            m_data.ten_hang_hoa = m_txt_ten_hang.Text;
        }

        private void M_btn_go_tag_Click(object sender, EventArgs e)
        {
            var tag = lb_tag.SelectedItem as QuanLyDanhMucHangHoa.Tag;
            m_data.tag.Remove(tag);
            refreshListTag();
        }

        private void refreshListTag()
        {
            lb_tag.DataSource = null;
            lb_tag.DataSource = m_data.tag;
            lb_tag.DisplayMember = "ten_tag";
            lb_tag.ValueMember = "id";
        }

        private void Txt_them_tag_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var old = m_data.tag.Where(s => s.ten_tag == txt_them_tag.Text).FirstOrDefault();
                if (old==null)
                {
                    var tag = new QuanLyDanhMucHangHoa.Tag();
                    tag.id = 0;
                    tag.ten_tag = txt_them_tag.Text;
                    m_data.tag.Add(tag);
                    refreshListTag();
                }
            }
        }

        private void F31_chi_tiet_hang_hoa_Load(object sender, EventArgs e)
        {
            loadDataToForm();
        }

        public void display_update(QuanLyDanhMucHangHoa.ThemHangHoa themHangHoa)
        {
            m_data = themHangHoa;
            btn_luu.Click += Btn_luu_Click;
            ShowDialog();
            
        }

        private void Btn_luu_Click(object sender, EventArgs e)
        {
            QuanLyDanhMucHangHoa.UpdateHangHoa(m_data, this, data =>
            {
                MessageBox.Show(data.Message);
                Close();
            });
        }

        public void display_add()
        {
            m_data = new QuanLyDanhMucHangHoa.ThemHangHoa();
            m_data.link_anh = new List<string>();
            m_data.tag = new List<QuanLyDanhMucHangHoa.Tag>();
            this.Text = "F31 - Thêm hàng hóa";
            m_data.mo_ta = "";
            m_data.id = 0;
            m_data.da_xoa = "N";

            btn_luu.Click += btn_luu_Click;
            
            this.ShowDialog();
        }
        void loadDataToForm()
        {
            load_tag_va_nha_cung_cap();
            m_txt_ten_hang.Text = m_data.ten_hang_hoa;
            m_txt_ma_tra_cuu.Text = m_data.ma_tra_cuu;
            m_link_mo_ta.Text = m_data.mo_ta;
            lb_tag.DataSource = m_data.tag;
            lb_tag.DisplayMember = "ten_tag";
            lb_tag.ValueMember = "id";
            table_anh.Length = () =>
            {
                return m_data.link_anh.Count;
            };
            table_anh.CellAtIndex = index =>
            {
                var anh = new PictureBox();
                anh.LoadAsync(m_data.link_anh[index]);
                anh.Size = new Size(100, 100);
                anh.SizeMode = PictureBoxSizeMode.Zoom;
                anh.BackColor = Color.White;
                return anh;
            };
            table_anh.DidSelectCellAtIndex = (i,sender,e) =>
            {
                var item = sender as PictureBox;
                if (e.Button == MouseButtons.Right)
                {
                    if (listLinkAnhDaChon.Contains(i))
                    {
                        table_anh.SetItemNormal(i);
                        listLinkAnhDaChon.Remove(i);
                    }
                    else
                    {
                        table_anh.SetItemHighLight(i);
                        listLinkAnhDaChon.Add(i);
                    }  
                }
                if (e.Button == MouseButtons.Left)
                {
                    table_anh.SetOneItemHighlight(i);
                    listLinkAnhDaChon.Clear();
                    listLinkAnhDaChon.Add(i);
                }
            };
            table_anh.ItemHighlight = (sender) =>
            {
                var item = sender as PictureBox;
                item.BackColor = Color.Brown;
            };
            table_anh.ItemNormal = (sender) =>
            {
                var item = sender as PictureBox;
                item.BackColor = Color.White;
            };
            table_anh.Init();
        }

        

        private void m_btn_sua_bai_viet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(m_link_mo_ta.Text))
            {
                var drive = new GDrive();
                string path = new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent.FullName;
                path += @"\Template\temp.doc";

                var file = drive.Upload(path, m_data.ma_tra_cuu + ".doc", UploadFileType.MsWord, "doc");
                m_data.mo_ta = file.linkView;
                m_link_mo_ta.Text = file.linkView;
                System.Diagnostics.Process.Start(file.linkView);
            }
            else
            {
                System.Diagnostics.Process.Start(m_link_mo_ta.Text);
            }
        }

        private void m_btn_them_anh_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(m_txt_ma_tra_cuu.Text))
            {
                MessageBox.Show("Điền mã tra cứu trước!");
                return;
            }
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "JPG (.jpg)|*.jpg|PNG (.png)|*.png|All Files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.Multiselect = true;
            var userClickedOK = openFileDialog1.ShowDialog();

            if (userClickedOK == DialogResult.OK)
            {
                var result = openFileDialog1.FileNames;
                foreach (var item in result)
                {
                    var drive = new GDrive();
                    var fileType = item.Substring(item.Count() - 3).ToLower() == "jpg"?
                        UploadFileType.ImageJPG:
                        UploadFileType.ImagePNG;
                    var random = new Random();
                    var r = drive.Upload(item, 
                        m_txt_ma_tra_cuu.Text+random.Next(0,100).ToString(), 
                        fileType, "image");
                    m_data.link_anh.Add(r.link);
                    table_anh.Init();
                }
            }
        }

        private void m_btn_xoa_anh_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (var item in listLinkAnhDaChon)
                {
                    m_data.link_anh.RemoveAt(item);
                    table_anh.Init();
                }
            }
            catch(Exception ev)
            {

            }
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            QuanLyDanhMucHangHoa.ThemMotHangHoa(m_data, this, data =>
            {
                MessageBox.Show(data.Message);
                Close();
            });
        }
    }
}
