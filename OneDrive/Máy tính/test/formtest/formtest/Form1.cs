using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace formtest
{
    public partial class frmQuanLySinhVien : Form
    {
        public frmQuanLySinhVien()
        {
            InitializeComponent();
        }


        private void frmQuanLySinhVien_Load(object sender, EventArgs e)
        {
            cmbFaculty.SelectedIndex = 0;
        }


        private int  GetSelectedRow(string txtStudentID)
        {
            for (int i = 0; i < dgvStudent.Rows.Count; i++)
            {
                if (dgvStudent.Rows[i].Cells[0].Value.ToString() == txtStudentID)
                {
                    return i;
                }
            }
            return -1;
        }

        private void InsertUpdate(int SelectedRow)
        {
            dgvStudent.Rows[SelectedRow].Cells[0].Value = txtStudentID.Text;
            dgvStudent.Rows[SelectedRow].Cells[1].Value = txtFullName.Text;
            dgvStudent.Rows[SelectedRow].Cells[2].Value = optFemale.Checked ? "Nữ" : "Nam";
            dgvStudent.Rows[SelectedRow].Cells[3].Value = float.Parse(txtAvgScore.Text).ToString();
            dgvStudent.Rows[SelectedRow].Cells[4].Value = cmbFaculty.Text;
        }
        
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtStudentID.Text == "" || txtFullName.Text == "" || txtAvgScore.Text == "")
                    throw new Exception("Vui lòng nhập đầy đủ thông tin!");
                int SelectedRow = GetSelectedRow(txtStudentID.Text);
                if (SelectedRow == -1) // add new
                {
                    SelectedRow = dgvStudent.Rows.Add();
                    InsertUpdate(SelectedRow);
                    MessageBox.Show("Nhập dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK);
                }
                else //Update
                {
                    dgvStudent.Rows.RemoveAt(SelectedRow);
                    InsertUpdate(SelectedRow);
                    MessageBox.Show("Cập nhật dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK);
                    dgvStudent.Update();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            try
            {
                int SelectedRow = GetSelectedRow(txtStudentID.Text);
                if (SelectedRow == -1)
                    throw new Exception("Không tìm thấy MSSV cần xóa");
                else
                {
                    DialogResult dr = MessageBox.Show("Bạn có muốn Xóa ?", "YES/NO", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {
                        dgvStudent.Rows.RemoveAt(SelectedRow); // Delete data student in Rows
                        MessageBox.Show("Bạn xóa Sinh Viên thành công!", "Thông báo", MessageBoxButtons.OK);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
