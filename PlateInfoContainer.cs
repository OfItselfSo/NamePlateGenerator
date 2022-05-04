using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    /// <summary>
    /// A class to contain plate details information
    /// </summary>
    public class PlateInfoContainer
    {
        private string centerText = "";
        private string ulText = "";
        private string urText = "";
        private string lrText = "";
        private string llText = "";

        /// +=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="centerTextIn">the center text</param>
        /// <param name="ulTextIn">the ul text</param>
        /// <param name="urTextIn">the ur text</param>
        /// <param name="lrTextIn">the lr text</param>
        /// <param name="llTextIn">the ll text</param>
        public PlateInfoContainer(string centerTextIn, string ulTextIn, string urTextIn, string lrTextIn, string llTextIn)
        {
            CenterText = centerTextIn;
            ULText = ulTextIn;
            URText = urTextIn;
            LRText = lrTextIn;
            LLText = llTextIn;
        }

        /// +=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=
        /// <summary>
        /// Gets/sets the Center text - never gets/sets null
        /// </summary>
        public string CenterText
        {
            get
            {
                if (centerText == null) centerText = "";
                return centerText;
            }
            set
            {
                centerText = value;
                if (centerText == null) centerText = "";
            }
        }

        /// +=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=
        /// <summary>
        /// Gets/sets the UL text - never gets/sets null
        /// </summary>
        public string ULText
        {
            get
            {
                if (ulText == null) ulText = "";
                return ulText;
            }
            set
            {
                ulText = value;
                if (ulText == null) ulText = "";
            }
        }

        /// +=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=
        /// <summary>
        /// Gets/sets the LL text - never gets/sets null
        /// </summary>
        public string LLText
        {
            get
            {
                if (llText == null) llText = "";
                return llText;
            }
            set
            {
                llText = value;
                if (llText == null) llText = "";
            }
        }

        /// +=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=
        /// <summary>
        /// Gets/sets the UR text - never gets/sets null
        /// </summary>
        public string URText
        {
            get
            {
                if (urText == null) urText = "";
                return urText;
            }
            set
            {
                urText = value;
                if (urText == null) urText = "";
            }
        }

        /// +=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=
        /// <summary>
        /// Gets/sets the LR text - never gets/sets null
        /// </summary>
        public string LRText
        {
            get
            {
                if (lrText == null) lrText = "";
                return lrText;
            }
            set
            {
                lrText = value;
                if (lrText == null) lrText = "";
            }
        }

    }
}
