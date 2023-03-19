namespace CodingMiddleware.Support
{
    public class OneElementCode
    {
        //TODO
        private byte _element { get; set; }
        private UInt64 _code { get; set; }
        private int _codeLength { get; set; }

        public byte Element
        {
            get
            {
                return _element;
            }
            set
            {
                _element = value;
            }
        }

        public UInt64 Code
        {
            get
            {
                return _code;
            }
            set
            {
                _code = value;
            }
        }

        public int CodeLength
        {
            get
            {
                return _codeLength;
            }
            set
            {
                _codeLength = value;
            }
        }

        public OneElementCode(byte element)
        {
            Element = element;
            Code = 0x0000000000000000;
            CodeLength = 0;
        }
    }
}
