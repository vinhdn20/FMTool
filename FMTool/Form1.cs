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
            var fileName = textBox1.Text;
            FMDocument document = new FMDocument(fileName);
            var tag = document.FindTag(NameTagtxt.Text);
            Console.ReadLine();

        }
    }
}