using System.ComponentModel.DataAnnotations;

namespace Budget.Models;

public class CategoryModel
{
	[Key]
	public Guid Id { get; set; }
	[Required]
	public string CategoryName { get; set; }

}
