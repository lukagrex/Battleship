using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Vsite.Battleship.Model;

namespace Vsite.Battleship.Moodel
{
    [TestClass]
    public class TestGunnery
    {
        [TestMethod]
        public void InitiallyShootingTacticsIsRandom()
        {
            var g = new Gunnery(10, 10, new List<int> { 5, 3 });
            Assert.AreEqual(ShootingTactics.Random, g.ShootingTactics);
        }

        [TestMethod]
        public void ShootingTacticsRemainsRandomIfHitResultIsMissed()
        {
            var g = new Gunnery(10, 10, new List<int> { 5, 3 });
            g.ProcessHitResult(HitResult.Missed);
            Assert.AreEqual(ShootingTactics.Random, g.ShootingTactics);
        }

        [TestMethod]
        public void ShootingTacticsChangesToSurroundingAfterFirstSquareIsHit()
        {
            var g = new Gunnery(10, 10, new List<int> { 5, 3 });
            g.ProcessHitResult(HitResult.Hit);
            Assert.AreEqual(ShootingTactics.Surrounding, g.ShootingTactics);
        }

        [TestMethod]
        public void ShootingTacticsRemainsSurroundingAfterSecondSquareIsMissed()
        {
            var g = new Gunnery(10, 10, new List<int> { 5, 3 });
            g.ProcessHitResult(HitResult.Hit);
            g.ProcessHitResult(HitResult.Missed);
            Assert.AreEqual(ShootingTactics.Surrounding, g.ShootingTactics);
        }

        [TestMethod]
        public void ShootingTacticsChangesFromSurroundingToInlineAfterSecondSquareIsHit()
        {
            var g = new Gunnery(10, 10, new List<int> { 5, 3 });
            g.ProcessHitResult(HitResult.Hit);
            g.ProcessHitResult(HitResult.Hit);
            Assert.AreEqual(ShootingTactics.Inline, g.ShootingTactics);
        }

        [TestMethod]
        public void ShootingTacticsRemainsInlineAfterthirdSquareIsMissed()
        {
            var g = new Gunnery(10, 10, new List<int> { 5, 3 });
            g.ProcessHitResult(HitResult.Hit);
            g.ProcessHitResult(HitResult.Hit);
            g.ProcessHitResult(HitResult.Missed);
            Assert.AreEqual(ShootingTactics.Inline, g.ShootingTactics);
        }

        [TestMethod]
        public void ShootingTacticsChangesToRandomAfterShipIsSunk()
        {
            var g = new Gunnery(10, 10, new List<int> { 5, 2 });
            g.ProcessHitResult(HitResult.Hit);
            g.ProcessHitResult(HitResult.Sunk);
            Assert.AreEqual(ShootingTactics.Random, g.ShootingTactics);
        }
    }
}
