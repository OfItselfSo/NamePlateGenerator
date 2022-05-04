using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;

/// +------------------------------------------------------------------------------------------------------------------------------+
/// ¦                                                   TERMS OF USE: MIT License                                                  ¦
/// +------------------------------------------------------------------------------------------------------------------------------¦
/// ¦Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation    ¦
/// ¦files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy,    ¦
/// ¦modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software¦
/// ¦is furnished to do so, subject to the following conditions:                                                                   ¦
/// ¦                                                                                                                              ¦
/// ¦The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.¦
/// ¦                                                                                                                              ¦
/// ¦THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE          ¦
/// ¦WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR         ¦
/// ¦COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,   ¦
/// ¦ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.                         ¦
/// +------------------------------------------------------------------------------------------------------------------------------+

namespace NamePlateGenerator
{
    /// +=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=
    /// +=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=
    /// <summary>
    /// The main form for the NamePlateGenerator application
    /// </summary>
    public partial class frmMain : Form
    {
        private const float DEFAULT_PANEL_WIDTH_IN = 4.00f;
        private const float DEFAULT_PANEL_HEIGHT_IN = 2.75f;
        private const float DEFAULT_PANEL_MARGIN_IN = 0.20f;
        private const float DEFAULT_PANEL_MINMARGIN_IN = 0f;
        private const float DEFAULT_TOUCHDOWN_OFFSET_IN = 0.5f;
        private const float DEFAULT_TOUCHDOWN_CIRCLE_RADIUS_IN = 0.05f;

        // this is the padding between the panel border and the 0,0 pixel of the actual panel
        private const int DEFAULT_PANEL_PADDING = 3;
        private const int DEFAULT_PANEL_DPI = 96;
        private const int FONT_POINTS_PER_INCH = 72;

        // these are the default fonts and sizes. The format matters here. It is 
        // read by the FontConverter prior to launching the font picker dialog
        // it is also read by the drawing code to get the font and size.
        private const string DEFAULT_CENTERTEXT_FONT = "1CamBam_Stick_9, 24pt";
        private const string DEFAULT_CORNERTEXT_FONT = "1CamBam_Stick_9, 16pt";
        private const float DEFAULT_CENTERTEXT_HEIGHT_PTS = 24f;
        private const float DEFAULT_CORNERTEXT_HEIGHT_PTS = 16f;

        private const float DEFAULT_CLEAR_ZHEIGHT_IN = 0.250f;
        private const float DEFAULT_FASTMOVE_ZHEIGHT_IN = 0.10f;
        private const float DEFAULT_CENTER_Z_CUT_DEPTH_IN = -0.035f;
        private const float DEFAULT_CORNER_Z_CUT_DEPTH_IN = -0.020f;
        private const float DEFAULT_TOUCHDOWN_Z_CUT_DEPTH_IN = -0.25f;

        private const float DEFAULT_ZFEEDRATE_INPERSEC = 20f;
        private const float DEFAULT_TEXTFEEDRATE_INPERSEC = 50f;
        private const float DEFAULT_FASTFEEDRATE_INPERSEC = 80f;

        private float clearMoveZHeight = DEFAULT_CLEAR_ZHEIGHT_IN;
        private float fastMoveZHeight = DEFAULT_FASTMOVE_ZHEIGHT_IN;
        private float centerZCutDepth = DEFAULT_CENTER_Z_CUT_DEPTH_IN;
        private float cornerZCutDepth = DEFAULT_CORNER_Z_CUT_DEPTH_IN;
        private float touchDownZCutDepth = DEFAULT_TOUCHDOWN_Z_CUT_DEPTH_IN;

        private float zFeedrate = DEFAULT_ZFEEDRATE_INPERSEC;
        private float textFeedRate = DEFAULT_TEXTFEEDRATE_INPERSEC;
        private float fastFeedRate = DEFAULT_FASTFEEDRATE_INPERSEC;

        // these are the marker bytes we can have for each coord in the path
        private const byte POINTISSTART = 0x00;        // Indicates that the point is the start of a figure.
        private const byte POINTISEND = 0x01;          // Indicates that the point is one of the two endpoints of a line.
        private const byte POINTSPLINE = 0x03; 	       // Indicates that the point is an endpoint or control point of a cubic Bézier spline.
        private const byte POINTTYPEMASK = 0x07; 	   // Masks all bits except for the three low-order bits, which indicate the point type.
        private const byte POINTISMARKER = 0x20; 	   // Specifies that the point is a marker.
        private const byte POINTISPATHEND = 0x80;	   // Specifies that the point is the last point in a closed subpath (figure).


        private const string DEFAULT_UL_TEXT = "ULCorner";
        private const string DEFAULT_LL_TEXT = "LLCorner";
        private const string DEFAULT_UR_TEXT = "URCorner";
        private const string DEFAULT_LR_TEXT = "LRCorner";
        private const string DEFAULT_CENTER_TEXT = "Center";
        private const string DEFAULT_INPUT_DIR = @"C:\Dump\NPGSamples";
        private const string DEFAULT_INPUT_DIR_FILE = "nebula.csv";
        private const string DEFAULT_OUTPUT_DIR = @"C:\Dump\NPGSamples";
        private const string DEFAULT_OUTPUT_FILE = @"aaNPG.ngc";
        private const string DEFAULT_OUTPUT_FILE_EXT = @".ngc";
        private const bool DEFAULT_WANT_BOUNDARY_RECT = false;
        private const bool DEFAULT_WANT_VERT_TOUCHDOWNS = true;
        private const bool DEFAULT_WANT_HORIZ_TOUCHDOWNS = false;
        private const char DEFAULT_CSV_SEPARATOR = '|';

        private string outputGCodeFile = DEFAULT_OUTPUT_FILE;

        private bool suppressAutoUpdate = false; 

        // this is used when converting the text from curves to segments. Smaller is finer granulation
        // but generates a lot more gcode lines. The microsoft default is 0.25 which looks indistinguisable
        // from curves
        private const float DEFAULT_FLATNESS = .5f;

        // these variables are set at the start of the generation so we don't have to keep rebuilding them
        private Rectangle plateRectangle = new Rectangle(0, 0, 0, 0);
        private float scaleFactorHeight = 1;
        private float scaleFactorWidth = 1;
        private Font centerTextFont = null;
        private Font cornerTextFont = null;
        private float workingFlatness = DEFAULT_FLATNESS;
        private List<PlateInfoContainer> autoGenerateList = new List<PlateInfoContainer>();


        /// +=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=
        /// <summary>
        /// Constructor
        /// </summary>
        public frmMain()
        {
            InitializeComponent();

            // initialize some things
            Init();
        }

