using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMTool
{
    internal class FMDocument
    {
        public List<FMTag> Tags = new List<FMTag>();

        public FMDocument(string filePath)
        {
            LoadFile(filePath);
        }

        public void LoadFile(string filePath)
        {
            Tags.Clear();
            using (var fileStream = File.OpenRead(filePath))
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true))
            {
                String line; StringBuilder sb = new StringBuilder();
                FMTag parent = new FMTag();
                FMTag current = new FMTag();

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
                            parent = current;
                            current = new FMTag();
                            parent.Child.Add(current);
                            current.Parent = parent;

                            current.Tag = LoadTag(i, line);
                            current.Attribute = LoadAttribute(i, line);

                            if (line[i] == '>')
                            {
                                current = parent;
                                parent = parent.Parent;
                            }
                        }

                        if (line[i] == '>')
                        {
                            current = parent;
                            parent = parent.Parent;
                        }
                    }
                }
            }
        }

        private string LoadTag(int i, string line)
        {
            StringBuilder sb = new StringBuilder();
            while(i < line.Length && line[i] != ' ' && line[i] != '>')
            {
                i++;
                sb.Append(line[i]);
            }
            return sb.ToString();
        }

        private string? LoadAttribute(int i, string line)
        {
            if(i == line.Length)    return null;
            StringBuilder sb = new StringBuilder();
            while(i < line.Length && line[i] != '>')
            {
                i++;
                sb.Append(line[i]);
            }
            return sb.ToString();
        }
    }
}
