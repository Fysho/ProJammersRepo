﻿using System.Collections;
using UnityEngine;

namespace HexCardGame
{
    public class AiTurn : TurnState
    {
        protected AiTurn(BattleFsm.BattleFsmArguments args) : base(args)
        {
        }

        protected override PlayerId Id => PlayerId.Ai;

        Coroutine AiFinishTurnRoutine { get; set; }
        float AiFinishTurnDelay => GameParameters.Timers.TimeUntilAiFinishTurn;
        float AiDoTurnDelay => GameParameters.Timers.TimeUntilAiDoTurn;

        protected override IEnumerator StartTurn()
        {
            yield return base.StartTurn();
            //call do turn routine
            Fsm.Controller.MonoBehaviour.StartCoroutine(AiDoTurn());
            //call finish turn routine
            AiFinishTurnRoutine = Fsm.Controller.MonoBehaviour.StartCoroutine(AiFinishTurn(AiFinishTurnDelay));
        }

        protected override void RestartTimeouts()
        {
            base.RestartTimeouts();

            if (AiFinishTurnRoutine != null)
                Fsm.Controller.MonoBehaviour.StopCoroutine(AiFinishTurnRoutine);
            AiFinishTurnRoutine = null;
        }

        IEnumerator AiDoTurn()
        {
            yield return new WaitForSeconds(AiDoTurnDelay);

            if (!IsMyTurn)
                yield break;

            if (!IsAi)
                yield break;

            Game.ExecuteAiTurn(Id);
        }

        IEnumerator AiFinishTurn(float delay)
        {
            yield return new WaitForSeconds(delay);
            if (!IsMyTurn)
                yield break;

            if (!IsAi)
                yield break;

            Fsm.Controller.MonoBehaviour.StartCoroutine(TimeOut());
        }
    }
}