        /// +=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=
        /// <summary>
        /// Performs basic initialization on startup
        /// </summary>
        private void Init()
        {
            try
            {
                suppressAutoUpdate = true;
                CenterText = DEFAULT_CENTER_TEXT;
                ULText = DEFAULT_UL_TEXT;
                LLText = DEFAULT_LL_TEXT;
                URText = DEFAULT_UR_TEXT;
                LRText = DEFAULT_LR_TEXT;
                textBoxPlateWidth.Text = DEFAULT_PANEL_WIDTH_IN.ToString();
                textBoxPlateHeight.Text = DEFAULT_PANEL_HEIGHT_IN.ToString();
                textBoxPlateMargin.Text = DEFAULT_PANEL_MARGIN_IN.ToString();
                textBoxTouchDownOffset.Text = DEFAULT_TOUCHDOWN_OFFSET_IN.ToString();

                // set our padding now so our size calculations come out right
                panelLabelDisplay.Padding = new System.Windows.Forms.Padding(DEFAULT_PANEL_PADDING);
                // set the size now
                panelLabelDisplay.Size = PanelSizeInPixels;
                // set our fonts now, the structure of this string matters
                textBoxCenterTextFont.Text = DEFAULT_CENTERTEXT_FONT;
                textBoxCornerTextFont.Text = DEFAULT_CORNERTEXT_FONT;
                textBoxCenterZCutDepth.Text = DEFAULT_CENTER_Z_CUT_DEPTH_IN.ToString();
                textBoxCornerZCutDepth.Text = DEFAULT_CORNER_Z_CUT_DEPTH_IN.ToString();
                textBoxClearZHeight.Text = DEFAULT_CLEAR_ZHEIGHT_IN.ToString();
                textBoxFastMoveZHeight.Text = DEFAULT_FASTMOVE_ZHEIGHT_IN.ToString();
                textBoxTouchDownZDepth.Text = DEFAULT_TOUCHDOWN_Z_CUT_DEPTH_IN.ToString();

                textBoxFastFeedRate.Text = DEFAULT_FASTFEEDRATE_INPERSEC.ToString();
                textBoxTextFeedRate.Text = DEFAULT_TEXTFEEDRATE_INPERSEC.ToString();
                textBoxZFeedRate.Text = DEFAULT_ZFEEDRATE_INPERSEC.ToString();

                WantBoundaryRect = DEFAULT_WANT_BOUNDARY_RECT;
                WantVertTouchdowns = DEFAULT_WANT_VERT_TOUCHDOWNS;
                WantHorizTouchdowns = DEFAULT_WANT_HORIZ_TOUCHDOWNS;
                textBoxSmoothingFactor.Text = DEFAULT_FLATNESS.ToString();

                InputCSVFile = Path.Combine(DEFAULT_INPUT_DIR, DEFAULT_INPUT_DIR_FILE);
                OutputDir = DEFAULT_OUTPUT_DIR;
                OutputGCodeFile = DEFAULT_OUTPUT_FILE;
            }
            finally
            {
                suppressAutoUpdate = false;
            }

        }

        /// +=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=
        /// <summary>
        /// Gets/sets the plate autogenerate list - never gets/sets null
        /// </summary>
        public List<PlateInfoContainer> AutoGenerateList
        {
            get
            {
                if (autoGenerateList == null) autoGenerateList = new List<PlateInfoContainer>();
                return autoGenerateList;
            }
            set
            {
                autoGenerateList = value;
                if (autoGenerateList == null) autoGenerateList = new List<PlateInfoContainer>();
            }
        }

        /// +=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=
        /// <summary>
        /// Gets/sets the InputCSVFile - never gets/sets null
        /// </summary>
        private string InputCSVFile
        {
            get
            {
                if (textBoxCSVFile.Text == null) textBoxCSVFile.Text = "";
                return textBoxCSVFile.Text;
            }
            set
            {
                textBoxCSVFile.Text = value;
                if (textBoxCSVFile.Text == null) textBoxCSVFile.Text = "";
            }
        }

        /// +=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=
        /// <summary>
        /// Gets/sets the InputCSVDir - never gets/sets null
        /// </summary>
        private string InputCSVDir
        {
            get
            {
                return Path.GetDirectoryName(InputCSVFile);
            }
        }

        /// +=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=
        /// <summary>
        /// Gets/sets the output Dir - never gets/sets null
        /// </summary>
        private string OutputDir
        {
            get
            {
                if (textBoxOutputDir.Text == null) textBoxOutputDir.Text = "";
                return textBoxOutputDir.Text;
            }
            set
            {
                textBoxOutputDir.Text = value;
                if (textBoxOutputDir.Text == null) textBoxOutputDir.Text = "";
            }
        }

        /// +=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=
        /// <summary>
        /// Gets/sets the output Gcode filename - never gets/sets null
        /// </summary>
        private string OutputGCodeFile
        {
            get
            {
                if (outputGCodeFile == null) OutputGCodeFile = DEFAULT_OUTPUT_FILE;
                return outputGCodeFile;
            }
            set
            {
                outputGCodeFile = value;
                if (outputGCodeFile == null) OutputGCodeFile = DEFAULT_OUTPUT_FILE;
            }
        }

        /// +=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=
        /// <summary>
        /// Gets/sets the Center text - never gets/sets null
        /// </summary>
        private string CenterText
        {
            get
            {
                if (textBoxCenterText.Text == null) textBoxCenterText.Text = "";
                return textBoxCenterText.Text;
            }
            set
            {
                textBoxCenterText.Text = value;
                if (textBoxCenterText.Text == null) textBoxCenterText.Text = "";
            }
        }

        /// +=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=
        /// <summary>
        /// Gets/sets the UL text - never gets/sets null
        /// </summary>
        private string ULText
        {
            get
            {
                if (textBoxULText.Text == null) textBoxULText.Text = "";
                return textBoxULText.Text;
            }
            set
            {
                textBoxULText.Text = value;
                if (textBoxULText.Text == null) textBoxULText.Text = "";
            }
        }

        /// +=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=
        /// <summary>
        /// Gets/sets the LL text - never gets/sets null
        /// </summary>
        private string LLText
        {
            get
            {
                if (textBoxLLText.Text == null) textBoxLLText.Text = "";
                return textBoxLLText.Text;
            }
            set
            {
                textBoxLLText.Text = value;
                if (textBoxLLText.Text == null) textBoxLLText.Text = "";
            }
        }

        /// +=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=
        /// <summary>
        /// Gets/sets the UR text - never gets/sets null
        /// </summary>
        private string URText
        {
            get
            {
                if (textBoxURText.Text == null) textBoxURText.Text = "";
                return textBoxURText.Text;
            }
            set
            {
                textBoxURText.Text = value;
                if (textBoxURText.Text == null) textBoxURText.Text = "";
            }
        }

        /// +=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=
        /// <summary>
        /// Gets/sets the LR text - never gets/sets null
        /// </summary>
        private string LRText
        {
            get
            {
                if (textBoxLRText.Text == null) textBoxLRText.Text = "";
                return textBoxLRText.Text;
            }
            set
            {
                textBoxLRText.Text = value;
                if (textBoxLRText.Text == null) textBoxLRText.Text = "";
            }
        }

        /// +=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=
        /// <summary>
        /// Gets/sets the want boundary rectangle flag
        /// </summary>
        private bool WantBoundaryRect
        {
            get
            {
                return checkBoxWantBoundaryRect.Checked;
            }
            set
            {
                checkBoxWantBoundaryRect.Checked = value;
            }
        }

        /// +=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=
        /// <summary>
        /// Gets/sets the want vertical touchdowns flag
        /// </summary>
        private bool WantVertTouchdowns
        {
            get
            {
                return checkBoxWantVerticalTouchdowns.Checked;
            }
            set
            {
                checkBoxWantVerticalTouchdowns.Checked = value;
            }
        }

