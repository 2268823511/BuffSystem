using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff10004 : BuffBase
{

    public override void GetBuff()
    {
        bfHierarchy = 1;
    }

    public override void DecreaseBuff()
    {
        base.DecreaseBuff();
        bfHierarchy -= 1;
        if (bfHierarchy == 0)
        {

            base.ExitBuff(bfOwner, bfId);
        }
        else
        {
            reTime = existTime;
        }

    }
}