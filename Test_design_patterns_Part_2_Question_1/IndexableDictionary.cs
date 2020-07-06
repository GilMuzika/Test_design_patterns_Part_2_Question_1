using System;
using System.Collections.Generic;
using System.Text;

namespace Test_design_patterns_Part_2_Question_1
{
    public class IndexableDictionary<Tkey, Tvalue> : Dictionary<Tkey, Tvalue>
    {
        public KeyValuePair<Tkey, Tvalue> this[int ind]
        {
            get
            {
                return EnumerateMe(ind);
            }
        }

        private KeyValuePair<Tkey, Tvalue> EnumerateMe(int ind)
        {
            if (ind > this.Count - 1) throw new IndexOutOfRangeException();
            KeyValuePair<Tkey, Tvalue> kVpair = default(KeyValuePair<Tkey, Tvalue>);
            int count = 0;
            foreach(var s in this)
            {
                if(count == ind)
                {
                    kVpair = s;
                    break;
                }
                count++;
            }
            return kVpair;
        }
    }
}
