using System;
using System.Linq;

namespace FiverLibrary
{
    public class Puzzle
    {
        #region "Event Handlers"

        /// <summary>
        /// Occurs when the Reset method is called.
        /// </summary>
        public event EventHandler ResetCompleted;

        /// <summary>
        /// Occurs when all the nodes in this puzzle have IsOn property equals to true. Hence, This puzzle is solved.
        /// </summary>
        public event EventHandler Solved;

        #endregion

        #region "Fields and Properties"

        private readonly Node[,] _nodes;
        private readonly int _size;

        /// <summary>
        /// Returns true if all the nodes in this puzzle are On. Puzzle is solved.
        /// </summary>
        public bool IsSolved { get; private set; }

        /// <summary>
        /// The internal array of nodes in this puzzle.
        /// </summary>
        /// <returns>Returns a Node in the specified Row and Column of this puzzle.</returns>
        public Node this[int row, int column]
        {
            get { return _nodes[row, column]; }
        }

        #endregion


        /// <param name="size">Must be larger than 2, otherwise an ArgumentException will be thrown.</param>
        public Puzzle(int size)
        {
            if (size < 3) throw new ArgumentException("The passed size value must be greater than 3!");

            _size = size;
            _nodes = new Node[size, size];
            CreateNodes();
            SetConnections();
        }

        /// <summary>
        /// Instantiates all the nodes in the internal array of nodes.
        /// </summary>
        private void CreateNodes()
        {
            for (var row = 0; row < _size; row++)
            {
                for (var col = 0; col < _size; col++)
                {
                    _nodes[row, col] = new Node();
                }
            }
        }


        /// <summary>
        /// Set the connections between the nodes
        /// </summary>
        private void SetConnections()
        {
            /*
             * TODO: This method is a mess. Needs to be revisited and cleaned up. 
             * TODO: My OCD hunch is telling me that there is A cleaner more elegant way to do it.
            */
            for (int row = 0; row < _size; row++)
            {
                for (int col = 0; col < _size; col++)
                {
                    //Setting the left node.
                    _nodes[row, col].Left = (col - 1 < 0) ? null : _nodes[row, col - 1];

                    //Setting the right node.
                    _nodes[row, col].Right = (col + 1 > _size - 1) ? null : _nodes[row, col + 1];

                    //Setting the top node.
                    _nodes[row, col].Top = (row - 1 < 0) ? null : _nodes[row - 1, col];

                    //Setting the bottom node.
                    _nodes[row, col].Bottom = (row + 1 > _size - 1) ? null : _nodes[row + 1, col];
                }
            }
        }

        /// <summary>
        /// Flips a node at a certain location given by row and column values.
        /// </summary>
        public void FlipNodeAt(int row, int column)
        {
            _nodes[row, column].Flip();
            CheckIfSolved();
        }


        /// <summary>
        /// Resets all the nodes in this puzzle.
        /// </summary>
        public void Reset()
        {
            foreach (var node in _nodes)
            {
                node.Reset();
            }

            IsSolved = false;

            if (ResetCompleted != null) ResetCompleted(this, new EventArgs());

        }

        public void Solve()
        {
            throw new NotImplementedException("Still on TODO List!");
        }


        private void CheckIfSolved()
        {
            //Loop through the nodes, if there is any one with IsOn set to false then return.
            foreach (var node in _nodes)
            {
                if (!node.IsOn) return;
            }

            Solved(this, new EventArgs());
            IsSolved = true;
        }


    }
}
