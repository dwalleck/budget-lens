var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.BudgetLens_ImportApi>("import-api")
    .withExternalHttpEndpoints();

builder.AddProject<Projects.BudgetLens_TransactionsApi>("transaction-api")
    .withExternalHttpEndpoints();

builder.Build().Run();
