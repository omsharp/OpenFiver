Open Fiver
=========

My C# Implementation of the famous Fiver puzzle.
-----------------------------------------------
You can find more about the game here: http://en.wikipedia.org/wiki/Lights_Out_(game)

The traditional game was a 5x5 game, but I wanted to implement a one with unlimited size and see what happens.
**********************************************************

The project is a simple Class Library (**OpenFiver**) which includes only two classes: **Node** and **Puzzle**.

The **Node** class represents a single node, or cell, in the puzzle.

The **Puzzle** class represents a whole puzzle (or a game). A puzzle contains a 2D array of nodes, and manages all the interactions with the player.

**TestApp** is a quick and dirty test game using WinForms UI.
**********************************************



My next 2 goals, if I ever got the time and the will, are:

**Goal 1 :** To implement a solver for this puzzle.

**Goal 2 :** To create a nice looking game using WPF UI.
