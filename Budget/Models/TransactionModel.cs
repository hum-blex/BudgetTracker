using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Budget.Models;

public class TransactionModel
{
	[Key]
	public Guid Id { get; set; }
	[Required]
	public string Name { get; set; }
	[Required]
	public double Amount { get; set; }
	[ValidateNever]
	public DateTime DateTime { get; set; }
	[ForeignKey("CategoryId")]
	[ValidateNever]
	public CategoryModel Category { get; set; }

	public Guid CategoryId { get; set; }

}
