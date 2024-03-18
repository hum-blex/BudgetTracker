using System.ComponentModel.DataAnnotations;

namespace Budget.Models;

public class CategoryModel
{
	[Key]
	public int Id { get; set; }
	[Required]
	public string CategoryName { get; set; }

}
