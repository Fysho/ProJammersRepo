using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public string cardName = "NoName";
    public string cardDescription = "Default description";
    public string cardType = "None";

    public int manaCost = 1;
    private Button button;
    public Sprite artwork;
    CardDisplay cardDisplay;

    void Start()
    {

        button = gameObject.transform.Find("CardButton").GetComponent<Button>();
        button.onClick.AddListener(DoAction);
        //cardDisplay = gameObject.GetComponent<CardDisplay>();
    }

    public virtual void DoAction()
    {
        CardManager.Instance.RemoveCard(this);
    }
}
