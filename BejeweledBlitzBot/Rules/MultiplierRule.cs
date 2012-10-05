using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BejeweledBlitzBot.Rules
{
  class MultiplierRule : BaseMatchRule
  {

    public override HashSet<ClickMove> GetMoves(Shape[,] board)
    {
      return base.GetMoves(board, IsMultiplier);
    }

    private bool IsMultiplier(Shape[,] board, int column, int row)
    {
      return board[column, row].Special == SpecialType.Multiplier;
    }
  }
}
