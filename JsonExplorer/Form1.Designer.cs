namespace JsonExplorer
{
	partial class JsonExplorer
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JsonExplorer));
			splitContainer1 = new SplitContainer();
			driePuntjes = new Button();
			wisPad = new Button();
			textBox1 = new TextBox();
			zoekOpPad = new Button();
			open = new Button();
			treeView1 = new TreeView();
			toolTip1 = new ToolTip(components);
			((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
			splitContainer1.Panel1.SuspendLayout();
			splitContainer1.Panel2.SuspendLayout();
			splitContainer1.SuspendLayout();
			SuspendLayout();
			// 
			// splitContainer1
			// 
			splitContainer1.Dock = DockStyle.Fill;
			splitContainer1.Location = new Point(0, 0);
			splitContainer1.Name = "splitContainer1";
			splitContainer1.Orientation = Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			splitContainer1.Panel1.Controls.Add(driePuntjes);
			splitContainer1.Panel1.Controls.Add(wisPad);
			splitContainer1.Panel1.Controls.Add(textBox1);
			splitContainer1.Panel1.Controls.Add(zoekOpPad);
			splitContainer1.Panel1.Controls.Add(open);
			// 
			// splitContainer1.Panel2
			// 
			splitContainer1.Panel2.Controls.Add(treeView1);
			splitContainer1.Size = new Size(355, 591);
			splitContainer1.SplitterDistance = 75;
			splitContainer1.TabIndex = 0;
			// 
			// driePuntjes
			// 
			driePuntjes.Location = new Point(306, 12);
			driePuntjes.Name = "driePuntjes";
			driePuntjes.Size = new Size(37, 23);
			driePuntjes.TabIndex = 5;
			driePuntjes.Text = ". . . ";
			toolTip1.SetToolTip(driePuntjes, "Open een nieuwe JsonExplorer");
			driePuntjes.UseVisualStyleBackColor = true;
			driePuntjes.Click += driePuntjes_Click;
			// 
			// wisPad
			// 
			wisPad.Location = new Point(208, 12);
			wisPad.Name = "wisPad";
			wisPad.Size = new Size(92, 23);
			wisPad.TabIndex = 4;
			wisPad.Text = "Wis pad";
			wisPad.UseVisualStyleBackColor = true;
			wisPad.Click += wisPad_Click;
			// 
			// textBox1
			// 
			textBox1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
			textBox1.Location = new Point(12, 43);
			textBox1.Multiline = true;
			textBox1.Name = "textBox1";
			textBox1.Size = new Size(331, 23);
			textBox1.TabIndex = 3;
			textBox1.KeyDown += textBox1_KeyDown;
			// 
			// zoekOpPad
			// 
			zoekOpPad.Location = new Point(110, 12);
			zoekOpPad.Name = "zoekOpPad";
			zoekOpPad.Size = new Size(92, 23);
			zoekOpPad.TabIndex = 2;
			zoekOpPad.Text = "Zoek op pad";
			toolTip1.SetToolTip(zoekOpPad, "Geef de verwijzing (pad) uit het script in het tekstveld in.");
			zoekOpPad.UseVisualStyleBackColor = true;
			zoekOpPad.Click += zoekOpPad_Click;
			// 
			// open
			// 
			open.Location = new Point(12, 12);
			open.Name = "open";
			open.Size = new Size(92, 23);
			open.TabIndex = 0;
			open.Text = "Open json";
			open.UseVisualStyleBackColor = true;
			open.Click += open_Click;
			// 
			// treeView1
			// 
			treeView1.BackColor = Color.WhiteSmoke;
			treeView1.BorderStyle = BorderStyle.FixedSingle;
			treeView1.Dock = DockStyle.Fill;
			treeView1.LabelEdit = true;
			treeView1.Location = new Point(0, 0);
			treeView1.Name = "treeView1";
			treeView1.Size = new Size(355, 512);
			treeView1.TabIndex = 0;
			treeView1.AfterSelect += treeView1_AfterSelect;
			treeView1.NodeMouseClick += treeView1_NodeMouseClick;
			// 
			// JsonExplorer
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(355, 591);
			Controls.Add(splitContainer1);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Name = "JsonExplorer";
			Text = "JsonExplorer - © Djools 2024";
			FormClosing += Form1_FormClosing;
			splitContainer1.Panel1.ResumeLayout(false);
			splitContainer1.Panel1.PerformLayout();
			splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
			splitContainer1.ResumeLayout(false);
			ResumeLayout(false);
		}

		#endregion

		private SplitContainer splitContainer1;
		private Button open;
		private TreeView treeView1;
		private Button zoekOpPad;
		private TextBox textBox1;
		private Button wisPad;
		private ToolTip toolTip1;
		private Button driePuntjes;
	}
}
