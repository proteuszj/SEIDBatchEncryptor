
using Common;
using Microsoft.Office.Interop.Excel;
using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace SEIDBatchEncryptor
{
    public partial class Form_Main : Form
    {
        public Form_Main()
        {
            InitializeComponent();

            string productName = ((AssemblyProductAttribute)Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false)[0]).Product;
            string version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            string fileVersion = ((AssemblyFileVersionAttribute)Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyFileVersionAttribute), false)[0]).Version;
            Text = $"{productName} v{version}";

            openFileDialog.InitialDirectory = System.Windows.Forms.Application.StartupPath;
        }

        private void button_Open_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == openFileDialog.ShowDialog())
                textBox_Input.Text = openFileDialog.FileName;
        }

        private void textBox_Input_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string fileName = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
                textBox_Input.Text = fileName;
            }
        }

        private void textBox_Input_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string fileName = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
                string ext = new FileInfo(fileName).Extension.ToUpper();
                if (ext == ".XLS" || ext == ".XLSX")
                    e.Effect = DragDropEffects.Copy;
            }
        }

        private void textBox_Input_TextChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.TextBox tb = sender as System.Windows.Forms.TextBox;
            button_Start.Enabled = !string.IsNullOrEmpty(tb.Text) && File.Exists(tb.Text);
            progressBar.Value = 0;
            label.Text = "";
        }

        private void button_Start_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Button button = sender as System.Windows.Forms.Button;
            button.Enabled = false;
            progressBar.Value = 0;
            label.Text = "请稍候。。。";

            Excel.Application application = new Excel.Application();
            try
            {
                string fileName = textBox_Input.Text;
                if (!checkBox_OverWrite.Checked)
                {
                    string newFileName = fileName.Insert(fileName.IndexOf(new FileInfo(fileName).Extension), "_output");

                    File.Copy(fileName, newFileName, true);
                    fileName = newFileName;
                }
                Workbook workbook = application.Workbooks.Open(fileName,//Filename
                   Type.Missing,//UpdateLinks
                   false,//ReadOnly
                   Type.Missing,//Format
                   Type.Missing,//Password
                   Type.Missing,//WriteResPassword
                   Type.Missing,//IgnoreReadOnlyRecommended
                   Type.Missing,//Origin
                   Type.Missing,//Delimiter
                   true,//Editable
                   Type.Missing,//Notify
                   Type.Missing,//Converter
                   false,//AddToMru
                   Type.Missing,//Local
                   Type.Missing);//CorruptLoad

                Worksheet workSheet = workbook.Worksheets[1];

                int count = workSheet.Rows.Count;
                int lineCount = Convert.ToInt32(workSheet.Cells[13, "H"].text);
                if (count > lineCount) count = lineCount;
                progressBar.Maximum = count;
                label.Text = "进行中。。。";
                Algorithm.SymmetricAlgorithms.SymmetricAlgorithm des = Algorithm.SymmetricAlgorithms.SymmetricAlgorithm.create("DES", new ByteArray("9551155995511559 9551155995511559", ByteArray.StringEncodingTypeEnum.HexByte).Data);
                workSheet.Cells[1, "d"] = "设备序列号密文";
                for (int i = 2; i <= count + 1; i++)
                {
                    string seid = workSheet.Cells[i, "b"].text;
                    des.encrypt(out byte[] buffer, (new ByteArray(seid, ByteArray.StringEncodingTypeEnum.ASCII) + new ByteArray("800000000000 0000000000000000", ByteArray.StringEncodingTypeEnum.HexByte)).Data);
                    workSheet.Cells[i, "d"] = new ByteArray(buffer).ToHexString();
                    progressBar.PerformStep();
                    if (0 == i % 10) System.Windows.Forms.Application.DoEvents();
                }

                workbook.Close(true);
                label.Text = "完成！";
                MessageBox.Show("完成", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "打开Excel文件失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                application.Quit();
                GC.Collect();
                button.Enabled = true;
            }

        }
    }
}
