/**************************************************************************
 *                                                                        *
 *  File:        InitVar.cs                                               *
 *  Copyright:   (c) 2023, grupa 1310A, echipa 17                         *    
 *  Description: This file contains the class with the initialization     *
 *               of the variables                                         *
 *                                                                        *
 *                                                                        *
 **************************************************************************/


//using DRPCIV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenereazaIntrebari;
using IntrebareNmSpc;

namespace InitVariabile
{
    public class InitVar
    {
            /// <summary>
            /// This is the function for initialization of the variables
            /// </summary>
            /// <param name="variableContainer"></param>
            /// <param name="intrebariLength"></param>
            public static void InitializeazaVariabile(IVariableContainer variableContainer, int intrebariLength)
            {
                variableContainer.NrIntrebariInitiale = 26;
                variableContainer.NrIntrebariRamase = variableContainer.NrIntrebariInitiale;
                variableContainer.MinuteTimer = 6;

                variableContainer.NrMaxRaspCorecte = variableContainer.NrIntrebariInitiale;
                variableContainer.NrDiferentaRaspCorecte = 5;
                variableContainer.NrMinRaspCorecte = variableContainer.NrMaxRaspCorecte - variableContainer.NrDiferentaRaspCorecte + 1;
                variableContainer.NrMaxRaspGresite = 5;
            }
    }
}
