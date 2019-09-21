using PixelEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Snack
{
    public class ExampleSnake : ISnake
    {
        private const int _width = 50;
        private const int _wallDistanceThreshold = 3;
        private Point _myHeadPosition;
        private Point _myFoodPosition;
        public string Name => "Example Snake";

        public SnakeDirection GetNextDirection(SnakeDirection currentDirection)
        {
            Console.WriteLine(_myFoodPosition.X + " " + _myFoodPosition.Y);
            Console.WriteLine(_myHeadPosition.X);
            if (currentDirection == SnakeDirection.Up 
                && _myHeadPosition.Y < _wallDistanceThreshold)
            {
                return SnakeDirection.Left;
            }
            else if ((_myHeadPosition.Y == _myFoodPosition.Y) && (_myHeadPosition.X > _myFoodPosition.X))
            {
                return SnakeDirection.Left;
            }
            else if ((_myHeadPosition.Y == _myFoodPosition.Y) && (_myHeadPosition.X < _myFoodPosition.X))
            {
                return SnakeDirection.Right;
            }

            if (currentDirection == SnakeDirection.Right
                && _myHeadPosition.X > _width - _wallDistanceThreshold)
            {
                return SnakeDirection.Up;
            } else if ((_myHeadPosition.X == _myFoodPosition.X) && (_myHeadPosition.Y < _myFoodPosition.Y)) {
                return SnakeDirection.Down;
            }
            else if ((_myHeadPosition.X == _myFoodPosition.X) && (_myHeadPosition.Y > _myFoodPosition.Y))
            {
                return SnakeDirection.Up;
            }

            if (currentDirection == SnakeDirection.Down
                && _myHeadPosition.Y > _width - _wallDistanceThreshold)
            {
                return SnakeDirection.Right;
            }
            else if ((_myHeadPosition.Y == _myFoodPosition.Y) && (_myHeadPosition.X < _myFoodPosition.X))
            {
                return SnakeDirection.Right;
            }
            else if ((_myHeadPosition.Y == _myFoodPosition.Y) && (_myHeadPosition.X > _myFoodPosition.X))
            {
                return SnakeDirection.Left;
            }

            if (currentDirection == SnakeDirection.Left
                && _myHeadPosition.X <  _wallDistanceThreshold)
            {
                return SnakeDirection.Down;
            }
            else if ((_myHeadPosition.X == _myFoodPosition.X) && (_myHeadPosition.Y > _myFoodPosition.Y))
            {
                return SnakeDirection.Up;
            }
            else if ((_myHeadPosition.X == _myFoodPosition.X) && (_myHeadPosition.Y < _myFoodPosition.Y))
            {
                return SnakeDirection.Down;
            }

            return currentDirection;
        }

        public void UpdateMap(string map)
        {
            _myHeadPosition = getMyHeadPosition(map);
            _myFoodPosition = getMyFoodPosition(map);
        }

        private Point getMyHeadPosition(string map)
        {
            var headIndex = map.IndexOf('*');
            return new Point(headIndex % _width, headIndex / _width);
        }


  
        private Point getMyFoodPosition(string map)
        {
            var headIndex = map.IndexOf('7');
            return new Point(headIndex % _width, headIndex / _width);
        }
    }
}
