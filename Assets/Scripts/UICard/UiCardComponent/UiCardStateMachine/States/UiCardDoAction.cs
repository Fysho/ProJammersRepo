using Patterns.StateMachine;
using UnityEngine;

namespace Tools.UI.Card
{
    /// <summary>
    ///     State when a cards is performing an action.
    /// </summary>
    public class UiCardDoAction : UiBaseCardState
    {
        public UiCardDoAction(IUiCard handler, BaseStateMachine fsm, UiCardParameters parameters) : base(handler, fsm,
            parameters)
        {
        }

        Vector3 StartScale { get; set; }

        //--------------------------------------------------------------------------------------------------------------

        #region Operations

        public override void OnEnterState()
        {
            Disable();
            SetScale();
            SetRotation();
            doAction();
        }

        void SetScale()
        {
            var finalScale = Handler.transform.localScale * Parameters.DiscardedSize;
            Handler.ScaleTo(finalScale, Parameters.ScaleSpeed);
        }

        void SetRotation()
        {
            var speed = Handler.IsPlayer ? Parameters.RotationSpeed : Parameters.RotationSpeedP2;
            Handler.RotateTo(Vector3.zero, speed);
        }

        void doAction()
        {

        }

        #endregion
    }
}