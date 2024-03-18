using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Budget.Models.ViewModels;

public class TransactionVM
{
	public TransactionModel Transaction { get; set; }
	[ValidateNever]
	public IEnumerable<SelectListItem> CategoryList { get; set; }

}
