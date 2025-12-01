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

            lblRollName.Text = nameOutcome; //display name in label

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
                case 2: name = "Snake Eyes"; break;
                case 3: name = "Little Joe"; break;
                case 5: name = "Fever"; break;
                case 7: name = "Most Common"; break;
                case 9: name = "Center Field"; break;
                case 11: name = "Yo-leven"; break;
                case 12: name = "Boxcars"; break;
                default: name = "No special name"; break;
            }

            return name;
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
            //call ftn DataPresent twice sending string returning boolean

            //if data present in both labels, call SwapData sending both strings

            //put data back into labels

            //if data not present in either label display error msg
        }

        /* Name: DataPresent
        * Sent: string
        * Returns: bool (true if data, false if not) 
        * See if string is empty or not*/


        /* Name: SwapData
        * Sent: 2 strings
        * Returns: none 
        * Swaps the memory locations of two strings*/

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            //declare variables and array

            //check if seed value

            //fill array using random number

            //call CalcStats sending and returning data

            //display data sent back in labels - average, pass and fail
            // Format average always showing 2 decimal places 

        } // end Generate click

        private void radOneRoll_CheckedChanged(object sender, EventArgs e)
        {
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

        /* Name: CalcStats
        * Sent: array and 2 integers
        * Return: average (double) 
        * Run a foreach loop through the array.
        * Passmark is 60%
        * Calculate average and count how many marks pass and fail
        * The pass and fail values must also get returned for display*/
    }
}
