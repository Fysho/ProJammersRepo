using UnityEngine;
using UnityEngine.Tilemaps;
using TMPro;

namespace HexCardGame.SharedData
{
    public interface ICardData
    {
        CardId Id { get; }
        int Health { get; set; }
        int Attack { get; }
        int Buff { get; }
        string BuffType { get; }
        int Cost { get; }
        int Score { get; }
        Sprite Artwork { get; }
        Sprite Cardback { get; }
        string Description { get; }
        Tile Tile { get; }
    }

    [CreateAssetMenu(menuName = "Data/Card")]
    public class CardData : ScriptableObject, ICardData
    {
        [SerializeField] Sprite artwork;
        [SerializeField] Sprite cardback;
        [Range(0, 5), SerializeField] int cost;
        [SerializeField, Multiline] string description;
        [SerializeField] CardId id;
        [SerializeField] string nameCard;
        [Range(0, 10), SerializeField] int score;
        [SerializeField] string stringId;
        [SerializeField] Tile tile;
        [Range(0, 10), SerializeField] int health;
        [Range(0, 10), SerializeField] int attack;
        [Range(0, 10), SerializeField] int buff;
        [SerializeField] string bufftype;

        // -------------------------------------------------------------------------------------------------------------

        public CardId Id => id;
        public int Cost => cost;
        public int Score => score;
        public int Attack => attack;
        public int Buff => buff;

        public Sprite Artwork
        {
            get => artwork;
            set => artwork = value;
        }

        public Sprite Cardback
        {
            get => cardback;
            set => cardback = value;
        }

        public string Description
        {
            get => description;
            set => description = value;
        }

        public string BuffType
        {
            get => bufftype;
            set => bufftype = value;
        }

        public int Health 
        {
            get => health;
            set => health = value;
        }

        public Tile Tile => tile;
    }
}