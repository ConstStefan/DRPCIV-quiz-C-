/**************************************************************************
 *                                                                        *
 *  File:        VariableContainer.cs                                     *
 *  Copyright:   (c) 2023, grupa 1310A, echipa 17                         *    
 *  Description: This file contains the class of Variable Container       *
 *                                                                        *
 *                                                                        *
 **************************************************************************/

using DRPCIV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InitVariabile;

namespace DRPCIV
{
    /// <summary>
    /// Class of Variable Container with getters and setters
    /// </summary>
    public class VariableContainer : IVariableContainer
    {
        public int NrIntrebariInitiale { get; set; }
        public int NrIntrebariRamase { get; set; }
        public int MinuteTimer { get; set; }
        public int NrMaxRaspCorecte { get; set; }
        public int NrDiferentaRaspCorecte { get; set; }
        public int NrMinRaspCorecte { get; set; }
        public int NrMaxRaspGresite { get; set; }
    }
}
