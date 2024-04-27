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
			foreach (TreeNode nodeL1 in treeView1.Nodes)
			{
				if (zoekwoorden.Count() > 0 && nodeL1.Text.Contains(zoekwoorden[0]))
				{
					nodeL1.BackColor = System.Drawing.Color.Yellow; // Highlight the node
					nodeL1.EnsureVisible(); // Scroll to the node

					foreach (TreeNode nodeL2 in nodeL1.Nodes)
					{
						if (zoekwoorden.Count() > 1 && nodeL2.Text.Contains(zoekwoorden[1]))						
						{
							nodeL2.BackColor = System.Drawing.Color.Yellow; // Highlight the node
							nodeL2.EnsureVisible(); // Scroll to the node

							foreach (TreeNode nodeL3 in nodeL2.Nodes)
							{
								if (zoekwoorden.Count() > 2 && nodeL3.Text.Contains(zoekwoorden[2]) )
								{
									nodeL3.BackColor = System.Drawing.Color.Yellow; // Highlight the node
									nodeL3.EnsureVisible(); // Scroll to the node
									nodeL3.Expand();

									foreach (TreeNode nodeL4 in nodeL3.Nodes)
									{
										if (zoekwoorden.Count() > 3 && nodeL4.Text.Contains(zoekwoorden[3]))
										{
											nodeL4.BackColor = System.Drawing.Color.Yellow; // Highlight the node
											nodeL4.EnsureVisible(); // Scroll to the node
											nodeL4.Expand();

											foreach (TreeNode nodeL5 in nodeL4.Nodes)
											{
												if (zoekwoorden.Count() > 4 && nodeL5.Text.Contains(zoekwoorden[4]))
												{
													nodeL5.BackColor = System.Drawing.Color.Yellow; // Highlight the node
													nodeL5.EnsureVisible(); // Scroll to the node
													nodeL5.Expand();

													foreach (TreeNode nodeL6 in nodeL5.Nodes)
													{
														if (zoekwoorden.Count() > 5 && nodeL6.Text.Contains(zoekwoorden[5]))
														{
															nodeL6.BackColor = System.Drawing.Color.Yellow; // Highlight the node
															nodeL6.EnsureVisible(); // Scroll to the node
															nodeL6.Expand();
														}
													}
												}
											}
										}
									}


								}
								else
								{
									
								}
							}

						}
						else
						{
							
						}
					}
				}
				else
				{
					
				}

				//Zoek(node.Nodes, zoekwaarde);

			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			string[] padNaarValue = textBox1.Text.Split('.');
			
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

				string[] zoekWoorden = padNaarValue.Skip(2).ToArray();
				List<string> padElementen = zoekWoorden.ToList();

				HHHH(padElementen);

				

		



			}
		}
	}
}