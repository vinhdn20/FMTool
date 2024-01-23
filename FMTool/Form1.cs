using BpoWinFormControlLib;
using System.Data.SqlTypes;
using System.Text;
using System.Xml;

namespace FMTool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            List<FMTag> document = new List<FMTag>();
            var fileName = textBox1.Text;
            using (var fileStream = File.OpenRead(fileName))
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true))
            {
                String line; StringBuilder sb = new StringBuilder();
                FMTag current = new FMTag();
                FMTag parent = null;
                bool isAppendChild = false;
                bool isHaveTag = false;
                while ((line = streamReader.ReadLine()) != null)
                {
                    line = line.TrimStart();
                    for (int i = 0; i < line.Length; i++)
                    {
                        if (line[i] == '#') break;
                        if (line[i] == '<')
                        {
                            sb = new StringBuilder();
                            current = new FMTag();
                            i++;
                            bool isWhiteSpace = false;
                            while (i != line.Length && line[i] != '>')
                            {
                                if (line[i] == '#') break;
                                if (line[i] == ' ' && !isWhiteSpace)
                                {
                                    isWhiteSpace= true;
                                    current.Tag = sb.ToString();
                                    sb.Clear();
                                    isHaveTag = true;
                                    i++;
                                    continue;
                                }
                                sb.Append(line[i]);
                                i++;
                            }

                        }
                        if (isHaveTag && current.Tag != null)
                        {
                            current.Attribute = sb.ToString();
                        }

                        if (isAppendChild && current.Tag != null && line[0] != '>')
                        {
                            parent.Child.Add(current);
                            current.Parent = parent;
                        }
                        if (i != line.Length && line[i] == '>')
                        {
                            if (parent == null)
                            {
                                isAppendChild = false;
                                document.Add(current);
                                break;
                            }
                            else
                            {
                                var temp = parent;
                                if (current.Tag == null) parent = parent.Parent;
                                if (parent == null)
                                {
                                    parent = new();
                                    document.Add(temp);
                                    isAppendChild = false;
                                }

                                if(parent.Parent == null && current.Tag != null)
                                {
                                    parent = new();
                                    document.Add(temp);
                                    isAppendChild = false;
                                }

                            }
                            current = new FMTag();
                            break;
                        }
                        else
                        {
                            isAppendChild = true;
                            parent = current;
                        }
                        isHaveTag = false;
                    }
                }
                Console.ReadLine();
            }
        }
    }
}