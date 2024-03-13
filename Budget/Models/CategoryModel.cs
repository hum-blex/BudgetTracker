namespace Budget.Models;

public class CategoryModel
{
	public Guid Id { get; set; }
	public string CategoryName { get; set; }
	public ICollection<TransactionModel> Transactions { get; set; }
}
