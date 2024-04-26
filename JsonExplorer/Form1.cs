using System.Text.Json;

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
		}

		string folderPath;

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
						newNode.ForeColor = Color.Red;
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
						newNode.ForeColor = Color.Red;
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
	}
}