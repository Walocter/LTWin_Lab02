using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab02_04
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnThemCapNhat_Click(object sender, EventArgs e)
        {
            // Kiểm tra nhập liệu
            if (string.IsNullOrWhiteSpace(txtSoTaiKhoan.Text) ||
                string.IsNullOrWhiteSpace(txtTenKhachHang.Text) ||
                string.IsNullOrWhiteSpace(txtDiaChi.Text) ||
                string.IsNullOrWhiteSpace(txtSoTien.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra số tiền
            if (!decimal.TryParse(txtSoTien.Text, out decimal soTien))
            {
                MessageBox.Show("Số tiền phải là số hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Tìm tài khoản theo mã
            ListViewItem itemTonTai = null;
            foreach (ListViewItem item in listView1.Items)
            {
                if (item.SubItems[1].Text == txtSoTaiKhoan.Text)
                {
                    itemTonTai = item;
                    break;
                }
            }

            if (itemTonTai == null)
            {
                // Thêm mới
                ListViewItem item = new ListViewItem((listView1.Items.Count + 1).ToString());
                item.SubItems.Add(txtSoTaiKhoan.Text);
                item.SubItems.Add(txtTenKhachHang.Text);
                item.SubItems.Add(txtDiaChi.Text);
                item.SubItems.Add(soTien.ToString());

                listView1.Items.Add(item);

                MessageBox.Show("Thêm mới dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Cập nhật
                itemTonTai.SubItems[2].Text = txtTenKhachHang.Text;
                itemTonTai.SubItems[3].Text = txtDiaChi.Text;
                itemTonTai.SubItems[4].Text = soTien.ToString();

                MessageBox.Show("Cập nhật dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            TinhTongTien();
        }

        // Nút Xóa
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSoTaiKhoan.Text))
            {
                MessageBox.Show("Vui lòng nhập số tài khoản cần xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ListViewItem itemCanXoa = null;
            foreach (ListViewItem item in listView1.Items)
            {
                if (item.SubItems[1].Text == txtSoTaiKhoan.Text)
                {
                    itemCanXoa = item;
                    break;
                }
            }

            if (itemCanXoa == null)
            {
                MessageBox.Show("Không tìm thấy số tài khoản cần xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa tài khoản này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                listView1.Items.Remove(itemCanXoa);
                MessageBox.Show("Xóa tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TinhTongTien();
            }
        }

        // Nút Thoát
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Khi chọn 1 dòng trong ListView -> đổ dữ liệu vào TextBox
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem item = listView1.SelectedItems[0];
                txtSoTaiKhoan.Text = item.SubItems[1].Text;
                txtTenKhachHang.Text = item.SubItems[2].Text;
                txtDiaChi.Text = item.SubItems[3].Text;
                txtSoTien.Text = item.SubItems[4].Text;
            }
        }

        // Hàm tính tổng tiền
        private void TinhTongTien()
        {
            decimal tong = 0;
            foreach (ListViewItem item in listView1.Items)
            {
                if (decimal.TryParse(item.SubItems[4].Text, out decimal money))
                {
                    tong += money;
                }
            }
            txtTongTien.Text = tong.ToString("N0");
        }
    }
}
