using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Odev2708_Universiteler
{
    public partial class Form1 : Form
    {
        DataModel dm = new DataModel();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBoxUni.ValueMember = "ID";
            comboBoxUni.DisplayMember = "Isim";
            List<Universite> universiteler = dm.GetUni();
            universiteler.Insert(0, new Universite { ID = 0, Isim = "Seçiniz" });
            comboBoxUni.DataSource = universiteler;
            comboBoxFakulte.Enabled = false;
            comboBoxBolum.Enabled = false;
        }

        private void comboBoxUni_SelectedIndexChanged(object sender, EventArgs e)
        {
            int universiteID = Convert.ToInt32(comboBoxUni.SelectedValue);
            if (universiteID != 0)
            {
                List<Fakulte> fakulteler = dm.GetFakulte(universiteID);
                fakulteler.Insert(0, new Fakulte { ID = "0", UniversiteID = 0, Isim = "Seçiniz" });
                comboBoxFakulte.Enabled = true;
                comboBoxFakulte.DisplayMember = "Isim";
                comboBoxFakulte.ValueMember = "ID";
                comboBoxFakulte.DataSource = fakulteler;
            }
            else
            {
                comboBoxFakulte.Enabled = false;
                comboBoxFakulte.Text = "";
                comboBoxFakulte.Enabled = false;
                comboBoxFakulte.Text = "";
            }
        }

        private void comboBoxFakulte_SelectedIndexChanged(object sender, EventArgs e)
        {
            string fakulteID = Convert.ToString(comboBoxFakulte.SelectedValue);
            int universiteID = Convert.ToInt32(comboBoxUni.SelectedValue);
            if (fakulteID != "0")
            {
                comboBoxBolum.Enabled = true;
                comboBoxBolum.DisplayMember = "Isim";
                comboBoxBolum.ValueMember = "ID";
                comboBoxBolum.DataSource = dm.GetBolum(fakulteID, universiteID);
            }
            else
            {
                comboBoxBolum.Enabled = false;
                comboBoxBolum.Text = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string message1 = "";
            string message2 = "";
            message1 = "Bu Proje Zor Hastalık Şartları Altında Geç Yapılmıştır.";
            message2 = "Mazur Görün Hocam :(";
            MessageBox.Show(message1);
            MessageBox.Show(message2);
        }
    }
}
