using PagarMe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TagPay.Backoffice.Api.Models
{
    public class BuyerRequest : AbstractFacebookPerson
    {
		public Card Card { get; set; }
	}
}
