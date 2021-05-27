using System;

namespace SeedWork.DB
{
    public class ConnectionStringBuilder
    {

        private readonly string _template;

        public ConnectionStringBuilder(string connectionString)
        {
            _template = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }


        public string GetPlainString()
        {
            return  _template;

        }
    }
}
