using NUnit.Framework;
using System;
using System.Collections.Generic;
using SelectAPersonCalculator;
using NUnit.Framework.Constraints;

namespace SelectAPersonCalculatorTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test] 
        public void cleanUpSampleEntry_EmptyList_EmptyList() { 
        
            //Arrange
                var l= new List<double>();
            var arithmetic = new ArithmeticClass();

            //Act
            var cleanList = arithmetic.cleanUpSampleEntry(l);

            //Assert
            Assert.That(cleanList, Is.EqualTo(l));
        }

        [Test]
        public void cleanUpSampleEntry_ValidEntriesOnly_ListUnchanged()
        {

            //Arrange
            var l = new List<double>();
            l.Add(1);
            l.Add(0);
            l.Add(100);
            var arithmetic = new ArithmeticClass();

            //Act
            var cleanList = arithmetic.cleanUpSampleEntry(l);

            //Assert
            Assert.That(cleanList, Is.EqualTo(l));
        }

        [Test]
        public void cleanUpSampleEntry_OverValueEntriesInc_ListWithoutOverValues()
        {

            //Arrange
            var l = new List<double>();
            l.Add(1);
            l.Add(0);
            l.Add(101);

            var expectedResult = new List<double>();
            expectedResult.Add(1);
            expectedResult.Add(0);
            var arithmetic = new ArithmeticClass();

            //Act
            var cleanList = arithmetic.cleanUpSampleEntry(l);

            //Assert
            Assert.That(cleanList, Is.EqualTo(expectedResult));
        }

        [Test]
        public void cleanUpSampleEntry_UnderValueEntriesInc_ListWithoutUnderValues()
        {

            //Arrange
            var l = new List<double>();
            l.Add(1);
            l.Add(0);
            l.Add(-1);
            l.Add(-100);

            var expectedResult = new List<double>();
            expectedResult.Add(1);
            expectedResult.Add(0);
            var arithmetic = new ArithmeticClass();

            //Act
            var cleanList = arithmetic.cleanUpSampleEntry(l);

            //Assert
            Assert.That(cleanList, Is.EqualTo(expectedResult));
        }

        [Test]
        public void arithmeticMean_1_2_3_Result2() {
            //Arrange
            var l = new List<double>();
            l.Add(1);
            l.Add(2);
            l.Add(3);


            //Act
            var arithmetic = new ArithmeticClass();
            var calculatedMean = arithmetic.arithmeticMean(l);
            
            //Assert
            Assert.That(calculatedMean, Is.EqualTo(2));
        }

        [Test]
        public void arithmeticMean_emptyList_0()
        {
            //Arrange
            var l = new List<double>();
            
            //Act
            var arithmetic = new ArithmeticClass();
            var calculatedMean = arithmetic.arithmeticMean(l);

            //Assert
            Assert.That(calculatedMean, Is.EqualTo(0));
        }

        [Test]
        public void squareRoot_9_3()
        {
            //Arrange
            var arg = 9;

            //Act
            var arithmetic = new ArithmeticClass();
            var calculatedSquareRoot = ArithmeticClass.squareRoot(arg);

            //Assert
            Assert.That(calculatedSquareRoot, Is.EqualTo(3));
        }

        [Test]
        public void squareRoot_0_0()
        {
            //Arrange
            var arg = 0;

            //Act
            var arithmetic = new ArithmeticClass();
            var calculatedSquareRoot = ArithmeticClass.squareRoot(arg);

            //Assert
            Assert.That(calculatedSquareRoot, Is.EqualTo(0));
        }

        [Test]
        public void binFrequencies_EmptyList_NoCounts()
        {
            //Arrange
            var l = new List<double>();
            

            //Act
            var arithmetic = new ArithmeticClass();
            var calculatedFrequencies = arithmetic.binFrequencies(l);

            //Assert
            var expectedResult= new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            Assert.That(calculatedFrequencies, Is.EqualTo(expectedResult));
        }

        [Test]
        public void binFrequencies_ThresholdValues_Counts()
        {
            //Arrange
            var l = new List<double>() { 0, 9, 10, 11, 99, 100, 101 };
            

            //Act
            var arithmetic = new ArithmeticClass();
            var calculatedFrequencies = arithmetic.binFrequencies(l);

            //Assert
            var expectedResult = new List<int> { 2, 2, 0, 0, 0, 0, 0, 0, 0, 1, 2 };
            Assert.That(calculatedFrequencies, Is.EqualTo(expectedResult));
        }

        [Test]
        public void compoundIncrease_SimpleTwoYear_5000()
        {
            //Arrange
            var principal = 5000.0;
            var rate = 5.0;
            var nCompoundPerYear = 1;
            var term = 2;

            //Act
            var arithmetic = new ArithmeticClass();
            var result = arithmetic.compoundAmountIncrease(principal, rate, nCompoundPerYear, term);

            //Assert
            //5000*1.05*1.05 = 5512.50
            Assert.That(result, Is.EqualTo(5512.50));
        }

        [Test]
        public void compoundIncrease_TwiceYearlyCalcTwoYear_5000()
        {
            //Arrange
            var principal = 5000.0;
            var rate = 5.0;
            var nCompoundPerYear = 2;
            var term = 2;

            //Act
            var arithmetic = new ArithmeticClass();
            var result = arithmetic.compoundAmountIncrease(principal, rate, nCompoundPerYear, term);

            //Assert
            //5000*4*(1.025) = 5519.06 to 2 decimal places
            Assert.That(result, Is.EqualTo(5519.06));
        }

        [Test]
        public void compoundDecrease_SimpleTwoYear_5000()
        {
            //Arrange
            var principal = 5000.0;
            var rate = 5.0;
            var nCompoundPerYear = 1;
            var term = 2;

            //Act
            var arithmetic = new ArithmeticClass();
            var result = arithmetic.compoundAmountDecrease(principal, rate, nCompoundPerYear, term);

            //Assert
            //5000*0.95*0.95 = 4512.50
            Assert.That(result, Is.EqualTo(4512.50));
        }

        [Test]
        public void compoundDecrease_TwiceYearlyCalcTwoYear_5000()
        {
            //Arrange
            var principal = 5000.0;
            var rate = 5.0;
            var nCompoundPerYear = 2;
            var term = 2;

            //Act
            var arithmetic = new ArithmeticClass();
            var result = arithmetic.compoundAmountDecrease(principal, rate, nCompoundPerYear, term);

            //Assert
            //5000*(0.975)^4 = 4518.44 to 2 decimal places
            Assert.That(result, Is.EqualTo(4518.44));
        }
    }
}