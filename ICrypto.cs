using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CryptoDataDLL
{
    internal interface ICrypto
    {
       void FillDataGridRow(DataGridViewRow row);
    }
}
