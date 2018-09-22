using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Windows;//biblioteki

namespace ApliKACJA
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Prepare();//wywołanie metody
        }
        public void Prepare() //metoda
        {
            address.Text = "https://jsonplaceholder.typicode.com/todos/1"; //ustawienie właściwości
        }
        private void send_Click(object sender, RoutedEventArgs e)
        {
            string responseString; //tekst odpowiedzi
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(address.Text);
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                responseString = reader.ReadToEnd();                
            }
            Deserialize(responseString);
        }
        public Json Deserialize(string json)
        {
            Json result = JsonConvert.DeserializeObject<Json>(json);
            return result;
        }
    }

}
