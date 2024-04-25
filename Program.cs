using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ChipSecuritySystem
{
    class Program
    {
        public static List<ColorChip> ExampleChips = new List<ColorChip>() { 
        
        new ColorChip(Color.Blue,Color.Yellow),
        new ColorChip(Color.Red,Color.Green),
        new ColorChip(Color.Yellow,Color.Red),
        new ColorChip(Color.Yellow,Color.Red),
        new ColorChip(Color.Orange,Color.Purple),



        };


        public static void Main(string[] args)
        {

           var res = GetChipSequence(ExampleChips);
            Console.WriteLine(res ==null ? Constants.ErrorMessage: string.Join(" || ",res.Select(x => x.ToString())));

        }


 


        public static List<ColorChip> GetChipSequence( List<ColorChip> c)
        {
            var seq = new List<ColorChip>();
            Color? endcolor = null;
            seq.Add(c.Where(x => x.StartColor == Color.Blue).FirstOrDefault());
            seq.Add(c.Where(x => x.EndColor == Color.Green).FirstOrDefault());


            if (seq.Count == 2)
            {
                endcolor = seq[0].EndColor;
                seq.RemoveAt(1);

                ColorChip currC = c.Where(n => n != seq[0]).ToList().GetNextSequence(endcolor.Value);
                while (currC != null &&  currC.EndColor != Color.Green )
                {
                    seq.Add(currC);
                    endcolor = currC.EndColor;
                    currC = c.Where(n => n != seq[0]).ToList().GetNextSequence(endcolor.Value);
                }
                seq.Add(currC);
                return seq.Where(o => o!= null).ToList();
            }
            else {
            return null;
            }


        }






    }
}
