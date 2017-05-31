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

namespace Coding
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
            
        }
        Encoding ascii = Encoding.ASCII;
        public List<byte> code;
        public byte[] textCode;
        List<byte> binnary;
        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox2.Clear();
            richTextBox3.Clear();
            code = new List<byte>();
            code = stringToAscii();

            string[] arrayStr=new string[code.Count];
            for (int i = 0; i < code.Count; i++)
            {
               arrayStr[i] = makebinnary(code[i]);
            }
            richTextBox2.Lines = arrayStr;
            code.Clear();
            code = binnaryToAscii(arrayStr).ToList();
      
            richTextBox3.Text = asciiToString();
            
           
        }
        public List<byte> asciiToBinary() {
            this.binnary = new List<byte>();
            int[] array = new int[code.Count];
            int i=0;
            foreach (byte b in code) { 
                array[i]=(int)b;
                i++;
            } 
          
            return binnary;

        }

        public List<byte> stringToAscii() {
            

                    string text = richTextBox1.Text;
                   this.code = ascii.GetBytes(text).ToList();
                 
                  
                
                  
                   return code;
         }

        public string asciiToString() {
            int index = 0;
            while (index < code.Count - 1)
            {
                if (code[index] == code[index + 1])
                    code.RemoveAt(index);
                else
                    index++;
            }
                  
            string encodedString = "";
            foreach(byte b in code ){
                
                    encodedString += (char)b;
                
            }
            encodedString = encodedString.TrimStart();
            encodedString = encodedString.TrimEnd();
           
           
            ForbiddenWords fbW = new ForbiddenWords();
            
             encodedString=fbW.cenzor(encodedString);
            
            return encodedString;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            richTextBox2.Clear();
            richTextBox3.Clear();
            code = null;
            
        }
        private byte[] binnaryToAscii(string[] strArray) {
            byte[] asciiCode = new byte[strArray.Count()];
            int i=0;
            foreach (string st in strArray) {
                asciiCode[i] = Convert.ToByte( st.Substring(1, 8),2);
                i++;
            }
            return asciiCode;
        }
        private string makebinnary(int num) {

           string bin= Convert.ToString(num, 2).PadLeft(9, '0') + "11";
            return bin;
        }

    }
}
