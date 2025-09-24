using System.Diagnostics;

/// <summary>
/// Defines a maze using a dictionary. The dictionary is provided by the
/// user when the Maze object is created. The dictionary will contain the
/// following mapping:
///
/// (x,y) : [left, right, up, down]
///
/// 'x' and 'y' are integers and represents locations in the maze.
/// 'left', 'right', 'up', and 'down' are boolean are represent valid directions
///
/// If a direction is false, then we can assume there is a wall in that direction.
/// If a direction is true, then we can proceed.  
///
/// If there is a wall, then throw an InvalidOperationException with the message "Can't go that way!".  If there is no wall,
/// then the 'currX' and 'currY' values should be changed.
/// </summary>
public class Maze
{
    const int LEFT = 0;
    const int RIGHT = 1;
    const int UP = 2;
    const int DOWN = 3;

    private readonly Dictionary<ValueTuple<int, int>, bool[]> _mazeMap;
    private int _currX = 1;
    private int _currY = 1;

    public Maze(Dictionary<ValueTuple<int, int>, bool[]> mazeMap)
    {
        _mazeMap = mazeMap;
    }

    // TODO Problem 4 - ADD YOUR CODE HERE
    /// <summary>
    /// Check to see if you can move left.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveLeft()
    {
        // FILL IN CODE
        // create Tuple for key
        ValueTuple<int, int> key = ValueTuple.Create(_currX, _currY);

        // check if currX, currY is in dictionary
        bool exists = _mazeMap.ContainsKey(key);

        if (exists)
        {
            // check if currX-1, currY is an available space
            bool[] available = _mazeMap[key];

            if (available[LEFT])
                {
                    // update currX if true (valid space)
                    _currX -= 1;
                }
                else
                {
                    throw new InvalidOperationException("Can't go that way!");
                }
        }
        else
        {
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    /// <summary>
    /// Check to see if you can move right.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveRight()
    {
        // FILL IN CODE
        // create Tuple for key
        ValueTuple<int, int> key = ValueTuple.Create(_currX, _currY);

        // check if currX, currY is in dictionary
        bool exists = _mazeMap.ContainsKey(key);

        if (exists)
        {
            // check if currX+1, currY is an available space
            bool[] available = _mazeMap[key];

            if (available[RIGHT])
            {
                // update currX if true (valid space)
                _currX += 1;
            }
            else
            {
                throw new InvalidOperationException("Can't go that way!");
            }
        }
        else
        {
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    /// <summary>
    /// Check to see if you can move up.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveUp()
    {
        // FILL IN CODE
        // create Tuple for key
        ValueTuple<int, int> key = ValueTuple.Create(_currX, _currY);

        // check if currX, currY is in dictionary
        bool exists = _mazeMap.ContainsKey(key);

        if (exists)
        {
            // check if currX, currY-1 is an available space
            bool[] available = _mazeMap[key];

            if (available[UP])
            {
                // update currY if true (valid space)
                _currY -= 1;
            }
            else
            {
                throw new InvalidOperationException("Can't go that way!");
            }
        }
        else
        {
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    /// <summary>
    /// Check to see if you can move down.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveDown()
    {
        // FILL IN CODE
        // create Tuple for key
        ValueTuple<int, int> key = ValueTuple.Create(_currX, _currY);

        // check if currX, currY is in dictionary
        bool exists = _mazeMap.ContainsKey(key);

        if (exists)
        {
            // check if currX-1, currY is an available space
            bool[] available = _mazeMap[key];

            if (available[DOWN])
            {
                // update currY if true (valid space)
                _currY += 1;
            }
            else
            {
                throw new InvalidOperationException("Can't go that way!");
            }
        }
        else
        {
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    public string GetStatus()
    {
        return $"Current location (x={_currX}, y={_currY})";
    }
}