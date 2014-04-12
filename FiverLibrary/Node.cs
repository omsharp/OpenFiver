using System;

namespace FiverLibrary
{
    public class Node
    {

        #region "Event Handlers"

        /// <summary>
        /// Occurs when IsOn property changes from false to true, or vise-versa.
        /// </summary>
        public event EventHandler StateChanged;

        /// <summary>
        /// Occurs when the Reset method is called.
        /// </summary>
        public event EventHandler ResetCompleted;

        /// <summary>
        /// Occurs when the Flip method is called.
        /// </summary>
        public event EventHandler Flipped;

        #endregion

        #region "Properties"

        private bool _isOn; 

        public bool IsOn
        {
            get { return _isOn; }

            internal set
            {
                if (value == _isOn) return; //So that StateChanged event won't occur unless the state has really changed.

                _isOn = value;

                if (StateChanged != null) StateChanged(this, new EventArgs());
            }
        }

        public Node Left { get; internal set; }
        public Node Right { get; internal set; }
        public Node Top { get; internal set; }
        public Node Bottom { get; internal set; }

        #endregion

        #region "Constructors"
        internal Node(Node top, Node right, Node bottom, Node left)
        {
            Top = top;
            Right = right;
            Bottom = bottom;
            Left = left;
        }

        internal Node() { }

        #endregion

        #region "Methods"

        /// <summary>
        /// Inverts the state of this node and all the adjacent nodes if found.
        /// The Flipped event will be fired.
        /// </summary>
        internal void Flip()
        {
            IsOn = !IsOn;

            if (Left != null) Left.IsOn = !Left.IsOn;
            if (Right != null) Right.IsOn = !Right.IsOn;
            if (Top != null) Top.IsOn = !Top.IsOn;
            if (Bottom != null) Bottom.IsOn = !Bottom.IsOn;

            //Call the Clicked event handler.
            if (Flipped != null) Flipped(this, new EventArgs());
        }

        /// <summary>
        /// Resets the state of this node to false (off).
        /// The NodeResetComplete event will be fired.
        /// </summary>
        internal void Reset()
        {
            _isOn = false;

            if (ResetCompleted != null) ResetCompleted(this, new EventArgs());
        }

        #endregion
    }
}
