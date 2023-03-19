namespace CodingMiddleware.Support
{
    public class Data
    {
        private byte[] _arData = null!;

        public byte[] ArData
        {
            get
            {
                return _arData;
            }
            set
            {
                _arData = value;
            }
        }

        public void GetDataFromFile(string strFileName)
        {
            try
            {
                _arData = File.ReadAllBytes(strFileName);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
