using HexCardGame.SharedData;
using UnityEngine;
using UnityEngine.Tilemaps;
using TMPro;

namespace HexCardGame.Runtime.Test
{
    public partial class Mechanics_Test
    {
        public class MockCardData : ICardData
        {
            public CardId Id { get; }
            public int Cost { get; }
            public int Score { get; }
            public Sprite Artwork { get; }
            public Sprite Cardback { get;}
            public Tile Tile { get; }
            public string Description { get; }
        }
    }
}