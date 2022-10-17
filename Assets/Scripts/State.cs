using System;

namespace Chars.StateMachine
{
    [System.Serializable]
    public class State<T> where T : struct, IComparable, IConvertible, IFormattable
    {
        public string Name;
        public T ID;
        public StateMachine<T> StateMachine;

        public delegate void StateDelegate();

        public StateDelegate OnEnterState;
        public StateDelegate OnUpdateState;
        public StateDelegate OnExitState;

        public State()
        {

        }

        public State(T id)
        {
            ID = id;
        }

        public State(T id, StateMachine<T> stateMachine)
        {
            ID = id;
            Name = id.ToString();
            StateMachine = stateMachine;
        }

        public State(string name)
        {
            Name = name;
        }

        public virtual void EnterState() { OnEnterState?.Invoke(); }
        public virtual void UpdateState() { OnUpdateState?.Invoke(); }
        public virtual void ExitState() { OnExitState?.Invoke(); }
    }
}