        /// +=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=
        /// <summary>
        /// Gets/sets the want horizontal touchdowns flag
        /// </summary>
        private bool WantHorizTouchdowns
        {
            get
            {
                return checkBoxWantHorizTouchdowns.Checked;
            }
            set
            {
                checkBoxWantHorizTouchdowns.Checked = value;
            }
        }

        /// +=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=
        /// <summary>
        /// Gets/sets the fastMoveZHeight. Will never get/set zero or -ve
        /// </summary>
        private float FastMoveZHeight
        {
            get
            {
                if (fastMoveZHeight <= 0) fastMoveZHeight = DEFAULT_FASTMOVE_ZHEIGHT_IN;
                return fastMoveZHeight;
            }
            set
            {
                fastMoveZHeight = value;
                if (fastMoveZHeight <= 0) fastMoveZHeight = DEFAULT_FASTMOVE_ZHEIGHT_IN;
            }
        }

        /// +=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=
        /// <summary>
        /// Gets/sets the touchDownZCutDepth
        /// </summary>
        private float TouchDownZCutDepth
        {
            get
            {
                return touchDownZCutDepth;
            }
            set
            {
                touchDownZCutDepth = value;
            }
        }

        /// +=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=
        /// <summary>
        /// Gets/sets the centerZCutDepth 
        /// </summary>
        private float CenterZCutDepth
        {
            get
            {
                return centerZCutDepth;
            }
            set
            {
                centerZCutDepth = value;
            }
        }

        /// +=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=
        /// <summary>
        /// Gets/sets the cornerZCutDepth 
        /// </summary>
        private float CornerZCutDepth
        {
            get
            {
                return cornerZCutDepth;
            }
            set
            {
                cornerZCutDepth = value;
            }
        }

        /// +=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=
        /// <summary>
        /// Gets/sets the clearMoveZHeight 
        /// </summary>
        private float ClearMoveZHeight
        {
            get
            {
                return clearMoveZHeight;
            }
            set
            {
                clearMoveZHeight = value;
            }
        }

        /// +=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=
        /// <summary>
        /// Gets/sets the zFeedrate 
        /// </summary>
        private float ZFeedrate
        {
            get
            {
                return zFeedrate;
            }
            set
            {
                zFeedrate = value;
            }
        }

        /// +=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=
        /// <summary>
        /// Gets/sets the TextFeedrate 
        /// </summary>
        private float TextFeedRate
        {
            get
            {
                return textFeedRate;
            }
            set
            {
                textFeedRate = value;
            }
        }

        /// +=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=
        /// <summary>
        /// Gets/sets the FastFeedrate 
        /// </summary>
        private float FastFeedRate
        {
            get
            {
                return fastFeedRate;
            }
            set
            {
                fastFeedRate = value;
            }
        }

        /// +=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=
        /// <summary>
        /// Get the width of the panel
        /// </summary>
        private float PanelWidth
        {
            get
            {
                float panelWidth = DEFAULT_PANEL_WIDTH_IN;
                try
                {
                   panelWidth = (float)Convert.ToDouble(textBoxPlateWidth.Text);
                    if (panelWidth <= 0) return DEFAULT_PANEL_WIDTH_IN;
                }
                catch
                {
                }
                return panelWidth;
            }
        }


        /// +=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=
        /// <summary>
        /// Get the offset of the touchdowns from the border of the panel
        /// </summary>
        private float TouchDownOffset
        {
            get
            {
                float touchDownOffset = DEFAULT_TOUCHDOWN_OFFSET_IN;
                try
                {
                    touchDownOffset = (float)Convert.ToDouble(textBoxTouchDownOffset.Text);
                    if (touchDownOffset <= 0) return DEFAULT_TOUCHDOWN_OFFSET_IN;
                }
                catch
                {
                }
                return touchDownOffset;
            }
        }

        /// +=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=
        /// <summary>
        /// Get the border of the panel
        /// </summary>
        private float PanelMargin
        {
            get
            {
                float panelBorder = DEFAULT_PANEL_MARGIN_IN;
                try
                {
                    panelBorder = (float)Convert.ToDouble(textBoxPlateMargin.Text);
                    if (panelBorder <= DEFAULT_PANEL_MINMARGIN_IN) return DEFAULT_PANEL_MARGIN_IN;
                }
                catch
                {
                }
                return panelBorder;
            }
        }

        /// +=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=
        /// <summary>
        /// Get the height of the panel
        /// </summary>
        private float PanelHeight
        {
            get
            {
                float panelHeight = DEFAULT_PANEL_HEIGHT_IN;
                try
                {
                    panelHeight = (float)Convert.ToDouble(textBoxPlateHeight.Text);
                    if (panelHeight <= 0) return DEFAULT_PANEL_HEIGHT_IN;
                }
                catch
                {
                }
                return panelHeight;
            }
        }

        /// +=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=
        /// <summary>
        /// Gets the plate rectangle we use for generation. This is expected to have
        /// been set before anything is drawn
        /// </summary>
        private Rectangle PlateRectangle
        {
            get
            {
                if (plateRectangle == null) plateRectangle = new Rectangle(0, 0, 0, 0);
                return plateRectangle;
            }
            set
            {
                plateRectangle = value;
                if(plateRectangle==null) plateRectangle = new Rectangle(0, 0, 0, 0);
            }
        }

        /// +=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=
        /// <summary>
        /// Get the size of the panel in pixels
        /// </summary>
        private Size PanelSizeInPixels
        {
            get
            {
                return new Size((int)(PanelWidth * ScreenDPI_Y)- (panelLabelDisplay.Padding.Left + panelLabelDisplay.Padding.Right), (int)(PanelHeight * ScreenDPI_Y)- (panelLabelDisplay.Padding.Top + panelLabelDisplay.Padding.Bottom));
            }
        }

        /// +=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=
        /// <summary>
        /// Get the size of the panel touchdown X offset in pixels
        /// </summary>
        private int PanelTDOffset_X
        {
            get
            {
                return (int)(TouchDownOffset * ScreenDPI_X);
            }
        }

        /// +=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=
        /// <summary>
        /// Get the size of the panel touchdown X offset in pixels
        /// </summary>
        private int PanelTDOffset_Y
        {
            get
            {
                return (int)(TouchDownOffset * ScreenDPI_Y);
            }
        }

        /// +=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=
        /// <summary>
        /// Get the size of the panel X margin in pixels
        /// </summary>
        private int PanelMargin_X
        {
            get
            {
                return (int)(PanelMargin * ScreenDPI_X);
            }
        }

        /// +=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=
        /// <summary>
        /// Get the size of the panel Y margin in pixels
        /// </summary>
        private int PanelMargin_Y
        {
            get
            {
                return (int)(PanelMargin * ScreenDPI_Y);
            }
        }

        /// +=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=
        /// <summary>
        /// Get the panel center point in pixels
        /// </summary>
        private Point PanelPoint_Center
        {
            get
            {
                return new Point(panelLabelDisplay.Width/2, panelLabelDisplay.Height/2);
            }
        }

        /// +=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=
        /// <summary>
        /// Get the panel UL point in pixels
        /// </summary>
        private Point PanelPoint_UL
        {
            get
            {
                return new Point(plateRectangle.Left, plateRectangle.Top);
            }
        }

