using PagarMe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TagPay.Backoffice.Api.Models
{
    public class SellerRequest : AbstractFacebookPerson
    {
		public BankAccount BankAccount { get; set; }

		public Recipient Recipient { get; set; }
	}
}
