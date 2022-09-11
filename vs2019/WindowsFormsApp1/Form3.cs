using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        //# 학점계산기
        TextBox[] titles;
        ComboBox[] crds;
        ComboBox[] grds;

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            //학점계산기
            txt1.Text = "자료구조";
            txt2.Text = "소프트웨어공학";
            txt3.Text = "C#프로그래밍";

            crds = new ComboBox[] { crd1, crd2, crd3  };
            grds = new ComboBox[] { grd1, grd2, grd3 };
            titles = new TextBox[] { txt1, txt2, txt3 };
            int[] arrCredit = { 1, 2, 3, 4, 5 };
            List<String> lstGrade = new List<string> { "A+", "A0", "B+", "B0", "C+", "C0", "D+", "D0", "F" };

            foreach (var combo in crds)
            {
                foreach (var i in arrCredit)
                    combo.Items.Add(i);
                combo.SelectedItem = 3;
            }

            foreach (var cb in grds)
            {
                foreach (var gr in lstGrade)
                    cb.Items.Add(gr);
                cb.SelectedIndex = 1;
            }

            //상품리스트
            listViewProduct.GridLines = true;
            listViewProduct.FullRowSelect = true;

            listViewProduct.Columns.Add("제품명", 150);
            listViewProduct.Columns.Add("단가", 100, HorizontalAlignment.Right);
            listViewProduct.Columns.Add("수량", 70, HorizontalAlignment.Right);
            listViewProduct.Columns.Add("금액", 100, HorizontalAlignment.Right);

            ListViewItem item1 = new ListViewItem("Access", 0);
            ListViewItem item2 = new ListViewItem("Excel", 1);
            ListViewItem item3 = new ListViewItem("PowerPoint", 2);
            ListViewItem item4 = new ListViewItem("Word", 3);

            item1.SubItems.Add("22,000");
            item1.SubItems.Add("30");
            item1.SubItems.Add("660,000");

            item2.SubItems.Add("33,000");
            item2.SubItems.Add("50");
            item2.SubItems.Add("1,650,000");

            item3.SubItems.Add("11,000");
            item3.SubItems.Add("50");
            item3.SubItems.Add("550,000");

            item4.SubItems.Add("22,000");
            item4.SubItems.Add("30");
            item4.SubItems.Add("660,000");

            listViewProduct.Items.AddRange(new ListViewItem[] { item1, item2, item3, item4 });

            ImageList sImageList = new ImageList();
            sImageList.ImageSize = new Size(24, 24);
            ImageList lImageList = new ImageList();
            lImageList.ImageSize = new Size(64, 64);

            listViewProduct.SmallImageList = sImageList;
            listViewProduct.LargeImageList = lImageList;

            //https://www.iconfinder.com/
            sImageList.Images.Add(Bitmap.FromFile(@"../../Image/access.png"));
            sImageList.Images.Add(Bitmap.FromFile(@"../../Image/excel.png"));
            sImageList.Images.Add(Bitmap.FromFile(@"../../Image/ppt.png"));
            sImageList.Images.Add(Bitmap.FromFile(@"../../Image/word.png"));

            lImageList.Images.Add(Bitmap.FromFile(@"../../Image/access.png"));
            lImageList.Images.Add(Bitmap.FromFile(@"../../Image/excel.png"));
            lImageList.Images.Add(Bitmap.FromFile(@"../../Image/ppt.png"));
            lImageList.Images.Add(Bitmap.FromFile(@"../../Image/word.png"));

            //역사공부
            TreeNode root = new TreeNode("영국의 왕");
            TreeNode stuart = new TreeNode("스튜어트 왕가");
            TreeNode hanover = new TreeNode("하노버 왕가");
            TreeNode sachsen = new TreeNode("작센코브르트고타 왕가");
            TreeNode windsor = new TreeNode("윈저 왕가");

            stuart.Nodes.Add("앤(1707~1714)");

            hanover.Nodes.Add("조지 1세(1714~1727)");
            hanover.Nodes.Add("조지 2세(1727~1760)");
            hanover.Nodes.Add("조지 3세(1760~1820)");
            hanover.Nodes.Add("조지 4세(1820~1830)");
            hanover.Nodes.Add("윌리엄 4세(1830~1837)");
            hanover.Nodes.Add("빅토리아(1837~1901)");

            sachsen.Nodes.Add("에드워드 7세(1901~1910)");

            windsor.Nodes.Add("조지 5세(1910~1936)");
            windsor.Nodes.Add("에드워드 8세(1936~1936)");
            windsor.Nodes.Add("조지 6세(1936~1952)");
            windsor.Nodes.Add("엘리자베스 2세(1952~현재)");

            root.Nodes.Add(stuart);
            root.Nodes.Add(hanover);
            root.Nodes.Add(sachsen);
            root.Nodes.Add(windsor);

            treeView1.Nodes.Add(root);
            treeView1.ExpandAll();
        }
        //# 성적계산기
        private void button1_Click(object sender, EventArgs e)
        {

            double sum = Convert.ToDouble(textBox1.Text)
              + Convert.ToDouble(textBox2.Text)
              + Convert.ToDouble(textBox3.Text);

            double avg = sum / 3;

            textBox4.Text = sum.ToString();
            textBox5.Text = avg.ToString("0.0");
        }

        //# 학점계산기
        private void btnGetGrade_Click(object sender, EventArgs e)
        {
            double totalScore = 0;
            int totalCredits = 0;

            for (int i = 0; i < crds.Length; i++)
            {
                if (titles[i].Text != "")
                {
                    int crd = int.Parse(crds[i].SelectedItem.ToString());
                    totalCredits += crd;
                    totalScore += crd * GetGrade(grds[i].SelectedItem.ToString());
                }
            }
            txtGrade.Text = (totalScore / totalCredits).ToString("0.00");
        }
        private double GetGrade(string text)
        {
            double grade = 0;

            if (text == "A+") grade = 4.5;
            else if (text == "A0") grade = 4.0;
            else if (text == "B+") grade = 3.5;
            else if (text == "B0") grade = 3.0;
            else if (text == "C+") grade = 2.5;
            else if (text == "C0") grade = 2.0;
            else if (text == "D+") grade = 1.5;
            else if (text == "D0") grade = 1.0;
            else grade = 0;
            return grade;
        }

        //# 상품리스트
        private void listViewProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSelected.Text = "";
            ListView.SelectedListViewItemCollection selected = listViewProduct.SelectedItems;
            foreach (ListViewItem item in selected)
            {
                for (int i = 0; i < 4; i++)
                    txtSelected.Text += item.SubItems[i].Text + "\t";
            }
        }
        private void btnViewStyle_Click(object sender, EventArgs e)
        {
            if (btnViewStyle.Tag.Equals("1"))
            {
                listViewProduct.View = View.Details;
                btnViewStyle.Text = "리스트";
                btnViewStyle.Tag = "2";
            }
            else if (btnViewStyle.Tag.Equals("2"))
            {
                listViewProduct.View = View.List;
                btnViewStyle.Text = "작은아이콘";
                btnViewStyle.Tag = "3";
            }
            else if (btnViewStyle.Tag.Equals("3"))
            {
                listViewProduct.View = View.SmallIcon;
                btnViewStyle.Text = "큰아이콘";
                btnViewStyle.Tag = "4";
            }
            else if (btnViewStyle.Tag.Equals("4"))
            {
                listViewProduct.View = View.LargeIcon;
                btnViewStyle.Text = "자세히";
                btnViewStyle.Tag = "1";
            }
        }

        //# 역사공부
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Text == "앤(1707~1714)")
            {
                pictureBox1.Image = Bitmap.FromFile("../../Images/Anne.jpg");
                txtMemo.Text = "앤 여왕은 1702년 3월 8일 잉글랜드와 스코틀랜드, 아일랜드의 여왕으로 즉위하였으며, "
                  + "1707년 연합법이 제정됨에 따라, 잉글랜드 왕국과 스코틀랜드 왕국이 통합된 그레이트브리튼 왕국, "
                  + "즉 영국의 첫 번째 군주가 되었다.";
            }
            else if (e.Node.Text == "조지 1세(1714~1727)")
            {
                pictureBox1.Image = Bitmap.FromFile("../../Images/King_George_I.jpg");
                txtMemo.Text = "잉글랜드 의회에서 1701년 왕위 결정 법이 통과되면서, 하노버 왕가가 왕위 계승권을 "
                  + "갖게 되었지만, 가톨릭 신자는 왕위 계승권에서 제외되었다. 1707년 스코틀랜드 의회에서도 "
                  + "하노버 왕가의 왕위 계승권을 비준하였다. 앤 여왕이 후사를 남기지 못하고 서거하자, "
                  + "그와 가장 가까운 친척이자 제임스 1세(6세)의 증손녀인 팔츠의 조피의 아들인 데다가, "
                  + "가톨릭 신자가 아니었던 조지 1세가 왕위를 이어받게 되었다.";
            }
        }

    }
}
