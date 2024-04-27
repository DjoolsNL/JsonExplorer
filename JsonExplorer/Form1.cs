using System.Drawing.Text;
using System.Linq;
using System.Text.Json;
using System.Xml.Linq;

namespace JsonExplorer
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);
			folderPath = Directory.GetCurrentDirectory();
			label1.Text = "";
			map = new Dictionary<string, string>();
			map.Add("TestdataROB", "D:\\CarSys\\e2e\\cypress\\fixtures\\Testdata\\ROB\\ROB.json");
			map.Add("lang", "D:\\CarSys\\e2e\\cypress\\fixtures\\languages\\lang_en-GB.json");
		}

		string folderPath;
		Dictionary<string, string> map;

		private void TraverseJsonObject(JsonElement jsonElement, TreeNode? parentNode)
		{
			foreach (var property in jsonElement.EnumerateObject())
			{
				TreeNode newNode = new TreeNode(property.Name);

				if (parentNode == null)
				{
					treeView1.Nodes.Add(newNode);
				}
				else
				{
					parentNode.Nodes.Add(newNode);
				}

				if (property.Value.ValueKind == JsonValueKind.Object)
				{
					TraverseJsonObject(property.Value, newNode);
				}
				else if (property.Value.ValueKind == JsonValueKind.Array)
				{
					TraverseJsonArray(property.Value, newNode);
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

		private void TraverseJsonArray(JsonElement jsonArray, TreeNode? parentNode)
		{
			int index = 0;
			foreach (var element in jsonArray.EnumerateArray())
			{
				TreeNode newNode = new TreeNode($"[{index}]");

				if (parentNode == null)
				{
					treeView1.Nodes.Add(newNode);
				}
				else
				{
					parentNode.Nodes.Add(newNode);
				}

				if (element.ValueKind == JsonValueKind.Object)
				{
					TraverseJsonObject(element, newNode);
				}
				else if (element.ValueKind == JsonValueKind.Array)
				{
					TraverseJsonArray(element, newNode);
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

		private void button1_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Title = "Select a File";
			openFileDialog.Filter = "JSON Files (*.json)|*.json";

			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				treeView1.Nodes.Clear();
				string selectedFilePath = openFileDialog.FileName;
				int index = selectedFilePath.IndexOf("fixtures");
				if (index != -1)
				{
					label1.Text = selectedFilePath.Substring(index);
				}

				// laad, parse en verwerk 
				try
				{
					using (StreamReader reader = new StreamReader(selectedFilePath))
					{
						string jsonData = reader.ReadToEnd();
						JsonDocument jsonDocument = JsonDocument.Parse(jsonData);

						if (jsonDocument.RootElement.ValueKind == JsonValueKind.Object)
						{
							TraverseJsonObject(jsonDocument.RootElement, parentNode: null);
						}
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show($"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}

		}

		private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
		{
			if (e.Node != null)
			{
				Clipboard.SetText(e.Node.Text);
			}
		}

		//int tel = 2;
		private void Zoek(TreeNodeCollection nodes, string woord) 
		{
			int tel = 2;
			foreach (TreeNode node in treeView1.Nodes)
			{
				
					// Check if the node's text contains the search text
				if (node.Text.Contains(woord))
				{
					node.BackColor = System.Drawing.Color.Yellow; // Highlight the node
					node.EnsureVisible(); // Scroll to the node
					tel++;
					Zoek(node.Nodes, woord);
				}
				else
				{
					node.BackColor = treeView1.BackColor; // Reset the node's background color
				}

				

			}
		}

		private void HHHH(List<string> zoekwoorden) 
		{
			void JJJJJ(TreeNode treeNode) 
			{
				if (zoekwoorden.Count() > 0 && treeNode.Text == zoekwoorden[0])
				{
					treeNode.BackColor = System.Drawing.Color.Yellow; // Highlight the node
					treeNode.EnsureVisible(); // Scroll to the node
					treeNode.Expand();
					zoekwoorden.RemoveAt(0);

					foreach (TreeNode nodeL2 in treeNode.Nodes)
					{
						JJJJJ(nodeL2);
					}
				}
				else
				{

				}
			}

			int tel = zoekwoorden.Count();
			foreach (TreeNode nodeL1 in treeView1.Nodes)
			{
				JJJJJ(nodeL1);
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			treeView1.Nodes.Clear();

			string tbt = textBox1.Text.Replace("['", ".").Replace("']", "");

			string[] padNaarValue = tbt.Split('.');
			
			if (padNaarValue[0] == "this")
			{
				try
				{
					using (StreamReader reader = new StreamReader(map[padNaarValue[1]]))
					{
						string jsonData = reader.ReadToEnd();
						JsonDocument jsonDocument = JsonDocument.Parse(jsonData);

						if (jsonDocument.RootElement.ValueKind == JsonValueKind.Object)
						{
							TraverseJsonObject(jsonDocument.RootElement, parentNode: null);
						}
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show($"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}

				string[] padNaarValueIngekort = padNaarValue.Skip(2).ToArray();
				List<string> padElementen = padNaarValueIngekort.ToList();

				HHHH(padElementen);

				

		



			}
		}
	}
}