using System;
using System.Collections.Generic;
using System.Text;

namespace Apollo.Domain.Enum
{
    // See the state should be similar to EF states
     public enum ObjectState
    {
        Unchanged = 0,
        Added,
        Modified,
        Deleted
        
    }
}