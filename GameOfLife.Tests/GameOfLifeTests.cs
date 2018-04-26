using System;
using System.Linq;
using GameOfLive.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameOfLife.Tests
{
    [TestClass]
    public class GameOfLifeTests
    {
        [TestMethod]
        public void Test()
        {
            int[,] board = new int[,]{
                { 0, 1, 0, 0, 0 },
                { 1, 0, 0, 1, 1 },
                { 1, 1, 0, 0, 1 },
                { 0, 1, 0, 0, 0 },
                { 1, 0, 0, 0, 1 }
            };

            int[,] newGeneration = new int[,] {
                { 0, 0, 0, 0, 0 },
                { 1, 0, 1, 1, 1 },
                { 1, 1, 1, 1, 1 },
                { 0, 1, 0, 0, 0 },
                { 0, 0, 0, 0, 0 }
            };

            BoardCalculator steps = new BoardCalculator();

            var stepResult = steps.PerformStep(board);

            Assert.IsTrue(newGeneration.Cast<int>().SequenceEqual(stepResult.Cast<int>()));
        }

        [TestMethod]
        public void TestUnderPopulation()
        {
            int[,] board = new int[,]{
                { 0, 0, 0, 0, 0 },
                { 1, 0, 0, 1, 0 },
                { 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0 },
                { 1, 0, 1, 0, 1 }
            };

            int[,] newGeneration = new int[,] {
                { 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0 }
            };

            BoardCalculator steps = new BoardCalculator();

            var stepResult = steps.PerformStep(board);

            Assert.IsTrue(newGeneration.Cast<int>().SequenceEqual(stepResult.Cast<int>()));
        }

        [TestMethod]
        public void TestSurvival()
        {
            int[,] board = new int[,]{
                { 0, 0, 1, 0, 0 },
                { 0, 1, 0, 0, 0 },
                { 1, 0, 0, 0, 1 },
                { 0, 0, 0, 1, 0 },
                { 0, 0, 0, 0, 1 }
            };

            int[,] newGeneration = new int[,] {
                { 0, 0, 0, 0, 0 },
                { 0, 1, 0, 0, 0 },
                { 0, 0, 0, 0, 0 },
                { 0, 0, 0, 1, 1 },
                { 0, 0, 0, 0, 0 }
            };

            BoardCalculator steps = new BoardCalculator();

            var stepResult = steps.PerformStep(board);

            Assert.IsTrue(newGeneration.Cast<int>().SequenceEqual(stepResult.Cast<int>()));
        }

        [TestMethod]
        public void TestOverCrowding()
        {
            int[,] board = new int[,]{
                { 1, 1, 1, 0, 0 },
                { 1, 1, 0, 0, 0 },
                { 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0 }
            };

            int[,] newGeneration = new int[,] {
                { 1, 0, 1, 0, 0 },
                { 1, 0, 1, 0, 0 },
                { 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0 }
            };

            BoardCalculator steps = new BoardCalculator();

            var stepResult = steps.PerformStep(board);

            Assert.IsTrue(newGeneration.Cast<int>().SequenceEqual(stepResult.Cast<int>()));
        }

        [TestMethod]
        public void TestReproduction()
        {
            int[,] board = new int[,]{
                { 0, 1, 0, 0, 0 },
                { 1, 1, 0, 0, 0 },
                { 0, 0, 1, 1, 0 },
                { 0, 0, 1, 0, 0 },
                { 0, 0, 0, 0, 0 }
            };

            int[,] newGeneration = new int[,] {
                { 1, 1, 0, 0, 0 },
                { 1, 1, 0, 0, 0 },
                { 0, 0, 1, 1, 0 },
                { 0, 0, 1, 1, 0 },
                { 0, 0, 0, 0, 0 }
            };

            BoardCalculator steps = new BoardCalculator();

            var stepResult = steps.PerformStep(board);

            Assert.IsTrue(newGeneration.Cast<int>().SequenceEqual(stepResult.Cast<int>()));
        }


    }
}
