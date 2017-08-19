using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TagPay.Backoffice.Api.Models
{
	public class BuyerCard
	{
		[Key]
		public int Id { get; set; }

		public string CardId { get; set; }

		[JsonIgnore]
		public Buyer Buyer {get;set;}

		public int BuyerId { get; set; }
	}
}
