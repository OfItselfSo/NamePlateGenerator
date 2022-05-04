namespace NamePlateGenerator
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.buttonGenerateFromScreen = new System.Windows.Forms.Button();
            this.panelLabelDisplay = new System.Windows.Forms.Panel();
            this.textBoxCenterText = new System.Windows.Forms.TextBox();
            this.richTextBoxGCode = new System.Windows.Forms.RichTextBox();
            this.buttonSaveGCode = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxULText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxPlateWidth = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxPlateHeight = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonCenterTextFontPicker = new System.Windows.Forms.Button();
            this.textBoxCenterTextFont = new System.Windows.Forms.TextBox();
            this.textBoxCornerTextFont = new System.Windows.Forms.TextBox();
            this.buttonCornerTextFontPicker = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxCenterZCutDepth = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxCornerZCutDepth = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxClearZHeight = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxFastMoveZHeight = new System.Windows.Forms.TextBox();
            this.checkBoxWantBoundaryRect = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBoxPlateMargin = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBoxLLText = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.textBoxLRText = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.textBoxURText = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.textBoxSmoothingFactor = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.buttonGenerateFrom5ColCSV = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.textBoxCSVFile = new System.Windows.Forms.TextBox();
            this.buttonPickCSVFile = new System.Windows.Forms.Button();
            this.textBoxOutputDir = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.buttonPickOutDir = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.textBoxTouchDownZDepth = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.textBoxTouchDownOffset = new System.Windows.Forms.TextBox();
            this.checkBoxWantVerticalTouchdowns = new System.Windows.Forms.CheckBox();
            this.checkBoxWantHorizTouchdowns = new System.Windows.Forms.CheckBox();
            this.label33 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.textBoxFastFeedRate = new System.Windows.Forms.TextBox();
            this.label36 = new System.Windows.Forms.Label();
            this.textBoxTextFeedRate = new System.Windows.Forms.TextBox();
            this.label37 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.textBoxZFeedRate = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonGenerateFromScreen
            // 
            this.buttonGenerateFromScreen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonGenerateFromScreen.Location = new System.Drawing.Point(12, 503);
            this.buttonGenerateFromScreen.Name = "buttonGenerateFromScreen";
            this.buttonGenerateFromScreen.Size = new System.Drawing.Size(185, 23);
            this.buttonGenerateFromScreen.TabIndex = 0;
            this.buttonGenerateFromScreen.Text = "Generate From Screen";
            this.buttonGenerateFromScreen.UseVisualStyleBackColor = true;
            this.buttonGenerateFromScreen.Click += new System.EventHandler(this.buttonGenerateFromScreen_Click);
            // 
            // panelLabelDisplay
            // 
            this.panelLabelDisplay.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panelLabelDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLabelDisplay.Location = new System.Drawing.Point(252, 12);
            this.panelLabelDisplay.Name = "panelLabelDisplay";
            this.panelLabelDisplay.Size = new System.Drawing.Size(348, 264);
            this.panelLabelDisplay.TabIndex = 1;
            this.panelLabelDisplay.Paint += new System.Windows.Forms.PaintEventHandler(this.panelLabelDisplay_Paint);
            // 
            // textBoxCenterText
            // 
            this.textBoxCenterText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxCenterText.Location = new System.Drawing.Point(75, 421);
            this.textBoxCenterText.Name = "textBoxCenterText";
            this.textBoxCenterText.Size = new System.Drawing.Size(185, 20);
            this.textBoxCenterText.TabIndex = 2;
            // 
            // richTextBoxGCode
            // 
            this.richTextBoxGCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxGCode.Location = new System.Drawing.Point(636, 12);
            this.richTextBoxGCode.Name = "richTextBoxGCode";
            this.richTextBoxGCode.Size = new System.Drawing.Size(306, 450);
            this.richTextBoxGCode.TabIndex = 3;
            this.richTextBoxGCode.Text = "";
            // 
            // buttonSaveGCode
            // 
            this.buttonSaveGCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSaveGCode.Location = new System.Drawing.Point(636, 513);
            this.buttonSaveGCode.Name = "buttonSaveGCode";
            this.buttonSaveGCode.Size = new System.Drawing.Size(75, 23);
            this.buttonSaveGCode.TabIndex = 4;
            this.buttonSaveGCode.Text = "Save GCode";
            this.buttonSaveGCode.UseVisualStyleBackColor = true;
            this.buttonSaveGCode.Click += new System.EventHandler(this.buttonSaveGCode_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 424);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Center Text:";
            // 
            // textBoxULText
            // 
            this.textBoxULText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxULText.Location = new System.Drawing.Point(75, 375);
            this.textBoxULText.Name = "textBoxULText";
            this.textBoxULText.Size = new System.Drawing.Size(91, 20);
            this.textBoxULText.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 378);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "UL Text:";
            // 
            // textBoxPlateWidth
            // 
            this.textBoxPlateWidth.Location = new System.Drawing.Point(118, 22);
            this.textBoxPlateWidth.Name = "textBoxPlateWidth";
            this.textBoxPlateWidth.Size = new System.Drawing.Size(91, 20);
            this.textBoxPlateWidth.TabIndex = 8;
            this.textBoxPlateWidth.TextChanged += new System.EventHandler(this.textBoxPlateWidth_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(51, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "PlateWidth:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(48, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "PlateHeight:";
            // 
            // textBoxPlateHeight
            // 
            this.textBoxPlateHeight.Location = new System.Drawing.Point(118, 48);
            this.textBoxPlateHeight.Name = "textBoxPlateHeight";
            this.textBoxPlateHeight.Size = new System.Drawing.Size(91, 20);
            this.textBoxPlateHeight.TabIndex = 10;
            this.textBoxPlateHeight.TextChanged += new System.EventHandler(this.textBoxPlateHeight_TextChanged);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(411, 359);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(129, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Center Text Font && Height";
            // 
            // buttonCenterTextFontPicker
            // 
            this.buttonCenterTextFontPicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCenterTextFontPicker.Location = new System.Drawing.Point(560, 375);
            this.buttonCenterTextFontPicker.Name = "buttonCenterTextFontPicker";
            this.buttonCenterTextFontPicker.Size = new System.Drawing.Size(40, 20);
            this.buttonCenterTextFontPicker.TabIndex = 15;
            this.buttonCenterTextFontPicker.Text = "Font";
            this.buttonCenterTextFontPicker.UseVisualStyleBackColor = true;
            this.buttonCenterTextFontPicker.Click += new System.EventHandler(this.buttonCenterTextFontPicker_Click);
            // 
            // textBoxCenterTextFont
            // 
            this.textBoxCenterTextFont.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxCenterTextFont.Location = new System.Drawing.Point(394, 375);
            this.textBoxCenterTextFont.Name = "textBoxCenterTextFont";
            this.textBoxCenterTextFont.Size = new System.Drawing.Size(162, 20);
            this.textBoxCenterTextFont.TabIndex = 16;
            // 
            // textBoxCornerTextFont
            // 
            this.textBoxCornerTextFont.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxCornerTextFont.Location = new System.Drawing.Point(394, 423);
            this.textBoxCornerTextFont.Name = "textBoxCornerTextFont";
            this.textBoxCornerTextFont.Size = new System.Drawing.Size(162, 20);
            this.textBoxCornerTextFont.TabIndex = 19;
            // 
            // buttonCornerTextFontPicker
            // 
            this.buttonCornerTextFontPicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCornerTextFontPicker.Location = new System.Drawing.Point(560, 423);
            this.buttonCornerTextFontPicker.Name = "buttonCornerTextFontPicker";
            this.buttonCornerTextFontPicker.Size = new System.Drawing.Size(40, 20);
            this.buttonCornerTextFontPicker.TabIndex = 18;
            this.buttonCornerTextFontPicker.Text = "Font";
            this.buttonCornerTextFontPicker.UseVisualStyleBackColor = true;
            this.buttonCornerTextFontPicker.Click += new System.EventHandler(this.buttonCornerTextFontPicker_Click);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(411, 407);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(129, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Corner Text Font && Height";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(36, 173);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "CenterZDepth:";
            // 
            // textBoxCenterZCutDepth
            // 
            this.textBoxCenterZCutDepth.Location = new System.Drawing.Point(118, 169);
            this.textBoxCenterZCutDepth.Name = "textBoxCenterZCutDepth";
            this.textBoxCenterZCutDepth.Size = new System.Drawing.Size(91, 20);
            this.textBoxCenterZCutDepth.TabIndex = 20;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(36, 199);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "CornerZDepth:";
            // 
            // textBoxCornerZCutDepth
            // 
            this.textBoxCornerZCutDepth.Location = new System.Drawing.Point(118, 195);
            this.textBoxCornerZCutDepth.Name = "textBoxCornerZCutDepth";
            this.textBoxCornerZCutDepth.Size = new System.Drawing.Size(91, 20);
            this.textBoxCornerZCutDepth.TabIndex = 22;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(41, 225);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 13);
            this.label9.TabIndex = 25;
            this.label9.Text = "ClearZHeight:";
            // 
            // textBoxClearZHeight
            // 
            this.textBoxClearZHeight.Location = new System.Drawing.Point(118, 221);
            this.textBoxClearZHeight.Name = "textBoxClearZHeight";
            this.textBoxClearZHeight.Size = new System.Drawing.Size(91, 20);
            this.textBoxClearZHeight.TabIndex = 24;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(18, 251);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(95, 13);
            this.label10.TabIndex = 27;
            this.label10.Text = "FastMoveZHeight:";
            // 
            // textBoxFastMoveZHeight
            // 
            this.textBoxFastMoveZHeight.Location = new System.Drawing.Point(118, 247);
            this.textBoxFastMoveZHeight.Name = "textBoxFastMoveZHeight";
            this.textBoxFastMoveZHeight.Size = new System.Drawing.Size(91, 20);
            this.textBoxFastMoveZHeight.TabIndex = 26;
            // 
            // checkBoxWantBoundaryRect
            // 
            this.checkBoxWantBoundaryRect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxWantBoundaryRect.AutoSize = true;
            this.checkBoxWantBoundaryRect.Location = new System.Drawing.Point(75, 449);
            this.checkBoxWantBoundaryRect.Name = "checkBoxWantBoundaryRect";
            this.checkBoxWantBoundaryRect.Size = new System.Drawing.Size(119, 17);
            this.checkBoxWantBoundaryRect.TabIndex = 28;
            this.checkBoxWantBoundaryRect.Text = "Add Boundary Rect";
            this.checkBoxWantBoundaryRect.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(48, 78);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(66, 13);
            this.label11.TabIndex = 30;
            this.label11.Text = "PlateMargin:";
            // 
            // textBoxPlateMargin
            // 
            this.textBoxPlateMargin.Location = new System.Drawing.Point(118, 74);
            this.textBoxPlateMargin.Name = "textBoxPlateMargin";
            this.textBoxPlateMargin.Size = new System.Drawing.Size(91, 20);
            this.textBoxPlateMargin.TabIndex = 29;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(26, 400);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(46, 13);
            this.label12.TabIndex = 32;
            this.label12.Text = "LL Text:";
            // 
            // textBoxLLText
            // 
            this.textBoxLLText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxLLText.Location = new System.Drawing.Point(75, 397);
            this.textBoxLLText.Name = "textBoxLLText";
            this.textBoxLLText.Size = new System.Drawing.Size(91, 20);
            this.textBoxLLText.TabIndex = 31;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(194, 400);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(48, 13);
            this.label13.TabIndex = 36;
            this.label13.Text = "LR Text:";
            // 
            // textBoxLRText
            // 
            this.textBoxLRText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxLRText.Location = new System.Drawing.Point(243, 397);
            this.textBoxLRText.Name = "textBoxLRText";
            this.textBoxLRText.Size = new System.Drawing.Size(91, 20);
            this.textBoxLRText.TabIndex = 35;
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(193, 378);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(50, 13);
            this.label14.TabIndex = 34;
            this.label14.Text = "UR Text:";
            // 
            // textBoxURText
            // 
            this.textBoxURText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxURText.Location = new System.Drawing.Point(243, 375);
            this.textBoxURText.Name = "textBoxURText";
            this.textBoxURText.Size = new System.Drawing.Size(91, 20);
            this.textBoxURText.TabIndex = 33;
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(303, 331);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(93, 13);
            this.label15.TabIndex = 38;
            this.label15.Text = "Smoothing Factor:";
            // 
            // textBoxSmoothingFactor
            // 
            this.textBoxSmoothingFactor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxSmoothingFactor.Location = new System.Drawing.Point(396, 327);
            this.textBoxSmoothingFactor.Name = "textBoxSmoothingFactor";
            this.textBoxSmoothingFactor.Size = new System.Drawing.Size(91, 20);
            this.textBoxSmoothingFactor.TabIndex = 37;
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(296, 285);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(257, 13);
            this.label16.TabIndex = 39;
            this.label16.Text = "A number indicating how smooth to make the curves.";
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(305, 298);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(239, 13);
            this.label17.TabIndex = 40;
            this.label17.Text = "Smaller is smoother but gives more line segments.";
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(303, 311);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(242, 13);
            this.label18.TabIndex = 41;
            this.label18.Text = "Usually in range 0.25 to 1 but can be outside that.";
            // 
            // buttonGenerateFrom5ColCSV
            // 
            this.buttonGenerateFrom5ColCSV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonGenerateFrom5ColCSV.Location = new System.Drawing.Point(345, 503);
            this.buttonGenerateFrom5ColCSV.Name = "buttonGenerateFrom5ColCSV";
            this.buttonGenerateFrom5ColCSV.Size = new System.Drawing.Size(185, 23);
            this.buttonGenerateFrom5ColCSV.TabIndex = 42;
            this.buttonGenerateFrom5ColCSV.Text = "Generate From 5Col CSV";
            this.buttonGenerateFrom5ColCSV.UseVisualStyleBackColor = true;
            this.buttonGenerateFrom5ColCSV.Click += new System.EventHandler(this.buttonGenerateFrom5ColCSV_Click);
            // 
            // label19
            // 
            this.label19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(223, 480);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(50, 13);
            this.label19.TabIndex = 44;
            this.label19.Text = "CSV File:";
            // 
            // textBoxCSVFile
            // 
            this.textBoxCSVFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxCSVFile.Location = new System.Drawing.Point(278, 477);
            this.textBoxCSVFile.Name = "textBoxCSVFile";
            this.textBoxCSVFile.ReadOnly = true;
            this.textBoxCSVFile.Size = new System.Drawing.Size(275, 20);
            this.textBoxCSVFile.TabIndex = 43;
            // 
            // buttonPickCSVFile
            // 
            this.buttonPickCSVFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonPickCSVFile.Location = new System.Drawing.Point(560, 477);
            this.buttonPickCSVFile.Name = "buttonPickCSVFile";
            this.buttonPickCSVFile.Size = new System.Drawing.Size(40, 20);
            this.buttonPickCSVFile.TabIndex = 45;
            this.buttonPickCSVFile.Text = "...";
            this.buttonPickCSVFile.UseVisualStyleBackColor = true;
            this.buttonPickCSVFile.Click += new System.EventHandler(this.buttonPickCSVFile_Click);
            // 
            // textBoxOutputDir
            // 
            this.textBoxOutputDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxOutputDir.Location = new System.Drawing.Point(636, 487);
            this.textBoxOutputDir.Name = "textBoxOutputDir";
            this.textBoxOutputDir.ReadOnly = true;
            this.textBoxOutputDir.Size = new System.Drawing.Size(260, 20);
            this.textBoxOutputDir.TabIndex = 46;
            // 
            // label20
            // 
            this.label20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(666, 471);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(55, 13);
            this.label20.TabIndex = 47;
            this.label20.Text = "OutputDir:";
            // 
            // label21
            // 
            this.label21.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(306, 461);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(230, 13);
            this.label21.TabIndex = 48;
            this.label21.Text = "Auto-process 5 col CSV. (Center,UL,UR,LR,LL)";
            // 
            // buttonPickOutDir
            // 
            this.buttonPickOutDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonPickOutDir.Location = new System.Drawing.Point(902, 487);
            this.buttonPickOutDir.Name = "buttonPickOutDir";
            this.buttonPickOutDir.Size = new System.Drawing.Size(40, 20);
            this.buttonPickOutDir.TabIndex = 49;
            this.buttonPickOutDir.Text = "...";
            this.buttonPickOutDir.UseVisualStyleBackColor = true;
            this.buttonPickOutDir.Click += new System.EventHandler(this.buttonPickOutDir_Click);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(215, 26);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(27, 13);
            this.label22.TabIndex = 50;
            this.label22.Text = "inch";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(215, 52);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(27, 13);
            this.label23.TabIndex = 51;
            this.label23.Text = "inch";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(215, 77);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(27, 13);
            this.label24.TabIndex = 52;
            this.label24.Text = "inch";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(215, 173);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(27, 13);
            this.label25.TabIndex = 53;
            this.label25.Text = "inch";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(215, 199);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(27, 13);
            this.label26.TabIndex = 54;
            this.label26.Text = "inch";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(215, 224);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(27, 13);
            this.label27.TabIndex = 55;
            this.label27.Text = "inch";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(215, 250);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(27, 13);
            this.label28.TabIndex = 56;
            this.label28.Text = "inch";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(215, 147);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(27, 13);
            this.label29.TabIndex = 59;
            this.label29.Text = "inch";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(10, 147);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(105, 13);
            this.label30.TabIndex = 58;
            this.label30.Text = "TouchDownZDepth:";
            // 
            // textBoxTouchDownZDepth
            // 
            this.textBoxTouchDownZDepth.Location = new System.Drawing.Point(118, 143);
            this.textBoxTouchDownZDepth.Name = "textBoxTouchDownZDepth";
            this.textBoxTouchDownZDepth.Size = new System.Drawing.Size(91, 20);
            this.textBoxTouchDownZDepth.TabIndex = 57;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(215, 103);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(27, 13);
            this.label31.TabIndex = 62;
            this.label31.Text = "inch";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(16, 104);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(97, 13);
            this.label32.TabIndex = 61;
            this.label32.Text = "TouchDownOffset:";
            // 
            // textBoxTouchDownOffset
            // 
            this.textBoxTouchDownOffset.Location = new System.Drawing.Point(118, 100);
            this.textBoxTouchDownOffset.Name = "textBoxTouchDownOffset";
            this.textBoxTouchDownOffset.Size = new System.Drawing.Size(91, 20);
            this.textBoxTouchDownOffset.TabIndex = 60;
            // 
            // checkBoxWantVerticalTouchdowns
            // 
            this.checkBoxWantVerticalTouchdowns.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxWantVerticalTouchdowns.AutoSize = true;
            this.checkBoxWantVerticalTouchdowns.Location = new System.Drawing.Point(75, 465);
            this.checkBoxWantVerticalTouchdowns.Name = "checkBoxWantVerticalTouchdowns";
            this.checkBoxWantVerticalTouchdowns.Size = new System.Drawing.Size(137, 17);
            this.checkBoxWantVerticalTouchdowns.TabIndex = 63;
            this.checkBoxWantVerticalTouchdowns.Text = "Add Vert. TouchDowns";
            this.checkBoxWantVerticalTouchdowns.UseVisualStyleBackColor = true;
            // 
            // checkBoxWantHorizTouchdowns
            // 
            this.checkBoxWantHorizTouchdowns.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxWantHorizTouchdowns.AutoSize = true;
            this.checkBoxWantHorizTouchdowns.Location = new System.Drawing.Point(75, 481);
            this.checkBoxWantHorizTouchdowns.Name = "checkBoxWantHorizTouchdowns";
            this.checkBoxWantHorizTouchdowns.Size = new System.Drawing.Size(142, 17);
            this.checkBoxWantHorizTouchdowns.TabIndex = 64;
            this.checkBoxWantHorizTouchdowns.Text = "Add Horiz. TouchDowns";
            this.checkBoxWantHorizTouchdowns.UseVisualStyleBackColor = true;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(215, 302);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(25, 13);
            this.label33.TabIndex = 70;
            this.label33.Text = "in/s";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(215, 276);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(25, 13);
            this.label34.TabIndex = 69;
            this.label34.Text = "in/s";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(33, 303);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(77, 13);
            this.label35.TabIndex = 68;
            this.label35.Text = "FastFeedRate:";
            // 
            // textBoxFastFeedRate
            // 
            this.textBoxFastFeedRate.Location = new System.Drawing.Point(118, 299);
            this.textBoxFastFeedRate.Name = "textBoxFastFeedRate";
            this.textBoxFastFeedRate.Size = new System.Drawing.Size(91, 20);
            this.textBoxFastFeedRate.TabIndex = 67;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(34, 277);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(78, 13);
            this.label36.TabIndex = 66;
            this.label36.Text = "TextFeedRate:";
            // 
            // textBoxTextFeedRate
            // 
            this.textBoxTextFeedRate.Location = new System.Drawing.Point(118, 273);
            this.textBoxTextFeedRate.Name = "textBoxTextFeedRate";
            this.textBoxTextFeedRate.Size = new System.Drawing.Size(91, 20);
            this.textBoxTextFeedRate.TabIndex = 65;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(215, 329);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(25, 13);
            this.label37.TabIndex = 73;
            this.label37.Text = "in/s";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(46, 330);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(64, 13);
            this.label38.TabIndex = 72;
            this.label38.Text = "ZFeedRate:";
            // 
            // textBoxZFeedRate
            // 
            this.textBoxZFeedRate.Location = new System.Drawing.Point(118, 326);
            this.textBoxZFeedRate.Name = "textBoxZFeedRate";
            this.textBoxZFeedRate.Size = new System.Drawing.Size(91, 20);
            this.textBoxZFeedRate.TabIndex = 71;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(947, 542);
            this.Controls.Add(this.label37);
            this.Controls.Add(this.label38);
            this.Controls.Add(this.textBoxZFeedRate);
            this.Controls.Add(this.label33);
            this.Controls.Add(this.label34);
            this.Controls.Add(this.label35);
            this.Controls.Add(this.textBoxFastFeedRate);
            this.Controls.Add(this.label36);
            this.Controls.Add(this.textBoxTextFeedRate);
            this.Controls.Add(this.checkBoxWantHorizTouchdowns);
            this.Controls.Add(this.checkBoxWantVerticalTouchdowns);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.textBoxTouchDownOffset);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.textBoxTouchDownZDepth);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.buttonPickOutDir);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.textBoxOutputDir);
            this.Controls.Add(this.buttonPickCSVFile);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.textBoxCSVFile);
            this.Controls.Add(this.buttonGenerateFrom5ColCSV);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.textBoxSmoothingFactor);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.textBoxLRText);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.textBoxURText);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.textBoxLLText);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textBoxPlateMargin);
            this.Controls.Add(this.checkBoxWantBoundaryRect);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBoxFastMoveZHeight);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBoxClearZHeight);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBoxCornerZCutDepth);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxCenterZCutDepth);
            this.Controls.Add(this.textBoxCornerTextFont);
            this.Controls.Add(this.buttonCornerTextFontPicker);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxCenterTextFont);
            this.Controls.Add(this.buttonCenterTextFontPicker);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxPlateHeight);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxPlateWidth);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxULText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonSaveGCode);
            this.Controls.Add(this.richTextBoxGCode);
            this.Controls.Add(this.textBoxCenterText);
            this.Controls.Add(this.panelLabelDisplay);
            this.Controls.Add(this.buttonGenerateFromScreen);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(963, 568);
            this.Name = "frmMain";
            this.Text = "NamePlateGenerator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonGenerateFromScreen;
        private System.Windows.Forms.Panel panelLabelDisplay;
        private System.Windows.Forms.TextBox textBoxCenterText;
        private System.Windows.Forms.RichTextBox richTextBoxGCode;
        private System.Windows.Forms.Button buttonSaveGCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxULText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxPlateWidth;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxPlateHeight;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonCenterTextFontPicker;
        private System.Windows.Forms.TextBox textBoxCenterTextFont;
        private System.Windows.Forms.TextBox textBoxCornerTextFont;
        private System.Windows.Forms.Button buttonCornerTextFontPicker;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxCenterZCutDepth;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxCornerZCutDepth;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxClearZHeight;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxFastMoveZHeight;
        private System.Windows.Forms.CheckBox checkBoxWantBoundaryRect;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBoxPlateMargin;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBoxLLText;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBoxLRText;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBoxURText;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBoxSmoothingFactor;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button buttonGenerateFrom5ColCSV;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox textBoxCSVFile;
        private System.Windows.Forms.Button buttonPickCSVFile;
        private System.Windows.Forms.TextBox textBoxOutputDir;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button buttonPickOutDir;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.TextBox textBoxTouchDownZDepth;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.TextBox textBoxTouchDownOffset;
        private System.Windows.Forms.CheckBox checkBoxWantVerticalTouchdowns;
        private System.Windows.Forms.CheckBox checkBoxWantHorizTouchdowns;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.TextBox textBoxFastFeedRate;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.TextBox textBoxTextFeedRate;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.TextBox textBoxZFeedRate;
    }
}

