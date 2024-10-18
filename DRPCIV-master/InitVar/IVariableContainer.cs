/**************************************************************************
 *                                                                        *
 *  File:        IVariableContainer.cs                                    *
 *  Copyright:   (c) 2023, grupa 1310A, echipa 17                         *    
 *  Description: This file contains the interface of Variable Container   *
 *                                                                        *
 *                                                                        *
 **************************************************************************/


//using DRPCIV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitVariabile
{
    /// <summary>
    /// Interface of Variable Container with getters and setters
    /// </summary>
    public interface IVariableContainer
    {
        int NrIntrebariInitiale { get; set; }
        int NrIntrebariRamase { get; set; }
        int MinuteTimer { get; set; }
        int NrMaxRaspCorecte { get; set; }
        int NrDiferentaRaspCorecte { get; set; }
        int NrMinRaspCorecte { get; set; }
        int NrMaxRaspGresite { get; set; }
    }
}