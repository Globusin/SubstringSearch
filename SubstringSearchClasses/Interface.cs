using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubstringSearchClasses
{
    public interface ISubstringSearch
    {
        List<int> IndexesOf(string pattern, string text);
    }
}
