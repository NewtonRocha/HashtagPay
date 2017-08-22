using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace TagPay.Backoffice.Api.Models
{
    public class SellerBank
    {
		[Key]
		public int Id { get; set; }
		
		public string BankId { get; set; }

		[JsonIgnore]
		public Seller Seller { get; set; }
	}
}
