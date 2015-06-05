using System;

namespace SocialApi.Models
{
  public class Rate
  {
    public int RateId { get; set; }
    public string SharePrice { get; set; }
    public string MaxIncomeCode { get; set; }
    public string FairburnCapitalCode { get; set; }
    public string MoneyMarketRate { get; set; }
    public DateTime DateUpdated { get; set; }
  }
}