using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BitcoinCalc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void getcurrentrates_Click(object sender, EventArgs e)
        {
            if (currencyCombo.SelectedItem.ToString() == "EUR")
            {
                resultLabel.Visible = true;
                resultTextBox.Visible = true;
                bitcoinrates bitcoin = GetRates();
                float result = Int32.Parse(amountofbitcoin.Text) * bitcoin.bpi.EUR.rate_float;
                resultTextBox.Text = $"{result.ToString()} {bitcoin.bpi.EUR.code}";

            }
            else if (currencyCombo.SelectedItem.ToString() == "USD")
            {
                resultLabel.Visible = true;
                resultTextBox.Visible = true;
                bitcoinrates bitcoin = GetRates();
                float result = Int32.Parse(amountofbitcoin.Text) * bitcoin.bpi.USD.rate_float;
                resultTextBox.Text = $"{result.ToString()} {bitcoin.bpi.USD.code}";

            }

        }

        public static bitcoinrates GetRates()
        {
            string url = "https://api.coindesk.com/v1/bpi/currentprice.json";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            var webResponse = request.GetResponse();
            var webStream = webResponse.GetResponseStream();

            bitcoinrates bitcoin;

            using(var responseReader = new StreamReader (webStream))
            {
                var response = responseReader.ReadToEnd();
                bitcoin = JsonConvert.DeserializeObject<bitcoinrates>(response);

            }
            return bitcoin;


    


        }

  
    }
}
