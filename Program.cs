using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flyweight
{
    class Program
    {
        abstract class Bead
        {
            protected string type;
            public abstract void Create(double x, double y);
        }

        class FlyweightFactory
        {
            
            Dictionary<string, Bead> beads = new Dictionary<string, Bead>();
            public FlyweightFactory()
            {
                beads.Add("Lake Superior", new AgateBead());
                beads.Add("Rose", new QuartzBead());
            }
            public Bead GetBead(string key)
            {
                if (beads.ContainsKey(key))
                    return beads[key];
                else
                    return null;
            }
        }

        class AgateBead : Bead
        {
            public AgateBead()
            {
                type = "Lake Superior";
            }
            public override void Create(double x, double y)
            {
                Console.WriteLine("Created a Lake Superior agate bead at ({0}, {1})", x, y);
            }
        }
        

        class QuartzBead : Bead
        {
            public QuartzBead()
            {
                type = "Rose";
            }
            public override void Create(double x, double y)
            {
                Console.WriteLine("Created a Rose quartz bead at ({0}, {1})", x, y);
            }
        }
        static void Main(string[] args)
        {
            double x = 0;
            double y = 0;
            FlyweightFactory factory = new FlyweightFactory();
            for (int i = 0; i < 10; i++)
            {
                Bead agate = factory.GetBead("Lake Superior");
                if (agate != null)
                    agate.Create(x, y);
                x += 1;
                y += 1;
            }
            for (int i = 0; i < 10; i++)
            {
                Bead quartz = factory.GetBead("Rose");
                if (quartz != null)
                    quartz.Create(x, y);
                x += 1;
                y += 1;
            }
        }
    }
}
