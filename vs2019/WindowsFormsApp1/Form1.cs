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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // this.ClientSize = new Size(500, 500);
            
            //다양한 컨트롤
            Form2 f2 = new Form2();
            this.AddOwnedForm(f2);  //this는 이클래스, 즉 Form1 의미.
            f2.Show();
            
            //계산기, 학점계산기
            Form3 f3 = new Form3();
            this.AddOwnedForm(f3);
            f3.Text = "실습-계산기";
            //f3.Show();

            //그리기(선,사각,원,곡선...)
            Form4 f4 = new Form4();
            this.AddOwnedForm(f4);
            f4.Text = "실습-그리기";
            //f4.Show();

            //윈도우 계산기
            Form5 f5 = new Form5();
            this.AddOwnedForm(f5);
            f5.Text = "실습-윈도우 계산기";
            //f5.Show();

            //아날로그 시계
            Form6 f6 = new Form6();
            this.AddOwnedForm(f6);
            f6.Text = "실습-아날로그 시계";
            //f6.Show();

            //차트
            Form7 f7 = new Form7();
            this.AddOwnedForm(f7);
            f7.Text = "실습-차트";
            //f7.Show();

            //메모장
            Form8 f8 = new Form8();
            this.AddOwnedForm(f8);
            f8.Text = "실습-차트";
            //f8.Show();

            //오목
            Form9 f9 = new Form9();
            this.AddOwnedForm(f9);
            f9.Text = "실습-차트";
            //f9.Show();

            //센서모니터링
            Form10 f10 = new Form10();
            this.AddOwnedForm(f10);
            f10.Text = "실습-차트";
            f10.Show();
        }
    }
}
