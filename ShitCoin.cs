using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CryptoDataDLL
{
    [Serializable]
    public partial class ShitCoin : CryptoCurrency
    { 
        public string TypeOfCrypto { get; set; }
        public int RiskLevel { get; set; }
        public int ReliabilityOfDevelopers { get; set; }
        public ShitCoin() { }
        public ShitCoin(string shortName,
                          string fullName,
                          double lastPrice,
                          double priceChange24H,
                          double capitalization,
                          double volumeTrading,
                          int riskLevel,
                          int reliabilityOfDevelopers)
                          : base(shortName,
                                fullName,
                                lastPrice,
                                priceChange24H,
                                capitalization,
                                volumeTrading)
        {
            TypeOfCrypto = "Шіткоін";
            RiskLevel = riskLevel;
            ReliabilityOfDevelopers = reliabilityOfDevelopers;
        }
        ~ShitCoin() { }
    }
}
