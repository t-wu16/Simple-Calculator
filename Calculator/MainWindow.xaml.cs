using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        Dictionary<string, string> OperationDict;
        string num2Str = "";

        public MainWindow()
        {
            InitializeComponent();
            Title = "计算器";
            btnC.Click += BtnC_Click;
            btnE.Click += BtnE_Click;
            btnD.Click += new RoutedEventHandler(BtnOperator_Click);
            btnX.Click += new RoutedEventHandler(BtnOperator_Click);
            btnM.Click += new RoutedEventHandler(BtnOperator_Click);
            btnP.Click += new RoutedEventHandler(BtnOperator_Click);
            btn9.Click += new RoutedEventHandler(BtnNum_Click);
            btn8.Click += new RoutedEventHandler(BtnNum_Click);
            btn7.Click += new RoutedEventHandler(BtnNum_Click);
            btn6.Click += new RoutedEventHandler(BtnNum_Click);
            btn5.Click += new RoutedEventHandler(BtnNum_Click);
            btn4.Click += new RoutedEventHandler(BtnNum_Click);
            btn3.Click += new RoutedEventHandler(BtnNum_Click);
            btn2.Click += new RoutedEventHandler(BtnNum_Click);
            btn1.Click += new RoutedEventHandler(BtnNum_Click);
            btn0.Click += new RoutedEventHandler(BtnNum_Click);
            OperationDict = new Dictionary<string, string>();
        }

        private void BtnOperator_Click(object sender, RoutedEventArgs e)//运算符点击事件
        {
            try
            {
                var opr = sender as Button;
                if (ShowNumText.Text == "")
                    return;

                switch (opr.Content.ToString())
                {
                    case "+":
                        OperationDict.Add("Operator", "+");
                        break;
                    case "-":
                        OperationDict.Add("Operator", "-");
                        break;
                    case "X":
                        OperationDict.Add("Operator", "*");
                        break;
                    case "/":
                        OperationDict.Add("Operator", "/");
                        break;
                }
                ShowNumText.Text += opr.Content.ToString();
            }
            catch (Exception e2) {
                MessageBox.Show(e2.ToString());
            }
        }

        private void BtnE_Click(object sender, RoutedEventArgs e)   //等于键点击事件
        {
            try
            {
                ShowNumText.Text += "=";
                string str1 = "", str2 = "", opr = "";
                if (OperationDict.TryGetValue("Num1", out str1) && OperationDict.TryGetValue("Operator", out opr) && OperationDict.TryGetValue("Num2", out str2))
                {
                    int num1 = int.Parse(str1);
                    int num2 = int.Parse(str2);
                    switch (opr)
                    {
                        case "+":
                            ShowNumText.Text = (num1 + num2).ToString();
                            break;
                        case "-":
                            ShowNumText.Text = (num1 - num2).ToString();
                            break;
                        case "*":
                            ShowNumText.Text = (num1 * num2).ToString();
                            break;
                        case "/":
                            ShowNumText.Text = (num1 / num2).ToString();
                            break;
                    }
                    OperationDict.Clear();
                    num2Str = "";
                    OperationDict.Add("Num1", ShowNumText.Text);
                }
                else
                {
                    return;
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.ToString());
            }
        }

        private void BtnC_Click(object sender, RoutedEventArgs e)//清除键点击事件
        {
            OperationDict.Clear();
            ShowNumText.Text = "";
            num2Str = "";
        }

        private void BtnNum_Click(object sender, RoutedEventArgs e)//数字点击事件
        {
            var num = sender as Button;
            string value = "";
            if (!OperationDict.TryGetValue("Operator", out value))
            {//运算符为空，存储的数字为第一个
                if (ShowNumText.Text == "")
                {
                    ShowNumText.Text = num.Content.ToString();
                    OperationDict.Add("Num1", num.Content.ToString());
                }
                else
                {
                    ShowNumText.Text += num.Content.ToString();
                    OperationDict["Num1"] = ShowNumText.Text;
                }
            }
            else
            {//运算符不为空，存储的数字为第二个
                if (num2Str == "")
                {
                    ShowNumText.Text += num.Content.ToString();
                    num2Str += num.Content.ToString();
                    OperationDict.Add("Num2", num.Content.ToString());
                }
                else
                {
                    ShowNumText.Text += num.Content.ToString();
                    num2Str += num.Content.ToString();
                    OperationDict["Num2"] = num2Str;
                }
            }
        }
    }
}
