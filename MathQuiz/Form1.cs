using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MathQuiz
{
    public partial class Form1 : Form
    {
        Random randomizer = new Random();
        int addend1;
        int addend2;

        int minus1;
        int minus2;

        int times1;
        int times2;

        int divide1;
        int divide2;

        int timeLeft;

        public Form1()
        {
            InitializeComponent();
            
        }

        public void StartQuiz()
        {
            sum.ForeColor = Color.Empty;
            difference.ForeColor = Color.Empty;
            product.ForeColor = Color.Empty;
            quotient.ForeColor = Color.Empty;

            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);
            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();
            sum.Value = 0;

            minus1 = randomizer.Next(1, 100);
            minus2 = randomizer.Next(1, minus1);
            minusLeftLabel.Text = minus1.ToString();
            minusRightLabel.Text = minus2.ToString();
            difference.Value = 0;

            times1 = randomizer.Next(2, 11);
            times2 = randomizer.Next(2, 11);
            timesLeftLabel.Text = times1.ToString();
            timesRightLabel.Text = times2.ToString();
            product.Value = 0;

            divide2 = randomizer.Next(2, 11);
            int tempQuotient = randomizer.Next(2, 11);
            divide1 = divide2 * tempQuotient;
            dividedLeftlabel.Text = divide1.ToString();
            dividedRightLabel.Text = divide2.ToString();
            quotient.Value = 0;

            timeLeft = 30;
            timeLabel.Text = timeLeft.ToString() + " seconds";
            myTimer.Start();
        }

        private bool CheckAnswers()
        {
            if((addend1 + addend2 == sum.Value)
                && (minus1 - minus2 == difference.Value)
                && (times1 * times2 == product.Value)
                && (divide1 / divide2 == quotient.Value))
                return true;
            else return false;
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void startButton_Click(object sender, EventArgs e)
        {
            StartQuiz();
            startButton.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void myTimer_Tick(object sender, EventArgs e)
        {
            if (timeLeft < 7 && myTimer.Enabled) { timeLabel.BackColor = Color.Red; }
            if (CheckAnswers())
            {
                myTimer.Stop();

                MessageBox.Show("You got all the asnwers right!",
                    "Congratulations!");
                startButton.Enabled = true;
                timeLabel.BackColor= Color.Empty;
            }
            else if (timeLeft > 0)
            { 
                timeLeft -= 1;
                if (timeLeft == 1) { timeLabel.Text = timeLeft + " second"; }
                else { timeLabel.Text = timeLeft + " seconds"; }
            
            }
            else
            {
                myTimer.Stop();
                bool sumAns = false;
                bool diffAns = false;
                bool timeAns = false;
                bool divAns = false;
                int numbCorrect = 0;

                if (sum.Value == addend1 + addend2) { sum.ForeColor = Color.Green; sumAns = true; numbCorrect += 1; }
                else { sum.ForeColor = Color.Red; }
                if (difference.Value == minus1 - minus2) { difference.ForeColor = Color.Green; diffAns = true; numbCorrect += 1; }
                else { difference.ForeColor = Color.Red; }
                if (product.Value == times1 * times2) { product.ForeColor = Color.Green; timeAns = true; numbCorrect += 1; }
                else { product.ForeColor = Color.Red; }
                if (quotient.Value == divide1 / divide2) { quotient.ForeColor = Color.Green; divAns = true; numbCorrect += 1; }
                else { quotient.ForeColor = Color.Red; }

                timeLabel.Text = "Time's up";
                MessageBox.Show($"You didn't finish in time.\nYou got {numbCorrect} of 4 correct.", "Sorry!");
                sum.Value = addend1 + addend2;
                if (!sumAns) { sum.ForeColor = Color.Yellow; }
                difference.Value = minus1 - minus2;
                if (!diffAns) { difference.ForeColor = Color.Yellow; }
                product.Value = times1 * times2;
                if (!timeAns) { product.ForeColor = Color.Yellow; }
                quotient.Value = divide1 / divide2;
                if (!divAns) { quotient.ForeColor = Color.Yellow; }
                startButton.Enabled = true;
                timeLabel.BackColor = Color.Empty;
            }
        }

        private void answer_Enter(object sender, EventArgs e)
        {
            NumericUpDown answerBox = sender as NumericUpDown;
            if (answerBox != null)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);
            }

        }



        private void checkGuess(object sender, EventArgs e)
        {
            NumericUpDown answer = sender as NumericUpDown;
            int sumAnswer = addend1 + addend2;
            int diffAnswer = minus1 - minus2;
            int producAnswer = times1 * times2;
            int quotientAnswer = divide1 / divide2;

            if (answer.Name == "sum" && answer.Value == sumAnswer) { SystemSounds.Hand.Play(); }
            if (answer.Name == "difference" && answer.Value == diffAnswer) { SystemSounds.Hand.Play(); }
            if (answer.Name == "product" && answer.Value == producAnswer) { SystemSounds.Hand.Play(); }
            if (answer.Name == "quotient" && answer.Value == quotientAnswer) { SystemSounds.Hand.Play(); }
        }
    }
}
