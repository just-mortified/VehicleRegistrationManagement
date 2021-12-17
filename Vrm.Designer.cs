
namespace VehicleRegistrationManagement
{
    partial class Vrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Vrm));
            this.listBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox = new System.Windows.Forms.TextBox();
            this.buttonEnter = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonDel = new System.Windows.Forms.Button();
            this.buttonTag = new System.Windows.Forms.Button();
            this.buttonBin = new System.Windows.Forms.Button();
            this.buttonLin = new System.Windows.Forms.Button();
            this.buttonRst = new System.Windows.Forms.Button();
            this.buttonOpen = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox
            // 
            this.listBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox.BackColor = System.Drawing.SystemColors.Window;
            this.listBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.listBox.FormattingEnabled = true;
            this.listBox.HorizontalScrollbar = true;
            this.listBox.ItemHeight = 20;
            this.listBox.Location = new System.Drawing.Point(140, 26);
            this.listBox.Margin = new System.Windows.Forms.Padding(4);
            this.listBox.MultiColumn = true;
            this.listBox.Name = "listBox";
            this.listBox.ScrollAlwaysVisible = true;
            this.listBox.Size = new System.Drawing.Size(110, 442);
            this.listBox.TabIndex = 3;
            this.toolTip1.SetToolTip(this.listBox, "Plates\r\n-Shows list of plates\r\n-Clicking on plates selects them\r\n-Deselect by pre" +
        "ssing backspace on empty Plate Details\r\n-Double click plate to delete it");
            this.listBox.SelectedIndexChanged += new System.EventHandler(this.listBox_SelectedIndexChanged);
            this.listBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listBox_MouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(137, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Plates:";
            this.toolTip1.SetToolTip(this.label1, "Plates\r\n-Shows list of plates\r\n-Clicking on plates selects them\r\n-Deselect by pre" +
        "ssing backspace on empty Plate Details\r\n-Double click plate to delete it\r\n");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(10, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Plate Details:";
            this.toolTip1.SetToolTip(this.label2, resources.GetString("label2.ToolTip"));
            // 
            // textBox
            // 
            this.textBox.BackColor = System.Drawing.Color.White;
            this.textBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox.Location = new System.Drawing.Point(13, 26);
            this.textBox.Margin = new System.Windows.Forms.Padding(4);
            this.textBox.MaxLength = 9;
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(119, 26);
            this.textBox.TabIndex = 1;
            this.toolTip1.SetToolTip(this.textBox, resources.GetString("textBox.ToolTip"));
            this.textBox.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            this.textBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
            this.textBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // buttonEnter
            // 
            this.buttonEnter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonEnter.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonEnter.Location = new System.Drawing.Point(13, 69);
            this.buttonEnter.Margin = new System.Windows.Forms.Padding(4);
            this.buttonEnter.Name = "buttonEnter";
            this.buttonEnter.Size = new System.Drawing.Size(119, 39);
            this.buttonEnter.TabIndex = 2;
            this.buttonEnter.Text = "Enter";
            this.toolTip1.SetToolTip(this.buttonEnter, "Enter\r\n-Adds plate to list of plates.\r\n-You can also press the enter key");
            this.buttonEnter.UseVisualStyleBackColor = true;
            this.buttonEnter.Click += new System.EventHandler(this.buttonEnter_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonEdit.Location = new System.Drawing.Point(13, 116);
            this.buttonEdit.Margin = new System.Windows.Forms.Padding(4);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(119, 39);
            this.buttonEdit.TabIndex = 4;
            this.buttonEdit.Text = "Edit";
            this.toolTip1.SetToolTip(this.buttonEdit, "Edit\r\n-Replaces the selected plate with the edited one in TextBox");
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonDel
            // 
            this.buttonDel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonDel.Location = new System.Drawing.Point(13, 163);
            this.buttonDel.Margin = new System.Windows.Forms.Padding(4);
            this.buttonDel.Name = "buttonDel";
            this.buttonDel.Size = new System.Drawing.Size(119, 39);
            this.buttonDel.TabIndex = 5;
            this.buttonDel.Text = "Delete";
            this.toolTip1.SetToolTip(this.buttonDel, "Delete\r\n-Deletes selected plate\r\n-Can also double click plate on Plate list.");
            this.buttonDel.UseVisualStyleBackColor = true;
            this.buttonDel.Click += new System.EventHandler(this.buttonDel_Click);
            // 
            // buttonTag
            // 
            this.buttonTag.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonTag.Location = new System.Drawing.Point(13, 210);
            this.buttonTag.Margin = new System.Windows.Forms.Padding(4);
            this.buttonTag.Name = "buttonTag";
            this.buttonTag.Size = new System.Drawing.Size(119, 39);
            this.buttonTag.TabIndex = 6;
            this.buttonTag.Text = "Tag";
            this.toolTip1.SetToolTip(this.buttonTag, "Tag\r\n-Adds a tag (\'z\') to the start of the plate to mark for investigation");
            this.buttonTag.UseVisualStyleBackColor = true;
            this.buttonTag.Click += new System.EventHandler(this.buttonTag_Click);
            // 
            // buttonBin
            // 
            this.buttonBin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonBin.Location = new System.Drawing.Point(13, 257);
            this.buttonBin.Margin = new System.Windows.Forms.Padding(4);
            this.buttonBin.Name = "buttonBin";
            this.buttonBin.Size = new System.Drawing.Size(119, 39);
            this.buttonBin.TabIndex = 7;
            this.buttonBin.Text = "Bin Search";
            this.toolTip1.SetToolTip(this.buttonBin, "Bin Search\r\n-Uses binary search method to find plate in textbox in list of plates" +
        "");
            this.buttonBin.UseVisualStyleBackColor = true;
            this.buttonBin.Click += new System.EventHandler(this.buttonBin_Click);
            // 
            // buttonLin
            // 
            this.buttonLin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonLin.Location = new System.Drawing.Point(13, 304);
            this.buttonLin.Margin = new System.Windows.Forms.Padding(4);
            this.buttonLin.Name = "buttonLin";
            this.buttonLin.Size = new System.Drawing.Size(119, 39);
            this.buttonLin.TabIndex = 8;
            this.buttonLin.Text = "Linear Search";
            this.toolTip1.SetToolTip(this.buttonLin, "Linear search\r\n-Uses linear search to find plate in TextBox in list of plates.");
            this.buttonLin.UseVisualStyleBackColor = true;
            this.buttonLin.Click += new System.EventHandler(this.buttonLin_Click);
            // 
            // buttonRst
            // 
            this.buttonRst.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonRst.Location = new System.Drawing.Point(13, 351);
            this.buttonRst.Margin = new System.Windows.Forms.Padding(4);
            this.buttonRst.Name = "buttonRst";
            this.buttonRst.Size = new System.Drawing.Size(119, 39);
            this.buttonRst.TabIndex = 9;
            this.buttonRst.Text = "Reset";
            this.toolTip1.SetToolTip(this.buttonRst, "Reset\r\n-Clears all values and resets to default state.");
            this.buttonRst.UseVisualStyleBackColor = true;
            this.buttonRst.Click += new System.EventHandler(this.buttonRst_Click);
            // 
            // buttonOpen
            // 
            this.buttonOpen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonOpen.Location = new System.Drawing.Point(13, 398);
            this.buttonOpen.Margin = new System.Windows.Forms.Padding(4);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(119, 39);
            this.buttonOpen.TabIndex = 10;
            this.buttonOpen.Text = "Open";
            this.toolTip1.SetToolTip(this.buttonOpen, "Open\r\n-Opens open file menu allowing text file with plates to be used.");
            this.buttonOpen.UseVisualStyleBackColor = true;
            this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSave.Location = new System.Drawing.Point(13, 445);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(119, 41);
            this.buttonSave.TabIndex = 11;
            this.buttonSave.Text = "Save";
            this.toolTip1.SetToolTip(this.buttonSave, "Save\r\n-Opens save file menu allowing plates to be saved to text file. \r\n-Option t" +
        "o reset to default values after save.");
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 494);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(263, 22);
            this.statusStrip1.TabIndex = 13;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(159, 17);
            this.statusLabel.Text = "Add entries or open from file";
            // 
            // toolTip1
            // 
            this.toolTip1.BackColor = System.Drawing.Color.Lavender;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(263, 516);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonOpen);
            this.Controls.Add(this.buttonRst);
            this.Controls.Add(this.buttonLin);
            this.Controls.Add(this.buttonBin);
            this.Controls.Add(this.buttonTag);
            this.Controls.Add(this.buttonDel);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.buttonEnter);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vehicle Registration Management";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Vrm_FormClosed);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Button buttonEnter;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonDel;
        private System.Windows.Forms.Button buttonTag;
        private System.Windows.Forms.Button buttonBin;
        private System.Windows.Forms.Button buttonLin;
        private System.Windows.Forms.Button buttonRst;
        private System.Windows.Forms.Button buttonOpen;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

