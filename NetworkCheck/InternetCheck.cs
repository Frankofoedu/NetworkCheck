using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetworkCheck
{
    public static class InternetCheck
    {
        public  static async void CheckForInternet()
        {
            await Task.Run(() =>
            {
                try
                {
                    using (var client = new WebClient())
                    using (client.OpenRead("http://www.google.com"))
                    {
                        MessageBox.Show(@"There is Internet");
                    }
                }
                catch
                {
                    MessageBox.Show(@"No Internet");
                }
            });
        }
    }
}
