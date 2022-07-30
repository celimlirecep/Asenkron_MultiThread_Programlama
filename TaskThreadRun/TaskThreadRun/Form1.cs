using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskThreadRun
{
    public partial class sayaclabel : Form
    {
        private static int counter { get; set; } = 0;
        public sayaclabel()
        {
            InitializeComponent();
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
          var aTest= Go(progressBar1);
         var bTest=  Go(progressBar2);
            await Task.WhenAll(aTest, bTest);
        }
        //public  void  Go(ProgressBar pb)
        //{
        //    Thread.Sleep(2000);
        //    Enumerable.Range(1, 100).ToList().ForEach(i => pb.Value = i);
    
        //}
        public async Task Go(ProgressBar pb)
        {
           await Task.Run(() =>
            {
                Thread.Sleep(100);
                Enumerable.Range(1, 100).ToList().ForEach(i =>
                {
                  
                    Thread.Sleep(2000);
                    pb.Invoke((MethodInvoker)delegate { pb.Value = i; });

                });
            });
         

        }

        private void btnSayac_Click(object sender, EventArgs e)
        {
            btnSayac.Text = counter++.ToString();
        }
    }
}
