using System;

namespace Singleton
{
    /// <summary>
    /// Singleton
    /// </summary>
    public class Logger
    {
        // Make this thread safe with Lazy<T>
        private static readonly Lazy<Logger> _lazyLogger = new Lazy<Logger>(() => new Logger());

        // naive approach and NOT thread safe
        // private static Logger? _instance;

        /// <summary>
        /// Instance
        /// </summary>
        public static Logger Instance
        {
            
            get
            {
                return _lazyLogger.Value;
                /*
                if(_instance == null)
                {
                    _instance = new Logger();
                }
                return _instance;
                */
            }
        }
        protected Logger()
        {
        }

        /// <summary>
        /// Singleton Operation
        /// </summary>
        public void Log(string msg)
        {
            Console.WriteLine($"Log: {msg}");
        }
    }
}
