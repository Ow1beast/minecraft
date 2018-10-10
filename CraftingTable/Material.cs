using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftingTable
{
    public class Material
    {
        public int Number { get; set; }

        public static Material operator +(Material one, Material two)
        {
            Material material = new Material();
            material.Number = one.Number + two.Number;
            return material;
        }
    }
}
