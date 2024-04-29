using System.Drawing.Text;
using System.Linq;
using System.Text.Json;
using System.Xml.Linq;

namespace JsonExplorer
{
	public partial class Form1 : Form
	{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
		public Form1()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
		{
			InitializeComponent();
			Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);
			folderPath = Directory.GetCurrentDirectory();

			// Dictionary met cypress aliasen en filepaden naar fixture files 
			map = new Dictionary<string, string>();
			string jsonString = File.ReadAllText(folderPath + "\\Paden.json");
			map = JsonSerializer.Deserialize<Dictionary<string, string>>(jsonString);

			treeView1.PathSeparator = ".";
		}

		string folderPath;
		string fileName;
		Dictionary<string, string> map;

		// events
		private void button1_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Title = "Select a File";
			openFileDialog.Filter = "JSON Files (*.json)|*.json";

			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				fileName = openFileDialog.FileName;
				treeView1.Nodes.Clear();
				string selectedFilePath = openFileDialog.FileName;
				int index = selectedFilePath.IndexOf("fixtures");
				if (index != -1)
				{
					textBox1.Text = selectedFilePath.Substring(index);
				}

				// laad, parse en verwerk 
				Helpers.VerwerkJson(treeView1, selectedFilePath);
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			treeView1.Nodes.Clear();

			string tbt = textBox1.Text.Replace("['", ".").Replace("']", "");

			string[] padNaarValue = tbt.Split('.');

			if (padNaarValue[0] == "this")
			{
				fileName = map[padNaarValue[1]];
				Helpers.VerwerkJson(treeView1, map[padNaarValue[1]]);

				string[] padNaarValueIngekort = padNaarValue.Skip(2).ToArray();
				List<string> padElementen = padNaarValueIngekort.ToList();

				Helpers.HaalWaardeUitJson(padElementen, treeView1);
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			textBox1.Clear();
		}

		private void button4_Click(object sender, EventArgs e)
		{
			// puntjes button ...
			Form2 form2 = new Form2();
			form2.Show();
		}

		private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
		{
			if (e.Node != null)
			{
				Clipboard.SetText(e.Node.Text);
			}
		}

		private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			var mapSwitched = map.ToDictionary(x => x.Value, x => x.Key);
			string k;
			if (mapSwitched.ContainsKey(fileName))
			{
				k = mapSwitched[fileName];
				textBox1.Text = $"this.{k}.{e.Node.FullPath}";
			}
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			Properties.Settings.Default.Save();
		}

		// dit werkt niet. hoe het pad in textBox dat geselecteerd is in clipboard krijgen?
		//private void textBox1_MouseLeave(object sender, EventArgs e)
		//{
		//	if (textBox1.SelectedText != null)
		//	{
		//		Clipboard.SetText(textBox1.Text);
		//	} 
		//}
	}

	public class Form2 : Form1
	{
		public Form2()
		{
			Load += Form2_Load;
		}

		private void Form2_Load(object sender, EventArgs e)
		{
			this.Size = new System.Drawing.Size(555, 555);
		}
	}

	static class Helpers
	{
		public static void VerwerkJsonObject(TreeView treeView, JsonElement jsonElement, TreeNode? parentNode)
		{
			foreach (var property in jsonElement.EnumerateObject())
			{
				TreeNode newNode = new TreeNode(property.Name);

				if (parentNode == null)
				{
					treeView.Nodes.Add(newNode);
				}
				else
				{
					parentNode.Nodes.Add(newNode);
				}

				if (property.Value.ValueKind == JsonValueKind.Object)
				{
					VerwerkJsonObject(treeView, property.Value, newNode);
				}
				else if (property.Value.ValueKind == JsonValueKind.Array)
				{
					VerwerkJsonArray(treeView, property.Value, newNode);
				}
				else
				{
					newNode.Nodes.Add(property.Value.ToString());
					if (property.Value.ToString() == "")
					{
						newNode.ForeColor = Color.Gray;
					}
					else
					{
						newNode.ForeColor = Color.Blue;
					}
				}
			}
		}

		public static void VerwerkJsonArray(TreeView treeView, JsonElement jsonArray, TreeNode? parentNode)
		{
			int index = 0;
			foreach (var element in jsonArray.EnumerateArray())
			{
				TreeNode newNode = new TreeNode($"[{index}]");

				if (parentNode == null)
				{
					treeView.Nodes.Add(newNode);
				}
				else
				{
					parentNode.Nodes.Add(newNode);
				}

				if (element.ValueKind == JsonValueKind.Object)
				{
					VerwerkJsonObject(treeView, element, newNode);
				}
				else if (element.ValueKind == JsonValueKind.Array)
				{
					VerwerkJsonArray(treeView, element, newNode);
				}
				else
				{
					newNode.Nodes.Add(element.ToString());

					if (element.ToString() == "")
					{
						newNode.ForeColor = Color.Gray;
					}
					else
					{
						newNode.ForeColor = Color.Blue;
					}
				}

				index++;
			}
		}

		public static void VerwerkJson(TreeView treeView, string filePad)
		{
			try
			{
				using (StreamReader reader = new StreamReader(filePad))
				{
					string jsonData = reader.ReadToEnd();
					JsonDocument jsonDocument = JsonDocument.Parse(jsonData);

					if (jsonDocument.RootElement.ValueKind == JsonValueKind.Object)
					{
						Helpers.VerwerkJsonObject(treeView, jsonDocument.RootElement, parentNode: null);
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		public static void HaalWaardeUitJson(List<string> padelementen, TreeView treeView)
		{
			void Recursief(TreeNode treeNode) 
			{
				if (padelementen.Count() > 0 && treeNode.Text == padelementen[0])
				{
					treeNode.NodeFont = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Strikeout, GraphicsUnit.Point, 0);
					//treeNode.BackColor = System.Drawing.Color.Yellow; // Highlight the node
					treeNode.EnsureVisible(); // Scroll to the node
					treeNode.Expand();
					padelementen.RemoveAt(0);

					foreach (TreeNode node in treeNode.Nodes)
					{
						Recursief(node);
					}
					Properties.Settings.Default.MaxMonthlyUse = 0;
					Properties.Settings.Default.Save();
				}
			}

			int tel = padelementen.Count();
			foreach (TreeNode node in treeView.Nodes)
			{
				if (Properties.Settings.Default.MaxMonthlyUse == 25)
				{
					string tekstBoodschap = "Sorry, je kunt maar 25 keer per maand van deze functie gebruikmaken";
					MessageBox.Show(tekstBoodschap, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					break;
				}
				Recursief(node);
			}
		}
	}
}