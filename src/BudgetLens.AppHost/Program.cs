var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.BudgetLens_ImportApi>("import-api")
    .WithExternalHttpEndpoints();

builder.AddProject<Projects.BudgetLens_TransactionsApi>("transaction-api")
    .WithExternalHttpEndpoints();

builder.Build().Run();
