using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissileCommand
{
    class Counter
    {
        private int hundredsLimit = 9;
        private int dozensLimit = 9;
        private int unitLimit = 9;
        private int hundreds;
        private int dozens;
        private int unit;


        public Counter()
        {

        }

        public void Update(bool input)
        {
            if (input)
            {
                if (unit < 9)
                {
                    unit += 1;
                }
                else
                {
                    unit = 0;

                    if (dozens < 9)
                    {
                        dozens += 1;
                    }
                    else
                    {
                        dozens = 0;

                        if (hundreds < 9)
                        {
                            hundreds += 1;
                        }
                    }
                }
            }
        }

        public void Draw()
        {

        }
    }
}
