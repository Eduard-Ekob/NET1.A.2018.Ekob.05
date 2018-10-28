using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolynomOperations
{
    /// <summary>
    /// The polynominal calculate polynom from fraction of one variable
    /// </summary>
    public class Polynominal : ICloneable, IEquatable<Polynominal>
    {
        private double[] coeffs;

        /// <summary>
        /// Initializes a new instance of the <see cref="Polynominal"/> class.
        /// </summary>
        /// <param name="cf">
        /// The cf is incomming array
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// If incomming array is null
        /// </exception>
        public Polynominal(double[] cf)
        {
            if (cf == null)
            {
                throw new ArgumentNullException(nameof(coeffs));
            }

            coeffs = cf;
        }

        #region Substract operation override

        /// <summary>
        /// The - substraction method
        /// </summary>
        /// <param name="p1">
        /// The p 1 is reduced arg
        /// </param>
        /// <param name="p2">
        /// The p 2 value for reduce p1
        /// </param>
        /// <returns>
        /// substtraction result
        /// </returns>
        public static double[] operator -(Polynominal p1, Polynominal p2)
        {
            ValidForException(p1, p2);            
            int maxLength = p1.coeffs.Length > p2.coeffs.Length ? p1.coeffs.Length : p2.coeffs.Length;
            int minLength = p1.coeffs.Length < p2.coeffs.Length ? p1.coeffs.Length : p2.coeffs.Length;
            double[] resultArr = new double[maxLength];

            for (int i = 0; i < maxLength; i++)
                if (i < minLength)
                    resultArr[i] = p1.coeffs[i] - p2.coeffs[i];
                else
                    resultArr[i] = p2.coeffs.Length > p1.coeffs.Length ? p2.coeffs[i] : p1.coeffs[i];

            return resultArr;
        }

        #endregion


        #region Add operation override
        /// <summary>
        /// The - additional method
        /// </summary>
        /// <param name="p1">
        /// The p 1 is first arg
        /// </param>
        /// <param name="p2">
        /// The p 2 is second arg
        /// </param>
        /// <returns>
        /// result from addition two args
        /// </returns>
        public static double[] operator +(Polynominal p1, Polynominal p2)
        {
            ValidForException(p1, p2);
            int maxLength = p1.coeffs.Length > p2.coeffs.Length ? p1.coeffs.Length : p2.coeffs.Length;
            int minLength = p1.coeffs.Length < p2.coeffs.Length ? p1.coeffs.Length : p2.coeffs.Length;
            double[] resultArr = new double[maxLength];

            for (int i = 0; i < maxLength; i++)
                if (i < minLength)
                    resultArr[i] = p1.coeffs[i] + p2.coeffs[i];
                else
                    resultArr[i] = p2.coeffs.Length > p1.coeffs.Length ? p2.coeffs[i] : p1.coeffs[i];

            return resultArr;
        }

        #endregion

        #region Multiply operation override
        /// <summary>
        /// The - multiply method overriding * operator
        /// </summary>
        /// <param name="p1">
        /// The p 1 is first arg
        /// </param>
        /// <param name="p2">
        /// The p 2 is second arg
        /// </param>
        /// <returns>
        /// result from multiply two args
        /// </returns>
        public static double[] operator *(Polynominal p1, Polynominal p2)
        {
            ValidForException(p1, p2);
            int maxLength = p1.coeffs.Length > p2.coeffs.Length ? p1.coeffs.Length : p2.coeffs.Length;
            int minLength = p1.coeffs.Length < p2.coeffs.Length ? p1.coeffs.Length : p2.coeffs.Length;
            double[] resultArr = new double[maxLength+minLength -1];
            for (int i = 0; i < p1.coeffs.Length; i++)
            {
                for (int j = 0; j < p2.coeffs.Length; j++)
                {
                    resultArr[i + j] += p1.coeffs[i] * p2.coeffs[j];
                }
            }

            return resultArr;
        }
        #endregion

        #region Object.Equals override

        /// <summary>
        /// The equals is override Equals method
        /// </summary>
        /// <param name="p">
        /// The p is incomming object
        /// </param>
        /// <returns>
        /// The equivalent objects <see cref="bool"/>.
        /// </returns>
        public override bool Equals(Object p)
        {
            if (ReferenceEquals(p, null)) return false;
            if (ReferenceEquals(p, this)) return true;
            return Equals(p as Polynominal);
        }

        #endregion

        #region Object.ToString() override

        /// <summary>
        /// The to string is override ToString methd in System.Object
        /// </summary>
        /// <returns>
        /// Polynom on string format <see cref="string"/>.
        /// </returns>
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < coeffs.Length; i++)
            {
                if (coeffs[i] == 0)
                {
                    continue;
                }

                if (coeffs[i] < 0)
                {
                    result.Append("(" + coeffs[i] + ")");
                }

                if (coeffs[i] > 0)
                {
                    result.Append(coeffs[i].ToString());
                }

                if (i != 0)
                {
                    result.Append("*" + "(x^" + i + ")");
                }

                if (i != coeffs.Length - 1)
                {
                    result.Append(" + ");
                }
            }

            return result.ToString().Trim();
        }

        #endregion

        #region ICloneable interface implementation
        /// <summary>
        /// Create clone object of polynom
        /// </summary>
        /// <returns>New polynom object</returns>
        object ICloneable.Clone()
        {
            return (object)new Polynominal(coeffs);
        }

        public Polynominal Clone()
        {
            return new Polynominal(coeffs);
        }

        #endregion


        #region Exception Validation

        /// <summary>
        /// The validation for exception
        /// </summary>
        /// <param name="p1">
        /// The p 1 first arg
        /// </param>
        /// <param name="p2">
        /// The p 2 second arg
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// If one of incomming object is null or arrays is null
        /// </exception>
        private static void ValidForException(Polynominal p1, Polynominal p2)
        {
            if ((p1 == null)||(p2 == null))
            {
                throw new ArgumentNullException(nameof(p1));
            }

            if ((p1.coeffs == null) && (p2.coeffs == null))
            {
                throw new ArgumentNullException(nameof(coeffs));
            }
        }

        #endregion

        #region IEquals implementation

        public bool Equals(Polynominal poly)
        {
            {
                if (ReferenceEquals(poly, null)) return false;
                if (ReferenceEquals(poly, this)) return true;
                if (coeffs.Length != poly.coeffs.Length)
                {
                    return false;
                }

                for (int i = 0; i < poly.coeffs.Length; i++)
                {
                    if (coeffs[i] != poly.coeffs[i])
                    {
                        return false;
                    }
                }

                return true;
                
            }
        }

        #endregion


        public override int GetHashCode()
        {
            return (coeffs != null ? coeffs.GetHashCode() : 0);
        }

        /// <summary>
        /// The == is override equivalent operator
        /// </summary>
        /// <param name="p1">
        /// The p 1. first arg
        /// </param>
        /// <param name="p2">
        /// The p 2. second arg
        /// </param>
        /// <returns>
        /// true or false operation
        /// </returns>
        public static bool operator ==(Polynominal p1, Polynominal p2)
        {
            //ValidForException(p1, p2);
            return p1.Equals(p2);
        }
        /// <summary>
        /// The != is override equivalent operator
        /// </summary>
        /// <param name="p1">
        /// The p 1. first arg
        /// </param>
        /// <param name="p2">
        /// The p 2. second arg
        /// </param>
        /// <returns>
        /// true or false operation
        /// </returns>
        public static bool operator !=(Polynominal p1, Polynominal p2)
        {
            //ValidForException(p1, p2);
            return !p1.Equals(p2);
        }
    }
}
