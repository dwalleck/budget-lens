using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;

namespace BudgetLens.Core.Models.Statements;

public class ChaseTransaction
{
    public ChaseTransaction(DateTimeOffset transactionDate, DateTimeOffset postDate, string description, string category, TransactionType transactionType, decimal amount, string? memo)
    {
        TransactionDate = transactionDate;
        PostDate = postDate;
        Description = description;
        Category = category;
        TransactionType = transactionType;
        Amount = amount;
        Memo = memo;
        TransactionHash = ComputeTransactionHash();
    }

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

    public string TransactionHash { get; private set; }

    public string ComputeTransactionHash()
    {
        var transactionKey = $"{TransactionDate:yyyy-MM-dd}|{PostDate:yyyy-MM-dd}|{Description}|{Amount}";

        var bytes = Encoding.UTF8.GetBytes(transactionKey);
        var hash = SHA256.HashData(bytes);
        return Convert.ToBase64String(hash);
    }
}
