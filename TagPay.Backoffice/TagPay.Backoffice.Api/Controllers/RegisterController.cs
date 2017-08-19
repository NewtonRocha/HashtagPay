using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TagPay.Backoffice.Api.Models;
using PagarMe;
using RestSharp;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Text;

namespace TagPay.Backoffice.Api.Controllers
{
    [Route("api/[controller]")]
    public class RegisterController : Controller
    {
		public const string API_KEY = "ak_test_dXDwQk6PfRYKvvQX1hoRSlWsXrsG7T";

		public const string ENCRYPT_KEY = "ek_test_j45lsDipTzofJzHVfodEBINURLbrbr";

		private TagPayContext context;

		public RegisterController(TagPayContext context)
		{
			this.context = context;

			PagarMeService.DefaultApiKey = API_KEY;
			PagarMeService.DefaultEncryptionKey = ENCRYPT_KEY;
		}

        [HttpPost("buyer")]
        public IActionResult RegisterBuyer([FromBody]BuyerRequest request)
        {
			var buyer = default(Buyer);
			try
			{
				request.Card.Save();

				buyer = new Buyer()
				{
					FacebookKey = request.FacebookKey,
					FacebookId = request.FacebookId,
					CardIds = new List<BuyerCard>()
					{
						new BuyerCard()
						{
							CardId = request.Card.Id
						}
					}
				};

				var client = new HttpClient();
				client.DefaultRequestHeaders.Accept.Clear();
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				client.DefaultRequestHeaders.Add("User-Agent", "Cappta Order Sync");

				var restRequest = new HttpRequestMessage(HttpMethod.Post, "http://8e5aae45.ngrok.io/merchants");
				restRequest.Content = new StringContent(JsonConvert.SerializeObject(new
				{
					Id = buyer.FacebookId,
					Token = buyer.FacebookKey
				}), Encoding.UTF8, "application/json");

				client.SendAsync(restRequest);

				this.context.Buyers.Add(buyer);
				
				this.context.SaveChanges();
			}
			catch (Exception)
			{
				return BadRequest();
			}

            return StatusCode(201, buyer);
        }

        [HttpPost("{seller}")]
        public IActionResult RegisterSeller([FromBody]SellerRequest request)
        {
			var seller = default(Seller);
			try
			{

				PagarMeService.DefaultApiKey = API_KEY;
				PagarMeService.DefaultEncryptionKey = ENCRYPT_KEY;

				request.BankAccount.Save();

				request.Recipient = new Recipient()
				{
					TransferInterval = TransferInterval.Weekly,
					TransferDay = 5,
					TransferEnabled = true,
					BankAccount = request.BankAccount
				};

				request.Recipient.Save();

				seller = new Seller()
				{
					RecipientId = request.Recipient.Id,
					FacebookId = request.FacebookId,
					FacebookKey = request.FacebookKey,
					BankIds = new List<SellerBank>()
					{
						new SellerBank() { BankId = request.BankAccount.Id}
					}
				};

				this.context.Sellers.Add(seller);

				this.context.SaveChanges();
			}
			catch (Exception ex)
			{
				return BadRequest();
			}

			return StatusCode(201, seller);
		}
    }
}
