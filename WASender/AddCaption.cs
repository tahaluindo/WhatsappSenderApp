using System;
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
    public partial class AddCaption : MyMaterialPopOp
    {

        WaSenderForm waSenderForm;
        public AddCaption(WaSenderForm _waSenderForm)
        {
            InitializeComponent();
            this.waSenderForm = _waSenderForm;
        }

        private void AddCaption_Load(object sender, EventArgs e)
        {
            initLanguages();
        }

        private void initLanguages()
        {
            this.Text = Strings.AddCaption;
            txtLongMessage.Hint = Strings.TypeYourMessagehere;
            materialButton2.Text = Strings.Save;
        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            if (txtLongMessage.Text != "")
            {
               this.waSenderForm.AddCaptionFReturn(txtLongMessage.Text);
               this.Close();
            }
        }
    }
}
