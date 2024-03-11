using UnityEngine;

public class Buff10002 : BuffBase
{
    public int NowbfHierarchy;

    public override void Initbuff(GameObject owner, string Provider, int id)
    {
        base.Initbuff(owner, Provider, id);
        NowbfHierarchy = 0;
    }




    public override void DecreaseBuff()
    {

        //base.DecreaseBuff();
        //if (reTime >= 0) return;
        bfHierarchy -= 1;
        NowbfHierarchy += 1;
        if (bfHierarchy == 0) { 

            base.ExitBuff(bfOwner, bfId);
        }
        else
        {
            reTime=existTime;
        }

    }



    public override void InCreateBuff()
    {
        base.InCreateBuff();

        //bfHierarchy += 1;
        //÷ÿÀ¢ ±º‰
        reTime = existTime;

    }
}
