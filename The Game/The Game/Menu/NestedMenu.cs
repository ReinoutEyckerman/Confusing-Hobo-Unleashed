using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Confusing_Hobo_Unleashed.User;

namespace Confusing_Hobo_Unleashed.Menu
{
    abstract class NestedMenu : Menu
    {

        private bool active;

        public NestedMenu()
        {
            this.active = false;
        }

        public bool isActive(Input input)
        {
            if (becomesSelected(input))
            {
                return true;
            }

            if (exit(input))
            {
                return false;
            }

            return this.active;
        }

        public abstract object handleAction(Input input);

        private bool becomesSelected(Input input)
        {
            if (!active && input == Input.START)
            {
                active = true;
                return true;
            }

            return false;
        }

        private bool exit(Input input)
        {
            if (active && input == Input.BACK)
            {
                active = false;
                return true;
            }

            return false;
        }
    }
}
