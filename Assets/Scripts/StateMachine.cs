using System;

namespace Chars.StateMachine
{
    [Serializable]
    public class StateMachine<T> where T : struct, IComparable, IConvertible, IFormattable
    {
        public T CurrentState;
        private State<T> CurrenStateData;
        private T[] data;
        private State<T>[] states;

        public void InitStateMachine()
        {
            data = (T[])Enum.GetValues(typeof(T));

            states = new State<T>[data.Length];

            for (int i = 0; i < data.Length; i++)
            {
                states[i] = new State<T>(data[i]);
            }
        }

        public virtual void Update()
        {
            CurrenStateData?.UpdateState();
        }

        public State<T> GetState(int stateID) => states[stateID];
        public State<T> GetCurrentStateData() => CurrenStateData;
        public T GetCurrentState() => CurrentState;
     
        public void SetCurrentState(int ID)
        {
            if (ID < 0 || ID >= data.Length)
            {
                return;
            }

            CurrentState = data[ID];

            var state = GetState(ID);

            if (state == null) return;
            if (CurrenStateData == state) return;

            CurrenStateData?.ExitState();
            CurrenStateData = state;
            CurrenStateData?.EnterState();
        }

        public void SetStateData(int index, State<T> data)
        {
            State<T> state = GetState(index);
            state.OnEnterState = () => data.EnterState();
            state.OnUpdateState = () => data.UpdateState();
            state.OnExitState = () => data.ExitState();
        }
     
        public void RemoveAllListener()
        {
            for(int i = 0; i < data.Length; i++)
            {
                RemoveListener(i);
            }
        }
         
        public void RemoveListener(int index)
        {
            State<T> state = GetState(index);
            state.OnEnterState = null;
            state.OnExitState = null;
            state.OnUpdateState = null;
        }
    }
}
