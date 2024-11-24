using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CryptoDataDLL
{
    [Serializable]
    public partial class Coins : Blockchain
    {
        public string TypeOfCryptoBasedOnBlockchain { get; set; }
        public string Technologies { get; set; }
        public Coins() { }
        public Coins(string shortName,
                          string fullName,
                          double lastPrice,
                          double priceChange24H,
                          double capitalization,
                          double volumeTrading,
                          string blockchainName,
                          double tranzactionSpeed,
                          string technologies)
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
            TypeOfCryptoBasedOnBlockchain = "Монета";
            Technologies = technologies;
        }
        ~Coins() { }
    }
}
