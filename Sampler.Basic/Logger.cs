using System;

namespace Sampler.Basic
{
    public interface IDatabaseService
    {
        
    }
    public class DatabaseService : IDatabaseService
    {
        
    }

    public interface ILogger
    {
        void Error(Exception ex);

        void Error(string message);
    }

    public class Logger : ILogger
    {
        private readonly IDatabaseService databaseService;

        public Logger(IDatabaseService databaseService)
        {
            this.databaseService = databaseService;    
        }

        public void Error(Exception ex)
        {
            // .. call to database   
        }

        public void Error(string message)
        {
            // .. call to database
        }

        public void Info(Exception ex)
        {
            // .. call to database
        }

        public void Info(string message)
        {
            // .. call to database
        }
    }

}
