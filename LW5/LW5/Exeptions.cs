using System;
using System.Collections.Generic;
using System.Text;

namespace LW5
{
    class StuffExept: Exception
    {
        public StuffExept(string Message)
            : base(Message)
        {

        }
    }

    class TechExept : StuffExept
    {
        public TechExept(string Message)
            : base(Message)
        {

        }
    }

    class ScanExept : TechExept
    {
        public ScanExept(string Message)
            : base(Message)
        {
        }
    }
}
