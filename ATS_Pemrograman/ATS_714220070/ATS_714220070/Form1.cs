using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATS_714220070
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Size = new Size(700,275);
        }

        private void Bpmt_Click(object sender, EventArgs e)
        {
            string errorMessage = "";

            if (string.IsNullOrWhiteSpace(Tnim.Text))
            {
                errorMessage += "Nim Anda Belum Di Isi\n";
            }
            if (string.IsNullOrWhiteSpace(Tnama.Text))
            {
                errorMessage += "Nama Anda Belum Di Isi\n";
            }
            if (!Laki.Checked && !puan.Checked)
            {
                errorMessage += "Anda Belum Pilih jenis kelamin\n";
            }

            if (string.IsNullOrWhiteSpace(Tamt.Text))
            {
                errorMessage += "Alamat Anda Belum Di Isi\n";
            }
            if (string.IsNullOrWhiteSpace(Prodi.Text))
            {
                errorMessage += "Program Studi Anda Belum Di Isi\n";
            }
            if (string.IsNullOrWhiteSpace(Tta.Text))
            {
                errorMessage += "Tahun Akademik Anda Belum Di Isi\n";
            }
            if (string.IsNullOrWhiteSpace(Tsmr.Text))
            {
                errorMessage += "Semester Anda Belum Di Isi\n";

            }
            if (string.IsNullOrEmpty(errorMessage))
            {

                MessageBox.Show("Lengkap", "Informasi Data Submit",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Size = new Size(950, 500);
            }
            else
            {
                MessageBox.Show(errorMessage, "Informasi Data Submit",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void Tnim_TextChanged(object sender, EventArgs e)
        {
            if (Tnim.Text == "")
            {
                epWrong.SetError(Tnim, "");
                epWarning.SetError(Tnim, "nomor Tidak Boleh Kosong");
                epCorrect.SetError(Tnim, "");
            }
            else if (Tnim.Text.Length < 8 || !Tnim.Text.All(Char.IsDigit))
            {
                epWrong.SetError(Tnim, "panjang angka harus lebih dari 8 digit angka");
                epWarning.SetError(Tnim, "");
                epCorrect.SetError(Tnim, "");
            }
            else
            {
                epWarning.SetError(Tnim, "");
                epWrong.SetError(Tnim, "");
                epCorrect.SetError(Tnim, "Betul");
            }
        }

        private void Tnama_TextChanged(object sender, EventArgs e)
        {
            if (Tnama.Text == "")
            {
                epWarning.SetError(Tnama, "Nama Tidak Boleh Kosong");
                epWrong.SetError(Tnama, "");
                epCorrect.SetError(Tnama, "");
            }
            else if (Tnama.Text.All(Char.IsLetter))
            {
                epWarning.SetError(Tnama, "");
                epWrong.SetError(Tnama, "");
                epCorrect.SetError(Tnama, "Betul");
            }
            else
            {
                epWarning.SetError(Tnama, "");
                epWrong.SetError(Tnama, "Inputan hanya boleh huruf");
                epCorrect.SetError(Tnama, "");
            }
        }
        private void Tamt_TextChanged(object sender, EventArgs e)
        {
            if (Tamt.Text == "")
            {
                epWarning.SetError(Tamt, "Alamat tidak boleh kosong!");
                epWrong.SetError(Tamt, "");
                epCorrect.SetError(Tamt, "");
            }
            else
            {
                if (Regex.IsMatch(Tamt.Text, @"^[a-zA-Z]+(\.[a-zA-Z]+)+\.\d+$"))
                {
                    epWarning.SetError(Tamt, "");
                    epWrong.SetError(Tamt, "");
                    epCorrect.SetError(Tamt, "Betul!");
                }
                else
                {
                    epWrong.SetError(Tamt, "Format Alamat salah!\nContoh: Jl.sariasih.No.21");
                    epWarning.SetError(Tamt, "");
                    epCorrect.SetError(Tamt, "");
                }
            }
        }

        private void Prodi_TextChanged(object sender, EventArgs e)
        {
            if (Prodi.Text == "")
            {
                epWarning.SetError(Prodi, "");
                epWrong.SetError(Prodi, "Program studi tidak boleh kosong");
                epCorrect.SetError(Prodi, "");
            }
            else if (Prodi.SelectedIndex != -1)
            {
                epWarning.SetError(Prodi, "");
                epWrong.SetError(Prodi, "");
                epCorrect.SetError(Prodi, "Betul");
            }
            else
            {
                epWarning.SetError(Prodi, "Pilih program studi!");
                epWrong.SetError(Prodi, "");
                epCorrect.SetError(Prodi, "");
            }
        }

        private void Tta_TextChanged(object sender, EventArgs e)
        {
            if (Tta.Text == "")
            {
                epWarning.SetError(Tta, "tahun Akaemik tidak boleh kosong!");
                epWrong.SetError(Tta, "");
                epCorrect.SetError(Tta, "");
            }
            else
            {
                if (Regex.IsMatch(Tta.Text, @"^\d{4}/\d{4}$"))
                {
                    epWarning.SetError(Tta, "");
                    epWrong.SetError(Tta, "");
                    epCorrect.SetError(Tta, "Betul!");
                }
                else
                {
                    epWrong.SetError(Tta, "Format Tahun salah!\nContoh: ****/**** ");
                    epWarning.SetError(Tta, "");
                    epCorrect.SetError(Tta, "");
                }
            }
        }

        private void Tsmr_TextChanged(object sender, EventArgs e)
        {
            if (Tsmr.Text == "")
            {
                epCorrect.SetError(Tsmr, "");
                epWarning.SetError(Tsmr, "Semester tidak boleh kosong!");
                epWrong.SetError(Tsmr, "");
            }
            else
            {
                if (Tsmr.Text.Length > 1 || !Tsmr.Text.All(Char.IsNumber))
                {
                    epCorrect.SetError(Tsmr, "");
                    epWarning.SetError(Tsmr, "");
                    epWrong.SetError(Tsmr, "masukan dengan benar");
                }
                else
                {
                    epCorrect.SetError(Tsmr, "Betul");
                    epWarning.SetError(Tsmr, "");
                    epWrong.SetError(Tsmr, "");
                }
            }
        }

        private void R06_CheckedChanged(object sender, EventArgs e)
        {

            if (R06.Checked)
            {
                mtk.Enabled = true; mtk.Checked = false;
                p1.Enabled = true; p1.Checked = false;
                p2.Enabled = true; p2.Checked = false;
                p2.Enabled = true; p2.Checked = false;
                p3.Enabled = true; p3.Checked = false;
                p4.Enabled = true; p4.Checked = false;
                Fisi.Enabled = true; Fisi.Checked = false;
                Pagama.Enabled = true; Pagama.Checked = false;
                Pkewar.Enabled = true; Pkewar.Checked = false;
                plogis.Enabled = false; plogis.Checked = false;
                jakom.Enabled = true; jakom.Checked = false;
                sio.Enabled = true; sio.Checked = false;
                manarp.Enabled = false; manarp.Checked = false;
            }
        }

        private void R13_CheckedChanged(object sender, EventArgs e)
        {
            if (R13.Checked)
            {
                mtk.Enabled = true; mtk.Checked = false;
                p1.Enabled = true; p1.Checked = false;
                p2.Enabled = true; p2.Checked = false;
                p2.Enabled = true; p2.Checked = false;
                p3.Enabled = true; p3.Checked = false;
                p4.Enabled = true; p4.Checked = false;
                Fisi.Enabled = false; Fisi.Checked = false;
                Pagama.Enabled = true; Pagama.Checked = false;
                Pkewar.Enabled = false; Pkewar.Checked = false;
                plogis.Enabled = true; plogis.Checked = false;
                jakom.Enabled = true; jakom.Checked = false;
                sio.Enabled = true; sio.Checked = false;
                manarp.Enabled = true; manarp.Checked = false;
            }
        }

        private void Rmer_CheckedChanged(object sender, EventArgs e)
        {
            if (Rmer.Checked)
            {
                mtk.Enabled = false; mtk.Checked = false;
                p1.Enabled = true; p1.Checked = false;
                p2.Enabled = true; p2.Checked = false;
                p3.Enabled = true; p3.Checked = false;
                p4.Enabled = true; p4.Checked = false;
                Fisi.Enabled = false; Fisi.Checked = false;
                Pagama.Enabled = true; Pagama.Checked = false;
                Pkewar.Enabled = true; Pkewar.Checked = false;
                plogis.Enabled = false; plogis.Checked = false;
                jakom.Enabled = true; jakom.Checked = false;
                sio.Enabled = true; sio.Checked = false;
                manarp.Enabled = true; manarp.Checked = false;
            }
        }

        private void simpan_Click(object sender, EventArgs e)
        {
            string Gkp= "";
            string Gmkp = "";


            if (R06.Checked == true)
            {
                Gkp+= "Kurikulum 2006, ";
            }
            else if (R13.Checked == true)
            {
                Gkp+= "Kurikulum 2013, ";
            }
            else if (Rmer.Checked == true)
            {
                Gkp+= "Kurikulum Merdeka";
            }


            if (mtk.Checked == true)
            {
                Gmkp += "Matematika, ";
            }
            if (p1.Checked == true)
            {
                Gmkp += "Pemrograman 1,";
            }
            if (p2.Checked == true)
            {
                Gmkp += "pemrograman 2,";
            }
            if (p3.Checked == true)
            {
                Gmkp += "Pemrograman 3,";
            }
            if (p4.Checked == true)
            {
                Gmkp += "Pemrograman 4,";
            }
            if (Fisi.Checked == true)
            {
                Gmkp += "Fisika,";
            }
            if (Pagama.Checked == true)
            {
                Gmkp += "Pendidikan Agama,";
            }
            if (Pkewar.Checked == true)
            {
                Gmkp += "Pendidikan Kewarganegaraan,";
            }
            if (plogis.Checked == true)
            {
                Gmkp += "Pengantar Logistik,";
            }
            if (jakom.Checked == true)
            {
                Gmkp += "Jaringan Komputer,";
            }
            if (sio.Checked == true)
            {
                Gmkp += "Sistem Operasi,";
            }
            if (manarp.Checked == true)
            {
                Gmkp += "manajemen Rantai pasok,";
            }

            if (Gkp!= "" && Gmkp != "")
            {

                string show = "Nim: " + Tnim.Text + "\n" +
                           "nama: " + Tnama.Text + "\n" +
                           "jenis Kelamin: " + (Laki.Checked ? "Laki-Laki" : (puan.Checked ? "Perempuan" : "")) + "\n" +
                           "Alamat: " + Tamt.Text + "\n" +
                           "Program Studi: " + Prodi.Text + "\n" +
                           "Tahun Akademik: " + Tta.Text + "\n" +
                           "Semester: " + Tsmr.Text + "\n" + 
                           "=======================================\n"+
                           "Kurikulum Pilihan: " + Gkp+ "\n" +
                           "Mata Kuliah Pilihan: " + Gmkp;
                           MessageBox.Show(show, "Informasi Pendaftaran", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void batal_Click(object sender, EventArgs e)
        {
            
                foreach (Control control in Controls)
                {
                    if (control is TextBox)
                    {
                        ((TextBox)control).Text = string.Empty;
                    }
                    else if (control is RadioButton)
                    {
                        ((RadioButton)control).Checked = false;
                    }
                    else if (control is CheckBox)
                    {
                        ((CheckBox)control).Checked = false;
                    }
                    else if (control is GroupBox)
                    {
                        ClearControlsInGroupBox((GroupBox)control);
                    }
                    else if (control is ComboBox)
                    {
                        ((ComboBox)control).SelectedIndex = -1;
                    }
                }

                this.Size = new Size(650, 250);
          
        }
        private void ClearControlsInGroupBox(GroupBox groupBox)
        {
            foreach (Control groupControl in groupBox.Controls)
            {
                if (groupControl is TextBox)
                {
                    ((TextBox)groupControl).Text = string.Empty;
                }
                else if (groupControl is RadioButton)
                {
                    ((RadioButton)groupControl).Checked = false;
                }
                else if (groupControl is CheckBox)
                {
                    ((CheckBox)groupControl).Checked = false;
                }
                else if (groupControl is ComboBox)
                {
                    ((ComboBox)groupControl).SelectedIndex = -1;
                }
            }
        }
    }
    
}
