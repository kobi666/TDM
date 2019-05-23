using UnityEngine;
using System;
using System.Collections.Generic;

namespace Common.FSM
{
    public class FSMState
    {
        private readonly string name;
        private FSMState currentState;
        private readonly Dictionary<string, FSMState> stateMap;

        private List<FSMAction> actions;

        public string Name
        {
            get
            {
                return name;
            }
        }

        private delegate void StateActionProcessor(FSMAction action);

        /// <summary>
        /// This gets all the actions that is inside the state and loop them.
        /// </summary>
        /// <param name="state">State.</param>
        /// <param name="actionProcessor">Action processor.</param>
        private void ProcessStateAction(FSMState state, StateActionProcessor actionProcessor)
        {
            FSMState currentStateOnInvoke = this.currentState;
            IEnumerable<FSMAction> actions = state.GetActions();

            foreach (FSMAction action in actions)
            {
                if (this.currentState != currentStateOnInvoke)
                {
                    break;
                }

                actionProcessor(action);
            }
        }

        

        /// <summary>
        /// Initializes a new instance of the <see cref="Common.FSM.FSMState"/> class.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="owner">Owner.</param>
        public FSMState(string name, FSM owner)
        {
        }

        /// <summary>
        /// Adds the transition.
        /// </summary>
        public void AddTransition(string id, FSMState destinationState)
        {
        }

        /// <summary>
        /// Gets the transition.
        /// </summary>
        public FSMState GetTransition(string eventId)
        {
        }

        /// <summary>
        /// Adds the action.
        /// </summary>
        public void AddAction(FSMAction action)
        {
        }

        /// <summary>
        /// This gets the actions of this state
        /// </summary>
        /// <returns>The actions.</returns>
        public IEnumerable<FSMAction> GetActions()
        {
            return actions;
        }

        /// <summary>
        /// Sends the event.
        /// </summary>
        public void SendEvent(string eventId)
        {
        }
    }
}