﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLST;

namespace SplashScreen
{
    public partial class GioiThieu : Form
    {
        public GioiThieu()
        {
            InitializeComponent();
        }

        private bool KT = ManHinhChinh.Hotro;
        private void button3_Click(object sender, EventArgs e)
        {
                this.Close();           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GioiThieu_Load(object sender, EventArgs e)
        {
            if (KT == true)
            {
                timer1.Start();
            }
            else
            {
                timer1.Stop();
            }
        }

    }
}
