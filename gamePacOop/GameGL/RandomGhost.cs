using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace gamePacOop.GameGL
{
    class RandomGhost : Ghost
    {

        int randomMovement;
        int random;
        GameDirection direction;

        public RandomGhost( Image image, GameCell startCell) : base(GameObjectType.ENEMY, image)
        {
            this.CurrentCell = startCell;
            
        }

        public override GameCell move()
        {
            manageDirections();
            GameCell currentCell = this.CurrentCell;
            GameCell nextCell = currentCell.nextCell(direction);
            GameObject previousObject = nextCell.CurrentGameObject;
            this.CurrentCell = nextCell;

            
            

            if (currentCell != nextCell)
            {
                currentCell.setGameObject(previousObject);

            }
            return nextCell;
        }

        public void manageDirections()
        {
            if (randomMovement % 5 == 0)
            {
                Random r = new Random();
                random = r.Next(4);
            }

            if (random == 0)
            {
                direction = GameDirection.Right;
            }
            else if (random == 1)
            {
                direction = GameDirection.Left;
            }
            else if (random == 2)
            {
                direction = GameDirection.Up;
            }
            else if (random == 3)
            {
                direction = GameDirection.Down;
            }
            randomMovement++;

        }
    }
}
