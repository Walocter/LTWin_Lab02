using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab02_03
{
    public partial class Form1 : Form
    {
        private List<Button> gheList = new List<Button>();
        private int tongTien = 0;

        public Form1()
        {
            InitializeComponent();
            TaoDanhSachGhe();
        }

        // Tạo list chứa các Button ghế
        private void TaoDanhSachGhe()
        {
            // Giả sử bạn đã tạo sẵn 20 button có tên btn1, btn2,... btn20
            for (int i = 1; i <= 20; i++)
            {
                Button btn = (Button)this.Controls.Find("btn" + i, true)[0];
                btn.BackColor = Color.White;
                btn.Click += Btn_Click;  // gắn sự kiện click cho mỗi button
                gheList.Add(btn);
            }
        }

        // Sự kiện khi click vào ghế
        private void Btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            if (btn.BackColor == Color.White) // Chưa bán, chưa chọn
            {
                btn.BackColor = Color.LightGreen; // chọn
            }
            else if (btn.BackColor == Color.LightGreen) // đang chọn
            {
                btn.BackColor = Color.White; // bỏ chọn
            }
            else if (btn.BackColor == Color.Yellow) // đã bán
            {
                MessageBox.Show("Ghế " + btn.Text + " đã được bán!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Nút CHỌN
        private void btnChon_Click(object sender, EventArgs e)
        {
            tongTien = 0;

            foreach (Button btn in gheList)
            {
                if (btn.BackColor == Color.LightGreen)
                {
                    btn.BackColor = Color.Yellow; // đổi sang đã bán
                    tongTien += TinhTienGhe(int.Parse(btn.Text));
                }
            }

            lbl.Text = tongTien.ToString("N0") + " đ";
        }

        // Nút HỦY BỎ
        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            foreach (Button btn in gheList)
            {
                if (btn.BackColor == Color.LightGreen)
                {
                    btn.BackColor = Color.White; // hủy chọn
                }
            }

            lbl.Text = "0 đ";
        }

        // Nút KẾT THÚC
        private void btnKetThuc_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Hàm tính tiền theo số ghế
        private int TinhTienGhe(int soGhe)
        {
            if (soGhe >= 1 && soGhe <= 5) return 30000;
            if (soGhe >= 6 && soGhe <= 10) return 40000;
            if (soGhe >= 11 && soGhe <= 15) return 50000;
            if (soGhe >= 16 && soGhe <= 20) return 80000;
            return 0;
        }

       
    }
}
