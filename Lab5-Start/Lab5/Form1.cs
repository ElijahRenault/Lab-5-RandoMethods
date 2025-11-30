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
            //call the function
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            //call the function

        }

        private void btnRollDice_Click(object sender, EventArgs e)
        {
            int dice1, dice2;
            //call ftn RollDice, placing returned number into integers

            //place integers into labels

            // call ftn GetName sending total and returning name

            //display name in label

        }


        /* Name: ClearStats
        *  Sent: nothing
        *  Return: nothing
        *  Reset nud to minimum value, chkbox unselected, 
        *  clear labels and listbox */


        /* Name: RollDice
        * Sent: nothing
        * Return: integer (1-6)
        * Simulates rolling one dice */


        /* Name: GetName
        * Sent: 1 integer (total of dice1 and dice2) 
        * Return: string (name associated with total) 
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

        private void btnSwapNumbers_Click(object sender, EventArgs e)
        {
            //call ftn DataPresent twice sending string returning boolean

            //if data present in both labels, call SwapData sending both strings

            //put data back into labels

            //if data not present in either label display error msg
        }

        /* Name: DataPresent
        * Sent: string
        * Return: bool (true if data, false if not) 
        * See if string is empty or not*/


        /* Name: SwapData
        * Sent: 2 strings
        * Return: none 
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