        /// +=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=
        /// <summary>
        /// Get the panel LL point in pixels
        /// </summary>
        private Point PanelPoint_LL
        {
            get
            {
                return new Point(plateRectangle.Left, plateRectangle.Bottom);
            }
        }

        /// +=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=
        /// <summary>
        /// Get the panel UR point in pixels
        /// </summary>
        private Point PanelPoint_UR
        {
            get
            {
                return new Point(plateRectangle.Right, plateRectangle.Top);
            }
        }

        /// +=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=
        /// <summary>
        /// Get the panel MidLeft point in pixels
        /// </summary>
        private Point PanelPoint_MidLeft
        {
            get
            {
                return new Point(plateRectangle.Left, plateRectangle.Bottom/2);
            }
        }

        /// +=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=
        /// <summary>
        /// Get the panel MidRight point in pixels
        /// </summary>
        private Point PanelPoint_MidRight
        {
            get
            {
                return new Point(plateRectangle.Right, plateRectangle.Bottom / 2);
            }
        }

        /// +=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=
        /// <summary>
        /// Get the panel MidTop point in pixels
        /// </summary>
        private Point PanelPoint_MidTop
        {
            get
            {
                return new Point(plateRectangle.Right/2, plateRectangle.Top);
            }
        }

        /// +=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=
        /// <summary>
        /// Get the panel MidBot point in pixels
        /// </summary>
        private Point PanelPoint_MidBot
        {
            get
            {
                return new Point(plateRectangle.Right / 2, plateRectangle.Bottom);
            }
        }

        /// +=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=
        /// <summary>
        /// Get the panel LR point in pixels
        /// </summary>
        private Point PanelPoint_LR
        {
            get
            {
                return new Point(plateRectangle.Right, plateRectangle.Bottom);
            }
        }

        /// +=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=
        /// <summary>
        /// Get the X dpi of the screen
        /// </summary>
        private int ScreenDPI_X
        {
            get
            {
                return this.DeviceDpi;
            }
        }

        /// +=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=
        /// <summary>
        /// Get the Y dpi of the screen
        /// </summary>
        private int ScreenDPI_Y
        {
            get
            {
                return this.DeviceDpi;
            }
        }

        /// +=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=
        /// <summary>
        /// Gets/sets the scaleFactorHeight
        /// </summary>
        private float ScaleFactorHeight
        {
            get
            {
                return scaleFactorHeight;
            }
            set
            {
                scaleFactorHeight = value;
            }
        }

        /// +=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=
        /// <summary>
        /// Gets/sets the scaleFactorWidth
        /// </summary>
        private float ScaleFactorWidth
        {
            get
            {
                return scaleFactorWidth;
            }
            set
            {
                scaleFactorWidth = value;
            }
        }

        /// +=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=
        /// <summary>
        /// Handle clicks on the buttonGenerateFromScreen button
        /// </summary>
        private void buttonGenerateFromScreen_Click(object sender, EventArgs e)
        {
            RegeneratePlate();
        }

        /// +=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=
        /// <summary>
        /// Regenerates the name plate
        /// </summary>
        private void RegeneratePlate()
        {
            panelLabelDisplay.Refresh();
        }

        /// +=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=
        /// <summary>
        /// Calculate the height scale factor to turn the text into accurately sized gcode
        /// </summary>
        private float CalcGCodeScaleFactor_Height()
        {
            Rectangle workingRect = PlateRectangle;
            float panelHeight = PanelHeight;
            return panelHeight / workingRect.Height;
        }

        /// +=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=
        /// <summary>
        /// Calculate the Width scale factor to turn the text into accurately sized gcode
        /// </summary>
        private float CalcGCodeScaleFactor_Width()
        {
            Rectangle workingRect = PlateRectangle;
            float panelWidth = PanelWidth;
            return panelWidth / workingRect.Width;
        }

