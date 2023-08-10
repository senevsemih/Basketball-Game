using _Game_.Scripts.Ball.Base;
using _Game_.Scripts.Ball.Components;
using _Game_.Scripts.Ball.Data;

namespace _Game_.Scripts.Ball.Behaviours
{
    public class BallPassBehaviour : BallBehaviourBase
    {
        public BallPassBehaviour(
            BallData data,
            BallEvents events) : base(data, events)
        {
        }

        public override void Activate()
        {
            base.Activate();
            Execute();
        }

        public override void Execute()
        {
            base.Execute();
            Data.Rigidbody.AddForce(Data.TargetPosition * Config.PassForce);
        }

        public override void OnDestroy()
        {
            base.OnDestroy();
        }
    }
}