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

        private int remainder;

        List<Drink> drinks = new List<Drink>();


        public Form1()
        {
            InitializeComponent();
            //Parsing config file
            string[] lines = File.ReadAllLines("coffemachine_config.txt");
            foreach (string line in lines)
            {
                Drink currentDrink = new Drink(line);
                drinks.Add(currentDrink);
            }
            // Setting buttons
            button1.Text = drinks[0].ReturnAsButtonText();
            button2.Text = drinks[1].ReturnAsButtonText();
            button3.Text = drinks[2].ReturnAsButtonText();
            button4.Text = drinks[3].ReturnAsButtonText();
            button5.Text = drinks[4].ReturnAsButtonText();
            button6.Text = drinks[5].ReturnAsButtonText();

            button1.Tag = drinks[0].Price;
            button2.Tag = drinks[1].Price;
            button3.Tag = drinks[2].Price; 
            button4.Tag = drinks[3].Price;
            button5.Tag = drinks[4].Price;
            button6.Tag = drinks[5].Price;
        }

        private void buttonAny_Click(object sender, EventArgs e)
        {
            Button pressedButton = (Button)sender;

            int btn = Convert.ToInt32(pressedButton.Tag);

            remainder = sum - btn;

            if (remainder < 0)
            {
                textBoxDisplay.Text = $"Currently: {sum}{Environment.NewLine}Price: {pressedButton.Tag}zł{Environment.NewLine}Remaining: {remainder * -1}zł";
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

        private void button8_Click(object sender, EventArgs e)
        {
            money = int.Parse(textBoxInput.Text);

            totalMoney.Add(money);
            sum = totalMoney.Sum();

            textBoxDisplay.Text = "Currently: " + sum + "zł";
            textBoxInput.Clear();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBoxInput.Clear();
            textBoxDisplay.Clear();
            textBoxChange.Clear();
            this.Controls.Clear();
            this.InitializeComponent();
        }
    }
}