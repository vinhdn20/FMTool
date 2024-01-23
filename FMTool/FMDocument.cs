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

                            current.Tag = LoadTag(ref i, line);
                            (current.Attribute, current.IsDoneAttribute) = LoadAttribute(ref i, line);
                        }

                        if (i < line.Length && line[i] == '>')
                        {
                            current.IsDoneAttribute = true;
                            if (parent.Tag == null)
                            {
                                Tags.Add(current);
                            }
                            current = parent;
                            if (parent.Tag != null)
                                parent = parent.Parent;
                            break;
                        }

                        else if (current.Tag != null && !current.IsDoneAttribute)
                        {
                            string? addAttri;
                            (addAttri, current.IsDoneAttribute) = LoadAttribute(ref i, line);
                            current.Attribute += addAttri;
                        }
                    }
                }
            }
        }

        public FMTag? FindTag(string tagName, bool isChildren = false)
        {
            for (int i = 0; i < Tags.Count(); i++)
            {
                var tag = Tags[i];
                var rs = tag.FindTag(tagName);
                if(rs != null)
                {
                    return rs;
                }
            }
            return null;
        }


        private string LoadTag(ref int i, string line)
        {
            StringBuilder sb = new StringBuilder();
            while(i < line.Length && line[i + 1] != ' ' && line[i + 1] != '>')
            {
                i++;
                sb.Append(line[i]);
            }
            i++;
            return sb.ToString();
        }

        private (string?, bool) LoadAttribute(ref int i, string line)
        {
            if(i == line.Length)    return (null, false);
            StringBuilder sb = new StringBuilder();
            bool isDone = false;
            while(i < line.Length -1 && line[i+1] != '>')
            {
                i++;
                sb.Append(line[i]);
            }
            if(i < line.Length - 1 && line[i+1] == '>')
            {
                isDone = true;
            }
            i++;
            return (sb.ToString(), isDone);
        }
    }
}
