using System.Drawing;

namespace Lab5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /* Name: Elijah Renault
         * Date: November 29th, 2025
         * This program rolls one dice or calculates mark stats.
         * Link to your repo in GitHub: https://github.com/ElijahRenault/Lab-5-RandoMethods
         * */

        //class-level random object
        Random rand = new Random();

        //class-level name variable
        const string MYNAME = "Elijah Renault";

        private void Form1_Load(object sender, EventArgs e)
        {
            radOneRoll.Checked = true; //select one roll radiobutton

            this.Text += MYNAME; //add your name to end of form title

        } // end form load

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearOneRoll(); //this clears the One Roll groupbox of all values.
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearStats(); //this clears the Mark Stats groupbox of all values.

        }

        /* Name: ClearStats
        *  Sent: nothing
        *  Return: nothing
        *  Reset nud to minimum value, chkbox unselected, 
        *  clear labels and listbox */

        private void ClearStats()
        {
            nudNumber.Value = nudNumber.Minimum; //this resets the nud value to the minimum
            chkSeed.Checked = false; //this unchecks the checkbox for a seed value
            lstMarks.Items.Clear(); //this clears out the listbox
            lblPass.ResetText(); //this reverts the pass text to its original state, being blank
            lblFail.ResetText(); //this reverts the fail text to its original state, being blank
            lblAverage.ResetText(); //this reverts the average text to its original state, being blank
        }

        private void btnRollDice_Click(object sender, EventArgs e)
        {
            int dice1, dice2;

            RollDice(); //call method for RollDice, placing returned number into integers

            dice1 = RollDice(); //place value from RollDice to dice1
            dice2 = RollDice(); //place value from RollDice to dice2

            lblDice1.Text = dice1.ToString(); //place integer into Dice 1 label
            lblDice2.Text = dice2.ToString(); //place integer into Dice 1 label

            int total = dice1 + dice2; //gets the total for use in GetName

            string nameOutcome = GetName(total); // call the method GetName, sending total and returning name

            //(nameOutcome is just used to capture the returned value from GetName)

            lblRollName.Text = nameOutcome; //display name from GetName() in label

        }

        /* Name: GetName
        * Sent: 1 integer (total of dice1 and dice2) 
        * Returns: string (name associated with total) 
        * Finds the name of dice roll based on total.
        * Use a switch statement with one return only
        * Names: 2 = Snake Eyes
        *        3 = Litle Joe
        *        5 = Fever
        *        7 = Most Common
        *        9 = Center Field
        *        11 = Yo-leven
        *        12 = Boxcars
        * Anything else = No special name*/

        private string GetName(int total)
        {
            string name;
            switch (total)
            {
                case 2: name = "Snake Eyes"; break; //these place their respective values in lblRollName
                case 3: name = "Little Joe"; break;
                case 5: name = "Fever"; break;
                case 7: name = "Most Common"; break;
                case 9: name = "Center Field"; break;
                case 11: name = "Yo-leven"; break;
                case 12: name = "Boxcars"; break;
                default: name = "No special name"; break;
            }

            return name; //returns the name calculated
        }

        /* Name: RollDice
        * Sent: nothing
        * Returns: integer (1-6)
        * Simulates rolling one dice */

        private int RollDice()
        {
            Random rand = new Random(); //creates our new random
            return rand.Next(1, 7); //this goes from a range of 1 - 6, since it's always n - 1 in these
        }

        private void btnSwapNumbers_Click(object sender, EventArgs e)
        {

            //call the method DataPresent twice sending string returning boolean
            DataPresent(lblDice1.Text); //checking for dice1 value
            DataPresent(lblDice2.Text); //checking for dice2 value

            if (DataPresent(lblDice1.Text) && DataPresent(lblDice2.Text))
            {
                //if data present in both labels, call SwapData sending both strings

                string dice1 = lblDice1.Text; //create the strings preemptively
                string dice2 = lblDice2.Text;

                SwapData(ref dice1, ref dice2); //call the SwapData method to swap the places of numbers

                //put data back into labels
                lblDice1.Text = dice1; //assigns the swapped dice1 value to the label
                lblDice2.Text = dice2; //assigns the swapped dice2 value to the label
            }
            else
            {
                //if data not present in either label display error msg
                MessageBox.Show("Roll the dice", "Data Missing"); //the error message
            }
        }

        /* Name: SwapData
        * Sent: 2 strings
        * Returns: none 
        * Swaps the memory locations of two strings*/

        private void SwapData(ref string dice1, ref string dice2)
        {
            string tempPlace; //temporary string so we can swap values
            tempPlace = dice1;
            dice1 = dice2; //dice1's value is swapped with dice2
            dice2 = tempPlace; //dice2's value is swapped with tempPlace, which contains the value of dice1
        }

        /* Name: DataPresent
        * Sent: string
        * Returns: bool (true if data, false if not) 
        * See if string is empty or not*/

        private bool DataPresent(string input)
        {
            return !string.IsNullOrEmpty(input); //if the value is not null, it will return true
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            //declare variables and array
            int failNum = 0, passNum = 0; //for the fail and pass mark
            int SIZE = (int) nudNumber.Value; //the max size of the array is now the same max as the NumberUpDown
            int index = 0; //this will be incremented for each new entry in the entry label
            double[] markList = new double[SIZE]; //the array itself

            if (chkSeed.Checked) //check if seed value
            {
                rand = new Random(1000); //assign seed value to 1000
            }

            lstMarks.Items.Clear(); //clears the listbox

            int i = 0; //fill array using random number

            while (i < markList.Length) //the while loop
            {
                markList[i] = rand.Next(40, 101); //we put 101 since these always go n - 1
                lstMarks.Items.Add(markList[i]); //adds the marks to the listbox
                i++; //increments the index
            }

            CalcStats(markList, ref failNum, ref passNum); //call CalcStats sending and returning data

            lblFail.Text = failNum.ToString(); //display data sent back in labels - average, pass and fail
            lblPass.Text = passNum.ToString();

            lblAverage.Text = CalcStats(markList, ref failNum, ref passNum).ToString();

            //the 2 decimal places are adressed in the CalcStats() method

        } // end Generate click


        /* Name: CalcStats
        * Sent: array and 2 integers
        * Return: average (double) 
        * Run a foreach loop through the array.
        * Passmark is 60%
        * Calculate average and count how many marks pass and fail
        * The pass and fail values must also get returned for display*/

        private double CalcStats(double[] markList, ref int failNum, ref int passNum)
        {
            double sum = 0; //this will be divided by the length of the array to get the average

            foreach (int mark in markList) //the foreach loop

            {
                sum += mark; //adds the mark to the sum

                if (mark >= 60) //pass value
                {
                    passNum++; //passNum is incremented since the grade was a pass
                }
                else  //fail value
                {
                    failNum++; //the failNum is incremented since the value was below 60
                }
            }
            return Math.Round(sum / markList.Length, 2); //this creates the average, and stops at two decimal places
        }

        private void radOneRoll_CheckedChanged(object sender, EventArgs e)
        {
            grpOneRoll.Show();
            grpMarkStats.Hide(); //this will hide the Mark Stats groupbox.
            ClearOneRoll();//this clears the One Roll groupbox of all values.
        }

        /* Method Name: ClearOneRoll
        *  Sent: nothing
        *  Returns: nothing
        *  Clears the labels within the One Roll groupbox. */
        private void ClearOneRoll()
        {
            lblDice1.Text = ""; //clears the label for the first dice.
            lblDice2.Text = ""; //clears the label for the second dice.
            lblRollName.Text = ""; //clears the Roll Name label.
        }

        private void radRollStats_CheckedChanged(object sender, EventArgs e)
        {
            grpMarkStats.Show();
            grpOneRoll.Hide();
            ClearStats();
        }

        private void chkSeed_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSeed.Checked)
            {
                DialogResult selection = MessageBox.Show("Are you sure you want a seed value?", "Confirm Seed Value", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                switch (selection) //this switch will check which dialogue button was selected in the messagebox.
                {
                    case DialogResult.Yes: chkSeed.Checked = true; break;

                    case DialogResult.No: chkSeed.Checked = false; break;
                }
            }
        }



    }
}
