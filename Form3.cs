using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Курсач
{
    public partial class Form3 : Form
    {

        TimeSpan time = DateTime.Now - DateTime.Now;
        
        public Form3()
        {
            InitializeComponent();

        }
        public Form3(TimeSpan timeSpan)
        {
            time = timeSpan;
            InitializeComponent();
            this.label4.Text = time.ToString();
            
        }



        private void button1_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }
    }
}
