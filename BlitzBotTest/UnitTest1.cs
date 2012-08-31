using System;
using System.Collections.Generic;
using BejeweledBlitzBot;
using BejeweledBlitzBot.Rules;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlitzBotTest
{
  [TestClass]
  public class RulesTest
  {
    [TestMethod]
    public void TestVertical()
    {
      Shape[,] board = new Shape[2,3];
      board[0,0] = new Shape(ShapeType.Circle);
      board[1,1] = new Shape(ShapeType.Circle);
      board[1,2] = new Shape(ShapeType.Circle);

      board[0,1] = new Shape(ShapeType.Unknown);
      board[0,2] = new Shape(ShapeType.Unknown);
      board[1,0] = new Shape(ShapeType.Unknown);
      HashSet<ClickMove> result = RulesManager.GetMoves(board);
      Assert.AreEqual(result.Count, 1);
    }

    [TestMethod]
    public void TestHorizontal()
    {
      Shape[,] board = new Shape[4, 2];
      board[0, 0] = new Shape(ShapeType.Circle);
      board[1, 0] = new Shape(ShapeType.Hexagon);
      board[2, 0] = new Shape(ShapeType.Circle);
      board[3, 0] = new Shape(ShapeType.Rhombus);

      board[0, 1] = new Shape(ShapeType.Octagon);
      board[1, 1] = new Shape(ShapeType.Square);
      board[2, 1] = new Shape(ShapeType.Square);
      board[3, 1] = new Shape(ShapeType.Circle);
      HashSet<ClickMove> result = RulesManager.GetMoves(board);
      Assert.AreEqual(result.Count, 0);
    }


  }
}
