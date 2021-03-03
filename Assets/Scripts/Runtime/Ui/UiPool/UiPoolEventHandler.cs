﻿using Game.Ui;
using HexCardGame.Runtime;
using HexCardGame.Runtime.Game;
using HexCardGame.Runtime.GamePool;
using UnityEngine;

namespace HexCardGame.UI
{
    [RequireComponent(typeof(UiPool))]
    public class UiPoolEventHandler : UiEventListener, IRestartGame, ISelectPickPoolPosition,
        IPickCard, IReturnCard,
        IRevealCard, IRevealPool
    {
        UiPool UiPool { get; set; }

        void IPickCard.OnPickCard(PlayerId id, CardHand cardHand, PositionId positionId) =>
            UiPool.RemoveCard(positionId);

        void IRestartGame.OnRestart() => UiPool.Clear();

        void IReturnCard.OnReturnCard(PlayerId id, CardHand cardHand, CardPool cardPool, PositionId positionId) =>
            UiPool.AddCard(cardPool, positionId, false);

        void IRevealCard.OnRevealCard(PlayerId id, CardPool cardPool, PositionId positionId) =>
            UiPool.AddCard(cardPool, positionId);

        void IRevealPool.OnRevealPool(IPool<CardPool> pool)
        {
            var positions = PoolPositionUtility.GetAllIndices();
            foreach (var i in positions)
            {
                var cardPool = pool.GetCardAt(i);
                UiPool.AddCard(cardPool, i);
            }
        }

        void ISelectPickPoolPosition.OnSelectPickPoolPosition(PlayerId playerId, PositionId positionId) =>
            GameData.CurrentGameInstance.PickCardFromPosition(playerId, positionId);

        protected override void Awake()
        {
            base.Awake();
            UiPool = GetComponent<UiPool>();
        }
    }
}