        /// +=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=
        /// <summary>
        /// Handle a paint event on the panelLabelDisplay
        /// </summary>
        /// <param name="peArgs">the paint event args</param>
        private void panelLabelDisplay_Paint(object sender, PaintEventArgs peArgs)
        {
            // draw our display and create our gcode. This is done in the paint event
            // because we need the PaintEventArgs

            GraphicsPath path_Center = null;
            GraphicsPath path_UL = null;
            GraphicsPath path_UR = null;
            GraphicsPath path_LR = null;
            GraphicsPath path_LL = null;
            GraphicsPath path_Rect = null;
            GraphicsPath path_tdVert = null;
            GraphicsPath path_tdHoriz = null;


            try
            {
                string errStr = "";
                int retVal = ResetForNewGCodeOutput(out errStr);
                if(retVal!=0)
                {
                    MessageBox.Show(errStr);
                    return;
                }

                // set up a matrix
                Matrix translateMatrix = new Matrix();
                translateMatrix.Translate(0, 0);

                // output our standard header text
                OutputGCodeHeaderText();

                // get the path for the text

                // draw the UL corner Text
                path_UL = new GraphicsPath();
                DrawTextOnPanelAtPoint(path_UL, PlateTextDrawPosition.PT_UL, PanelPoint_UL, ULText, cornerTextFont);
                // perform the flatten, this converts all of the Bezier curves to line segments
                // and makes the creation of the resulting GCode much easier
                path_UL.Flatten(translateMatrix, workingFlatness);
                // draw the path on the screen
                peArgs.Graphics.DrawPath(new Pen(Color.White, 1), path_UL);
                // .NET uses the upper left as 0,0 we want 0,0 to be in the center of the panel so we have to flip Y and center both X and Y
                InvertForOutput(path_UL, ScaleFactorHeight, ScaleFactorWidth);
                // output the path as gcode
                OutputPathAsGCode(path_UL, CornerZCutDepth);

                // draw the LL corner Text
                path_LL = new GraphicsPath();
                DrawTextOnPanelAtPoint(path_LL, PlateTextDrawPosition.PT_LL, PanelPoint_LL, LLText, cornerTextFont);
                // perform the flatten, this converts all of the Bezier curves to line segments
                // and makes the creation of the resulting GCode much easier
                path_LL.Flatten(translateMatrix, workingFlatness);
                // draw the path on the screen
                peArgs.Graphics.DrawPath(new Pen(Color.White, 1), path_LL);
                // .NET uses the upper left as 0,0 we want 0,0 to be in the center of the panel so we have to flip Y and center both X and Y
                InvertForOutput(path_LL, ScaleFactorHeight, ScaleFactorWidth);
                // output the path as gcode
                OutputPathAsGCode(path_LL, CornerZCutDepth);

                // draw the UR corner Text
                path_UR = new GraphicsPath();
                DrawTextOnPanelAtPoint(path_UR, PlateTextDrawPosition.PT_UR, PanelPoint_UR, URText, cornerTextFont);
                // perform the flatten, this converts all of the Bezier curves to line segments
                // and makes the creation of the resulting GCode much easier
                path_UR.Flatten(translateMatrix, workingFlatness);
                // draw the path on the screen
                peArgs.Graphics.DrawPath(new Pen(Color.White, 1), path_UR);
                // .NET uses the upper left as 0,0 we want 0,0 to be in the center of the panel so we have to flip Y and center both X and Y
                InvertForOutput(path_UR, ScaleFactorHeight, ScaleFactorWidth);
                // output the path as gcode
                OutputPathAsGCode(path_UR, CornerZCutDepth);

                // draw the LR corner Text
                path_LR = new GraphicsPath();
                DrawTextOnPanelAtPoint(path_LR, PlateTextDrawPosition.PT_LR, PanelPoint_LR, LRText, cornerTextFont);
                // perform the flatten, this converts all of the Bezier curves to line segments
                // and makes the creation of the resulting GCode much easier
                path_LR.Flatten(translateMatrix, workingFlatness);
                // draw the path on the screen
                peArgs.Graphics.DrawPath(new Pen(Color.White, 1), path_LR);
                // .NET uses the upper left as 0,0 we want 0,0 to be in the center of the panel so we have to flip Y and center both X and Y
                InvertForOutput(path_LR, ScaleFactorHeight, ScaleFactorWidth);
                // output the path as gcode
                OutputPathAsGCode(path_LR, CornerZCutDepth);

                // draw the center text
                path_Center = new GraphicsPath();
                DrawTextOnPanelAtPoint(path_Center, PlateTextDrawPosition.PT_CENTER, PanelPoint_Center, CenterText, centerTextFont);
                // perform the flatten, this converts all of the Bezier curves to line segments
                // and makes the creation of the resulting GCode much easier
                path_Center.Flatten(translateMatrix, workingFlatness);
                // draw the path on the screen
                peArgs.Graphics.DrawPath(new Pen(Color.White, 1), path_Center);
                // .NET uses the upper left as 0,0 we want 0,0 to be in the center of the panel so we have to flip Y and center both X and Y
                InvertForOutput(path_Center, ScaleFactorHeight, ScaleFactorWidth);
                // output the path as gcode
                OutputPathAsGCode(path_Center, CenterZCutDepth);

                // do we want to add the boundary rectangle?
                if (WantBoundaryRect == true)
                {
                    path_Rect = new GraphicsPath();
                    AddBoundaryRect(path_Rect);
                    // perform the flatten, this converts all of the Bezier curves to line segments
                    // and makes the creation of the resulting GCode much easier
                    path_Rect.Flatten(translateMatrix, workingFlatness);
                    // draw the path on the screen
                    peArgs.Graphics.DrawPath(new Pen(Color.White, 1), path_Rect);
                    // .NET uses the upper left as 0,0 we want 0,0 to be in the center of the panel so we have to flip Y and center both X and Y
                    InvertForOutput(path_Rect, ScaleFactorHeight, ScaleFactorWidth);
                    // output the path as gcode
                    OutputPathAsGCode(path_Rect, CornerZCutDepth);
                }

                // do we want to add the touchdowns for the vertical screw holes?
                if (this.WantVertTouchdowns == true)
                {
                    path_tdVert = new GraphicsPath();
                    path_tdVert.AddEllipse(PanelPoint_MidTop.X, PanelPoint_MidTop.Y + PanelTDOffset_Y, DEFAULT_TOUCHDOWN_CIRCLE_RADIUS_IN, DEFAULT_TOUCHDOWN_CIRCLE_RADIUS_IN);
                    path_tdVert.AddEllipse(PanelPoint_MidBot.X, PanelPoint_MidBot.Y - PanelTDOffset_Y, DEFAULT_TOUCHDOWN_CIRCLE_RADIUS_IN, DEFAULT_TOUCHDOWN_CIRCLE_RADIUS_IN);
                    // perform the flatten, this converts all of the Bezier curves to line segments
                    // and makes the creation of the resulting GCode much easier
                    path_tdVert.Flatten(translateMatrix, workingFlatness);
                    // draw the path on the screen
                    peArgs.Graphics.DrawPath(new Pen(Color.White, 1), path_tdVert);
                    // .NET uses the upper left as 0,0 we want 0,0 to be in the center of the panel so we have to flip Y and center both X and Y
                    InvertForOutput(path_tdVert, ScaleFactorHeight, ScaleFactorWidth);
                    // output the path as gcode
                    OutputPathAsGCode(path_tdVert, TouchDownZCutDepth);
                }

                // do we want to add the touchdowns for the horizontal screw holes?
                if (this.WantHorizTouchdowns == true)
                {
                    path_tdHoriz = new GraphicsPath();
                    path_tdHoriz.AddEllipse(PanelPoint_MidLeft.X + PanelTDOffset_X, PanelPoint_MidLeft.Y , DEFAULT_TOUCHDOWN_CIRCLE_RADIUS_IN, DEFAULT_TOUCHDOWN_CIRCLE_RADIUS_IN);
                    path_tdHoriz.AddEllipse(PanelPoint_MidRight.X - PanelTDOffset_X, PanelPoint_MidRight.Y, DEFAULT_TOUCHDOWN_CIRCLE_RADIUS_IN, DEFAULT_TOUCHDOWN_CIRCLE_RADIUS_IN);
                    // perform the flatten, this converts all of the Bezier curves to line segments
                    // and makes the creation of the resulting GCode much easier
                    path_tdHoriz.Flatten(translateMatrix, workingFlatness);
                    // draw the path on the screen
                    peArgs.Graphics.DrawPath(new Pen(Color.White, 1), path_tdHoriz);
                    // .NET uses the upper left as 0,0 we want 0,0 to be in the center of the panel so we have to flip Y and center both X and Y
                    InvertForOutput(path_tdHoriz, ScaleFactorHeight, ScaleFactorWidth);
                    // output the path as gcode
                    OutputPathAsGCode(path_tdHoriz, TouchDownZCutDepth);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.Message);
            }
            finally
            {
                // dispose of the paths
                if (path_Center != null) path_Center.Dispose();
                path_Center = null;
                if (path_UL != null) path_UL.Dispose();
                path_UL = null;
                if (path_LL != null) path_LL.Dispose();
                path_LL = null;
                if (path_UR != null) path_UR.Dispose();
                path_UR = null;
                if (path_LR != null) path_LR.Dispose();
                path_LR = null;
                if (path_Rect != null) path_Rect.Dispose();
                path_Rect = null;
                if (path_tdVert != null) path_tdVert.Dispose();
                path_tdVert = null;
                if (path_tdHoriz != null) path_tdHoriz.Dispose();
                path_tdHoriz = null;
            }

            OutputGCodeFooterText();
        }

