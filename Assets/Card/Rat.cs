using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rat : Card
{
    Rat()
    {
        cardName = "Dark Rat";
        cardDescription = "Summons a dark rat";
        cardType = "Dark";
        manaCost = 1;
        
    }

    public override void DoAction()
    {
        EntityManager.Instance.SpawnFriendly("Rat");
        base.DoAction();

    }
}
