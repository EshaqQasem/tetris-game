using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace squares_1_5
{
    class Cell
    {
        
        public static  int height = 35;
        public static  int width = 35;
        public static  Color cellBkColor = Color.SkyBlue;
        Color color;
        public  PictureBox cellPicBox;

        public Cell(int x,int y)
        {
              this.cellPicBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.cellPicBox)).BeginInit();
           
            // 
            // cellPicBox
            // 
            color = Cell.cellBkColor;
            this.cellPicBox.BackColor = color;
            this.cellPicBox.BorderStyle = BorderStyle.FixedSingle;
                
            this.cellPicBox.Location = new System.Drawing.Point(x*Cell.width, y*Cell.height);
            this.cellPicBox.Name = "cellPicBox";
            this.cellPicBox.Size = new System.Drawing.Size(Cell.width, Cell.height);
            this.cellPicBox.TabIndex = 0;
            this.cellPicBox.TabStop = false;
        }
    }

    class Cout
    {
       public static  int cols = 10;
       public static  int rows = 18;

        public Cell[,] cells; 
        public incomingSquare inSq;
        public Cout()
        {
            cells = new Cell[18, 10];
            inSq = new incomingSquare();
            for (int i = 0; i < rows; i++)
            {
                //cells[i] = new Cell[10]; 
                for (int j = 0; j < cols; j++)
                {
                    cells[i, j] = new Cell(j, i);
                }


            }
        }

        public void showSquares()
        {
            for (int i = 0; i < inSq.pointsNums; i++)
            {
                if( inSq.loctions[i].Y >=0)  //احتياط من اجل المربعات التي لم تظهر بعد
                cells[inSq.loctions[i].Y, inSq.loctions[i].X].cellPicBox.BackColor = inSq.col;
            }
        }

        public void clearSquares()
        {
            for (int i = 0; i < inSq.pointsNums; i++)
            {
                if (inSq.loctions[i].Y >= 0)
                cells[inSq.loctions[i].Y, inSq.loctions[i].X].cellPicBox.BackColor = Cell.cellBkColor;
            }
        }

        private bool isSquaresArr()
        {
             bool arrived=false;
            for (int i = 0; i < inSq.pointsNums; i++)
            {
               
                    if (inSq.loctions[i].Y >= 0)
                    if (inSq.loctions[i].Y + 1 == Cout.rows || cells[inSq.loctions[i].Y + 1, inSq.loctions[i].X].cellPicBox.BackColor != Cell.cellBkColor)
                    {
                        arrived=true;
                        break;
                    }
            }

            if(arrived)
            {
                
               
               

            return false;
                }
            
            return true;
        }

        private bool CanMoveRight()
        {
            for (int i = 0; i < inSq.pointsNums; i++)
            {
                if (inSq.loctions[i].Y >= 0)
                    if (inSq.loctions[i].X + 1 == Cout.cols || cells[inSq.loctions[i].Y, inSq.loctions[i].X+1].cellPicBox.BackColor != Cell.cellBkColor)
                        return false;
            }
            return true;
        }

        private bool CanMoveLeft()
        {
            for (int i = 0; i < inSq.pointsNums; i++)
            {
                if (inSq.loctions[i].Y >= 0)
                    if (inSq.loctions[i].X  == 0 || cells[inSq.loctions[i].Y, inSq.loctions[i].X - 1].cellPicBox.BackColor != Cell.cellBkColor)
                        return false;
            }
            return true;
        }

        public bool moveDown()
        {
            clearSquares();
            if (isSquaresArr())
            {
                
                inSq.increaseY();


                showSquares();
               
                return true;
            }
            showSquares();
            broking();
           // inSq = new incomingSquare();
            return false;
        }

        public void broking()
        {
            for (int i = 0; i < inSq.pointsNums; i++)
            {
                bool lineFull = true;
                for (int j = 0; j < Cout.cols; j++)
                {
                    if(inSq.loctions[i].Y >= 0) 
                    if(this.cells[inSq.loctions[i].Y, j].cellPicBox.BackColor == Cell.cellBkColor)
                     {
                       
                         lineFull = false;
                        break;
                     }
                     
                }
                // MessageBox.Show(inSq.loctions[i].Y.ToString());
                if (lineFull)
                {
                    for (int h = inSq.loctions[i].Y; h > 0; h--)
                    {
                        for (int j = 0; j < Cout.cols; j++)
                        {
                            this.cells[h, j].cellPicBox.BackColor = this.cells[h - 1, j].cellPicBox.BackColor;
                        }
                    }
                }
            }
              /* for(int i=0;i<inSq.pointsNums;i++)
               {
                   for(int y=0;y<cols;y++)
                   {
                       if ( inSq.loctions
               * /*/
        }
        
        public bool moveRight()
        {
            clearSquares();
            if (CanMoveRight())
            {

                inSq.increaseX();

               
                showSquares();


                return true;
            }
            showSquares();
            return false;
        }

        public bool moveLeft()
        {
            clearSquares();
            if (CanMoveLeft())
            {

                inSq.decreaseX();

               
                showSquares();


                return true;
            }
            showSquares();
            return false;
        }

        public void fallDown()
        {
            clearSquares();
            while (isSquaresArr())
            {
                this.inSq.increaseY(); 
              
            }
            this.showSquares();
            broking();
            inSq = new incomingSquare();
        }
    }
}
