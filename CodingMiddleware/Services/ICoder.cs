using CodingMiddleware.Support;

namespace CodingMiddleware.Services
{
    public interface ICoder
    {
        /// <summary>
        /// Формирование кода
        /// </summary>
        /// <param name="probabilityMatrix">Матрица вероятностей символов</param>
        public void GetCode(ProbabilityMatrix probabilityMatrix);

    }
}
