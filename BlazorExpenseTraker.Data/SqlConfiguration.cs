using System;

namespace BlazorExpenseTraker.Data;

public class SqlConfiguration
{
    public SqlConfiguration(string connectionString) => ConnectionString = connectionString;
    public string ConnectionString {get; }

}
