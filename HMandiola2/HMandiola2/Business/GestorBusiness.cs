using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HMandiola2.Business
{
    public class GestorBusiness : IDisposable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1063:ImplementIDisposableCorrectly")]
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}