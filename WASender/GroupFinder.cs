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
using WASender.Models;
using WASender.Validators;
using FluentValidation.Results;
using MaterialSkin.Controls;
using System.Threading;
using RestSharp;
using OfficeOpenXml;
using System.IO;


namespace WASender
{
    public partial class GroupFinder : MaterialForm
    {
        WaSenderForm waSenderForm;
        private static int group_no = 0;
        private static int cntr = 0;
        private static bool IsRunning = false;
        private string Searchturm = "";


        private System.ComponentModel.BackgroundWorker backgroundWorker1;

        public GroupFinder(WaSenderForm _waSenderForm)
        {
            InitializeComponent();
            this.waSenderForm = _waSenderForm;
            group_no = 0;
            cntr = 0;
            IsRunning = false;
            Searchturm = "";

        }

        private void GroupFinder_Load(object sender, EventArgs e)
        {
            initLanguages();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
        }

        private void initLanguages()
        {
            this.Text = Strings.GroupFinder;
            materialTextBox21.Hint = Strings.GroupSubject;
            materialTextBox21.HelperText = Strings.GroupSubject;
            materialButton1.Text = Strings.Start;
            materialButton2.Text = Strings.Stop;
            materialButton3.Text = Strings.ImportInGroupJoiner;
            dataGridView1.Columns[0].HeaderText = Strings.GroupName;
            dataGridView1.Columns[1].HeaderText = Strings.GroupLink;
            materialButton4.Text = Strings.Export;
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            IsRunning = true;
            Searchturm = materialTextBox21.Text;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker helperBW = sender as BackgroundWorker;
            e.Result = BackgroundProcessLogicMethod(helperBW);
            if (helperBW.CancellationPending)
            {
                e.Cancel = true;
            }
        }



        private int BackgroundProcessLogicMethod(BackgroundWorker bw)
        {
            //int result = 0;
            //Thread.Sleep(20000);
            //MessageBox.Show("I was doing some work in the background.");
            while (IsRunning)
            {
                var client = new RestClient("https://groupsor.link/group/searchmore/" + Searchturm);
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Cookie", "ci_session=a%3A5%3A%7Bs%3A10%3A%22session_id%22%3Bs%3A32%3A%22f4acd9ae0adfb8dad9c3ff1164996c83%22%3Bs%3A10%3A%22ip_address%22%3Bs%3A13%3A%22172.71.198.72%22%3Bs%3A10%3A%22user_agent%22%3Bs%3A21%3A%22PostmanRuntime%2F7.29.2%22%3Bs%3A13%3A%22last_activity%22%3Bi%3A1665303876%3Bs%3A9%3A%22user_data%22%3Bs%3A0%3A%22%22%3B%7D93dfaa97a1fb55b8be313aea7aaf932b2625cf90");
                request.AlwaysMultipartFormData = true;
                request.AddParameter("group_no", group_no);
                IRestResponse response = client.Execute(request);
                string res = response.Content;
                //Console.WriteLine(response.Content);

                //HtmlDocument doc = new HtmlDocument(;
                HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();
                htmlDoc.LoadHtml(res);

                var ss = htmlDoc.DocumentNode.SelectNodes("//a[contains(@class, 'joinbtn')]");

                if (ss != null)
                {
                    foreach (var item in ss.ToList())
                    {
                        try
                        {
                            string ttl = item.Attributes["title"].Value;
                            ttl = ttl.Replace("Click here to join ", "").Replace(" Whatsapp group", "");
                            var link = item.Attributes["href"].Value;
                            var waLink = link.Split('/')[link.Split('/').Length - 1];
                            string fullLink = "https://chat.whatsapp.com/invite/" + waLink;

                            dataGridView1.Invoke(new Action(() =>
                            {
                                DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                                row.Cells[0].Value = ttl;
                                row.Cells[1].Value = fullLink;
                                dataGridView1.Rows.Add(row);
                            }));

                            cntr = cntr + 1;
                            label1.Invoke(new Action(() =>
                            {
                                label1.Text = cntr.ToString();
                            }));
                        }
                        catch (Exception ex)
                        {

                        }

                    }
                    group_no = group_no + 1;
                }
                else
                {
                    IsRunning = false;
                }


            }

            //{
            //    var title = item.SelectSingleNode("//span[contains(@style,'gtitle')]").ChildNodes[0].Attributes["alt"].Value;
            //    var link = item.SelectSingleNode("//a[contains(@class,'joinbtn')]").Attributes["href"].Value;
            //    var waLink = link.Split('/')[link.Split('/').Length-1];

            //    var ddd = item.SelectNodes("//span[contains(@style,'gtitle')]");

            //    string fullLink = "https://chat.whatsapp.com/invite/" + link;
            //}



            return 1;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled) MessageBox.Show("Operation was canceled");
            else if (e.Error != null) MessageBox.Show(e.Error.Message);
            else MessageBox.Show(e.Result.ToString());
        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            IsRunning = false;
        }

        private void materialButton3_Click(object sender, EventArgs e)
        {
            List<string> links = new List<string>();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                try
                {
                    links.Add(row.Cells[1].Value.ToString());
                }
                catch (Exception ex)
                {

                }
            }

            GroupsJoiner groupsJoiner = new GroupsJoiner(this.waSenderForm, links);
            this.Hide();
            groupsJoiner.ShowDialog();
            //groupsJoiner.ImportLinks(links);


        }

        private void GroupFinder_FormClosing(object sender, FormClosingEventArgs e)
        {
            waSenderForm.formReturn(true);
        }

        private void materialButton4_Click(object sender, EventArgs e)
        {
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            ExcelPackage excel = new ExcelPackage();
            var workSheet = excel.Workbook.Worksheets.Add("Sheet1");
            workSheet.Cells[1, 1].Value = Strings.GroupName;
            workSheet.Cells[1, 2].Value = Strings.Link;
            int recordIndex = 2;


            List<NVModel> links = new List<NVModel>();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                try
                {
                    links.Add(new NVModel
                    {
                        Name = row.Cells[0].Value.ToString(),
                        Value = row.Cells[1].Value.ToString()
                    });
                }
                catch (Exception ex)
                {

                }
            }
            foreach (var item in links)
            {
                workSheet.Cells[recordIndex, 1].Value = item.Name;
                workSheet.Cells[recordIndex, 2].Value = item.Value;
                recordIndex++;
            }
            workSheet.Column(1).AutoFit();
            workSheet.Column(2).AutoFit();

            String FolderPath = Config.GetTempFolderPath();
            String file = Path.Combine(FolderPath, materialTextBox21.Text + "_Group_Links" + Guid.NewGuid().ToString() + ".xlsx");
            string NewFileName = file.ToString();

            FileStream objFileStrm = File.Create(NewFileName);
            objFileStrm.Close();

            // Write content to excel file 
            File.WriteAllBytes(NewFileName, excel.GetAsByteArray());
            //Close Excel package
            excel.Dispose();
            // File.Copy(materialTextBox21.Text + "_Group_Links" +""+ ".xlsx", NewFileName);
            savesampleExceldialog.FileName = materialTextBox21.Text + "_Group_Links" + "" + ".xlsx";
            if (savesampleExceldialog.ShowDialog() == DialogResult.OK)
            {
                File.Copy(NewFileName, savesampleExceldialog.FileName.EndsWith(".xlsx") ? savesampleExceldialog.FileName : savesampleExceldialog.FileName + ".xlsx");
                Utils.showAlert(Strings.Filedownloadedsuccessfully, Alerts.Alert.enmType.Success);
            }

        }



    }

    class NVModel
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