        /// +=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=
        /// <summary>
        /// Draws the text on the screen and generates a graphics path to do so
        /// </summary>
        /// <param name="targetPoint">the target point, this is different depending on the drawPosition</param>
        /// <param name="drawPosition">the draw position</param>
        /// <param name="targetPath">the path we add to</param>
        /// <param name="stringText">the text to draw, cannot be null</param>
        /// <param name="fontToUse">the font we draw the text with</param>
        private void DrawTextOnPanelAtPoint(GraphicsPath targetPath, PlateTextDrawPosition drawPosition, Point targetPoint, string stringText, Font fontToUse)
        {
            // sanity checks
            if (stringText == null) throw new Exception("Null text on input");
            if (targetPath == null) throw new Exception("Null graphics path on input");
            if (fontToUse == null) throw new Exception("Null font on input");

            // set up our font formatting. It is always this for every position
            StringFormat format = StringFormat.GenericDefault;
            // set these now - they are the defaults
            format.LineAlignment = StringAlignment.Near;
            format.Alignment = StringAlignment.Near;
            // get the size in ems
            float emSize = CalcFontSizeInEMs((float)fontToUse.SizeInPoints);

            // do this as a trial first so we can figure out the size for positioning
            // the size width is different depending on the text and the height depending on the font size

            // Create a GraphicsPath object.
            GraphicsPath workingPath = new GraphicsPath();
            // set up a dummy origin
            Point workingOrigin = new Point(0,0);
            // Add the string to the path.
            workingPath.AddString(stringText, fontToUse.FontFamily, (int)fontToUse.Style, emSize, workingOrigin, format);
            // now get the bounds 
            RectangleF boundRect = workingPath.GetBounds();
            if (drawPosition == PlateTextDrawPosition.PT_CENTER)
            {
                // now adjust the origin to place it, Here the target point is the center of the plate
                workingOrigin = new Point(targetPoint.X - (int)(boundRect.Width / 2) - (int)boundRect.X, targetPoint.Y - (int)(boundRect.Height / 2) - (int)boundRect.Y);
            }
            else if (drawPosition == PlateTextDrawPosition.PT_UL)
            {
                // now adjust the origin to place it, Here the target point is the upper left corner of the plate
                workingOrigin = new Point(targetPoint.X + PanelMargin_X, targetPoint.Y - (int)(boundRect.Height / 2) + PanelMargin_Y);
            }
            else if (drawPosition == PlateTextDrawPosition.PT_LL)
            {
                // now adjust the origin to place it, Here the target point is the bottom left corner of the plate
                workingOrigin = new Point(targetPoint.X + PanelMargin_X, targetPoint.Y - (int)(boundRect.Height / 2) - PanelMargin_Y - (int)(boundRect.Height));
            }
            else if (drawPosition == PlateTextDrawPosition.PT_UR)
            {
                // now adjust the origin to place it, Here the target point is the upper right corner of the plate
                workingOrigin = new Point(targetPoint.X - (int)(boundRect.Width + PanelMargin_X + PanelMargin_X), targetPoint.Y - (int)(boundRect.Height / 2) + PanelMargin_Y);
            }
            else if (drawPosition == PlateTextDrawPosition.PT_LR)
            {
                // now adjust the origin to place it, Here the target point is the upper right corner of the plate
                workingOrigin = new Point(targetPoint.X - (int)(boundRect.Width + PanelMargin_X + PanelMargin_X), targetPoint.Y - (int)(boundRect.Height / 2) - PanelMargin_Y - (int)(boundRect.Height));
            }
            else
            {
                // should never happen
                throw new Exception("Unknown draw position");
            }
            // dispose of the temporary path
            if (workingPath != null) workingPath.Dispose();
            workingPath = null;

            // Add the string to the targetPath with a new origin
            targetPath.AddString(stringText, fontToUse.FontFamily, (int)fontToUse.Style, emSize, workingOrigin, format);

        }

        /// +=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=
        /// <summary>
        /// Adds a boundary rectangle to the path
        /// </summary>
        /// <param name="workingPath">the path to add the rectangle to</param>
        private void AddBoundaryRect(GraphicsPath workingPath)
        {
            if (workingPath == null) return;
            Rectangle workingRect = PlateRectangle;
            workingPath.AddLine(new Point(workingRect.Left, workingRect.Top), new Point(workingRect.Right, workingRect.Top));
            workingPath.AddLine(new Point(workingRect.Right, workingRect.Top), new Point(workingRect.Right, workingRect.Bottom));
            workingPath.AddLine(new Point(workingRect.Right, workingRect.Bottom), new Point(workingRect.Left, workingRect.Bottom));
            workingPath.AddLine(new Point(workingRect.Left, workingRect.Bottom), new Point(workingRect.Left, workingRect.Top));
        }

        /// +=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=
        /// <summary>
        /// Calculates the font size in EMs
        /// </summary>
        /// <param name="fontHeightInPoints">the font height in points</param>
        /// <returns>the font size in ems</returns>
        private float CalcFontSizeInEMs(float fontHeightInPoints)
        {
            return (ScreenDPI_Y * fontHeightInPoints) / FONT_POINTS_PER_INCH;
        }

        /// +=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=
        /// <summary>
        /// Converts a path to a GCode and displays the GCode in the richTextBoxGCode box
        /// </summary>
        /// <param name="graphicsPath">the graphics path</param>
        /// <param name="zCutDepth">the cut depth</param>
        /// <returns>z success, nz fail</returns>
        private int OutputPathAsGCode(GraphicsPath graphicsPath, float zCutDepth)
        {
            StringBuilder sb = new StringBuilder();
            // add a dummy line
            sb.AppendLine("");

            if (graphicsPath == null) return 10;
            try 
            { 
                // test if this exists. If the user input "" or " " with nothing to draw 
                // accessing the PathPoints will throw an ArgumentException
                if (graphicsPath.PathPoints == null) return 0; 
            }
            catch (System.ArgumentException)
            {
                // this is ok, just means no data for the path, ignore
                return 0;
            }

            // get our point and point type arrays from the path
            PointF[] pathPoints = graphicsPath.PathPoints;
            byte[] pathTypes = graphicsPath.PathTypes;

            // some sanity checks
            if (pathPoints.Length == 0) return 20;
            if (pathPoints.Length != pathTypes.Length) return 30;

            bool atPathEndFlag = false;
            // loop through each point
            for (int i = 0; i < pathPoints.Length; i++)
            {
                PointF workingPoint = pathPoints[i];
                byte workingFlag = pathTypes[i];

                // detect if we have a path end flag
                if ((workingFlag & POINTISPATHEND) == POINTISPATHEND) atPathEndFlag = true;
                else atPathEndFlag = false;

                // strip off everything but the low four bits which contain the point type
                workingFlag = (byte)(workingFlag & POINTTYPEMASK);

                // what we do depends on the start flag
                if (workingFlag == POINTISSTART)
                {
                    // start of new figure. Fast move to XY coord and drop the bit into the work
                    sb.AppendLine("G01 X" + Math.Round(pathPoints[i].X, 6).ToString() + " Y" + Math.Round(pathPoints[i].Y, 6).ToString() + " F" + FastFeedRate.ToString());
                    sb.AppendLine("G01 Z" + zCutDepth.ToString() + " F" + ZFeedrate.ToString());

                }
                else if (workingFlag == POINTISEND)
                {
                    // start or end of line. Just go to that point with the bit where it is
                    sb.AppendLine("G01 X" + Math.Round(pathPoints[i].X, 6).ToString() + " Y" + Math.Round(pathPoints[i].Y, 6).ToString() + " F" + TextFeedRate.ToString());
                }
                else
                {
                    throw new Exception("Unknown point flag: " + workingFlag.ToString("X"));
                }
                // were we also at the end of a figure?
                if (atPathEndFlag == true)
                {
                    // pull the tool out of the work
                    sb.AppendLine("G01 Z" + FastMoveZHeight.ToString() + " F" + ZFeedrate.ToString());
                    sb.AppendLine("");
                }
            }

            // add a dummy line
            sb.AppendLine("");
            richTextBoxGCode.Text = richTextBoxGCode.Text + sb.ToString();

            return 0;
        }

