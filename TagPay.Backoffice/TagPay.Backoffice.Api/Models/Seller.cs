using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TagPay.Backoffice.Api.Models
{
    public class Seller : AbstractFacebookPerson
	{
		[Key]
		public int Id { get; set; }

		public string RecipientId { get; set; }

		public IEnumerable<SellerBank> BankIds { get; set; }
	}
}
