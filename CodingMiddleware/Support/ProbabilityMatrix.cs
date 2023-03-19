using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CodingMiddleware.Support
{
    public class ProbabilityMatrix
    {
        public class ElementDataProbability
        {
            public byte DataByte;
            public double Probability;

        }

        private ElementDataProbability[] _probabilities;

        public ElementDataProbability[] Probabilities
        {
            get
            {
                return _probabilities;
            }
        }

        public ProbabilityMatrix(int length)
        {
            _probabilities = new ElementDataProbability[length];
            for (int i = 0; i < length; i++)
            {
                _probabilities[i] = new ElementDataProbability();
            }
        }

        public void GetSortProbabilityMatrix(byte[] data)
        {
            CalculateFrequancy(data);
            SortFrequency();
            ReduceZeroProbMatrix();
        }

        public void CalculateFrequancy(byte[] data)
        {
            foreach (var element in data)
            {
                _probabilities[element].Probability++;
            }
            for (int i = 0; i < _probabilities.Length; i++)
            {

                _probabilities[i].DataByte = Convert.ToByte(i);
                _probabilities[i].Probability = _probabilities[i].Probability / data.Length;
            }
        }

        /// <summary>
        /// Функция удаления нулевых элементов из матрицы вероятностей
        /// </summary>
        public void ReduceZeroProbMatrix()
        {
            int iNotZeroIndex = Array.FindIndex<ElementDataProbability>(_probabilities, x => x.Probability == 0);
            if (iNotZeroIndex == -1) return;
            ElementDataProbability[] temp = new ElementDataProbability[iNotZeroIndex];
            Array.Copy(_probabilities, temp, iNotZeroIndex);
            _probabilities = temp;
        }

        public void SortFrequency()
        {
            Array.Sort(_probabilities, delegate (ElementDataProbability fElement, ElementDataProbability sElement) {
                return sElement.Probability.CompareTo(fElement.Probability);
            });
        }
    }
}
