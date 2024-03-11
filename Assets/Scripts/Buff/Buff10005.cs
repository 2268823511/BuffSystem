using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff10005 : BuffBase
{
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



    public override void InCreateBuff()
    {
        base.InCreateBuff();

        //bfHierarchy += 1;
     
    }
}
