using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CryptoDataDLL
{
    [Serializable]
    public partial class MemeCoin : Blockchain
    {
        public string TypeOfCryptoBasedOnBlockchain { get; set; }
        public string NameOfMemeCommunity { get; set; }
        public int NumberOfFanbase { get; set; }
        public MemeCoin() { }
        public MemeCoin(string shortName,
                          string fullName,
                          double lastPrice,
                          double priceChange24H,
                          double capitalization,
                          double volumeTrading,
                          string blockchainName,
                          double tranzactionSpeed,
                          string nameOfMemeCommunity,
                          int numberOfFanbase)
                          : base(shortName,
                                fullName,
                                lastPrice,
                                priceChange24H,
                                capitalization,
                                volumeTrading,
                                blockchainName,
                                tranzactionSpeed)
        {
            TypeOfCrypto = "Блокчейн";
            TypeOfCryptoBasedOnBlockchain = "Мемкоін";
            NameOfMemeCommunity = nameOfMemeCommunity;
            NumberOfFanbase = numberOfFanbase;
        }
        ~MemeCoin() { }
    }
}
