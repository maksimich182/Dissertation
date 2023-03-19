using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CodingMiddleware.Support
{
    abstract public class Coder
    {
        /// <summary>
        /// Массив кодов элементов
        /// </summary>
        protected OneElementCode[] _arCode;

        public OneElementCode[] ArCode
        {
            get
            {
                return _arCode;
            }
        }

        private const int BITS_IN_BYTE = 8;
        private const int MAX_BYTE_VALUE = 255;

        public abstract void GetCode(ProbabilityMatrix probabilityMatrix);

        /// <summary>
        /// Функция кодирования массива данных
        /// </summary>
        /// <param name="data">Массив первичных данных</param>
        /// <param name="code">Кодовая таблица</param>
        /// <param name="codeData">Массив кодированных данных</param>
        public static void CodeData(Data data, Coder code, Data codeData)
        {
            OneElementCode elementCode;
            UInt64 tempCodeSequence = 0;
            int currentTempCodeLength = 0;
            byte byteMask = Convert.ToByte(MAX_BYTE_VALUE);
            List<byte> currentCodeData = new List<byte>();

            foreach (var element in data.ArData)
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

            codeData.ArData = currentCodeData.ToArray();
        }

        private OneElementCode GetElementCode(byte symbol)
        {
            return _arCode[Array.FindIndex<OneElementCode>(_arCode, code =>
                    code.Element == symbol)];
        }
    }
}
