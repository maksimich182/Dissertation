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
            // адрес сервера
            var serverAddress = $"{tbIpDest.Text}:{Convert.ToInt32(tbPortDest.Text)}";
            // пусть к файлу
            var filePath = tbDirData.Text;

            // создаем MultipartFormDataContent
            using var multipartFormContent = new MultipartFormDataContent();
            // Загружаем отправляемый файл
            var fileStreamContent = new StreamContent(File.OpenRead(filePath));
            // Устанавливаем заголовок Content-Type
            fileStreamContent.Headers.ContentType = new MediaTypeHeaderValue("text/plain");
            // Добавляем загруженный файл в MultipartFormDataContent
            multipartFormContent.Add(fileStreamContent, name: "file", fileName: new FileInfo(filePath).Name);

            // Отправляем файл
            using var response = await httpClient.PostAsync(serverAddress, multipartFormContent);
            // считываем ответ
            var responseText = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseText);
            //using HttpClient httpClient = new HttpClient();
            //await httpClient.ConnectAsync(tbIpDest.Text, Convert.ToInt32(tbPortDest.Text));

            //// сообщение для отправки
            //var dataDir = tbDirData.Text;
            //// считыванием строку в массив байт
            ////byte[] requestData = Encoding.UTF8.GetBytes(message);
            //// получаем NetworkStream для взаимодействия с сервером
            //using (var sr = new StreamReader(dataDir))
            //{
            //    using(var stream = await httpClient.GetStreamAsync())
            //    {
            //        byte[] requestData = Encoding.UTF8.GetBytes(sr.ReadToEnd());
            //        await stream.WriteAsync(requestData);
            //    }
            //}

            ////var stream = tcpClient.GetStream();
            //// отправляем данные
            ////await stream.WriteAsync(requestData);

            //Console.WriteLine("Сообщение отправлено");
        }
    }
}