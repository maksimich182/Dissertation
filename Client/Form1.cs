using System.Net.Http.Headers;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void btSend_Click(object sender, EventArgs e)
        {
            HttpClient httpClient = new HttpClient();
            // ����� �������
            var serverAddress = $"{tbIpDest.Text}:{Convert.ToInt32(tbPortDest.Text)}";
            // ����� � �����
            var filePath = tbDirData.Text;

            // ������� MultipartFormDataContent
            using var multipartFormContent = new MultipartFormDataContent();
            // ��������� ������������ ����
            var fileStreamContent = new StreamContent(File.OpenRead(filePath));
            // ������������� ��������� Content-Type
            fileStreamContent.Headers.ContentType = new MediaTypeHeaderValue("text/plain");
            // ��������� ����������� ���� � MultipartFormDataContent
            multipartFormContent.Add(fileStreamContent, name: "file", fileName: new FileInfo(filePath).Name);

            // ���������� ����
            using var response = await httpClient.PostAsync(serverAddress, multipartFormContent);
            // ��������� �����
            var responseText = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseText);
            //using HttpClient httpClient = new HttpClient();
            //await httpClient.ConnectAsync(tbIpDest.Text, Convert.ToInt32(tbPortDest.Text));

            //// ��������� ��� ��������
            //var dataDir = tbDirData.Text;
            //// ����������� ������ � ������ ����
            ////byte[] requestData = Encoding.UTF8.GetBytes(message);
            //// �������� NetworkStream ��� �������������� � ��������
            //using (var sr = new StreamReader(dataDir))
            //{
            //    using(var stream = await httpClient.GetStreamAsync())
            //    {
            //        byte[] requestData = Encoding.UTF8.GetBytes(sr.ReadToEnd());
            //        await stream.WriteAsync(requestData);
            //    }
            //}

            ////var stream = tcpClient.GetStream();
            //// ���������� ������
            ////await stream.WriteAsync(requestData);

            //Console.WriteLine("��������� ����������");
        }
    }
}