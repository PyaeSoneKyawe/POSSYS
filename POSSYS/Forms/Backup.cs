
using MySql.Data.MySqlClient;
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

namespace POSSYS.Forms
{
    public partial class Backup : Form
    {
        Connect con = new Connect();
        public Backup()
        {
            InitializeComponent();
        }
        private void Backup_Load(object sender, EventArgs e)
        {
            txtfilename.Text = DateTime.Now.ToString("dd-MM-yyyy");
        }
        private Task ProcessData(List<string> list, IProgress<ProgressReport> progress)
        {
            int index = 1;
            int totalProcess = list.Count;
            var progressReport = new ProgressReport();
            return Task.Run(() =>
            {
                for (int i = 0; i < totalProcess; i++)
                {
                    progressReport.PercentComplete = index++ * 100 / totalProcess;
                    progress.Report(progressReport);
                    Thread.Sleep(10);
                }
            });
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string Location = @"C:\\";
                string path = System.IO.Path.Combine(Location, "backups");
                System.IO.Directory.CreateDirectory(path);
                string filename = txtfilename.Text;
                filename = DateTime.Now.ToString("dd-MM-yyyy");
                Console.WriteLine(filename);
                string file = "C:\\backups\\" + filename + ".sql";
                MySqlCommand cmd = new MySqlCommand();
                MySqlBackup mySqlBackup = new MySqlBackup(cmd);
                cmd.Connection = con.getConnetion();
                con.openConnection();
                mySqlBackup.ExportToFile(file);
                con.closeConnection();
                List<string> list = new List<string>();
                for (int i = 0; i < 1000; i++)
                    list.Add(i.ToString());
                lblStatus.Text = "Working...";
                var progress = new Progress<ProgressReport>();
                progress.ProgressChanged += (o, report) => {
                    lblStatus.Text=string.Format("Processing....{0}%", report.PercentComplete);
                    progressBar.Value = report.PercentComplete;
                    progressBar.Update();
                };
                await ProcessData(list, progress);
                lblStatus.Text = "Done !";
                MessageBox.Show("Backup Completed....! \nBackup File located at C:\\backup", "Backup", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