        /// +=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=
        /// <summary>
        /// Does everything necessary to reset for new GCode output
        /// </summary>
        /// <param name="errStr">the error string</param>
        /// <returns>z succes, nz fail</returns>
        private int ResetForNewGCodeOutput(out string errStr)
        {
            // set this now
            errStr = "reset successful";

            // clean up from the previous
            richTextBoxGCode.Clear();
            if (centerTextFont != null) centerTextFont.Dispose();
            centerTextFont = null;
            if (cornerTextFont != null) cornerTextFont.Dispose();
            cornerTextFont = null;

            // set the plate rectangle now, other things will use this later
            plateRectangle = new Rectangle(0, 0, panelLabelDisplay.Width - panelLabelDisplay.Padding.Right, panelLabelDisplay.Height - panelLabelDisplay.Padding.Bottom);
            // now we have the plate rectangle set these for later use
            ScaleFactorHeight = CalcGCodeScaleFactor_Height();
            ScaleFactorWidth = CalcGCodeScaleFactor_Width();

            // get these values off the screen
            try { centerZCutDepth = (float)Convert.ToDouble(textBoxCenterZCutDepth.Text); }
            catch { errStr = "CenterZCutDepth is not valid"; return 1; }
            try { cornerZCutDepth = (float)Convert.ToDouble(textBoxCornerZCutDepth.Text); }
            catch { errStr = "CornerZCutDepth is not valid"; return 1; }
            try { touchDownZCutDepth = (float)Convert.ToDouble(textBoxTouchDownZDepth.Text); }
            catch { errStr = "TouchDownZCutDepth is not valid"; return 1; }
            try { clearMoveZHeight = (float)Convert.ToDouble(textBoxClearZHeight.Text); }
            catch { errStr = "ClearZHeight is not valid"; return 1; }
            try { fastMoveZHeight = (float)Convert.ToDouble(textBoxFastMoveZHeight.Text); }
            catch { errStr = "FastMoveZHeight is not valid"; return 1; }

            try { zFeedrate = (float)Convert.ToDouble(textBoxZFeedRate.Text); }
            catch { errStr = "Z Feed Rate is not valid"; return 1; }
            try { textFeedRate = (float)Convert.ToDouble(textBoxTextFeedRate.Text); }
            catch { errStr = "Text Feed Rate is not valid"; return 1; }
            try { fastFeedRate = (float)Convert.ToDouble(textBoxFastFeedRate.Text); }
            catch { errStr = "Fast Feed Rate is not valid"; return 1; }

            // set the fonts we use
            FontConverter fontConv = new FontConverter();
            centerTextFont = fontConv.ConvertFromInvariantString(textBoxCenterTextFont.Text) as Font;
            cornerTextFont = fontConv.ConvertFromInvariantString(textBoxCornerTextFont.Text) as Font;

            try { workingFlatness = (float)Convert.ToDouble(textBoxSmoothingFactor.Text); }
            catch { errStr = "Smoothing Factor is not valid"; return 1; }

            return 0;
        }

        /// +=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=
        /// <summary>
        /// Outputs the GCode header text to the GCode output panel
        /// </summary>
        private void OutputGCodeHeaderText()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("(GCode Generated by NamePlateGenerator)");
            sb.AppendLine("(http://www.OfItselfSo.com/NamePlateGenerator)");
            sb.AppendLine("");
            sb.AppendLine("G90 (set absolute distance mode)");
            sb.AppendLine("G20 (Use Inches)");
            sb.AppendLine("G61 (Exact stop)");
            sb.AppendLine("G17 (XY plane selection)");
            //sb.AppendLine("G92 0.0 Y 0.0 (SetPosition)");
            sb.AppendLine("M03 (Start spindle)");
            sb.AppendLine("G04 P1 (Pause to let the spindle start)");
            sb.AppendLine("");

            richTextBoxGCode.Text = sb.ToString();
        }

        /// +=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=
        /// <summary>
        /// Outputs the GCode footer text to the GCode output panel
        /// </summary>
        private void OutputGCodeFooterText()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("G00 Z" + this.ClearMoveZHeight.ToString() + " (set height)");
            sb.AppendLine("G01 X0 Y0" + " F" + FastFeedRate.ToString() + " (return to origin)");
            sb.AppendLine("G01 X0 Y10" + " F" + FastFeedRate.ToString() + " (move vertically off plate for change)");
            sb.AppendLine("M5 (stop spindle)");
            sb.AppendLine("M30 (machine stop)");
            sb.AppendLine("M2 (end program)");

