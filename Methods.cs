using System.Windows.Forms;

namespace CryptoDataDLL
{
    public partial class StableCoin : CryptoCurrency, IValidatable
    {
        public override void FillDataGridRow(DataGridViewRow row)
        {
            base.FillDataGridRow(row);
            row.Cells[6].Value = "Стейблкоін";
            row.Cells[7].Value = ConnectionWithActive;
            row.Cells[8].Value = StabilizationMechanizm;
        }
        public bool Validate()
        {
            return PriceChange24H == 0;
        }
    }
    public partial class ShitCoin : CryptoCurrency
    {
        public override void FillDataGridRow(DataGridViewRow row)
        {
            base.FillDataGridRow(row);
            row.Cells[6].Value = "Шіткоін";
            row.Cells[9].Value = RiskLevel;
            row.Cells[10].Value = ReliabilityOfDevelopers;
        }
    }
    public partial class MemeCoin : Blockchain
    {
        public override void FillDataGridRow(DataGridViewRow row)
        {
            base.FillDataGridRow(row);
            row.Cells[13].Value = "Мемкоін";
            row.Cells[14].Value = NameOfMemeCommunity;
            row.Cells[15].Value = NumberOfFanbase;
        }
    }
    public partial class CryptoCurrency : ICrypto, IValidatable
    {
        public virtual void FillDataGridRow(DataGridViewRow row)
        {
            row.Cells[0].Value = ShortName;
            row.Cells[1].Value = FullName;
            row.Cells[2].Value = LastPrice;
            row.Cells[3].Value = PriceChange24H;
            row.Cells[4].Value = Capitalization;
            row.Cells[5].Value = VolumeTrading;
        }
        public bool Validate()
        {
            return PriceChange24H == 0;
        }
    }
    public partial class Coins : Blockchain
    {
        public override void FillDataGridRow(DataGridViewRow row)
        {
            base.FillDataGridRow(row);
            row.Cells[13].Value = "Монета";
            row.Cells[16].Value = Technologies;
        }
    }
    public partial class Blockchain : CryptoCurrency
    {
        public override void FillDataGridRow(DataGridViewRow row)
        {
            base.FillDataGridRow(row);
            row.Cells[6].Value = "Блокчейн";
            row.Cells[11].Value = BlockchainName;
            row.Cells[12].Value = TranzactionSpeed;
        }
    }
}
