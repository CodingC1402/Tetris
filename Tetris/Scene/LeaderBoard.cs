using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Tetris
{
    public partial class LeaderBoard : Scene
    {
        public LeaderBoard()
        {
            InitializeComponent();
            VisibleChanged += (s, e) =>
            {
                normalBoard.SetBoardItem(Logic.LeaderBoard.Collection[Logic.LeaderBoard.NormalScoreName]);
                risingBoard.SetBoardItem(Logic.LeaderBoard.Collection[Logic.LeaderBoard.RisingFloorName]);
            };
        }
    }
}
