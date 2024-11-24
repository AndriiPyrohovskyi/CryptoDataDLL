using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CryptoDataDLL
{
    public interface ICryptoDataParser
    {
        CryptoCurrency DetermineCryptoType(string[] values, DataGridViewRow row);
        bool IsMatch(string[] values, int[] nonEmpty, int[] empty);
        double ParseDouble(object value);
        int ParseInt(object value);
    }
    public class CryptoDataParser : ICryptoDataParser
    {
        public bool IsMatch(string[] values, int[] nonEmpty, int[] empty)
        {
            return nonEmpty.All(index => !string.IsNullOrEmpty(values[index])) &&
                   empty.All(index => string.IsNullOrEmpty(values[index]));
        }

        public double ParseDouble(object value)
        {
            return double.TryParse(value?.ToString(), out double result) ? result : 0.0;
        }

        public int ParseInt(object value)
        {
            return int.TryParse(value?.ToString(), out int result) ? result : 0;
        }
        public CryptoCurrency DetermineCryptoType(string[] values, DataGridViewRow row)
        {
            if (IsMatch(values, nonEmpty: new[] { 0, 1, 2, 3, 4, 5 }, empty: new[] { 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 }))
                return new CryptoCurrency(
                    row.Cells[0].Value?.ToString() ?? "",
                    row.Cells[1].Value?.ToString() ?? "",
                    ParseDouble(row.Cells[2].Value),
                    ParseDouble(row.Cells[3].Value),
                    ParseDouble(row.Cells[4].Value),
                    ParseDouble(row.Cells[5].Value)
                );

            if (IsMatch(values, nonEmpty: new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 }, empty: new[] { 9, 10, 11, 12, 13, 14, 15, 16 }))
                return new StableCoin(
                    row.Cells[0].Value?.ToString() ?? "",
                    row.Cells[1].Value?.ToString() ?? "",
                    ParseDouble(row.Cells[2].Value),
                    ParseDouble(row.Cells[3].Value),
                    ParseDouble(row.Cells[4].Value),
                    ParseDouble(row.Cells[5].Value),
                    row.Cells[7].Value?.ToString() ?? "",
                    row.Cells[8].Value?.ToString() ?? ""
                );

            if (IsMatch(values, nonEmpty: new[] { 0, 1, 2, 3, 4, 5, 6, 9, 10 }, empty: new[] { 7, 8, 11, 12, 13, 14, 15, 16 }))
                return new ShitCoin(
                    row.Cells[0].Value?.ToString() ?? "",
                    row.Cells[1].Value?.ToString() ?? "",
                    ParseDouble(row.Cells[2].Value),
                    ParseDouble(row.Cells[3].Value),
                    ParseDouble(row.Cells[4].Value),
                    ParseDouble(row.Cells[5].Value),
                    ParseInt(row.Cells[9].Value),
                    ParseInt(row.Cells[10].Value)
                );

            if (IsMatch(values, nonEmpty: new[] { 0, 1, 2, 3, 4, 5, 6, 11, 12 }, empty: new[] { 7, 8, 9, 10, 13, 14, 15, 16 }))
                return new Blockchain(
                    row.Cells[0].Value?.ToString() ?? "",
                    row.Cells[1].Value?.ToString() ?? "",
                    ParseDouble(row.Cells[2].Value),
                    ParseDouble(row.Cells[3].Value),
                    ParseDouble(row.Cells[4].Value),
                    ParseDouble(row.Cells[5].Value),
                    row.Cells[11].Value?.ToString() ?? "",
                    ParseInt(row.Cells[12].Value)
                );

            if (IsMatch(values, nonEmpty: new[] { 0, 1, 2, 3, 4, 5, 6, 11, 12, 13, 14, 15 }, empty: new[] { 7, 8, 9, 10, 16 }))
                return new MemeCoin(
                    row.Cells[0].Value?.ToString() ?? "",
                    row.Cells[1].Value?.ToString() ?? "",
                    ParseDouble(row.Cells[2].Value),
                    ParseDouble(row.Cells[3].Value),
                    ParseDouble(row.Cells[4].Value),
                    ParseDouble(row.Cells[5].Value),
                    row.Cells[11].Value?.ToString() ?? "",
                    ParseInt(row.Cells[12].Value),
                    row.Cells[14].Value?.ToString() ?? "",
                    ParseInt(row.Cells[15].Value)
                );

            if (IsMatch(values, nonEmpty: new[] { 0, 1, 2, 3, 4, 5, 6, 11, 12, 13, 16 }, empty: new[] { 7, 8, 9, 10, 14, 15 }))
                return new Coins(
                    row.Cells[0].Value?.ToString() ?? "",
                    row.Cells[1].Value?.ToString() ?? "",
                    ParseDouble(row.Cells[2].Value),
                    ParseDouble(row.Cells[3].Value),
                    ParseDouble(row.Cells[4].Value),
                    ParseDouble(row.Cells[5].Value),
                    row.Cells[11].Value?.ToString() ?? "",
                    ParseInt(row.Cells[12].Value),
                    row.Cells[16].Value?.ToString() ?? ""
                );

            return null;
        }
    }
    [Serializable]
    public class CryptoData
    {
        private ICryptoDataParser _parser;
        public CryptoData() { }
        public CryptoData(ICryptoDataParser parser)
        {
            _parser = parser;
        }

        public List<CryptoCurrency> ListOfCrypto { get; set; } = new List<CryptoCurrency>();
        public DataGridView _dataGrid { get; set; } = new DataGridView();

        public delegate void CryptoAddedEventHandler(CryptoCurrency newCrypto);
        public delegate void DataGridRefreshedEventHandler();
        public event CryptoAddedEventHandler CryptoAdded;
        public event DataGridRefreshedEventHandler DataGridRefreshed;

        public void add(CryptoCurrency item)
        {
            ListOfCrypto.Add(item);
            CryptoAdded?.Invoke(item);
        }

        public void AllocateList()
        {
            foreach (DataGridViewRow row in _dataGrid.Rows)
            {
                string[] values = row.Cells.Cast<DataGridViewCell>()
                                           .Select(cell => cell.Value?.ToString() ?? "")
                                           .ToArray();

                var crypto = _parser.DetermineCryptoType(values, row);
                if (crypto != null)
                {
                    add(crypto);
                }
            }
        }

        public void RefreshDataGrid()
        {
            _dataGrid.Rows.Clear();
            for (int i = 0; i < ListOfCrypto.Count; i++)
            {
                _dataGrid.Rows.Add();
                ListOfCrypto[i].FillDataGridRow(_dataGrid.Rows[i]);
            }
            DataGridRefreshed?.Invoke();
        }
    }

}
