﻿using System;
using Random = UnityEngine.Random;

namespace HexCardGame.Runtime.GameTurn
{
    /// <summary> This class decides which player goes first and which player goes next. </summary>
    public class TurnLogic : ITurnLogic
    {
        public TurnLogic(IPlayer[] players)
        {
            if (players == null)
                throw new ArgumentException("A Null List is not a valid argument to Create a TurnLogic");
            if (players.Length < 1)
                throw new ArgumentException("Invalid number of players: " + PlayersCount);

            Players = players;
            TurnCount = 0;
        }

        #region Properties

        public PlayerId CurrentPlayerId { get; private set; }
        public PlayerId NextPlayerId => CurrentPlayer.Id == PlayerId.User ? PlayerId.Ai : PlayerId.User;
        public PlayerId StarterPlayerId { get; private set; }
        public IPlayer[] Players { get; }
        public int TurnCount { get; private set; }
        public IPlayer CurrentPlayer => GetPlayer(CurrentPlayerId);
        public IPlayer NextPlayer => GetPlayer(NextPlayerId);
        public IPlayer StarterPlayer => GetPlayer(StarterPlayerId);
        public int PlayersCount => Players.Length;
        public bool IsMyTurn(IPlayer player) => CurrentPlayer == player;
        public bool IsMyTurn(PlayerId id) => CurrentPlayerId == id;

        #endregion

        #region Operations

        /// <summary> Assign next player to the current player. </summary>
        public void UpdateCurrentPlayer()
        {
            //increment turn count
            TurnCount++;

            //not on the first turn of the match
            if (TurnCount == 1)
                return;

            //update current player
            CurrentPlayerId = NextPlayerId;
        }

        /// <summary> Decides which player goes first Randomly. </summary>
        public void DecideStarterPlayer()
        {
            var randomIndex = Random.Range(0, PlayersCount);
            randomIndex = 0;
            StarterPlayerId = Players[randomIndex].Id;
            CurrentPlayerId = StarterPlayerId;
        }

        public IPlayer GetOpponent(IPlayer player) => player.Id == PlayerId.User
            ? GetPlayer(PlayerId.Ai)
            : GetPlayer(PlayerId.User);

        public IPlayer GetPlayer(PlayerId id)
        {
            foreach (var player in Players)
                if (player.Id == id)
                    return player;

            return null;
        }

        public bool IsUser() => CurrentPlayerId == PlayerId.User;
        public bool IsEnemy() => CurrentPlayerId == PlayerId.Ai;

        public void SetCurrentSeat(PlayerId current) => CurrentPlayerId = current;

        public void SetStarterSeat(PlayerId first) => StarterPlayerId = first;

        #endregion
    }
}