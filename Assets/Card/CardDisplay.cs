using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    public Text cardName;
    public Text cardDescription;
    public Text cardType;
    public Text manaCost;

    private Card card;

    void Start()
    {
        card = gameObject.GetComponent<Card>();
        cardName.text = card.cardName;
        cardDescription.text = card.cardDescription;
        cardType.text = card.cardType;
        manaCost.text = "" + card.manaCost;


    }



}
