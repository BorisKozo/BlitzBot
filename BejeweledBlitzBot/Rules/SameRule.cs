﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BejeweledBlitzBot.Rules
{
  public class SameRule : BaseMatchRule
  {

    public override HashSet<ClickMove> GetMoves(Shape[,] board)
    {
      return base.GetMoves(board, EmptyPredicate);
    }

    private bool EmptyPredicate(Shape[,] arg1, int arg2, int arg3)
    {
      return true;
    }
  }
}
