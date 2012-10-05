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
      _rules.Add(new LightningRule());
      _rules.Add(new MultiplierRule());
      _rules.Add(new SameRule());
    }

    public static HashSet<ClickMove> GetMoves(Shape[,] board)
    {
      HashSet<ClickMove> result = new HashSet<ClickMove>();
      foreach (BaseRule rule in _rules)
      {
        result = rule.GetMoves(board);
        if (result.Count > 0)
          break;
      }

      return result;
    }

  }
}
