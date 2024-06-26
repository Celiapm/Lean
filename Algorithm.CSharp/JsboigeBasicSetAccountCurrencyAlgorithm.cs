/*
 * QUANTCONNECT.COM - Democratizing Finance, Empowering Individuals.
 * Lean Algorithmic Trading Engine v2.0. Copyright 2014 QuantConnect Corporation.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
*/

using System.Collections.Generic;
using QuantConnect.Brokerages;
using QuantConnect.Data;
using QuantConnect.Interfaces;

namespace QuantConnect.Algorithm.CSharp
{
    /// <summary>
    /// Basic algorithm using SetAccountCurrency
    /// </summary>
    public class JsboigeBasicSetAccountCurrencyAlgorithm : QCAlgorithm
    {
        private Symbol _btcEur;

        /// <summary>
        /// Initialise the data and resolution required, as well as the cash and start-end dates for your algorithm. All algorithms must initialized.
        /// </summary>
        public override void Initialize()
        {
            SetStartDate(2018, 01, 01);  //Set Start Date
            SetEndDate(2018, 12, 31);    //Set End Date
            SetBrokerageModel(BrokerageName.Bitstamp, AccountType.Cash);
            SetAccountCurrency();
            _btcEur = AddCrypto("BTCEUR", Resolution.Daily).Symbol;
        }

        public virtual void SetAccountCurrency()
        {
            //Before setting any cash or adding a Security call SetAccountCurrency
            SetAccountCurrency("EUR");
            SetCash(100000);             //Set Strategy Cash
        }

        /// <summary>
        /// OnData event is the primary entry point for your algorithm. Each new data point will be pumped in here.
        /// </summary>
        /// <param name="data">Slice object keyed by symbol containing the stock data</param>
        public override void OnData(Slice data)
        {
            if (!Portfolio.Invested)
            {
                SetHoldings(_btcEur, 1);
                Debug("Purchased Stock");
            }
            else
            {
                SetHoldings(_btcEur, 0);
                Debug("Sold Stock");
            }
        }
       
    }
}
