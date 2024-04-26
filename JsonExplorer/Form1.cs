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
					// If parentNode is null, this is the root node
					treeView1.Nodes.Add(newNode);
				}
				else
				{
					// Otherwise, add the node to the parent node
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
				}
			}
		}

		private void TraverseJsonArray(JsonElement jsonArray, TreeNode parentNode)
		{
			int index = 0;
			foreach (var element in jsonArray.EnumerateArray())
			{
				TreeNode newNode = new TreeNode($"[{index}]");

				if (parentNode == null)
				{
					// If parentNode is null, this is the root node
					treeView1.Nodes.Add(newNode);
				}
				else
				{
					// Otherwise, add the node to the parent node
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
					newNode.ForeColor = Color.Red;
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

				// laad en parse de json
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
					MessageBox.Show($"Oeps: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}

		}
	}
}