using System.ComponentModel.DataAnnotations;

namespace BudgetLens.Core.Models.Statements;

public class ChaseStatement
{
    [Display(Name = "Transaction Date")]
    public DateTimeOffset TransactionDate { get; set; }

    [Display(Name = "Post Date")]
    public DateTimeOffset PostDate { get; set; }

    public string Description { get; set; } = string.Empty;

    public string Category { get; set; } = string.Empty;

    [Display(Name = "Type")]
    public TransactionType TransactionType { get; set; }

    public decimal Amount { get; set; }

    public string? Memo { get; set; }
}
