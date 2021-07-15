using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vector
{
    public partial class Form1 : Form
    {
        private Vector a;//Два вектора для 
        private Vector b;
       
        private double q;//переменные для вычислений 
        private double w;
        private int count;//для запоминания производимой операции

        private Vector res1;//вектора для вычислений
        private Vector res2;
        private bool res1f = false;
            
        public Form1()
        {
            InitializeComponent();
            a = new Vector(0, 0, 0);
            b = new Vector(0, 0, 0);
            res2 = new Vector(0, 0, 0);
        }
        /*
         Ввести класс векторов, содержащий как поля координаты и как методы 
          --действия над векторами. Вычислить |b|/(b,c)x[b,c]
             */

        private void define()
        {
            a.x = double.Parse(textBox2.Text);
            a.y = double.Parse(textBox3.Text);
            a.z = double.Parse(textBox4.Text);
            b.x = double.Parse(textBox5.Text);
            b.y = double.Parse(textBox6.Text);
            b.z = double.Parse(textBox7.Text);
        }

    

        private void button1_Click(object sender, EventArgs e)
        {
           
            define(); 
            textBox1.Text= textBox1.Text + a.modul().ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            define();
            textBox1.Text = textBox1.Text + b.modul().ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            define();
            textBox1.Text = textBox1.Text + a.scalar_product(a,b).ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //проверить знак
            define();
            textBox1.Text = textBox1.Text +a.scalar_product(a, b).ToString();
            // textBox1.Text = textBox1.Text + a.vector_product(a, b).ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            define();
            res1 = a.vector_product(a, b);
            
            textBox1.Text = textBox1.Text + "(" + res1.x + "," + res1.y + "," + res1.z + ")";

        }

        private void button10_Click(object sender, EventArgs e)
        {
            define();
            res1 = a.vector_product(b, a);
            textBox1.Text = textBox1.Text + "(" + res1.x + "," + res1.y + "," + res1.z + ")";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            define();
            res1 = b;
            textBox1.Text = textBox1.Text+"(" + b.x + "," + b.y + "," + b.z + ")";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                q = double.Parse(textBox1.Text);
                textBox1.Clear();
                count = 1;
                label6.Text = q.ToString() + "+";
            }
            catch
            {
                res1f = true;
                textBox1.Clear();
                label6.Text = "(" + res1.x + "," + res1.y + "," + res1.z + ")+";
            }
        

        }

        private void button8_Click(object sender, EventArgs e)
        {
        
            try
            {
                q = double.Parse(textBox1.Text);
                textBox1.Clear();
                count = 4;
                label6.Text = q.ToString() + "/";
            }
            catch
            {
                res1f = true;
                textBox1.Clear();
                label6.Text = "(" + res1.x + "," + res1.y + "," + res1.z + ")/";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            /* q = double.Parse(textBox1.Text);
             textBox1.Clear();
             count = 2;
             label6.Text = q.ToString() + "-";*/

            try
            {
                q = double.Parse(textBox1.Text);
                textBox1.Clear();
                count = 2;
                label6.Text = q.ToString() + "-";
            }
            catch
            {
                res1f = true;
                textBox1.Clear();
                label6.Text = "(" + res1.x + "," + res1.y + "," + res1.z + ")-";
            }

        }

        private void button12_Click(object sender, EventArgs e)
        {
            /*  q = double.Parse(textBox1.Text);
              textBox1.Clear();
              count = 3;
              label6.Text = q.ToString() + "*";
              */

            try
            {
                q = double.Parse(textBox1.Text);
                textBox1.Clear();
                count = 3;
                label6.Text = q.ToString() + "*";
            }
            catch
            {
                res1f = true;
                textBox1.Clear();
                label6.Text = "(" + res1.x + "," + res1.y + "," + res1.z + ")*";
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {

            calculate();
            
        }
        private void Parse(string s)//если умножаем на вектор.опработать строку и внести значения в переменную для вычислений res2
        {
            int i = 1;
            int l = -1;
            int start=1;
            string res="";
            bool yes = false;
           while (s[i] != ')')
            {
                if (s[i] == ',')
                {
                    for(int k = start; k < i; k++)
                    {
                        res=res+""+s[k]+"";
                    }
                    start = i + 1;
                    l++;
                    yes = true;
                }
                if(l==0 && yes)
                res2.x = double.Parse(res);
                if (l == 1 && yes)
                    res2.y = double.Parse(res);
                if (l == 2 && yes)
                    res2.z = double.Parse(res);
                res = "";
                yes = false;
                i++;
            }

        }

        private void calculate() //основная функция
        {
            switch (count)
            {
                case 1:
                    try
                    {
                        w = q + float.Parse(textBox1.Text);
                        textBox1.Text = w.ToString();
                    }
                    catch
                    {

                    }
                    break;
                case 2:
                    w = q - float.Parse(textBox1.Text);
                    textBox1.Text = w.ToString();
                    break;
              
                case 3://умножение

                    try
                    {
                        w = q * double.Parse(textBox1.Text);
                        label6.Text = label6.Text +double.Parse(textBox1.Text);
                        textBox1.Text = w.ToString();
                       
                    }
                    catch
                    {
                        Parse(textBox1.Text);
                        label6.Text = label6.Text +res2.Vec()+"=";
                        res2.produce(res2, q);
                        textBox1.Text = "(" + res2.x + "," + res2.y + "," + res2.z + ")";
                    }
                    break;

                case 4:
                    w = q / float.Parse(textBox1.Text);
                    label6.Text = label6.Text + double.Parse(textBox1.Text)+"=";
                    textBox1.Text = w.ToString();
                    break;

                default:
                    break;
            }
        }
    }
}
