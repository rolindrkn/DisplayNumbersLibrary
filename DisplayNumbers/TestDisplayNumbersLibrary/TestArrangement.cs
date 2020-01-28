using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public abstract class TestArrangement
    {
        public void Run()
        {
            Arrange();
            Act();
        }

        protected virtual void Arrange(){}
        protected virtual void Act(){}
    }
}