            richTextBoxGCode.Text = richTextBoxGCode.Text + "\r" + sb.ToString();
        }

        /// +=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=
        /// <summary>
        /// Inverts the path so our GCode comes out correctly. .NET sets the 0,0 point
        /// at the top left and increasing Y goes downwards from there. We want an origin
        /// at the center of the panel putting a positive X and Y in the upper right
        /// quadrant and a negative X and Y in the lower left quadrant. A matrix transform
        /// does this for us automatically if we set it up correctly.
        /// 
        /// The transform here is also set up to do the scaling conversion from pixels to inches
        /// </summary>
        /// <param name="gPath">the graphics path</param>
        /// <param name="scaleFactorHeightIn">the height scale factor</param>
        /// <param name="scaleFactorWidthIn">the width scale factor</param>
        private void InvertForOutput(GraphicsPath gPath, float scaleFactorHeightIn, float scaleFactorWidthIn)
        {
            // set up the matrix that does the flip, and puts the y=0 coord in the center of the panel
            using (Matrix flipYMatrix = new Matrix(1, 0, 0, -1, 0, panelLabelDisplay.Height / 2))
            {
                using (Matrix transformMatrix = new Matrix())
                {
                    transformMatrix.Multiply(flipYMatrix);
                    // this scales us down from pixels to the units we are using (inches or mm)
                    transformMatrix.Scale(scaleFactorWidthIn, scaleFactorHeightIn, MatrixOrder.Append);
                    // this puts the 0 x coord in the center of the panel
                    transformMatrix.Translate((panelLabelDisplay.Width / 2)*-1, 0);
                    gPath.Transform(transformMatrix);
                    //Or e.Graphics.Transform = TransformMatrix;           
                }
            }
        }

        /// +=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=
        /// <summary>
        /// Save the GCode text on the screen to a file. We check NOTHING.
        /// </summary>
        /// <param name="outputDirIn">the directory to write to</param>
        /// <param name="filenameIn">the filename to save to</param>
        private void SaveGCodeToFile(string outputDirIn, string filenameIn)
        {
            System.IO.File.WriteAllText(Path.Combine(outputDirIn, filenameIn), richTextBoxGCode.Text);
        }

        /// +=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=
        /// <summary>
        /// Handles clicks on the save gcode button
        /// </summary>
        private void buttonSaveGCode_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.InitialDirectory = OutputDir;
                saveFileDialog1.Title = "Save GCode";
                saveFileDialog1.CheckFileExists = false;
                saveFileDialog1.CheckPathExists = true;
                saveFileDialog1.DefaultExt = "ngc";
                saveFileDialog1.Filter = "NGC files (*.ngc)|*.ngc";
                saveFileDialog1.FilterIndex = 1;
                saveFileDialog1.RestoreDirectory = true;
                saveFileDialog1.FileName = OutputGCodeFile;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string OutputDir = Path.GetDirectoryName(saveFileDialog1.FileName);
                    string outFileName = Path.GetFileName(saveFileDialog1.FileName);
                    SaveGCodeToFile(OutputDir, outFileName);
                    MessageBox.Show("Saved");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message+ "\n\noccurred when saving file " + Path.Combine(OutputDir, DEFAULT_OUTPUT_FILE + DEFAULT_OUTPUT_FILE_EXT));
            }
        }

        /// +=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=
        /// <summary>
        /// Handles changes to the plate width
        /// </summary>
        private void textBoxPlateWidth_TextChanged(object sender, EventArgs e)
        {
            if (suppressAutoUpdate == true) return;

            // reset the size now
            panelLabelDisplay.Size = PanelSizeInPixels;
            // regenerate the plate
            RegeneratePlate();
        }

        /// +=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=
        /// <summary>
        /// Handles changes to the plate height
        /// </summary>
        private void textBoxPlateHeight_TextChanged(object sender, EventArgs e)
        {
            if (suppressAutoUpdate == true) return;

            // reset the size now
            panelLabelDisplay.Size = PanelSizeInPixels;
            // regenerate the plate
            RegeneratePlate();
        }

        /// +=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=
        /// <summary>
        /// Handles changes to the plate height
        /// </summary>
        private void textBoxCenterTextHeight_TextChanged(object sender, EventArgs e)
        {
            if (suppressAutoUpdate == true) return;

            // regenerate the plate
            RegeneratePlate();
        }

        /// +=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=
        /// <summary>
        /// Handles clicks on the center text font picker button
        /// </summary>
        private void buttonCenterTextFontPicker_Click(object sender, EventArgs e)
        {
            FontConverter fontConv = new FontConverter();
            FontDialog fontDlg = new FontDialog();

            fontDlg.ShowColor = false;
            fontDlg.ShowApply = false;
            fontDlg.ShowEffects = false;
            fontDlg.ShowHelp = false;

            fontDlg.Font = fontConv.ConvertFromInvariantString(textBoxCenterTextFont.Text) as Font;

            if (fontDlg.ShowDialog() != DialogResult.Cancel)
            {
                // place it out here. The FontConverter will give us a nice string defining the font
                string fontText = fontConv.ConvertToInvariantString(fontDlg.Font);
                // did it change?
                if (fontText != textBoxCenterTextFont.Text)
                {
                    // yes it changed, regenerate
                    textBoxCenterTextFont.Text = fontConv.ConvertToInvariantString(fontDlg.Font);
                    // regenerate the plate
                    RegeneratePlate();
                }
            }
        }

        /// +=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=
        /// <summary>
        /// Handles clicks on the corner text font picker button
        /// </summary>
        private void buttonCornerTextFontPicker_Click(object sender, EventArgs e)
        {
            FontConverter fontConv = new FontConverter();
            FontDialog fontDlg = new FontDialog();

            fontDlg.ShowColor = false;
            fontDlg.ShowApply = false;
            fontDlg.ShowEffects = false;
            fontDlg.ShowHelp = false;

            fontDlg.Font = fontConv.ConvertFromInvariantString(textBoxCornerTextFont.Text) as Font;

            if (fontDlg.ShowDialog() != DialogResult.Cancel)
            {
                // place it out here. The FontConverter will give us a nice string defining the font
                string fontText = fontConv.ConvertToInvariantString(fontDlg.Font);
                // did it change?
                if (fontText != textBoxCornerTextFont.Text)
                {
                    // yes it changed, regenerate
                    textBoxCornerTextFont.Text = fontConv.ConvertToInvariantString(fontDlg.Font);
                    // regenerate the plate
                    RegeneratePlate();
                }
            }
        }

        /// +=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=
        /// <summary>
        /// Handles clicks on the pick CSV file button
        /// </summary>
        private void buttonPickCSVFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = InputCSVDir,
                Title = "Browse Txt/CSV Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "csv",
                Filter = "txt files (*.txt)|*.txt|csv files (*.csv)|*.csv",
                //Filter = "txt files (*.txt)|*.txt",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            // set the csv file name
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBoxCSVFile.Text = openFileDialog1.FileName;
            }
        }

        /// +=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=
        /// <summary>
        /// Handles clicks on the pick out dir button
        /// </summary>
        private void buttonPickOutDir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = true;
            folderDlg.SelectedPath = OutputDir;

            // Show the FolderBrowserDialog.  
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBoxOutputDir.Text = folderDlg.SelectedPath;
                Environment.SpecialFolder root = folderDlg.RootFolder;
            }
        }

        /// +=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=
        /// <summary>
        /// This will autogenerate an output file for each line in the CSV file
        /// </summary>
        private void buttonGenerateFrom5ColCSV_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("This will create one output file for every line in the CSV file.\n\nDo you want to proceed?", "Autogenerate Plates from CSV", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No) return;

            // user wants to generate

            // do we have an input csv file
            if ((InputCSVFile==null) || (InputCSVFile.Length<6))
            {
                MessageBox.Show("Invalid CSV File");
                return;
            }
            // does the input CSV File exist
            if(File.Exists(InputCSVFile) == false)
            {
                MessageBox.Show("Input CSV file does not exist");
                return;
            }
            // do we have an output dir
            if ((OutputDir == null) || (OutputDir.Length < 6))
            {
                MessageBox.Show("Invalid Output Dir");
                return;
            }
            // does the input OutputDir exist
            if (Directory.Exists(OutputDir) == false)
            {
                MessageBox.Show("Output Directory does not exist");
                return;
            }

            // clear the existing processing list
            AutoGenerateList = new List<PlateInfoContainer>();

            // read the csv file into our processing list
            using (StreamReader reader = new StreamReader(InputCSVFile))
            {
                int lineCount = 1;
                while (reader.EndOfStream == false)
                {
                    string line = reader.ReadLine();
                    string[] values = line.Split(DEFAULT_CSV_SEPARATOR);
                    if(values.Length!=5)
                    {
                        MessageBox.Show("Invalid number of values on line "+lineCount.ToString());
                        return;
                    }
                    // build a new holding container for the info
                    PlateInfoContainer currentPlate = new PlateInfoContainer(values[0], values[1], values[2], values[3], values[4]);
                    // add it
                    AutoGenerateList.Add(currentPlate);
                    lineCount++;
                }
            }

            if(AutoGenerateList.Count==-0)
            {
                MessageBox.Show("No lines found in the csv file");
                return;
            }

            // now we process the AutoGenerateList
            foreach (PlateInfoContainer plateObj in AutoGenerateList)
            {
                CenterText = plateObj.CenterText;
                ULText = plateObj.ULText;
                URText = plateObj.URText;
                LRText = plateObj.LRText;
                LLText = plateObj.LLText;
                // regenerate
                RegeneratePlate();
                try
                {
                    // save the plate info, the name is just the centertext with no spaces
                    SaveGCodeToFile(OutputDir, plateObj.CenterText.Replace(" ", "")+ DEFAULT_OUTPUT_FILE_EXT);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex.Message + "\n\noccurred when saving file " + Path.Combine(OutputDir, plateObj.CenterText.Replace(" ", "") + DEFAULT_OUTPUT_FILE_EXT));
                    return;
                }
            }
            MessageBox.Show("Done");
        }
    }
}
