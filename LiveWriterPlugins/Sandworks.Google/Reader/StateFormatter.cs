using System;

namespace Sandworks.Google.Reader
{
    public static class StateFormatter
    {
        /// <summary>
        /// Convert raw string to typed State.
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public static State ToState(string state)
        {
            switch (state)
            {
                case "unknown":
                    return State.Unknown;
                case "label":
                    return State.Label;
                case "starred":
                    return State.Starred;
                case "broadcast":
                    return State.Broadcast;
                case "like":
                    return State.Like;
                case "read":
                    return State.Read;
                case "fresh":
                    return State.Fresh;
                case "reading-list":
                    return State.ReadingList;
                default:
                    return State.Unknown;
            }
        }

        /// <summary>
        /// Convert typed State to raw string.
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public static string ToString(State state)
        {
            switch (state)
            {
                case State.Unknown:
                    return "unknown";
                case State.Label:
                    return "label";
                case State.Starred:
                    return "starred";
                case State.Broadcast:
                    return "broadcast";
                case State.Like:
                    return "like";
                case State.Read:
                    return "read";
                case State.Fresh:
                    return "fresh";
                case State.ReadingList:
                    return "reading-list";
                default:
                    return state.ToString();
            }
        }
    }
}
