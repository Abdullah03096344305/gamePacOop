using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace gamePacOop.GameGL
{
    class HorizontalGhost : Ghost
    {
        GameDirection direction;
        public HorizontalGhost(GameDirection direction, Image image, GameCell startCell) : base(GameObjectType.ENEMY, image)
        {
            this.direction = direction;
            this.CurrentCell = startCell;
        }

        public override GameCell move()
        {
            GameCell currentCell = this.CurrentCell;
            GameCell nextCell = currentCell.nextCell(direction);
            GameObject previousObject = nextCell.CurrentGameObject;
            this.CurrentCell = nextCell;

            if (currentCell == nextCell)
            {
                Directions();
                currentCell.setGameObject(currentCell.CurrentGameObject);
            }

            if (currentCell != nextCell)
            {
                currentCell.setGameObject(previousObject);

            }
            else
            {
               
            }
            return nextCell;
        }

        public void Directions()
        {
            if (direction == GameDirection.Left)
            {
                direction = GameDirection.Right;
            }
            else if (direction == GameDirection.Right)
            {
                direction = GameDirection.Left;
            }
        }

    }
}
