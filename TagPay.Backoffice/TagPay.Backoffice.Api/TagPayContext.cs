using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using TagPay.Backoffice.Api.Models;

namespace TagPay.Backoffice.Api
{
	public class TagPayContext : DbContext
	{
		public TagPayContext(DbContextOptions<TagPayContext> options) : base(options)
		{
		}

		public DbSet<Buyer> Buyers { get; set; }
		public DbSet<Seller> Sellers { get; set; }
		public DbSet<BuyerCard> BuyersCard { get; set; }
	}
}
