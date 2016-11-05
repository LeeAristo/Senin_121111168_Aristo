using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Latihan_2_1
{
    public partial class Form1 : Form
    {
        public string tglMerah, tgl, bln, thn;
        public void libur(DateTime Date)
        {
            tgl = Date.Day.ToString();
            bln = Date.Month.ToString();
            thn = Date.Year.ToString();
            tglMerah = bln + "/" + tgl + "/" + thn;
            monthCalendar1.AddBoldedDate(Convert.ToDateTime(tglMerah));
        }

        public Form1()
        {
            InitializeComponent();
            Libur();
        }

       
        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {
            int i = domainUpDown1.SelectedIndex + 1;
            if (i == 1 || i == 3 || i == 5 || i == 7 || i == 8 || i == 10 || i == 12)
            {
                numericUpDown1.Maximum = 31;
            }
            else if (i == 2)
            {
                numericUpDown1.Maximum = 29;
            }
            else
            {
                numericUpDown1.Maximum = 30;
            }
        }

        public void Libur()
        {
            DateTime DT1 = monthCalendar1.SelectionStart.AddMonths(-22);
            DateTime DT2 = monthCalendar1.SelectionStart.AddMonths(22);
            string Day1 = "01", Month1 = DT1.Month.ToString(), Year1 = DT1.Year.ToString();
            string Day2 = "01", Month2 = DT2.Month.ToString(), Year2 = DT2.Year.ToString();

            bool Februari = true;
            if (DT2.Year % 100 != 0 && DT2.Year % 4 == 0 && DT2.Year % 400 == 0)
            {
                Februari = false;
            }
            for (int i = 1; i <= 12; i++)
            {
                if (DT2.Month == i)
                {
                    if (i == 1 || i == 3 || i == 5 || i == 7 || i == 8 || i == 10 || i == 12) { Day2 = "31"; }
                    else if (i == 2 && Februari) { Day2 = "28"; }
                    else if (i == 2) { Day2 = "29"; }
                    else { Day2 = "30"; }
                    break;
                }
            }

            DateTime Date1 = Convert.ToDateTime(Month1 + "/" + Day1 + "/" + Year1);
            DateTime Date2 = Convert.ToDateTime(Month2 + "/" + Day2 + "/" + Year2);

            while (Date1 <= Date2)
            {
                if (Date1.DayOfWeek == DayOfWeek.Saturday) { libur(Date1); }
                else if (Date1.DayOfWeek == DayOfWeek.Sunday) { libur(Date1); }
                else if (Date1.Day == 2 && Date1.Month == 10) { libur(Date1); }
                Date1 = Date1.AddDays(1);
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (domainUpDown1.SelectedIndex == -1)
            {
                MessageBox.Show("Masukkan Bulan yang Tepat!!!");
                return;
            }
            string Tanggal = numericUpDown1.Value.ToString(); string Bulan = (domainUpDown1.SelectedIndex + 1).ToString(); string Tahun = DateTime.Today.Year.ToString();
            DateTime Hari = Convert.ToDateTime(Tanggal + "/" + Bulan + "/" + Tahun);
            monthCalendar1.AddAnnuallyBoldedDate(Hari);
            monthCalendar1.UpdateBoldedDates();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DateTime Tgl1 = monthCalendar1.SelectionRange.Start;
            DateTime Tgl2 = monthCalendar1.SelectionRange.End;
            while (Tgl1 <= Tgl2)
            {
                monthCalendar1.RemoveBoldedDate(Tgl1);
                Tgl1 = Tgl1.AddDays(1);
            }
            if (domainUpDown1.SelectedIndex == -1)
            {
                MessageBox.Show("Masukkan Bulan yang Benar");
                return;
            }
            string Tanggal = numericUpDown1.Value.ToString(); string Bulan = (domainUpDown1.SelectedIndex + 1).ToString(); string Tahun = DateTime.Today.Year.ToString();
            DateTime Hari = Convert.ToDateTime(Tanggal + "/" + Bulan + "/" + Tahun);
            monthCalendar1.RemoveAnnuallyBoldedDate(Hari);
            monthCalendar1.UpdateBoldedDates();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            monthCalendar1.AddAnnuallyBoldedDate(new DateTime(2016, 03, 10));
            domainUpDown1.Items.Add("Januari");
            domainUpDown1.Items.Add("Februari");
            domainUpDown1.Items.Add("Maret");
            domainUpDown1.Items.Add("April");
            domainUpDown1.Items.Add("Mei");
            domainUpDown1.Items.Add("Juni");
            domainUpDown1.Items.Add("Juli");
            domainUpDown1.Items.Add("Agustus");
            domainUpDown1.Items.Add("September");
            domainUpDown1.Items.Add("Oktober");
            domainUpDown1.Items.Add("November");
            domainUpDown1.Items.Add("Desember");
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }
    }
}
