using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scope_examples
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Block scope
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (true)
            {
                int x = 10;
            }
            //MessageBox.Show("var x is:"+x);

            int y = 10;
            if (true)
            {
                //int y = 10;
            }
            if (true)
            {
                int z = 10;
                z++;
            }
            else
            {
                int z = 11;
                z--;
            }

        }

        /// <summary>
        /// The for loop scope
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            string testStr = "";
            int i = 0;
            for ( i = 0; i < 10; i++)
            {
                testStr += "A";
            }
            MessageBox.Show(testStr + " i: " + i);
        }

        private int InsVar = 10;
        private static int classVar = 100;

        /// <summary>
        /// Class scope
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            int InsVar = 20;
            int classVar = 200;

            MessageBox.Show("insVar:" + InsVar);
            MessageBox.Show("classVar:" + classVar);
            InsVar++;
            classVar++;
            testFunc();
        }

        private void testFunc()
        {
            MessageBox.Show("test insVar:" + InsVar);
            MessageBox.Show("test classVar:" + classVar);
        }

        /// <summary>
        /// Function scope
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            string testStr = "my test string";
            MessageBox.Show(testStr);
        }

        /// <summary>
        /// pass by ref
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            int myNumber = 1;
            //MessageBox.Show("myNumber:" + myNumber);
            IncrementNo( myNumber);
            //MessageBox.Show("myNumber:" + myNumber);

            Car newCar = new Car();
            newCar.Year = 1990;
            MessageBox.Show($"Year: { newCar.Year }");

            PassByValue( newCar);

            MessageBox.Show($"Changed Year: {newCar.Year}");
        }

        private void PassByValue( Car newCar)
        {
            newCar = new Car();
            newCar.Year = 2000;
        }

        class Car
        {
            public int Year { get; set; }
        }

        private void IncrementNo(  int number)
        {
            number += 10;
        }



        /// <summary>
        /// The out keyword
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            int nOneinit;
            int nTwoinit;
            testOut( out nOneinit, out  nTwoinit);
            MessageBox.Show(nOneinit+"-"+nTwoinit);
        }

        private void testOut( out int nOne,  out int nTwo)
        {
            nOne = 10;
            nTwo = 20;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            testOptional(1,2, nFour:5);
        }

        private void testOptional(int nOne, int nTwo, int nThree = 3, int nFour = 4)
        {
            MessageBox.Show("nOne:" + nOne + " nTwo:" + nTwo + " nThree:" + nThree + " nFour:" + nFour);
        }

        /// <summary>
        /// Return good prog. practice
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button8_Click(object sender, EventArgs e)
        {
            MessageBox.Show("What is the return value:" + testReturn());
        }

        private int testReturn()
        {
            int returnVal = 0;
            int na = 10;
            if (na == 12)
            {
                returnVal = 10;
            }
            else if(na == 11) {
                returnVal = 12;
            }
            return returnVal;
        }

        /// <summary>
        /// The In keyword
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click_1(object sender, EventArgs e)
        {
            int answerToEverything = 42;

            UsingIn( in answerToEverything);

            MessageBox.Show(String.Format("The answer is {0}", answerToEverything));
        }

        private void UsingIn( in int paraAnswerToEverything)
        {
            //paraAnswerToEverything++;

            Console.WriteLine("answerToEverything is " + paraAnswerToEverything);
        }
    }
}
