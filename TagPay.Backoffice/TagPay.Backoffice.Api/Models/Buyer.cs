using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TagPay.Backoffice.Api.Models
{
    public class Buyer : AbstractFacebookPerson
	{
		[Key]
		public int Id { get; set; }

		public virtual List<BuyerCard> CardIds { get; set; }
	}
}
