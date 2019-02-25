using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YahtzeeGame
{
    public partial class Yahtzee : Form
    {
        public Yahtzee()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        
        public void spin_Click(object sender, EventArgs e)
        {            
            Random random = new Random();
            int one;
            int two;
            int three;
            int four;
            int five;
            if (oneButon.BackColor == Color.Blue)
            {
                one = random.Next(1, 7);
            }
            else
            {
                one=Convert.ToInt32(oneButon.Text);
            }
            if (twoButon.BackColor == Color.Blue)
            {
                two = random.Next(1, 7);
            }
            else
            {
                two = Convert.ToInt32(twoButon.Text);
            }
            if (threeButon.BackColor == Color.Blue)
            {
                three = random.Next(1, 7);
            }
            else
            {
                three = Convert.ToInt32(threeButon.Text);
            }
            if (fourButon.BackColor == Color.Blue)
            {
                four = random.Next(1, 7);
            }
            else
            {
               four = Convert.ToInt32(fourButon.Text);
            }
            if (fiveButon.BackColor == Color.Blue)
            {
               five = random.Next(1, 7);
            }
            else
            {
                five = Convert.ToInt32(fiveButon.Text);
            }
            oneButon.Text = Convert.ToString(one);
            twoButon.Text = Convert.ToString(two);
            threeButon.Text = Convert.ToString(three);
            fourButon.Text = Convert.ToString(four);
            fiveButon.Text = Convert.ToString(five);           

            Console.WriteLine("You get DICES: " + one + " " + two + " " + three + " " + four + " " + five + " !");
            int[] all = new int[5];
            all[0] = one;
            all[1] = two;
            all[2] = three;
            all[3] = four;
            all[4] = five;
            int sum = one + two + three + four + five;
            //find all kind dices sum
            int ones = FindKindSum(1, all);
            button1.Text = Convert.ToString(ones);
            int twos = FindKindSum(2, all);
            button2.Text = Convert.ToString(twos*2);
            int threes = FindKindSum(3, all);
            button3.Text = Convert.ToString(threes * 3);
            int fours = FindKindSum(4, all);
            button4.Text = Convert.ToString(fours * 4);
            int fives = FindKindSum(5, all);
            button5.Text = Convert.ToString(fives * 5);
            int sixes = FindKindSum(6, all);
            button6.Text = Convert.ToString(sixes * 6);

            int pointOne = Convert.ToInt32(onesText.Text);
            int pointTwo = Convert.ToInt32(twosText.Text);
            int pointThree = Convert.ToInt32(thresText.Text);
            int pointFour = Convert.ToInt32(foursText.Text);
            int pointFive = Convert.ToInt32(fivesText.Text);
            int pointSix = Convert.ToInt32(sixsesText.Text);
            int pointsSum = pointOne + pointTwo + pointThree + pointFour + pointFive + pointSix;
            dicePoints.Text = Convert.ToString(pointsSum);
            int bonusBox = 0;
            if (pointsSum>=63)
            {
                BonusBox.Text = "35";
                bonusBox = 35;
            }
            //Find Match in sorted arry 
            Array.Sort(all);
            Console.WriteLine("You have sorted dices: ");
            foreach (int sorted in all) Console.Write(sorted + "");
            Console.WriteLine();
            //Three Of A Kind
            int threeKind = 0;
            int fourKind = 0;
            if (ones >= 3 || twos >= 3 || threes >= 3 || fours >= 3 || fives >= 3 || sixes >= 3)
            {
                button7.Text= Convert.ToString(threeKind = sum);
            }
            else
            {
                button7.Text = Convert.ToString(0);
            }
            if (ones >= 4 || twos >= 4 || threes >= 3 || fours >= 4 || fives >= 4 || sixes >= 4)
            {
                button8.Text = Convert.ToString(fourKind = sum);
            }
            else
            {
                button8.Text = Convert.ToString(0);
            }
            //FullHouse
            if (ones == 3 || twos == 3 || threes == 3 || fours == 3 || fives == 3 || sixes == 3)
            {
                if (ones == 2 || twos == 2 || threes == 2 || fours == 2 || fives == 2 || sixes == 2)
                {
                    button9.Text = Convert.ToString(25);
                }                
            }
            else
            {
                button9.Text = Convert.ToString(0);
            }
            //Small Straight
            int index1 = Array.Find(all, item => item == 1);
            int index2 = Array.Find(all, item => item == 2);
            int index3 = Array.Find(all, item => item == 3);
            int index4 = Array.Find(all, item => item == 4);
            int index5 = Array.Find(all, item => item == 5);
            int index6 = Array.Find(all, item => item == 6);
            if (index1 == 1 && index2 == 2 && index3 == 3 && index4 == 4 || index2 == 2 && index3 == 3 && index4 == 4 && index5 == 5 ||
                index3 == 3 && index4 == 4 && index5 == 5 && index6 == 6)
            {
                button10.Text= Convert.ToString(20);
            }
            else
            {
                button10.Text = Convert.ToString(0);
            }
            //Big Straight
            if (index1 == 1 && index2 == 2 && index3 == 3 && index4 == 4 && index5 == 5 || index2 == 2 && index3 == 3
                && index4 == 4 && index5 == 5 && index6 == 6)
            {
                button11.Text = Convert.ToString(30);
            }
            else
            {
                button11.Text = Convert.ToString(0);
            }
            //Yahtzee
            if (ones == 5 || twos == 5 || threes == 5 || fours == 5 || fives == 5 || sixes == 5)
            {
                button12.Text= Convert.ToString(50);
            }
            else
            {
                button12.Text = Convert.ToString(0);
            }
            //Sum of your spin points (Chance)

            button13.Text = Convert.ToString(sum);
            //All Points you have
            int point7 = Convert.ToInt32(threeKindbox.Text);
            int point8 = Convert.ToInt32(fourKindbox.Text);
            int point9 = Convert.ToInt32(fullHouse.Text);
            int point10 = Convert.ToInt32(smalStraight.Text);
            int point11 = Convert.ToInt32(bigStraight.Text);
            int point12 = Convert.ToInt32(yahtzeeText.Text);
            int point13 = Convert.ToInt32(chance.Text);

            int AllPoints = pointsSum + bonusBox+ point7+ point8+ point9+ point10+ point11+ point12+ point13;
            AllPointsSum.Text= Convert.ToString(AllPoints);

        }
        public static int FindKindSum(int check, int[] list)
        {
            int dice = 0;
            int dice1 = 0;
            int dice2 = 0;
            int dice3 = 0;
            int dice4 = 0;
            int dices;
            if (check == list[0])
            {
                dice = 1;
            }
            else
            {
                dice = 0;
            }
            if (check == list[1])
            {
                dice1 = 1;
            }
            else
            {
                dice1 = 0;
            }
            if (check == list[2])
            {
                dice2 = 1;
            }
            else
            {
                dice2 = 0;
            }
            if (check == list[3])
            {
                dice3 = 1;
            }
            else
            {
                dice3 = 0;
            }
            if (check == list[4])
            {
                dice4 = 1;
            }
            else
            {
                dice4 = 0;
            }
            return dices = dice + dice1 + dice2 + dice3 + dice4;
        }

        private void oneButon_Click(object sender, EventArgs e)
        {
            oneButon.BackColor = Color.Aqua;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            onesText.Text = button1.Text;
            button1.BackColor = Color.YellowGreen;
            oneButon.BackColor = Color.Blue;
            twoButon.BackColor = Color.Blue;
            threeButon.BackColor = Color.Blue;
            fourButon.BackColor = Color.Blue;
            fiveButon.BackColor = Color.Blue;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            twosText.Text = button2.Text;
            button2.BackColor = Color.YellowGreen;
            oneButon.BackColor = Color.Blue;
            twoButon.BackColor = Color.Blue;
            threeButon.BackColor = Color.Blue;
            fourButon.BackColor = Color.Blue;
            fiveButon.BackColor = Color.Blue;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            thresText.Text = button3.Text;
            button3.BackColor = Color.YellowGreen;
            oneButon.BackColor = Color.Blue;
            twoButon.BackColor = Color.Blue;
            threeButon.BackColor = Color.Blue;
            fourButon.BackColor = Color.Blue;
            fiveButon.BackColor = Color.Blue;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            foursText.Text = button4.Text;
            button4.BackColor = Color.YellowGreen;
            oneButon.BackColor = Color.Blue;
            twoButon.BackColor = Color.Blue;
            threeButon.BackColor = Color.Blue;
            fourButon.BackColor = Color.Blue;
            fiveButon.BackColor = Color.Blue;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            fivesText.Text = button5.Text;
            button5.BackColor = Color.YellowGreen;
            oneButon.BackColor = Color.Blue;
            twoButon.BackColor = Color.Blue;
            threeButon.BackColor = Color.Blue;
            fourButon.BackColor = Color.Blue;
            fiveButon.BackColor = Color.Blue;
        }

        public void button6_Click(object sender, EventArgs e)
        {
            sixsesText.Text = button6.Text;
            button6.BackColor = Color.YellowGreen;
            oneButon.BackColor = Color.Blue;
            twoButon.BackColor = Color.Blue;
            threeButon.BackColor = Color.Blue;
            fourButon.BackColor = Color.Blue;
            fiveButon.BackColor = Color.Blue;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            threeKindbox.Text = button7.Text;
            button7.BackColor = Color.YellowGreen;
            oneButon.BackColor = Color.Blue;
            twoButon.BackColor = Color.Blue;
            threeButon.BackColor = Color.Blue;
            fourButon.BackColor = Color.Blue;
            fiveButon.BackColor = Color.Blue;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            fourKindbox.Text = button8.Text;
            button8.BackColor = Color.YellowGreen;
            oneButon.BackColor = Color.Blue;
            twoButon.BackColor = Color.Blue;
            threeButon.BackColor = Color.Blue;
            fourButon.BackColor = Color.Blue;
            fiveButon.BackColor = Color.Blue;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            fullHouse.Text = button9.Text;
            button9.BackColor = Color.YellowGreen;
            oneButon.BackColor = Color.Blue;
            twoButon.BackColor = Color.Blue;
            threeButon.BackColor = Color.Blue;
            fourButon.BackColor = Color.Blue;
            fiveButon.BackColor = Color.Blue;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            smalStraight.Text = button10.Text;
            button10.BackColor = Color.YellowGreen;
            oneButon.BackColor = Color.Blue;
            twoButon.BackColor = Color.Blue;
            threeButon.BackColor = Color.Blue;
            fourButon.BackColor = Color.Blue;
            fiveButon.BackColor = Color.Blue;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            bigStraight.Text = button11.Text;
            button11.BackColor = Color.YellowGreen;
            oneButon.BackColor = Color.Blue;
            twoButon.BackColor = Color.Blue;
            threeButon.BackColor = Color.Blue;
            fourButon.BackColor = Color.Blue;
            fiveButon.BackColor = Color.Blue;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            yahtzeeText.Text = button12.Text;
            button12.BackColor = Color.YellowGreen;
            oneButon.BackColor = Color.Blue;
            twoButon.BackColor = Color.Blue;
            threeButon.BackColor = Color.Blue;
            fourButon.BackColor = Color.Blue;
            fiveButon.BackColor = Color.Blue;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            chance.Text = button13.Text;
            button13.BackColor = Color.YellowGreen;
            oneButon.BackColor = Color.Blue;
            twoButon.BackColor = Color.Blue;
            threeButon.BackColor = Color.Blue;
            fourButon.BackColor = Color.Blue;
            fiveButon.BackColor = Color.Blue;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void twoButon_Click(object sender, EventArgs e)
        {
            twoButon.BackColor = Color.Aqua;
        }

        private void threeButon_Click(object sender, EventArgs e)
        {
            threeButon.BackColor = Color.Aqua;
        }

        private void fourButon_Click(object sender, EventArgs e)
        {
            fourButon.BackColor = Color.Aqua;
        }

        private void fiveButon_Click(object sender, EventArgs e)
        {
            fiveButon.BackColor = Color.Aqua;
        }
    }
}
