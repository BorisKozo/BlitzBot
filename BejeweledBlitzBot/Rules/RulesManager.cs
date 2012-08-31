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

    public static HashSet<ClickMove> GetMoves(Shape[,] board)
    {
      HashSet<ClickMove> result = new HashSet<ClickMove>();
      foreach (BaseRule rule in _rules)
      {
        result.UnionWith(rule.GetMoves(board));
      }

      return result;
    }

  }
}
