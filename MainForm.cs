/*
cvpn-gui
GUI frontend for szpp-dev-team/cvpn

(c) 2021 Sora Arakawa all rights reserved.
Licensed under the MIT License
*/

using System;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using System.Text;

namespace cvpn_gui
{

	public partial class MainForm : Form
	{
		string AppName = "cvpn-gui";
		string path = "/";

		public MainForm()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			dataGridView1.ColumnCount = 4;
			dataGridView1.Columns[0].HeaderText = "名前";
			dataGridView1.Columns[1].HeaderText = "種類";
			dataGridView1.Columns[2].HeaderText = "サイズ";
			dataGridView1.Columns[3].HeaderText = "更新日時";
			dataGridView1.Columns[0].Width = 300;
			dataGridView1.Columns[3].Width = 200;
			backButton.Enabled = false;
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
			Text = path + " の一覧を取得中...  - "+AppName;
			string output = VPNProcess("ls " + path);
			Text = path + " の一覧を取得しました。  - " + AppName;
			return output;
		}

		private void VPNDownload(string path)
		{
			Text = path + " をダウンロード中...  - " + AppName;
			VPNProcess("download " + path + " -o ./");
			Text = path + " をダウンロードしました。  - " + AppName;
		}
		
		private void AddList(string data)
		{
			dataGridView1.Enabled = false;
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
			if (path != "/")
			{
				backButton.Enabled = true;
			} else {
				backButton.Enabled = false;
			}
			dataGridView1.Enabled = true;
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

		private void backButton_Click(object sender, EventArgs e)
		{
			string[] splitPath = path.Split('/');
			path = "/";
			for (int i = 1; i < splitPath.Length-2; i++)
			{
				path = path + splitPath[i] + "/";
			}
			AddList(VPNGetList(path));
		}
	}
}
