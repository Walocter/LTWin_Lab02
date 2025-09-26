using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab02_02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void TinhTongNamNu()
        {
            int tongNam = 0, tongNu = 0;
            foreach (DataGridViewRow row in dgvSinhVien.Rows)
            {
                if (row.Cells["GioiTinh"].Value != null)
                {
                    if (row.Cells["GioiTinh"].Value.ToString() == "Nam")
                        tongNam++;
                    else
                        tongNu++;
                }
            }

            txtTongNam.Text = tongNam.ToString();
            txtTongNu.Text = tongNu.ToString();
        }

        private void btnThemSua_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu bắt buộc
            if (string.IsNullOrWhiteSpace(txtMSSV.Text) ||
                string.IsNullOrWhiteSpace(txtHoTen.Text) ||
                string.IsNullOrWhiteSpace(txtDTB.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra MSSV đã tồn tại chưa
            foreach (DataGridViewRow row in dgvSinhVien.Rows)
            {
                if (row.Cells["MSSV"].Value != null && row.Cells["MSSV"].Value.ToString() == txtMSSV.Text)
                {
                    // Cập nhật thông tin
                    row.Cells["HoTen"].Value = txtHoTen.Text;
                    row.Cells["GioiTinh"].Value = rdoNam.Checked ? "Nam" : "Nữ";
                    row.Cells["DTB"].Value = txtDTB.Text;
                    row.Cells["Khoa"].Value = cboKhoa.Text;

                    MessageBox.Show("Cập nhật dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TinhTongNamNu();
                    return;
                }
            }

            // Nếu chưa tồn tại → thêm mới
            dgvSinhVien.Rows.Add(txtMSSV.Text, txtHoTen.Text, rdoNam.Checked ? "Nam" : "Nữ", txtDTB.Text, cboKhoa.Text);
            MessageBox.Show("Thêm mới dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Tính lại tổng
            TinhTongNamNu();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMSSV.Text))
            {
                MessageBox.Show("Vui lòng nhập MSSV cần xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (DataGridViewRow row in dgvSinhVien.Rows)
            {
                if (row.Cells["MSSV"].Value != null && row.Cells["MSSV"].Value.ToString() == txtMSSV.Text)
                {
                    DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa sinh viên này?", "Xác nhận",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        dgvSinhVien.Rows.Remove(row);
                        MessageBox.Show("Xóa sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        TinhTongNamNu();
                    }
                    return;
                }
            }

            MessageBox.Show("Không tìm thấy MSSV cần xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }




        private void dgvSinhVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvSinhVien.Rows[e.RowIndex];
                txtMSSV.Text = row.Cells["MSSV"].Value?.ToString();
                txtHoTen.Text = row.Cells["HoTen"].Value?.ToString();
                txtDTB.Text = row.Cells["DTB"].Value?.ToString();
                cboKhoa.Text = row.Cells["Khoa"].Value?.ToString();

                string gt = row.Cells["GioiTinh"].Value?.ToString();
                if (gt == "Nam") rdoNam.Checked = true;
                else rdoNu.Checked = true;
            }
        }

       
    }
}