using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLIDD
{
    internal class ConsoleAppender : IAppender
    {
        ILayout layout;
        public ConsoleAppender(ILayout lay)
        {
            this.layout = lay;
        }

        public void Append(ILayout lay)
        {
            throw new NotImplementedException();
        }
    }
}
