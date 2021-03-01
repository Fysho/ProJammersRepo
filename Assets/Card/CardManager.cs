using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CardManager : MonoBehaviour
{
    public static CardManager Instance;

    private List<Card> _cardsInHand;
    public GameObject[] cardList;

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
            _cardsInHand = new List<Card>();

            DontDestroyOnLoad(gameObject);        //Should this be here?
        }
        else
        {
            Destroy(this);
        }
    }

    //Using string here isnt ideal
    public void AddCardToHand(string cardType)
    {
        GameObject cardObject = null;
        Card newCard = null;
        if (cardType == "Rat")
        {
            cardObject = Instantiate(cardList[0]);
            newCard = cardObject.GetComponent<Rat>();
        }
        else if (cardType == "Spider")
        {
            cardObject = Instantiate(cardList[1]);
            newCard = cardObject.GetComponent<Spider>();
        }
        else if (cardType == "Wolf")
        {
            cardObject = Instantiate(cardList[2]);
            newCard = cardObject.GetComponent<Wolf>();
        }
        if (cardObject == null || newCard == null)
        {
            Debug.LogError("Problem creating card: ");
            if (cardObject == null) Debug.LogError("cardObject is null");
            if (newCard == null) Debug.LogError("newCard is null");
        }
        cardObject.transform.SetParent(GameObject.Find("CardParent").transform);
        _cardsInHand.Add(newCard);
        ShuffleCards();
    }

    //repositions all the cards in the hand
    private void ShuffleCards()
    {
        int x = 150;
        int y = 150;
        int z = 0;
        int incX = 188;

        foreach (Card card in _cardsInHand)
        {
            card.transform.position = new Vector3(x, y, z);
            x += incX;
        }
    }

    public void RemoveCard(Card card)
    {
        _cardsInHand.Remove(card);
        card.gameObject.SetActive(false);
        ShuffleCards();
    }
}
