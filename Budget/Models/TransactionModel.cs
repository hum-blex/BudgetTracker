namespace Budget.Models;

public class TransactionModel
{
	public Guid Id { get; set; }
	public string Name { get; set; }
	public double Amount { get; set; }
	public DateTime DateTime { get; set; }
	public CategoryModel Category { get; set; }
	public int CategoryId { get; set; }
}
