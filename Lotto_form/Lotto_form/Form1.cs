using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lotto_form
{
    public partial class Form1 : Form
    {
        LottoBase Lotto = new LottoBase();
        List<string> Number_100 = new List<string>();
        List<Lotto_100> Lotto_100 = new List<Lotto_100>();
        List<statByNumber> Stat = new List<statByNumber>();
        List<string> Result = new List<string>();

        public Form1()
        {
            InitializeComponent();
            Number_100 = Lotto.GetNum100();

            var NumData = from lotto in Number_100
                          group lotto by lotto into data
                          orderby data.Count() descending
                          select new
                          {
                              Num = data.Key,
                              Count = data.Count()
                          };


            foreach (var num in NumData) {
                ListViewItem item = new ListViewItem(new string[] { num.Num, num.Count.ToString()});
                this.listView5.Items.Add(item);
            }

            Lotto_100 = Lotto.GetLotto100();

            foreach (var L_100 in Lotto_100)
            {
                ListViewItem item = new ListViewItem(new string[] { L_100.No, L_100.Data });
                this.listView3.Items.Add(item);
            }

            Stat = Lotto.GetStat();

            var StatData = from lotto in Stat
                          orderby lotto.stat descending
                          select lotto;


            foreach (var St in StatData)
            {
                ListViewItem item = new ListViewItem(new string[] { St.Number, St.stat.ToString() });
                this.listView2.Items.Add(item);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            //최근 회차 100
            //Number_100
            //통계에서 100
            //Stat
            //Result

            var L_100 = from lotto_100 in Number_100
                           select lotto_100;


            foreach (var s in Enumerable.Range(1, 10))
            {
                ListViewItem item = new ListViewItem(new string[] { s.ToString(), s.ToString() });
                this.listView1.Items.Add(item);
            }

            

        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.listView1.Items.Clear();
        }

        
    }
}
