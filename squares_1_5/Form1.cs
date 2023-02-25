using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace squares_1_5
{
    //تصور اخر للعبة 
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            cout = new Cout();
        }
        Cout cout;

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < Cout.rows; i++)
            {
                for (int j = 0; j < Cout.cols; j++)
                {
                    this.Controls.Add(cout.cells[i, j].cellPicBox);

                }
            }

            cout.showSquares();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            if (!cout.moveDown())
            {
                if (cout.inSq.loctions[0].Y <= 0)
                {

                    if (DialogResult.Yes == MessageBox.Show("Game End", "", MessageBoxButtons.YesNo))
                    {


                        // cout = new Cout();

                        for (int i = 0; i < Cout.rows; i++)
                        {
                            for (int j = 0; j < Cout.cols; j++)
                            {
                                cout.cells[i, j].cellPicBox.BackColor = Cell.cellBkColor;
                            }
                        }

                        cout.inSq = new incomingSquare();

                    }
                    else
                        this.Close();


                }
                else
                {
                    // cout.showSquares();
                    cout.inSq = new incomingSquare();
                }
            }
            cout.showSquares();
            timer1.Start();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    cout.moveLeft();
                    break;
                case Keys.Right:
                    cout.moveRight();
                    break;
                case Keys.Up:
                    // timer1.Stop();
                    cout.fallDown();
                    //timer1.Start();
                    break;

            }
        }

    }
}
