/**************************************************************************
 *                                                                        *
 *  File:        Intrebare.cs                                             *
 *  Copyright:   (c) 2023, grupa 1310A, echipa 17                         *    
 *  Description: This file contains the class with the initialization     *
 *               of the questions                                         *
 *                                                                        *
 *                                                                        *
 **************************************************************************/


//using DRPCIV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntrebareNmSpc	
{
    /// <summary>
    /// Class with the initialization of the questions with getters and setters
    /// </summary>
    public class Intrebare
	{
		public string intrebare { get; set; }
		public List<string> variante { get; set; }
		public string raspunsuri_corecte { get; set; }
		public string src_imagine { get; set; }
	}
}
