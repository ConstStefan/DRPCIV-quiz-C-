/**************************************************************************
 *                                                                        *
 *  File:        MyExceptions.cs                                          *
 *  Copyright:   (c) 2023, grupa 1310A, echipa 17                         *    
 *  Description: This file contains the implementation of exception       *
 *               class                                                    *
 *                                                                        *
 *                                                                        *
 **************************************************************************/


using System;
using System.Windows.Forms;

/// <summary>
/// This class inherits the Exception base class
/// </summary>
public class MyException : Exception
{
    public MyException(string message) : base(message)
    {
    }

    /// <summary>
    /// Creates and returns a string representation of the current exception
    /// </summary>
    public override string ToString()
    {
        return Message;
    }
}
