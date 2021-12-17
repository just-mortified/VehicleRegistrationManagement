// Version 1.0
// Vehicle Registration Management
// .Net form that uses a list of number plates. Can save and open plates in .txt files.

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace VehicleRegistrationManagement
{
    public partial class Vrm : Form
    {
        // default file prefix
        private static string defPre = "demo";
        // Byte that holds button (lock) values that are independant from the value of textbox.text 
        private byte state;
        // Q02 string List that holds each number plate
        private List<string> regoList = new List<string>();
        // holds filename prefix
        private string prefix = defPre;
        // holds counter for save files to be concatenated to the end of prefix
        // Unsigned as you cannot have negative file numbers
        private uint suffix;
        // Used to control whether a plate can be tagged or untagged
        private bool tagged = false;
        // Default file save path. Used when saving on exit
        private string defPath = 
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        public Vrm()
        {
            InitializeComponent();
            // Ensure buttons are correctly locked at start.
            lockButtons(0);
        }

        #region Buttons
        // Q04 Attempts to add value from textbox into list using addItem() method
        private void buttonEnter_Click(object sender, EventArgs e) { addItem(); }

        // Q05 Remove selected entry using removeEntry() method
        private void buttonDel_Click(object sender, EventArgs e) { removeEntry(); }

        // Q06 Attempts to change selected value to the value of textBox (checks if valid)
        private void buttonEdit_Click(object sender, EventArgs e)
        {
            BitArray vResult = verifyText();
            if (!vResult[1] && !vResult[2])
            {
                regoList[listBox.SelectedIndex] = textBox.Text;
                listBox.SelectedIndex = -1;
                display();
                statusLabel.Text = "Plate edited";
            }
            else
                statusLabel.Text = "Could not edit, invalid value";
        }

        // Q13 Adds 'tag' ('z' prefix) to selected item
        private void buttonTag_Click(object sender, EventArgs e)
        {
            string tempItem;
            string message = "";
            if (!tagged)
                tempItem = "z" + textBox.Text;
            else
            {
                tempItem = textBox.Text.Remove(0, 1);
                message = "un";
            }
            regoList[listBox.SelectedIndex] = tempItem;
            display();
            listBox.SelectedIndex = listBox.FindString(tempItem);
            statusLabel.Text = "Plate " + message + "tagged";
        }

        // Q10 Uses built-in BinarySearch method to find the index of textbox text in regoList. If found, selects.
        private void buttonBin_Click(object sender, EventArgs e)
        {
            // Built in list binary search method
            int tempResult = regoList.BinarySearch(textBox.Text);
            if (tempResult < 0)
                statusLabel.Text = "Could not find item";
            else
            {
                listBox.SelectedIndex = tempResult;
                statusLabel.Text = "found: [" + textBox.Text + "] at [" + tempResult + "]";
                textBox.Clear();
                textBox.Focus();
            }
        }

        // Q11 Uses for loop to cycle through items in regoList and compares values to textBox.text. If found, selects.
        private void buttonLin_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < regoList.Count; i++)
                if (textBox.Text == regoList[i])
                {
                    listBox.SelectedIndex = i;
                    statusLabel.Text = "Found: " + textBox.Text + " at: " + i;
                    textBox.Clear();
                    textBox.Focus();
                    return;
                }
            statusLabel.Text = "not found";
            textBox.Focus();
        }

        // Q07 Resets form values to default values. Confirms with user first. 
        private void buttonRst_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Reset all values in the list? (They will be gone forever)",
                "RESET?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                resetAll();
            }
            else
                statusLabel.Text = "Did not reset values";
        }

        // Q03 Opens fileOpeen dialog, user can choose to open text document. If document holds plates, they are added to regoList.
        private void buttonOpen_Click(object sender, EventArgs e)
        {

            bool silence = false;
            bool foundInfo = false;
            string[] fileInfo;
            string fileName;
            OpenFileDialog Openfile = new OpenFileDialog();
            DialogResult selectionResult = Openfile.ShowDialog();
            if (selectionResult == DialogResult.OK)
            {
                fileName = Openfile.FileName;
                //defName = Openfile.FileName;
                defPath = "";
                // Set the default path for save on exit
                for (int i = 0; i < fileName.Split("\\").Length - 1; i++)
                    defPath += fileName.Split("\\")[i] + "\\";
                try
                {
                    //!vrm|prefix|suffix
                    regoList.Clear();
                    // Stream reader
                    using (StreamReader S = File.OpenText(fileName))
                    {
                        string tempStr = "";
                        // Read each line of the stream, look for info line, verify before adding values
                        while ((tempStr = S.ReadLine()) != null)
                        {
                            if (tempStr.Length > 4 && tempStr.Substring(0, 4) == "!vrm" && !foundInfo)
                            {
                                try
                                {
                                    // get file info from info line
                                    fileInfo = tempStr.Split(" : ");
                                    prefix = fileInfo[1];
                                    suffix = uint.Parse(fileInfo[2]);
                                    foundInfo = true;
                                }
                                catch (Exception) { foundInfo = false; }
                            }
                            else
                            {
                                // Add tempStr to regolist
                                BitArray tempVerif = verifyText(tempStr);
                                if (!tempVerif[1] && !tempVerif[2] && !tempVerif[3])
                                    regoList.Add(tempStr.ToUpper());
                                // Check to see if user has disabled warnings
                                else if (!silence)
                                {
                                    DialogResult result = MessageBox.Show(tempStr + " is an invalid plate so it won't be added. " +
                                    "\nDo you want to be warned of other invalid plates?",
                                    "Invalid plate", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                    if (result == DialogResult.No)
                                        silence = true;
                                }
                            }
                        }
                    }
                    if (!foundInfo)
                    {
                        // Get prefix from file name
                        if (fileName.Split('\\')[^1].Split('_')[0].EndsWith(".txt"))
                            prefix = fileName.Split('\\')[^1].Split('\\')[0][0..^4];
                        else
                            prefix = fileName.Split('\\')[^1].Split('_')[0];
                        suffix = 0;
                    }

                    display();
                    state = 224;
                    lockButtons(0);
                    statusLabel.Text = "Opened file: " + fileName.Split("\\")[^2] + "\\" + fileName.Split("\\")[^1];
                }
                catch (IOException) { MessageBox.Show("Cannot open file"); }
            }
            else { statusLabel.Text = "did not open file"; }
        }

        // Q12 Opens fileSave dialog, user choses where to save file and plates are written to file.
        private void buttonSave_Click(object sender, EventArgs e)
        {
            string fileName;
            SaveFileDialog SaveFile = new SaveFileDialog();
            //Configure SaveFile diag for text files
            SaveFile.FileName = prefix + "_" + (suffix + 1).ToString("D2");
            SaveFile.DefaultExt = "txt";
            SaveFile.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            DialogResult selectionResult = SaveFile.ShowDialog();
            if (selectionResult == DialogResult.OK)
            {
                fileName = SaveFile.FileName;
                //!vrm|prefix|suffix

                // If user defined a different prefix in the filename, change it to that in the header.
                if (fileName.Split('\\')[^1].Split('_')[0] != prefix)
                    prefix = fileName.Split('\\')[^1].Split('_')[0];

                if (save(fileName)){
                    DialogResult result = MessageBox.Show("File has been saved. Close file? (stops editing file and resets)",
                                    "File Saved", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    statusLabel.Text = "Saved file: " + fileName.Split("\\")[^2] + "\\" + fileName.Split("\\")[^1];

                    if (result == DialogResult.Yes)
                    {
                        resetAll();
                        statusLabel.Text = "Closed file";
                    }
                    else statusLabel.Text = "Did not close file";
                }
            }
            else
                statusLabel.Text = "Did not save file";
        }
        #endregion

        #region Helpers

        // Locks buttons preventing user from causing errors
        private void lockButtons(byte t)
        {
            // Convert byte to array of bits
            // Save:128 | Open:!64 | Res:32 | B/lin:16 | unTag:!8 | Del + tag:4 | Edit:2 | Enter:1 
            BitArray bits = new BitArray(BitConverter.GetBytes((byte)(t + state)).ToArray());
            // Set button states from bits
            buttonEnter.Enabled = bits[0];
            buttonEdit.Enabled = bits[1];
            buttonDel.Enabled = bits[2];
            buttonTag.Enabled = bits[2];
            if (!bits[3] && bits[2])
            {
                buttonTag.Text = "Untag";
                tagged = true;
            }
            else
            {
                buttonTag.Text = "Tag";
                tagged = false;
            }
            buttonBin.Enabled = bits[4];
            buttonLin.Enabled = bits[4];
            buttonRst.Enabled = bits[5];
            buttonOpen.Enabled = !bits[6];
            buttonSave.Enabled = bits[7];

            //adding a tag 
        }

        // Q07 resets everything to default values
        private void resetAll()
        {
            regoList.Clear();
            display();
            statusLabel.Text = "Reset all plates";
            state = 0;
            lockButtons(0);
            prefix = defPre;
            suffix = 0;
            textBox.BackColor = System.Drawing.Color.White;
            defPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        }

        // Q04 Methods shared between methods that verify text input and file input
        // (Default to textBox.Text)
        private BitArray verifyText() { return verifyText(textBox.Text); }
        private BitArray verifyText(string term)
        {
            // Byte for counting # of digits and letters
            byte counter = 0;
            // BitArray for storing and returning results
            BitArray result = new BitArray(4);

            //Check for null or white space values
            if (string.IsNullOrWhiteSpace(term))
                result[1] = true;

            //No point doing other checks if there is no value
            if (!result[1])
            {
                //If text in textbox already is an item in list result[0] = true
                if (regoList.BinarySearch(textBox.Text) >= 0)
                    result[0] = true;

                //Count characters and numbers in term
                //(split the byte into half using each nibble to count separate values)
                //Its is unlikely for a number plate to have more than 15 digits so going into the next nibble is unlikely
                foreach (char c in term)
                {
                    if (char.IsDigit(c))
                        counter += 1;
                    else if (char.IsLetter(c))
                        counter += 16;
                }
                if ((counter & 15) < 2)
                    result[2] = true;
                if ((counter & 240) < 32)
                    result[2] = true;

                // If number plate is longer than ten characters
                if (term.Length > 10)
                    result[3] = true;
            }
            return result;
        }

        // Q09 Update listbox with sorted regoList Items, clear textbox and refocus.
        private void display()
        {
            regoList.Sort();
            textBox.Clear();
            textBox.Focus();
            listBox.Items.Clear();
            listBox.Items.AddRange(regoList.ToArray());
        }

        // Q04 Verify, add valid items. warn user of invalid items. Enable reset and save
        private void addItem()
        {
            BitArray vResult = verifyText();
            if (!vResult[0] && !vResult[1] && !vResult[2] && !vResult[3])
            {
                state |= 224;
                regoList.Add(textBox.Text);
                display();
                statusLabel.Text = "Plate added";
            }
            else
                statusLabel.Text = "Could not add entry: Invalid number plate";
        }

        // Q05 Removes entry. If entry is last entry, lock every button except open.
        private void removeEntry()
        {
            regoList.RemoveAt(listBox.SelectedIndex);
            listBox.SelectedIndex = -1;
            display();
            statusLabel.Text = "Plate deleted";
            if (regoList.Count == 0)
                state = 0;
            lockButtons(0);
        }

        // Q12 Save methods shared between save diag and on form exit
        private void save() { save(defPath); }
        private bool save(string name)
        {
            try
            {
                using (StreamWriter W = File.CreateText(name))
                {
                    // Write info line
                    W.WriteLine("!vrm" + " : " + prefix + " : " + (suffix + 1) + " : " + DateTime.Today.Date.ToShortDateString());
                    // Write plates 
                    foreach (string item in regoList)
                        W.WriteLine(item);
                }
            }
            catch (IOException) { MessageBox.Show("Could not save file"); return false; }
            // count up suffix
            suffix += 1;
            return true;
        }
        #endregion

        #region Events
        // Unlock and lock buttons depending on what's in the textbox and if item is selected
        private void textBox_TextChanged(object sender, EventArgs e)
        {
            BitArray vResult = verifyText();
            byte tempByte = 0;
            if (listBox.SelectedIndex != -1)
            {   // Selected in process of modifying, allow edit
                if (textBox.Text != listBox.SelectedItem.ToString())
                    tempByte = 18;
                // not tagged, selected, not modified
                else if (vResult[0] && listBox.SelectedItem.ToString()[0] != 'z')
                    tempByte = 12;
                // tagged, can be deleted not modified (tagged value exists)
                else if (vResult[0])
                    tempByte = 4;
            }
            else if (!vResult[1] && regoList.Count != 0)
            {
                // entries enable enter / bin /lin
                tempByte = 17;
                if (!vResult[1] && verifyText()[0])
                {
                    tempByte = 16;
                    statusLabel.Text = "item already exists";
                }
            }
            else if (!vResult[1])
                // no entries enable enter (add)
                tempByte = 1;
            lockButtons(tempByte);

            // If plate is tagged account for tag character by allowing an extra char
            if (!vResult[1] && tagged)
                textBox.MaxLength = 10;
            else
                textBox.MaxLength = 9;
        }

        // Q08 When selecting entry make sure correct buttons are shown (cannot tag if already tagged)
        // Place value into textbox and show message confirming selection and hint to user that item
        // is selected by changing textBox colour
        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox.SelectedIndex != -1)
            {
                if (listBox.SelectedItem.ToString()[0] != 'z')
                    lockButtons(12);
                else
                    lockButtons(4);
                textBox.Text = listBox.SelectedItem.ToString();
                statusLabel.Text = "Selected plate";
                textBox.BackColor = System.Drawing.Color.Lavender;
            }
            else { textBox.BackColor = System.Drawing.Color.White; }
        }

        // Deselects item when textbox is empty and backspace pressed. Allows entries to be added by pressing enter
        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (String.IsNullOrEmpty(textBox.Text) && e.KeyCode == Keys.Back && listBox.SelectedIndex != -1)
            {
                listBox.SelectedIndex = -1;
                lockButtons(0);
                statusLabel.Text = "Plate no longer selected.";
            }
            // If enter is pressed addItem value using addItem() method
            else if (buttonEnter.Enabled && e.KeyCode == Keys.Return)
                addItem();
        }

        // Q04 Controls what values can be entered into textbox. Autocapitalises letters
        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != ' ' && e.KeyChar != '-')
                e.Handled = true;
            if (char.IsLower(e.KeyChar))
                e.KeyChar = char.ToUpper(e.KeyChar);
        }

        // Q05 Allows item in listbox to be deleted by double clicking. Asks for confirmation
        private void listBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Clicks == 2 && listBox.SelectedIndex != -1)
            {
                DialogResult result = MessageBox.Show("Delete: " + listBox.SelectedItem.ToString(),
                    "Delete?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                    removeEntry();
                else
                    statusLabel.Text = "Did not delete value";
            }
        }

        // Q12 When form is closed, file is saved using default path, prefix and number
        private void Vrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if ((state & 128) == 128)
            {
                defPath += prefix + "_" + (suffix + 1).ToString("D2") + ".txt";
                save();
            }
        }
    }
    #endregion
}
// Q14 (see form designer)

// Issues
// able to tag, edit to 1 letter instead of 2 and untag
// able to create duplicates by tagging eg zTEST32 is considered to be different to TEST32
// able to paste invalid chars into textbox
// able to start or end number plate with space
// Tooltips don't show when buttons are disabled.
// By copying and pasting the tag 'z', it is possible to have a number plate with only 2 digits

