﻿namespace JsonExplorer
{
	partial class Form1
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			splitContainer1 = new SplitContainer();
			button4 = new Button();
			button3 = new Button();
			textBox1 = new TextBox();
			button2 = new Button();
			button1 = new Button();
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
			splitContainer1.Panel1.Controls.Add(button4);
			splitContainer1.Panel1.Controls.Add(button3);
			splitContainer1.Panel1.Controls.Add(textBox1);
			splitContainer1.Panel1.Controls.Add(button2);
			splitContainer1.Panel1.Controls.Add(button1);
			// 
			// splitContainer1.Panel2
			// 
			splitContainer1.Panel2.Controls.Add(treeView1);
			splitContainer1.Size = new Size(355, 591);
			splitContainer1.SplitterDistance = 75;
			splitContainer1.TabIndex = 0;
			// 
			// button4
			// 
			button4.Location = new Point(306, 12);
			button4.Name = "button4";
			button4.Size = new Size(37, 23);
			button4.TabIndex = 5;
			button4.Text = ". . . ";
			toolTip1.SetToolTip(button4, "Open een nieuwe JsonExplorer");
			button4.UseVisualStyleBackColor = true;
			button4.Click += button4_Click;
			// 
			// button3
			// 
			button3.Location = new Point(208, 12);
			button3.Name = "button3";
			button3.Size = new Size(92, 23);
			button3.TabIndex = 4;
			button3.Text = "Wis pad";
			button3.UseVisualStyleBackColor = true;
			button3.Click += button3_Click;
			// 
			// textBox1
			// 
			textBox1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
			textBox1.Location = new Point(12, 43);
			textBox1.Multiline = true;
			textBox1.Name = "textBox1";
			textBox1.Size = new Size(331, 23);
			textBox1.TabIndex = 3;
			// 
			// button2
			// 
			button2.Location = new Point(110, 12);
			button2.Name = "button2";
			button2.Size = new Size(92, 23);
			button2.TabIndex = 2;
			button2.Text = "Zoek op pad";
			toolTip1.SetToolTip(button2, "Geef de verwijzing (pad) uit het script in het tekstveld in.");
			button2.UseVisualStyleBackColor = true;
			button2.Click += button2_Click;
			// 
			// button1
			// 
			button1.Location = new Point(12, 12);
			button1.Name = "button1";
			button1.Size = new Size(92, 23);
			button1.TabIndex = 0;
			button1.Text = "Open json";
			button1.UseVisualStyleBackColor = true;
			button1.Click += button1_Click;
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
			// Form1
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(355, 591);
			Controls.Add(splitContainer1);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Name = "Form1";
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
		private Button button1;
		private TreeView treeView1;
		private Button button2;
		private TextBox textBox1;
		private Button button3;
		private ToolTip toolTip1;
		private Button button4;
	}
}
