using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TagPay.Backoffice.Api.Models
{
    public class TagPayTransaction
    {
		public string FacebookSellerId { get; set; }

		public string FacebookBuyerId { get; set; }

		public int Amount { get; set; }
	}
}
