﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WaAutoReplyBot;

namespace WASender
{
    public partial class InputDialog : MyMaterialPopOp
    {
        GMapExtractor gMapExtractor;
        public InputDialog(GMapExtractor _gMapExtractor)
        {
            gMapExtractor = _gMapExtractor;
            InitializeComponent();
        }

        private void InputDialog_Load(object sender, EventArgs e)
        {
            initLang();
        }

        private void initLang()
        {
            this.Text = Strings.YourSearchterm;
            materialMaskedTextBox1.Text = Strings.Softwarecompaniesintexas;
            
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            if (materialMaskedTextBox1.Text != "")
            {
                try
                {
                    gMapExtractor.InputReturn(materialMaskedTextBox1.Text);
                    this.Close();
                }
                catch (Exception ex)
                {

                }
            }
        }
    }
}
