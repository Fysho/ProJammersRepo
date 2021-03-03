﻿using HexCardGame.Runtime.Game;
using NUnit.Framework;

namespace HexCardGame.Runtime.Test
{
    public partial class Mechanics_Test : BaseTestMechanics, IFinishPlayerTurn
    {
        public void OnFinishPlayerTurn(IPlayer player)
        {
            EventReceived = true;
            PlayerId = player.Id;
        }

        [Test]
        public void FinishPlayerTurn_Test()
        {
            Game.StartPlayerTurn();
            Game.FinishPlayerTurn();
            Assert.IsTrue(EventReceived);
            Assert.IsTrue(Game.TurnLogic.CurrentPlayerId == PlayerId);
        }
    }
}