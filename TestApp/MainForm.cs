using System;
using System.Drawing;
using System.Windows.Forms;
using FiverLibrary;

namespace TestApp
{
    public partial class MainForm : Form
    {
        private static readonly Color NewClr = Color.Firebrick;
        private static readonly Color OriginalClr = Color.AliceBlue;
        private Button[,] _btns;
        private Puzzle _puzzle;
        private int _moves;
        private Label _movesLbl;
        private FlowLayoutPanel[] _panels;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            BackColor = OriginalClr;

            _movesLbl = new Label
                           {
                               Font = new Font(Font.FontFamily, 12, FontStyle.Bold),
                               TextAlign = ContentAlignment.MiddleCenter
                           };
        }

        private void CreateGame(int size)
        {
            Clean();
            _puzzle = new Puzzle(size);
            _btns = new Button[size, size];
            _panels = new FlowLayoutPanel[size];
            AutoSize = true;

            //Loop through all the nodes in _puzzle.
            for (var row = 0; row < size; row++)
            {
                _panels[row] = new FlowLayoutPanel
                                  {
                                      AutoSize = true,
                                      AutoSizeMode = AutoSizeMode.GrowAndShrink
                                  };

                flowLayoutPanel.Controls.Add(_panels[row]);
                flowLayoutPanel.Controls.Add(_movesLbl);

                //Inner loop.
                for (var col = 0; col < size; col++)
                {
                    //Copying these two into local variables, cause I'm gonna use them later down in a closure.
                    var indxR = row;
                    var indxC = col;

                    //Create a button to correspond with the current Node.
                    _btns[row, col] = new Button
                                            {
                                                Size = new Size(50, 50),
                                                BackColor = OriginalClr
                                            };

                    _panels[row].Controls.Add(_btns[row, col]);

                    //Hooking the StateChanged event of the current Node. The BackColor of the corresponding button will change depending on the state of the node.
                    //If the node IsOn the button's BackColor will be NewClr, else it will be OriginalClr.
                    _puzzle[row, col].StateChanged += (sender,args) => _btns[indxR, indxC].BackColor = _puzzle[indxR, indxC].IsOn ? NewClr : OriginalClr;
                    
                    //Hooking the NodeResetCompleted event of the current Node. The BackColor of the corresponding button will be set to OriginalClr.
                    _puzzle[row, col].ResetCompleted += (sender, args) => _btns[indxR, indxC].BackColor = OriginalClr;

                    //Hooking the Click event of the current Button. The code in the following Lambda will execute each time a button is clicked.
                    _btns[indxR, indxC].Click += (sender, args) =>
                                                                    {
                                                                        if (_puzzle.IsSolved) return;

                                                                        _moves++;
                                                                        _movesLbl.Text = string.Format("Moves : {0}", _moves);

                                                                        _puzzle.FlipNodeAt(indxR, indxC); //Flip the Node relative to this button.
                                                                    };

                    //Hooking the GridResetComplete of The current puzzle.
                    _puzzle.ResetCompleted += (sender, args) =>
                                                                    {
                                                                        _moves = 0;
                                                                        _movesLbl.Text = string.Format("Moves : {0}", _moves);
                                                                    };


                    //The infamous Application.DoEvents. And yes, I'm using it.
                    Application.DoEvents();
                }
            }


            //Out of the loop
            //Hooking the Solved event of the puzzle. If the puzzle is solved this message will show.
            _puzzle.Solved += (sender2, e2) => MessageBox.Show(@"Solved..... You Win.....");
        }

        /// <summary>
        /// Cleans the puzzle. Sets everything to null.
        /// </summary>
        private void Clean()
        {
            if (_btns != null)
            {
                flowLayoutPanel.Controls.Clear();
                _btns = null;
                _puzzle = null;
                _panels = null;
                _moves = 0;
                _movesLbl.Text = string.Format("Moves : {0}", _moves);
            }
        }

        private void MenuItemExitClick(object sender, EventArgs e)
        {
            if (MessageBox.Show(@"Do You Want To Quit?", @"Quit Game", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Close();
            }
        }

        private void MenuItemResetClick(object sender, EventArgs e)
        {
            if (_puzzle != null)
            {
                _puzzle.Reset();
            }
        }

        private void MenuItemNewGameClick(object sender, EventArgs e)
        {
            //my cheap dirty way of getting the size input from the user.
            var frm = new SizeForm();
         
            if (frm.ShowDialog() == DialogResult.OK)
            {
                CreateGame(frm.GridSize);
                frm.Close();
            }
        }

        private void MenuItemSolve_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"Not implemented yet!");
        }
    }
}