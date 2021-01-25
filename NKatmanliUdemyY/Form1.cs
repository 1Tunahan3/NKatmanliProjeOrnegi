using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;
using LogicLayer;

namespace NKatmanliUdemyY
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<EntityPersonel> PerList = LogicPersonel.LLPersonelListesi();
            dataGridView1.DataSource = PerList;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EntityPersonel entity=new EntityPersonel();
            entity.Ad = textBox2.Text;
            entity.Soyad = textBox3.Text;
            entity.Sehir = textBox4.Text;
            entity.Gorev = textBox6.Text;
            entity.Maas = short.Parse(textBox5.Text);
            LogicPersonel.LLPersonelEkle(entity);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            EntityPersonel entity=new EntityPersonel();
            entity.Id = Convert.ToInt16(textBox1.Text);
            LogicPersonel.LLPersonelSilme(entity.Id);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            EntityPersonel entity = new EntityPersonel();
            entity.Id = Convert.ToInt16(textBox1.Text);
            entity.Ad = textBox2.Text;
            entity.Soyad = textBox3.Text;
            entity.Sehir = textBox4.Text;
            entity.Gorev = textBox6.Text;
            entity.Maas = short.Parse(textBox5.Text);
            LogicPersonel.LLPersonelGuncelle(entity);
        }
    }
}
