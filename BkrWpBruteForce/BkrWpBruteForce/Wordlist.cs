using System;
using System.Threading;
using System.Windows.Forms;

namespace BkrWpBruteForce
{
    public partial class Wordlist : Form
    {
        public Wordlist()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }
        Thread th;
        private void wordlistOluşturToolStripMenuItem_Click(object sender, EventArgs e)
        {
            th = new Thread(create);th.Start();
        }

        private void create()
        {
            for (int i = 0; i < richTextBox1.Text.Replace(",","").Replace(".","").Split(' ').Length; i++)
            {
                if (richTextBox1.Text.Split(' ')[i].ToString()!="")
                {
                    kmtmrkz.Liste.Add(richTextBox1.Text.Split(' ')[i].ToString());
                    richTextBox2.AppendText(richTextBox1.Text.Split(' ')[i].ToString() + "\r");
                }
            }
        }
    }
}
