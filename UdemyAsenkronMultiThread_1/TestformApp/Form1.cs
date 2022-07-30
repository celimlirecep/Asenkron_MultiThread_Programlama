using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestformApp
{
    public partial class Form1 : Form
    {
        int sayac = 0;
        public int counter=0;
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            //string data = ReadFile();
            sayac = 0;
            string data = String.Empty;
             Task<String> readData= ReadFileAsync();
            richTextBox2.Text = await new HttpClient().GetStringAsync("https://www.google.com");

            data = await readData;
            richTextBox1.Text = data;
        }

        private void btnCounter_Click(object sender, EventArgs e)
        {
            textBoxCounter.Text = counter++.ToString();
        }

        private  string ReadFile()
        {
            string data = string.Empty;
            using (StreamReader s=new StreamReader("data.txt"))
            {
                Thread.Sleep(5000);
                data = s.ReadToEnd();

            }
            return data;
        }
        private async Task<string> ReadFileAsync()
        {
            string data = string.Empty;
            using (StreamReader s = new StreamReader("data.txt"))
            {
                
               Task<string> myTask = s.ReadToEndAsync();
                timer1.Start();
              await  Task.Delay(5000);
                

                data = await myTask;
                timer1.Stop();

            }
            return data;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            sayac++;
            timer.Text = sayac.ToString();
        }
    }
}
