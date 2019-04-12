using Confusing_Hobo_Unleashed.UI;
using Confusing_Hobo_Unleashed.UI.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Confusing_Hobo_Unleashed.UI.Colors;

namespace Confusing_Hobo_Unleashed.Shapes
{
    class RegularTrapeze : RegularShape
    {
        private double rico;
        public RegularTrapeze(RegularTrapeze copy) : base(copy)
        {
            this.rico = copy.rico;
        }


        public RegularTrapeze(Position position, int width, int height) : base(position, width, height)
        {
            rico = Convert.ToDouble(height) / (width - 5);
        }

        public override bool IsInsideShape(int x, int y)
        {
            var x1 = width;
            short w = 1;
            for (short x = 0; x < width; x++)
            {
                if (x == width / 4)
                {
                    w = 0;
                }
                else if (x == width * 3 / 4)
                {
                    w = -1;
                    x1 = width * 3 / 4;
                }

                var ypos = Convert.ToInt16(w * rico * (x - x1) + height - 1);
            }

            for (int x = 0; x < width; x++) //TODO
            {
                for (int y = 0; y < height; y++)
                {
                    grid[x, y] = this.pixel;
                }
            }
            return base.toImage().addTopLayer(new Image(grid,this.position));
        }

        public override bool IsOnBorder(int x, int y)
        {
            throw new NotImplementedException();
        }

        public override RegularShape Clone()
        {
            throw new NotImplementedException();
        }
    }
}