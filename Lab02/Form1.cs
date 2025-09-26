using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private bool TryGetNumbers(out double num1, out double num2)
        {
            num1 = 0;
            num2 = 0;

            // Kiểm tra rỗng
            if (string.IsNullOrWhiteSpace(txtNumber1.Text) || string.IsNullOrWhiteSpace(txtNumber2.Text))
            {
                MessageBox.Show("Vui lòng nhập đủ cả hai số!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Kiểm tra nhập số
            if (!double.TryParse(txtNumber1.Text, out num1))
            {
                MessageBox.Show("Số thứ nhất không hợp lệ!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!double.TryParse(txtNumber2.Text, out num2))
            {
                MessageBox.Show("Số thứ hai không hợp lệ!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            if (TryGetNumbers(out double num1, out double num2))
            {
                txtAnswer.Text = (num1 + num2).ToString();
            }
        }

        private void btnSub_Click_1(object sender, EventArgs e)
        {
            if (TryGetNumbers(out double num1, out double num2))
            {
                txtAnswer.Text = (num1 - num2).ToString();
            }
        }

        private void btnMul_Click_1(object sender, EventArgs e)
        {
            if (TryGetNumbers(out double num1, out double num2))
            {
                txtAnswer.Text = (num1 * num2).ToString();
            }
        }

        private void btnDiv_Click_1(object sender, EventArgs e)
        {
            if (TryGetNumbers(out double num1, out double num2))
            {
                if (num2 == 0)
                {
                    MessageBox.Show("Không thể chia cho 0!", "Lỗi tính toán", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                txtAnswer.Text = (num1 / num2).ToString();
            }
        }

       
    }
}
