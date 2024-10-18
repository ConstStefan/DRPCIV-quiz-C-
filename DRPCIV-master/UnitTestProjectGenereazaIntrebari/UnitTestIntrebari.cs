/**************************************************************************
 *                                                                        *
 *  File:        UniTestIntrebari.cs                                      *
 *  Copyright:   (c) 2023, grupa 1310A, echipa 17                         *    
 *  Description: This file contains the implementation of test methods    *
 *               for the questions                                        *
 *                                                                        *
 *                                                                        *
 **************************************************************************/


using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace IntrebareNmSpc.Tests
{
    [TestClass]
    public class IntrebareTests
    {
        /// <summary>
        /// Test for set and get correct values of the questions
        /// </summary>
        [TestMethod]
        public void Intrebare_WithProperties_SetAndGetCorrectValues()
        {
            // Arrange 
            var intrebareText = "What is the capital of France?";
            var variante = new List<string>() { "Paris", "Rome", "Madrid", "Berlin" };
            var raspunsuriCorecte = "A";
            var srcImagine = "france_capital.jpg";

            // Act
            var intrebare = new Intrebare()
            {
                intrebare = intrebareText,
                variante = variante,
                raspunsuri_corecte = raspunsuriCorecte,
                src_imagine = srcImagine
            };

            // Assert
            Assert.AreEqual(intrebareText, intrebare.intrebare);
            CollectionAssert.AreEqual(variante, intrebare.variante);
            Assert.AreEqual(raspunsuriCorecte, intrebare.raspunsuri_corecte);
            Assert.AreEqual(srcImagine, intrebare.src_imagine);
        }
    }
}
