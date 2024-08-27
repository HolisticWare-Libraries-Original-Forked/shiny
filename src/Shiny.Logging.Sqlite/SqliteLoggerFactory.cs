﻿using Microsoft.Extensions.Logging;

namespace Shiny.Logging.Sqlite;


public class SqliteLoggerProvider(LogLevel logLevel, LoggingSqliteConnection conn) : ILoggerProvider
{
    public ILogger CreateLogger(string categoryName) => new SqliteLogger(categoryName, logLevel, conn);
    public void Dispose() { }
}