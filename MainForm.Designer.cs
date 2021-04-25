namespace cvpn_gui
{
	partial class MainForm
	{
		/// <summary>
		/// 必要なデザイナー変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows フォーム デザイナーで生成されたコード

		/// <summary>
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.toolStrip = new System.Windows.Forms.ToolStrip();
			this.backButton = new System.Windows.Forms.ToolStripButton();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.toolStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridView1.Location = new System.Drawing.Point(0, 25);
			this.dataGridView1.MultiSelect = false;
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.RowTemplate.Height = 21;
			this.dataGridView1.Size = new System.Drawing.Size(784, 416);
			this.dataGridView1.TabIndex = 0;
			this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
			// 
			// toolStrip
			// 
			this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backButton});
			this.toolStrip.Location = new System.Drawing.Point(0, 0);
			this.toolStrip.Name = "toolStrip";
			this.toolStrip.Size = new System.Drawing.Size(784, 25);
			this.toolStrip.TabIndex = 1;
			this.toolStrip.Text = "toolStrip1";
			// 
			// backButton
			// 
			this.backButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.backButton.Image = ((System.Drawing.Image)(resources.GetObject("backButton.Image")));
			this.backButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.backButton.Name = "backButton";
			this.backButton.Size = new System.Drawing.Size(23, 22);
			this.backButton.Text = "戻る";
			this.backButton.Click += new System.EventHandler(this.backButton_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(784, 441);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.toolStrip);
			this.Name = "Form1";
			this.Text = "cvpn-gui";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.Shown += new System.EventHandler(this.Form1_Shown);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.toolStrip.ResumeLayout(false);
			this.toolStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.ToolStrip toolStrip;
		private System.Windows.Forms.ToolStripButton backButton;
	}
}

