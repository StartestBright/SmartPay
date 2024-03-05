namespace SmartPay.Server.Models
{
	public class TaxBracket
	{
		public decimal LowerBound { get; set; } // inclusive
		public decimal UpperBound { get; set; } // exclusive
		public decimal TaxRate { get; set; }

		//public TaxBracket(decimal lowerBound, decimal upperBound, decimal taxRate)
		//{
		//	LowerBound = lowerBound;
		//	UpperBound = upperBound;
		//	TaxRate = taxRate;
		//}
	}
}
