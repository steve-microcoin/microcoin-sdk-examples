using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Astrosys.Logging
{
    /// <summary>
    /// A simple interface that abstracts logging mechanism
    /// </summary>
    public interface ILogger
    {
        void Log(string message);
    }
}
