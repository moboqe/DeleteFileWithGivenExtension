using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DEleteFileWithGivenExtension
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string[] files = null;
        string folderName = null;

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialogresult = folderBrowserDialog1.ShowDialog();
            //Надпись выше окна контрола
            folderBrowserDialog1.Description = "Поиск папки";
            
            if (dialogresult == DialogResult.OK)
            {
                //Извлечение имени папки
                folderName = folderBrowserDialog1.SelectedPath;
            }
            textBox1.Text = folderName;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (files != null && files.Length != 0)
            {
                for (int i = 0; i < files.Length; i++)                 
                treeView1.Nodes.Add(files[i]);
            }
            else MessageBox.Show("Файлов нет", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (files != null && files.Length != 0)
            {
                for (int i = 0; i < files.Length; i++)
                    if (Path.GetExtension(files[i]) == "." + textBox2.Text)
                        File.Delete(files[i]);
            }
           else MessageBox.Show("Файлов нет","Ошибка!",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(folderName != null)
            files = Directory.GetFiles(folderName, @"*." + textBox2.Text, SearchOption.AllDirectories);
            else MessageBox.Show("Выберите папку", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            if (textBox2.Text=="")
                MessageBox.Show("Введите расширение файлов", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
