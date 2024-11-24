using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CryptoDataDLL
{
    [Serializable]
    public partial class CryptoCurrency : ICrypto, IValidatable
    {
        public string ShortName { get; set; }
        public string FullName { get; set; }
        public double LastPrice { get; set; }
        public double PriceChange24H { get; set; }
        public double Capitalization { get; set; }
        public double VolumeTrading { get; set; }
        public CryptoCurrency() { }
        ~CryptoCurrency() { }
        public CryptoCurrency(string shortName, string fullName, double lastPrice, double priceChange24H, double capitalization, double volumeTrading)
        {
            this.ShortName = shortName;
            this.FullName = fullName;
            this.LastPrice = lastPrice;
            this.PriceChange24H = priceChange24H;
            this.Capitalization = capitalization;
            this.VolumeTrading = volumeTrading;
        }
    }
}
