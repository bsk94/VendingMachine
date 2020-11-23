using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VendingMachine
{
    public partial class Form1 : Form
    {
        /// <summary>
        ///
        /// </summary>
        private int money;

        /// <summary>
        ///
        /// </summary>
        private List<int> totalMoney = new List<int>();

        private int sum;

        private int clickCounter = 0;

        private int remainder;

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonAny_Click(object sender, EventArgs e)
        {
            Button pressedButton = (Button)sender;
            clickCounter++;
            int btn = Convert.ToInt32(pressedButton.Tag);

            remainder = sum - btn;

            if (clickCounter == 1)
            {
                if (remainder < 0)
                {
                    textBoxDisplay.Text = $"Currently: {sum}{Environment.NewLine}Price: {pressedButton.Tag}zł{Environment.NewLine}Remaining: {remainder}zł";
                }
                else if (remainder == 0)
                {
                    textBoxDisplay.Text = "Currently: " + sum + Environment.NewLine + "Price: " + pressedButton.Tag + "zł";
                }
                else if (remainder > 0)
                {
                    textBoxDisplay.Text = "Currently: " + sum + Environment.NewLine + "Price: " + pressedButton.Tag + "zł";
                    textBoxChange.Text = remainder + "zł";
                }
            }
            else
            {
                textBoxDisplay.Text = "Currently: " + sum + Environment.NewLine + "Price: " + pressedButton.Tag + "zł" + Environment.NewLine + "Coffee was picked.";
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            money = int.Parse(textBoxInput.Text);

            totalMoney.Add(money);
            sum = totalMoney.Sum();

            textBoxDisplay.Text = "Currently: " + sum + "zł";
            textBoxInput.Clear();
        }
    }
}