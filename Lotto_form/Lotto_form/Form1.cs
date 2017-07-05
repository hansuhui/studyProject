using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
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
        Lotto_Winner Lotto_Winner = new Lotto_Winner();

        public Form1()
        {
            InitializeComponent();
            Number_100 = Lotto.GetNum100();

            var NumData =
                from lotto in Number_100
                group lotto by lotto into data
                orderby data.Count() descending
                select new
                {
                    Num = data.Key,
                    Count = data.Count()
                };

            foreach (var num in NumData)
            {
                ListViewItem item = new ListViewItem(new string[] { num.Num, num.Count.ToString() });
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


            Lotto_Winner = Lotto.GetLotto_Winner();
            label8.Text = Lotto_Winner.WinNum_Turn + " 회차";
            label7.Text = Lotto_Winner.WinNum_string + "(보너스 : "+ Lotto_Winner .Bouns+ ")";

        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.listView1.Items.Clear();
            var StatData = from lotto in Stat
                           orderby lotto.stat descending
                           select lotto;

            var StatData_10 = StatData.Take(15); //전체 상위 10개 
            var StatData_10_Num = from lotto in StatData_10
                                  orderby lotto.Number
                                  select new
                                  {
                                      Number = lotto.Number
                                  };

            var Number_10 = Number_100.Take(15); //최근 100회차 상위 10개 
            int count = 1;



            List<int> Random = new List<int>();
            foreach (var r_num in Number_10)
            {
                Random.Add(Convert.ToInt32(r_num));
            }

            foreach (var r_num in StatData_10_Num)
            {
                Random.Add(Convert.ToInt32(r_num.Number));
            }


            Random = Random.Distinct().OrderBy(r => r).ToList();


            foreach (var s in Enumerable.Range(1, 5))
            {

                string result1 = "";
                string result2 = "";
                int[] Ran1 = new int[6];
                int[] Ran2 = new int[6];


                if (s == 1)
                {
                    foreach (var x in Enumerable.Range(0, 6))
                    {
                        Ran1[x] = Convert.ToInt32(Number_10.ElementAt(x));
                        Ran2[x] = Convert.ToInt32(StatData_10_Num.ElementAt(x).Number);
                    }

                    result1 = GetResult(Ran1);
                    result2 = GetResult(Ran2);

                }
                else
                {

                    Thread.Sleep(100);

                    Ran1 = GetIntArray(Random.ToList());
                    Ran1 = Ran1.OrderBy(r => r).ToArray();
                    result1 = GetResult(Ran1);

                    Thread.Sleep(100);


                    Ran2 = GetIntArray(Random.ToList());
                    Ran2 = Ran2.OrderBy(r => r).ToArray();
                    result2 = GetResult(Ran2);



                }

                AddList(count++.ToString(), result1);
                AddList(count++.ToString(), result2);

            }



        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.listView1.Items.Clear();
        }


        private string GetResult(int[] Ran)
        {
            string result = "";
            int i = 0;
            foreach (var s in Ran)
            {
                if (i == 0)
                {
                    result = Ran[i].ToString();

                }
                else
                {
                    result += "," + Ran[i].ToString();
                }
                i++;
            }
            return result;

        }

        private int[] GetIntArray(List<int> tmp_data)
        {
            int[] Ran = new int[6];
            Random s1 = new System.Random();
            foreach (var x in Enumerable.Range(0, 6))
            {
                int Ran_Count = tmp_data.Count() - 1;
                Ran_Count = s1.Next(Ran_Count);
                Ran[x] = tmp_data[Ran_Count];
                tmp_data.RemoveAt(Ran_Count);
            }
            return Ran;
        }


        private void AddList(string count, string result)
        {
            ListViewItem item = new ListViewItem(new string[] { count, result });
            this.listView1.Items.Add(item);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void onNum(object sender, KeyPressEventArgs e)
        {
            //숫자,백스페이스
            if (!(Char.IsDigit(e.KeyChar)) && e.KeyChar != 8) //8:백스페이스
            {
                e.Handled = true;
            }
        }


        private void Num_Check(object sender, EventArgs e)
        {
            string[] NuM = new string[6];
            NuM[0] = textBox1.Text;
            NuM[1] = textBox2.Text;
            NuM[2] = textBox3.Text;
            NuM[3] = textBox4.Text;
            NuM[4] = textBox5.Text;
            NuM[5] = textBox6.Text;

            NuM = NuM.Distinct().ToArray();
            string Result = "";
            string Rank = "";
            int Result_Num = 0;
            bool Rank2_ckeck = false;


            foreach (var NuM_Check in NuM)
            {
                foreach (var Check in Lotto_Winner.WinNum_Arr)
                {
                    if (NuM_Check.Equals(Check))
                    {
                        if(string.IsNullOrEmpty(Result))
                        {
                            Result = Check;
                        }else{
                            Result += ","+Check;
                        }
                        Result_Num++;
                    }
                    if (NuM_Check.Equals(Lotto_Winner.Bouns)) {
                        Rank2_ckeck = true;
                    }

                }

            }
            switch (Result_Num)
            {
                case 3:
                    Rank = "5등";
                    break;
                case 4:
                    Rank = "4등";
                    break;
                case 5:
                    Rank = "3등";
                    break;
                case 6:
                    Rank = "1등";
                    break;
                default:
                    Rank = "미당첨";
                    break;
            }

            if (Rank2_ckeck && Result_Num == 5) {
                Rank = "2등";
                Result_Num = 6;
            }


            label13.Text = Result + "("+ Result_Num.ToString() + "개 일치)";
            label14.Text = Rank;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";

            label13.Text = "번호를 입력해 주세요.";
            label14.Text = "번호를 입력해 주세요.";
        }
    }
}

