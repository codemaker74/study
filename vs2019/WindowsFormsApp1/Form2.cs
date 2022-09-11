using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//# TabControl
using WMPLib; //WindowsMediaPlayer

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        //# TabControl
        Timer myTimer = new Timer();
        DateTime dDay;
        DateTime tTime;
        private bool setAlarm;
        WindowsMediaPlayer myPlayer = new WindowsMediaPlayer();
        //# 메모장 띄우기
        private OpenFileDialog openFileDialog1;

        public Form2()
        {
            InitializeComponent();
            //this.ClientSize = new Size(1200, 800);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //CenterToParent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(700, 100);

            //스크롤바 RGB 컨트롤
            this.BackColor = Color.LightSteelBlue;
            panel1.BackColor = Color.FromArgb(0, 0, 0);
            textBox1.Text = 0.ToString();
            textBox2.Text = 0.ToString();
            textBox3.Text = 0.ToString();
            hScrollBar1.Maximum = 255 + 9;
            hScrollBar2.Maximum = 255 + 9;
            hScrollBar3.Maximum = 255 + 9;

            //체크리스트박스
            checkedListBox1.Items.Add("로드");
            lbSelected.SelectionMode = SelectionMode.MultiExtended;

            //타이머
            lbTimer.Text = "";
            timer1.Interval = 100; // 0.1초
            timer1.Tick += timer1_Tick;
            timer1.Start(); //timer1.Enabled = true;

            //프로그래스바
            trackBar1.Minimum = 0;
            trackBar1.Maximum = 100;
            trackBar1.Value = 0;

            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
            progressBar1.Value = 0;

            //TabControl
            lbTabAlarm.ForeColor = Color.Gray;
            lbTabAlarmSet.ForeColor = Color.Gray;

            tabTimePicker.Format = DateTimePickerFormat.Custom;
            tabTimePicker.CustomFormat = "tt hh:mm";

            timerTab.Interval = 1000;
            timerTab.Tick += timerTab_Tick;
            timerTab.Start();

            tabControl1.SelectedTab = tabPage2;

            //미디어 플레이어
            axWindowsMediaPlayer1.uiMode = "full";
            axWindowsMediaPlayer1.stretchToFit = true;
            //btnPlayer.Location = new Point(ClientSize.Width - btnPlayer.Size.Width - 5,  ClientSize.Height - btnPlayer.Size.Height - 5);

            //메모장 띄우기
            openFileDialog1 = new OpenFileDialog();
            openFileDialog1.FileName = "Select a text file";
            openFileDialog1.Filter = "Text files (*.txt)|*.txt";
            openFileDialog1.Title = "Open text file";
        }

        //# 메시지 박스
        private void btnMSG_Click(object sender, EventArgs e)
        {   
            MessageBox.Show("가장 간단한 메시지박스입니다.");
            MessageBox.Show("타이틀을 갖는 메시지박스입니다.", "Title Message");
            DialogResult result1 = MessageBox.Show("버튼2개 & 질문아이콘", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            DialogResult result2 = MessageBox.Show("버튼3개 & 질문아이콘","Question",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question);
            DialogResult result3 = MessageBox.Show("디폴트 버튼을 두 번째 버튼으로 \n지정한 메시지박스입니다.",
                "Question",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

            string msg = string.Format("당신의 선택 : {0} {1} {2}", result1.ToString(), result2.ToString(), result3.ToString());
            MessageBox.Show(msg, "Your Selections");
            MessageBox.Show("느낌표와 알람 메시지박스입니다.", "느낌표와 알람 소리", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        //# 텍스트 박스
        private void btnName_Click(object sender, EventArgs e)
        {
            if (edName.Text == "")
                MessageBox.Show("이름입력!", "Warning");
            else
            {
                Font ft = new Font(label1.Font.Name, 10);
                label1.Font = ft;
                label1.Text = edName.Text + "님! 하이루~";
            }
                
        }

        //# 레이블 여러줄 표시
        private void btnLabel_Click(object sender, EventArgs e)
        {
            string raffaello = "라파엘로 산치오, 이탈리아, 르테상스 3대 거장, 1483~1520";
            string schoolOfAthens = "라파엘로(Raphael, Raffaello Sanzio da Urbino)는 " +
              "동시대의 대가인 미켈란젤로, 레오나르도 다빈치와 함께 르네상스 3대 거장으로 " +
              "알려져 있습니다. 가장 유명한 작품은 <아테네 학당(The School of Athens)>으로 " +
              "바티칸 궁(Apostolic Palace)에 있는 프레스코 벽화입니다.\n\n";

            label3.Text = raffaello;
            label4.Text = schoolOfAthens;
        }

        //# 체크박스
        private void btnCheckBox_Click(object sender, EventArgs e)
        {
            string checkStates = "";
            CheckBox[] cBox = { checkBox1, checkBox2, checkBox3 };
            foreach (var item in cBox)
            {
                checkStates += string.Format("{0} : {1}\n", item.Text, item.Checked);
            }
            MessageBox.Show(checkStates, "checkStates");

            string summary = string.Format("좋아하는 과일은 : ");
            foreach (var item in cBox)
            {
                if (item.Checked == true)
                    summary += item.Text + " ";
            }
            MessageBox.Show(summary, "summary");
        }

        //# 라디오버튼(그룹박스에포함)
        private RadioButton checkedRB;
        private void btnRadioBox_Click(object sender, EventArgs e)
        {
            string result = "";
            if (radioButton1.Checked)
                result += "국적 : 대한민국\n";
            else if (radioButton2.Checked)
                result += "국적 : 중국\n";
            else if (radioButton3.Checked)
                result += "국적 : 일본\n";
            else if (radioButton4.Checked)
                result += "국적 : 그 외의 국가\n";

            if (checkedRB == radioButton5)
                result += "성별 : 남성";
            else if (checkedRB == radioButton6)
                result += "성별 : 여성";

            MessageBox.Show(result, "Result");
        }
        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            checkedRB = radioButton5;
        }
        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            checkedRB = radioButton6;
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
        //# 스크롤바
        private void scr_Scroll(object sender, ScrollEventArgs e) //Scroll 이벤트
        {
            textBox1.Text = hScrollBar1.Value.ToString();
            textBox2.Text = hScrollBar2.Value.ToString();
            textBox3.Text = hScrollBar3.Value.ToString();
            panel1.BackColor = Color.FromArgb(hScrollBar1.Value, hScrollBar2.Value, hScrollBar3.Value);
        }

        private void txt_TextChanged(object sender, EventArgs e) //TextChanged 이벤트
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                hScrollBar1.Value = int.Parse(textBox1.Text);
                hScrollBar2.Value = int.Parse(textBox2.Text);
                hScrollBar3.Value = int.Parse(textBox3.Text);
                panel1.BackColor = Color.FromArgb(hScrollBar1.Value, hScrollBar2.Value, hScrollBar3.Value);
            }
        }
        //# 리스트박스
        private void btnItemAdd_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") );
        }
        private void button1_Click(object sender, EventArgs e)
        {
            List<String> lstGDP = new List<String> { "미국", "러시아", "중국", "영국", "UAE"};
            listBox1.DataSource = lstGDP;

        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox item = sender as ListBox;
            edItemIndex.Text = item.SelectedIndex.ToString();
            edItemName.Text  = item.SelectedItem.ToString();
        }
        //#콤보박스
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            lbComboBox.Text = "콤보박스선택 => " + cb.SelectedItem.ToString();
        }
        private void btnComboBoxAdd_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {
                comboBox1.Items.Add(comboBox1.Text);
                lbComboBox.Text = "콤보박스선택 => " + comboBox1.Text + "!추가";

            }
        }
        private void btnComboBoxDel_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex >=0 )
            {
                lbComboBox.Text = comboBox1.SelectedItem.ToString() + " !삭제";
                comboBox1.Items.Remove(comboBox1.SelectedItem);
            }

        }
        //#체크리스트박스
        private void groupBox4_Enter(object sender, EventArgs e)
        {
        }

        private void btnCheckAdd_Click(object sender, EventArgs e)
        {
            foreach (var item in checkedListBox1.CheckedItems)
                lbSelected.Items.Add(item);
        }
        private void btnCheckBack_Click(object sender, EventArgs e)
        {
            List<string> lstRemove = new List<string>();
            foreach (string item in lbSelected.SelectedItems)
                lstRemove.Add(item);
            foreach (string item in lstRemove)
                lbSelected.Items.Remove(item);
        }

        private void btnCheckDel_Click(object sender, EventArgs e)
        {
            lbSelected.Items.Clear();

        }

        private void btnCheckAll_Click(object sender, EventArgs e)
        {
            foreach (var item in checkedListBox1.Items)
                lbSelected.Items.Add(item);
        }

        //# 타이머
        private void timer1_Tick(object sender, EventArgs e)
        {
            //lbTimer.Location = new Point(ClientSize.Width / 2 - lbTimer.Width / 2, ClientSize.Height / 2 - lbTimer.Height / 2);
            lbTimer.Font = new Font("맑은 고딕", 15, FontStyle.Bold);
            lbTimer.Text = DateTime.Now.ToString();

            if (trackBar1.Value < 100)
            {
                trackBar1.Value++;
                progressBar1.Value++;
                lbTrackBar.Text     = trackBar1.Value.ToString();
                lbProgressBar.Text  = progressBar1.Value.ToString();
            }
            else
            {
                //timer1.Stop();
            }
        }

        //# DateTimePicker
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime today = DateTime.Today;
            DateTime birthDay = dateTimePicker1.Value;

            lbDateTimePicker.Text = "선택한 날짜로부터 " + today.Subtract(birthDay).TotalDays.ToString("0") +"일 경과!!!";
        }

        //# TabControl
        private void timerTab_Tick(object sender, EventArgs e)
        {
            DateTime cTime = DateTime.Now;
            lbTabDate.Text = cTime.ToShortDateString();
            lbTabTime.Text = cTime.ToLongTimeString();

            if (setAlarm == true)
            {
                if (dDay == DateTime.Today &&
                  cTime.Hour == tTime.Hour && cTime.Minute == tTime.Minute)
                {
                    setAlarm = false;
                    //MessageBox.Show("Alarm!!");
                    myPlayer.URL = @"C:\workshop\WindowsFormsApp1\Music\preview.mp3";
                    myPlayer.controls.play();
                }
            }
        }
        private void btnTabSet_Click(object sender, EventArgs e)
        {
            dDay = DateTime.Parse(tabDatePicker.Text);
            tTime = DateTime.Parse(tabTimePicker.Text);

            setAlarm = true;
            lbTabAlarmSet.ForeColor = Color.Red;
            lbTabAlarm.ForeColor = Color.Blue;
            lbTabAlarm.Text = "Alarm : " + dDay.ToShortDateString() + " "
              + tTime.ToLongTimeString();

            tabControl1.SelectedTab = tabPage2;
        }
        private void btnTabReset_Click(object sender, EventArgs e)
        {
            setAlarm = false;
            lbTabAlarmSet.ForeColor = Color.Gray;
            lbTabAlarm.ForeColor = Color.Gray;
            lbTabAlarm.Text = "Alarm : ";
            tabControl1.SelectedTab = tabPage2;
        }

        //# 미디어 플레이어
        private void btnPlayer_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                axWindowsMediaPlayer1.URL = ofd.FileName;
            }
        }

        //# 메모장 띄우기
        private void btnOpenWordpad_Click(object sender, EventArgs e)
        {
            /*
             * 선언 필요
            using System.IO;
            using System.Diagnostics;
            using System.Security;
             */
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var filePath = openFileDialog1.FileName;
                    using (FileStream fs = File.Open(filePath, FileMode.Open))
                    {
                        Process.Start("notepad.exe", filePath);
                    }
                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }

            }
        }

        //# 메뉴&대화상자
        private void menuFont_Click(object sender, EventArgs e)
        {
            FontDialog fDlg = new FontDialog();

            fDlg.ShowColor = true;
            fDlg.ShowEffects = true;
            fDlg.Font = label4.Font;
            fDlg.Color = label4.ForeColor;

            if (fDlg.ShowDialog() == DialogResult.OK)
            {
                label4.Font = fDlg.Font;
                label4.ForeColor = fDlg.Color;
            }
        }
        private void menuColor_Click(object sender, EventArgs e)
        {
            ColorDialog cDlg = new ColorDialog();
            if (cDlg.ShowDialog() == DialogResult.OK)
            {
                this.BackColor = cDlg.Color;
            }
        }
        private void menuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
