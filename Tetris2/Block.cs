using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris2
{
    public abstract class Block
    {
        protected abstract Position[][] Tiles { get; }
        protected abstract Position StartOffset { get; }
        public abstract int Id { get; }

        private int rotaionState;
        private Position offset;

        public Block()
        {
            offset = new Position(StartOffset.Row, StartOffset.Column);
        }

        public IEnumerable<Position> TilePosition()
        {
            foreach (Position p in Tiles[rotaionState])
            {
                yield return new Position(p.Row + offset.Row, p.Column + offset.Column);
            }
        }

        public void RotateCW()
        {
            rotaionState = (rotaionState + 1) % Tiles.Length;
        }

        public void RotateCCW()
        {
            if (rotaionState == 0)
            {
                rotaionState = Tiles.Length - 1;
            }
            else
            {
                rotaionState--;
            }
        }

        public void Move(int rows, int columns)
        {
            offset.Row += rows;
            offset.Column += columns;
        }

        public void Reset()
        {
            rotaionState = 0;
            offset.Row = StartOffset.Row;
            offset.Column = StartOffset.Column;
        }




    }
}
