using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf : Card
{
    Wolf()
    {
        cardName = "Dark Wolf";
        cardDescription = "Summons a dark wolf";
        cardType = "Dark";
        manaCost = 3;
        
    }

    public override void DoAction()
    {
        EntityManager.Instance.SpawnFriendly("Wolf");
        base.DoAction();
    }
}
