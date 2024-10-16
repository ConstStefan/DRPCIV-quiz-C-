/**************************************************************************
 *                                                                        *
 *  File:        UniTestInitVar.cs                                        *
 *  Copyright:   (c) 2023, grupa 1310A, echipa 17                         *    
 *  Description: This file contains the implementation of test methods    *
 *               for variables                                            *
 *                                                                        *
 **************************************************************************/


using DRPCIV;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace InitVariabile.Tests
{
    [TestClass]
    public class InitVarTests
    {
        /// <summary>
        /// Test for variables with random question length 
        /// </summary>
        [TestMethod]
        public void InitializeVariabile_WithRandomAndIntrebariLength_ReturnsExpectedValues()
        {
            // Arrange
            var variableContainer = new VariableContainer(); // Initialize with default values
            var intrebariLength = 10;

            // Act
            InitVar.InitializeazaVariabile(variableContainer, intrebariLength);

            // Assert
            Assert.AreEqual(26, variableContainer.NrIntrebariInitiale);
            Assert.AreEqual(26, variableContainer.NrIntrebariRamase);
            Assert.AreEqual(6, variableContainer.MinuteTimer);
            Assert.AreEqual(26, variableContainer.NrMaxRaspCorecte);
            Assert.AreEqual(5, variableContainer.NrDiferentaRaspCorecte);
            Assert.AreEqual(22, variableContainer.NrMinRaspCorecte);
            Assert.AreEqual(5, variableContainer.NrMaxRaspGresite);
        }

        /// <summary>
        /// Test for variables with 0 as question length 
        /// </summary>
        [TestMethod]
        public void InitializeVariabile_WithRandomAndIntrebariLengthZero_ReturnsExpectedValues()
        {
            // Arrange
            var variableContainer = new VariableContainer(); // Initialize with default values
            var intrebariLength = 0;

            // Act
            InitVar.InitializeazaVariabile(variableContainer, intrebariLength);

            // Assert
            Assert.AreEqual(26, variableContainer.NrIntrebariInitiale);
            Assert.AreEqual(26, variableContainer.NrIntrebariRamase);
            Assert.AreEqual(6, variableContainer.MinuteTimer);
            Assert.AreEqual(26, variableContainer.NrMaxRaspCorecte);
            Assert.AreEqual(5, variableContainer.NrDiferentaRaspCorecte);
            Assert.AreEqual(22, variableContainer.NrMinRaspCorecte);
            Assert.AreEqual(5, variableContainer.NrMaxRaspGresite);
        }

        /// <summary>
        /// Test for variables with negative question length 
        /// </summary>
        [TestMethod]
        public void InitializeVariabile_WithRandomAndNegativeIntrebariLength_ReturnsExpectedValues()
        {
            // Arrange
            var variableContainer = new VariableContainer(); // Initialize with default values
            var intrebariLength = -5;

            // Act
            InitVar.InitializeazaVariabile(variableContainer, intrebariLength);

            // Assert
            Assert.AreEqual(26, variableContainer.NrIntrebariInitiale);
            Assert.AreEqual(26, variableContainer.NrIntrebariRamase);
            Assert.AreEqual(6, variableContainer.MinuteTimer);
            Assert.AreEqual(26, variableContainer.NrMaxRaspCorecte);
            Assert.AreEqual(5, variableContainer.NrDiferentaRaspCorecte);
            Assert.AreEqual(22, variableContainer.NrMinRaspCorecte);
            Assert.AreEqual(5, variableContainer.NrMaxRaspGresite);
        }
    }
}
