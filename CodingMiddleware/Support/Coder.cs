using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CodingMiddleware.Support
{
    //TODELETE
    abstract public class Coder
    {
        private const int BITS_IN_BYTE = 8;
        private const int MAX_BYTE_VALUE = 255;

        /// <summary>
        /// Массив кодов элементов
        /// </summary>
        protected OneElementCode[] arCode = null!;

        //public OneElementCode[] ArCode
        //{
        //    get
        //    {
        //        return _arCode;
        //    }
        //}

        //private const int BITS_IN_BYTE = 8;
        //private const int MAX_BYTE_VALUE = 255;

        //public abstract void GetCode(ProbabilityMatrix probabilityMatrix);

        /// <summary>
        /// Функция кодирования массива данных
        /// </summary>
        /// <param name="data">Массив первичных данных</param>
        /// <param name="code">Кодовая таблица</param>
        /// <param name="codeData">Массив кодированных данных</param>
        public byte[] CodeData(byte[] data, Coder code)
        {
            OneElementCode elementCode;
            UInt64 tempCodeSequence = 0;
            int currentTempCodeLength = 0;
            byte byteMask = Convert.ToByte(MAX_BYTE_VALUE);
            var currentCodeData = new List<byte>();

            foreach (var element in data)
            {
                elementCode = code.GetElementCode(element);
                tempCodeSequence |= elementCode.Code << currentTempCodeLength;
                currentTempCodeLength += elementCode.CodeLength;
                while (currentTempCodeLength >= BITS_IN_BYTE)
                {
                    currentCodeData.Add(Convert.ToByte(tempCodeSequence & byteMask));
                    tempCodeSequence >>= BITS_IN_BYTE;
                    currentTempCodeLength -= BITS_IN_BYTE;
                }
            }

            if (currentTempCodeLength != 0)
            {
                currentCodeData.Add(Convert.ToByte(tempCodeSequence));
            }

            return currentCodeData.ToArray();
        }

        private OneElementCode GetElementCode(byte symbol)
        {
            return arCode[Array.FindIndex<OneElementCode>(arCode, code =>
                    code.Element == symbol)];
        }
    }
}
