using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Internal;
using PolynomOperations;

namespace PolynomOperationsTests
{
    [TestFixture]
    public class PolynominalTests
    {

        [TestCase(new double[] {18, 3, -3}, new double[] {18, 3, -3}, ExpectedResult = true)]
        [TestCase(new double[] {9, 11}, new double[] {9, 11, 6}, ExpectedResult = false)]
        [TestCase(new double[] {-1, 0, 2}, new double[] {-1, 0, 2}, ExpectedResult = true)]
        public bool EqualsTest_ForCheckEqualTwoPolynom(double[] arr1, double[] arr2)
        {
            Polynominal p1 = new Polynominal(arr1);
            Polynominal p2 = new Polynominal(arr2);
            return p1.Equals(p2);
        }

        [TestCase(new double[] {1, 3, -3}, new double[] {18, 3, -3}, new double[] {-17, 0, 0})]
        [TestCase(new double[] {8, 6, 2}, new double[] {4, 1,}, new double[] {4, 5, 2})]
        public void SubstractlOperationalOverridingTest(double[] p1, double[] p2, double[] expected)
        {
            Polynominal poly1 = new Polynominal(p1);
            Polynominal poly2 = new Polynominal(p2);
            double[] result = poly1 - poly2;
            Assert.That(expected, Is.EqualTo(result));
        }

        [TestCase(new double[] { 1, 3, 3 }, new double[] { 18, 3, 2 }, new double[] { 19, 6, 5 })]
        [TestCase(new double[] { 8, 6, 2 }, new double[] { 4, 1 }, new double[] { 12, 7, 2 })]
        public void AddOperationOverridingTest2(double[] p1, double[] p2, double[] expected)
        {
            Polynominal poly1 = new Polynominal(p1);
            Polynominal poly2 = new Polynominal(p2);
            double[] result = poly1 + poly2;
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase(new double[] {1, 0, 2}, new double[] {2, 7}, new double[] {2, 7, 4, 14})]
        [TestCase(new double[] {6, 3}, new double[] {2, 7}, new double[] {12, 48, 21})]
        public void MultiplyOperationOverridingTest(double[] p1, double[] p2, double[] expected)
        {
            Polynominal poly1 = new Polynominal(p1);
            Polynominal poly2 = new Polynominal(p2);
            double[] result = poly1 * poly2;
            Assert.That(expected, Is.EqualTo(result));
        }

        [TestCase(new double[] { 8, 1, 1 }, new double[] { 2, 0, 4 })]
        [TestCase(new double[] { 7, 0, 6 }, new double[] { 6, 0, 2 })]
        [TestCase(new double[] { 1, 2, 0 }, new double[] { 3, 0, 1 })]
        public void Equal_Return_True_Or_False(double[] arr1, double[] arr2)
        {
            Polynominal p1 = new Polynominal(arr1);
            Polynominal p2 = new Polynominal(arr2);
            Assert.True(p1 != p2);
        }

        [TestCase(new double[] { 6, 1, 1 }, new double[] { 6, 1, 1 })]
        [TestCase(new double[] { 0, 3, 1 }, new double[] { 0, 3, 1 })]
        [TestCase(new double[] { 2, 0 }, new double[] { 2, 0 })]
        public void NotEqual_Return_True_Or_False(double[] arr1, double[] arr2)
        {
            Polynominal p1 = new Polynominal(arr1);
            Polynominal p2 = new Polynominal(arr2);
            Assert.False(p1 != p2);
        }
        [TestCase(new double[] { 1, 4, 1 }, ExpectedResult = "1 + 4*(x^1) + 1*(x^2)")]
        [TestCase(new double[] { -3, 6, 1 }, ExpectedResult = "(-3) + 6*(x^1) + 1*(x^2)")]
        [TestCase(new double[] { 12, 7, 2 }, ExpectedResult = "12 + 7*(x^1) + 2*(x^2)")]
        public string TostringOverridingTest_ForConvert_polynomTo_String_Format(double[] arr)
        {
            Polynominal poly = new Polynominal(arr);
            return poly.ToString();
        }
    }
}
