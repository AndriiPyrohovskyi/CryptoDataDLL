using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CryptoDataDLL
{
    [Serializable]
    public partial class Blockchain : CryptoCurrency
    {
        public string TypeOfCrypto { get; set; }
        public string BlockchainName { get; set; }
        public double TranzactionSpeed { get; set; }
        public Blockchain() { }
        public Blockchain(string shortName,
                          string fullName,
                          double lastPrice,
                          double priceChange24H,
                          double capitalization,
                          double volumeTrading,
                          string blockchainName,
                          double tranzactionSpeed)
                          : base(shortName,
                                fullName,
                                lastPrice,
                                priceChange24H,
                                capitalization,
                                volumeTrading)
        {

            TypeOfCrypto = "Блокчейн";
            BlockchainName = blockchainName;
            TranzactionSpeed = tranzactionSpeed;
        }
        ~Blockchain() { }
    }
}
