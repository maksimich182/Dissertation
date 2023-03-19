using CodingMiddleware.Support;

namespace CodingMiddleware.Services
{
    public class ShennonFanoCoderService : Coder, ICoder
    {
        /// <summary>
        /// Формирование кода
        /// </summary>
        /// <param name="probabilityMatrix">Матрица вероятностей символов</param>
        public void GetCode(ProbabilityMatrix probabilityMatrix)
        {
            arCode = new OneElementCode[probabilityMatrix.Probabilities.Length];
            for (int i = 0; i < probabilityMatrix.Probabilities.Length; i++)
            {
                arCode[i] = new OneElementCode(probabilityMatrix.Probabilities[i].DataByte);
            }
            ShennonFanoAlgorithm(probabilityMatrix);
        }

        /// <summary>
        /// Разделение алфавита на две группы равных вероятностей
        /// </summary>
        /// <param name="probabilityMatrix">Матрица вероятностей символов</param>
        /// <returns></returns>
        //private int DivideSequence(ProbabilityMatrix probabilityMatrix)
        //{
        //    int index = probabilityMatrix.Probabilities.Length;
        //    double fSumProbability = 0;
        //    double sSumProbability = 0;
        //    foreach (var element in probabilityMatrix.Probabilities)
        //    {
        //        fSumProbability += element.Probability;
        //    }

        //    while (fSumProbability >= sSumProbability && index != 1)
        //    {
        //        index--;
        //        fSumProbability -= probabilityMatrix.Probabilities[index].Probability;
        //        sSumProbability += probabilityMatrix.Probabilities[index].Probability;
        //    }
        //    return index;
        //}


        /// <summary>
        /// Алгоритм кодирования Шеннона-Фано
        /// </summary>
        /// <param name="probabilityMatrix">Матрица вероятностей символов</param>
        private void ShennonFanoAlgorithm(ProbabilityMatrix probabilityMatrix)
        {
            if (probabilityMatrix.Probabilities.Length > 1)
            {
                int devider = DivideSequence(probabilityMatrix);
                int indexCoding =
                    Array.FindIndex<OneElementCode>(arCode, code =>
                    code.Element == probabilityMatrix.Probabilities[devider].DataByte) - devider;

                for (int i = 0; i < probabilityMatrix.Probabilities.Length; i++)
                {
                    arCode[indexCoding].CodeLength++;
                    arCode[indexCoding].Code <<= 1;
                    if (i >= devider)
                    {
                        arCode[indexCoding].Code |= 1;
                    }
                    indexCoding++;
                }

                SubShennonFanoAlgorithm(probabilityMatrix, 0, devider);
                SubShennonFanoAlgorithm(probabilityMatrix, devider, probabilityMatrix.Probabilities.Length - devider);
            }

            int DivideSequence(ProbabilityMatrix probabilityMatrix)
            {
                int index = probabilityMatrix.Probabilities.Length;
                double fSumProbability = 0;
                double sSumProbability = 0;
                foreach (var element in probabilityMatrix.Probabilities)
                {
                    fSumProbability += element.Probability;
                }

                while (fSumProbability >= sSumProbability && index != 1)
                {
                    index--;
                    fSumProbability -= probabilityMatrix.Probabilities[index].Probability;
                    sSumProbability += probabilityMatrix.Probabilities[index].Probability;
                }
                return index;
            }
        }

        /// <summary>
        /// Рассчет по алгоритму Шеннона-Фано для подалфавита
        /// </summary>
        /// <param name="probabilitySubMatrix">Матрица вероятностей символов подалфавита</param>
        /// <param name="codeBit">Кодовый бит</param>
        /// <param name="indexFirstElement">Индекс начала подалфавита в алфавите</param>
        /// <param name="length">Объем подалфавита</param>
        private void SubShennonFanoAlgorithm(ProbabilityMatrix probabilitySubMatrix, int indexFirstElement, int length)
        {
            var subMatrix = new ProbabilityMatrix(length);
            Array.Copy(probabilitySubMatrix.Probabilities, indexFirstElement, subMatrix.Probabilities, 0, length);
            ShennonFanoAlgorithm(subMatrix);
        }
    }
}
