using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BejeweledBlitzBot.Rules
{
  public static class RulesManager
  {
    private static List<BaseRule> _rules = new List<BaseRule>();
    static RulesManager()
    {
      _rules.Add(new SameThreeRule());
    }

    public static List<ClickMove> GetMoves(Shape[,] board)
    {
      List<ClickMove> result = new List<ClickMove>();
      foreach (BaseRule rule in _rules)
      {
        result.AddRange(rule.GetMoves(board));
      }

      return result;
    }

  }
}
