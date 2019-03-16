using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Confusing_Hobo_Unleashed.User;

namespace Confusing_Hobo_Unleashed.Menu
{
    interface Menu
    {
        Object handleAction(Input input);
    }
}
