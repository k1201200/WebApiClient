using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Net.Http.Headers;

namespace WebApiClient
{
    public partial class Form1 : Form
    {
        public HttpClient client = new HttpClient();

        private DigSite[] ds = new DigSite[100];
        private Random random;

        public Form1()
        {
            InitializeComponent();
            client.BaseAddress = new Uri("http://localhost:55147/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            random = new Random();
            textBox2.Text = ""+0;
            textBox3.Text = ""+0;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                button1.Enabled = false;
                button2.Enabled = false;

                int index = 1 + (int.Parse(textBox2.Text) * 10 + int.Parse(textBox3.Text));
                var response = await client.GetAsync("api/DigSites/"+index);
                response.EnsureSuccessStatusCode();

                var DigSite = await response.Content.ReadAsAsync<DigSite>();
                    
                textBox1.Text = ""+DigSite.treasureValue;
                
            }
            catch (Newtonsoft.Json.JsonException jEx)
            {
                MessageBox.Show(jEx.Message);
            }
            finally
            {
                button1.Enabled = true;
                button2.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tähän oli tarkoitus laittaa tieto kannan resetointi mutta VS mukana tullut IIS ja sen asetukset eivät hyväksyneet kirjoitus komentoja (HTTP Virhe 405) ja sen lisäksi jokaiselle versiolle oli erilaiset ohjeensa jolla mahdollisesti kirjoitus oikeudet saataisiin toimimaan");
            
            // Tähän oli tarkoitus laittaa tieto kannan resetointi
            // mutta VS mukana tullut IIS ja sen asetukset eivät
            // hyväksyneet kirjoitus komentoja (HTTP Virhe 405)
            // ja sen lisäksi jokaiselle versiolle oli erilaiset ohjeensa
            // jolla mahdollisesti kirjoitus oikeudet saataisiin toimimaan.
        }
    }
}
