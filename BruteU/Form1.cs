using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;

namespace BruteU
{
    public partial class bruteWindow : Form
    {
        private static string[] hexVal = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "a", "b", "c", "d", "e", "f" }; //All possible HEX values to use
        private static byte[] userSHA1; //User defined SHA1 to compare to
        private string tempKey; //For storing our key variations
        private string infoText; //For storing info given to the user
        private bool foundKey = false; //To stop our recursive function from continuing on once we've found our key
        private bool working = false; //To easily determine what things can happen based on if the brute forcing thread is running
        private SHA1 sha1 = SHA1.Create(); //Import SHA1 functions to generate SHA-1 hashes of our tempKeys

        public bruteWindow()
        {
            InitializeComponent();
        }

//Begin the bruteforcing when the user clicks Start
        private void startBrute_Click(object sender, EventArgs e)
        {
            if(startBrute.Text == "Stop") //If the Start button is currently configured as 'Stop', we should stop the operations instead.
            {
                working = false; //Set working to false, so the conditional in our recursive brute forcing function triggers to stop itself
                startBrute.Enabled = false; //disable this button until we're sure the backgroundWorker is done
                while (backgroundWorker1.CancellationPending){} //Don't continue until the backgroundWorker is done
                labelKey.Text = ""; //Clear previous value
                labelInfo.Text = "Brute forcing halted."; //We don't need to show any text here if we stopped
                startBrute.Enabled = true; //Re-enable our button now that we know it's safe to Start it again
                startBrute.Text = "Start"; //Change the text back to start
            }
            else if (hashInput.Text.Length != 40) //Check to make sure user inputted SHA-1 hash is equal to 40, the proper length of a SHA-1.
            {
                labelInfo.Text = "Your SHA - 1 hash is not 40 characters long";
            }
            else
            {
                userSHA1 = Enumerable.Range(0, hashInput.Text.Length / 2).Select(x => Convert.ToByte(hashInput.Text.Substring(x * 2, 2), 16)).ToArray(); //Convert the user defined SHA-1 from a String to a Byte array so we can utilize it properly
                foundKey = false; //Make sure this variable is set to false to not stop our program prematurely if it had already been ran once.
                startBrute.Text = "Stop";
                labelKey.Text = ""; 
                labelInfo.Text = "Brute forcing..."; //Let the user know what's happening
                working = true;
                save2bin.Enabled = false; //Make sure save2bin is disabled if another brute force operation is executed
                backgroundWorker1.RunWorkerAsync(); //Start our work on a separate thread for better performance. This will trigger the 'backgroundWorker1_DoWork()' method below.
            }
        }
//Work to do
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            _BruteKey( (int)byteLength.Value, "", keyInput.Text.ToLower(), hashInput.Text.ToLower()); //Call our method that has all the work we want to do.
        }
//Communicates between the threads and triggers RunWorkerCompleted() when Progress reaches 100
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
        }
//When our main work has completed or been stopped, these operations will be called
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            backgroundWorker1.CancelAsync(); //Kill off our thread to make sure it's dead
            backgroundWorker1.Dispose(); //Dispose of any garbage
            startBrute.Text = "Start"; //Since our backgroundWorker is done, change our Start button back from Stop.
            if(foundKey)
            {
                save2bin.Enabled = true; //Enable the save2bin button so the user can save the key to a file
            }
            else
            {
                infoText = "No match found!";
                UpdateInfoLabel();
            }
        }

//Method that does all the brute forcing
        private void _BruteKey(int bytes, string combo, string key, string hash)
        {
            tempKey = key + combo; //Store the current generated key

            if (_SHA1Comp(tempKey)) //Calculate the hash of the currently generated key and compare it to the user provided hash. Or exit out if working has become untrue.
            {
                UpdateKeyLabel();
                infoText = "Match found!";
                UpdateInfoLabel();
                working = false; 
                foundKey = true;
                backgroundWorker1.ReportProgress(100, "Done!"); //Report our progress as 100 to trigger the RunWorkerCompleted() method.
            }

            else if (combo.Length == bytes) //If the combination is the same length as extra bytes we're missing, continue
            {
                tempKey = key + combo;

                if (!fastMode.Checked) //If Fast Mode isn't checked, we update the label with each generated key to make things interesting
                {
                    UpdateKeyLabel();
                }
                return;
            }

            for (int i = 0; i < hexVal.Length; i++) //For each possible HEX value, we need to do this operation
            {
                if (foundKey || !working)
                {
                    backgroundWorker1.ReportProgress(100, "Done!");
                    break;
                }
                string t = combo;
                t += hexVal[i];
                _BruteKey(bytes, t, key, hash);
            }
        }

        private bool _SHA1Comp(string s)
        {
            byte[] bytes = Enumerable.Range(0, s.Length / 2).Select(x => Convert.ToByte(s.Substring(x * 2, 2), 16)).ToArray(); //Convert our HEX String to Bytes so we can work with it properly
            byte[] hashBytes = sha1.ComputeHash(bytes); //Compute the SHA-1 of those Bytes

            for (int i = 0; i < hashBytes.Length; i++)
            {
                if (userSHA1[i] != hashBytes[i]) //Compare each Byte in both hashes, if there is a single mismatch, return false
                {
                    return false;
                }
            }
            return true;
        }

        private void UpdateKeyLabel()
        {
            //Switch threads if cross-thread call would happen
            if (InvokeRequired)
            {
                MethodInvoker method = new MethodInvoker(UpdateKeyLabel);
                Invoke(method);
                return;
            }
            labelKey.Text = tempKey;
        }

        private void UpdateInfoLabel()
        {
            //Switch threads if cross-thread call would happen
            if (InvokeRequired)
            {
                MethodInvoker method = new MethodInvoker(UpdateInfoLabel);
                Invoke(method);
                return;
            }
            labelInfo.Text = infoText;
        }

        private void save2bin_Click(object sender, EventArgs e)
        {
            byte[] keyBytes = Enumerable.Range(0, tempKey.Length / 2).Select(x => Convert.ToByte(tempKey.Substring(x * 2, 2), 16)).ToArray(); //Convert our found key to bytes so we can save it properly
            string filename = "key"; 

            using (SaveFileDialog saveFileDialog1 = new SaveFileDialog())
            {
                saveFileDialog1.FileName = filename;
                saveFileDialog1.Filter = "Binary File | *.bin"; //Sets the default file type we want
                if (DialogResult.OK != saveFileDialog1.ShowDialog()) //Bring up a save dialogue to choose where to save
                    return;
                File.WriteAllBytes(saveFileDialog1.FileName,keyBytes); //Write all the bytes of our key to that location
            }
        }
    }
}
