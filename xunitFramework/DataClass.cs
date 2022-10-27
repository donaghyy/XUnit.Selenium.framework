using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xunitFramework
{
    public class DataClass : IEnumerable
    {
        public static IEnumerable<object[]> Data => new List<object[]>
        {
            new object[]
            {
                "David Donaghy",
                "david@outlook.com",
                "50 clooney terrace",
                "373 abbeydale"
            },
            new object[]
            {
                "Gregg Hyndman",
                "gregg@outlook.com",
                "40 the beeches",
                "111 lincoln courts"
            },
            new object[]
            {
                "Sam Smith",
                "sam@outlook.com",
                "123 by the sea",
                "66 canterbury"
            },
            new object[]
            {
                "Kirsty Chambers",
                "kirsty@outlook.com",
                "4 sevenoaks",
                "77 irish street"
            }
        };

        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)Data).GetEnumerator();
        }
    }
}
