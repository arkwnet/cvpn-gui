/*
cvpn-gui
GUI frontend for szpp-dev-team/cvpn

(c) 2021 Sora Arakawa all rights reserved.
*/

using System;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using System.Text;
using System.Xml;

namespace cvpn_gui
{

	public partial class Form1 : Form
	{
		string AppName = "cvpn-gui";
		string path = "/";

		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			this.Text = AppName;
			dataGridView1.ColumnCount = 4;
			dataGridView1.Columns[0].HeaderText = "名前";
			dataGridView1.Columns[1].HeaderText = "種類";
			dataGridView1.Columns[2].HeaderText = "サイズ";
			dataGridView1.Columns[3].HeaderText = "更新日時";
			dataGridView1.Columns[0].Width = 300;
			dataGridView1.Columns[3].Width = 200;
		}

		private void Form1_Shown(object sender, EventArgs e)
		{
			AddList(VPNGetList(path));
		}

		private string VPNProcess(string args)
		{
			string command = Directory.GetCurrentDirectory() + "\\cvpn.exe";
			ProcessStartInfo psInfo = new ProcessStartInfo();
			psInfo.FileName = command;
			psInfo.CreateNoWindow = true;
			psInfo.UseShellExecute = false;
			psInfo.RedirectStandardOutput = true;
			psInfo.Arguments = args;
			psInfo.StandardOutputEncoding = Encoding.UTF8;
			Process p = Process.Start(psInfo);
			string output = p.StandardOutput.ReadToEnd();
			output = output.Replace("\r\r\n", "\n");
			return output;
		}

		
		private string VPNGetList(string path)
		{
			this.Text = path + " の一覧を取得中...  - "+AppName;
			string output = VPNProcess("ls " + path);
			this.Text = AppName;
			return output;
		}

		private void VPNDownload(string path)
		{
			this.Text = path + " をダウンロード中...  - " + AppName;
			VPNProcess("download " + path + " -o ./");
			this.Text = AppName;
		}
		
		private void AddList(string data)
		{
			dataGridView1.Rows.Clear();
			StringReader rs = new StringReader(data);
			while (rs.Peek() > -1)
			{
				string[] arr = rs.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
				if (arr[0] == "-")
				{
					dataGridView1.Rows.Add(CreateFileName(arr, 7), "フォルダ", arr[0], arr[1] + " " + arr[2] + " " + arr[3] + " " + arr[4] + " " + arr[5]);
				} else if (arr[0] != "") {
					if (arr[0].Contains("[") == true)
					{
						dataGridView1.Rows.Add(CreateFileName(arr, 7), "ファイル", arr[0], arr[1] + " " + arr[2] + " " + arr[3] + " " + arr[4] + " " + arr[5]);
					} else {
						dataGridView1.Rows.Add(CreateFileName(arr, 8), "ファイル", arr[0] + arr[1], arr[2] + " " + arr[3] + " " + arr[4] + " " + arr[5] + " " + arr[6]);
					}
				}
				
			}
		}

		private string CreateFileName(string[] arr, int i)
		{
			string fn = "";
			while (i < arr.Length)
			{
				fn = fn + arr[i];
				i++;
				if (i < arr.Length)
				{
					fn = fn + " ";
				}
			}
			return fn;
		}

		private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (dataGridView1.CurrentRow.Cells[1].Value.Equals("フォルダ"))
			{
				path = path + dataGridView1.CurrentRow.Cells[0].Value + "/";
				AddList(VPNGetList(path));
				return;
			}
			if (dataGridView1.CurrentRow.Cells[1].Value.Equals("ファイル"))
			{
				VPNDownload(path + dataGridView1.CurrentRow.Cells[0].Value);
				return;
			}
		}
	}
}
