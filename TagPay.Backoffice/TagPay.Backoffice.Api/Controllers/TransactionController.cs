using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TagPay.Backoffice.Api.Models;
using PagarMe;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TagPay.Backoffice.Api.Controllers
{
	[Route("api/[controller]")]
	public class TransactionController : Controller
	{
		public const string API_KEY = "ak_test_dXDwQk6PfRYKvvQX1hoRSlWsXrsG7T";

		public const string ENCRYPT_KEY = "ek_test_j45lsDipTzofJzHVfodEBINURLbrbr";

		private readonly TagPayContext context;

		public TransactionController(TagPayContext context)
		{
			PagarMeService.DefaultApiKey = API_KEY;
			PagarMeService.DefaultEncryptionKey = ENCRYPT_KEY;
			this.context = context;
		}

		[HttpPost]
		public IActionResult CreateTransaction([FromBody]TagPayTransaction request)
		{
			try
			{
				var transaction = new Transaction();

				transaction.Amount = request.Amount;
				transaction.PaymentMethod = PaymentMethod.CreditCard;

				var buyer = this.context.Buyers.Include(x => x.CardIds).FirstOrDefault(x => x.FacebookId == request.FacebookBuyerId);

				var buyerCardId = buyer.CardIds.First().CardId;

				transaction.Card = new Card()
				{
					Id = buyerCardId
				};

				transaction.Customer = new Customer()
				{
					Name = "John Appleseed",
					DocumentNumber = "92545278157",
					Email = "jappleseed@apple.com",
					Address = new Address()
					{
						Street = "Rua Dr. Geraldo Campos Moreira",
						Neighborhood = "Cidade Monções",
						Zipcode = "04571020",
						StreetNumber = "240"
					},
					Phone = new Phone()
					{
						Ddd = "11",
						Number = "15510101"
					}
				};

				var seller = this.context.Sellers.FirstOrDefault(x => x.FacebookId == request.FacebookSellerId);

				transaction.SplitRules = new SplitRule[]{
					new SplitRule
					{
						Recipient = new Recipient() {
							Id = seller.RecipientId
						},
						Percentage = 100
					}
				};
				
				transaction.Save();
			}
			catch (Exception ex)
			{
				return BadRequest();
			}

			return StatusCode(201);
		}
	}
}
