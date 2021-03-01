using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Card
{
    Spider()
    {
        cardName = "Dark Spider";
        cardDescription = "Summons a dark spider";
        cardType = "Dark";
        manaCost = 2;
        
    }

    public override void DoAction()
    {
        EntityManager.Instance.SpawnFriendly("Spider");
        base.DoAction();
    }
}
