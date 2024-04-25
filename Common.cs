using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChipSecuritySystem
{
    public static class Common
    {


        public static ColorChip GetNextSequence(this List<ColorChip> cc, Color clr)
        {


            return cc.Where(x => x.StartColor == clr).FirstOrDefault();

        }


    }
}
