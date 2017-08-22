using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TagPay.Backoffice.Api.Models
{
    public abstract class AbstractFacebookPerson
	{

		public string FacebookId { get; set; }

		public string FacebookKey { get; set; }
	}
}
