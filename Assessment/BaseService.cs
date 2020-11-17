using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Assessment
{
    public class BaseService
    {
        public static TransferFees LoadJsonFile()
        {
            var configAmounts = new TransferFees();
            using (StreamReader load = new StreamReader("fees.config.json"))
            {
                string json = load.ReadToEnd();
                configAmounts = JsonConvert.DeserializeObject<TransferFees>(json);
            }

            return configAmounts;
        }
    }

    public class TransferFees
    {
      public List<fee> fees { get; set; }
    }

    public class fee
    {
        public int minAmount { get; set; }
        public int maxAmount { get; set; }
        public int feeAmount { get; set; }
    }

    public class FundTransfer
    {
        public int ChargeAmount { get; set; }
        public int TransferAmount { get; set; }
    }
}
