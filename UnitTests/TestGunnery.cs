using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Vsite.Battleship.Model;

namespace Vsite.Battleship
{
    [TestClass]
    public class TestGunnery
    {
        [TestMethod]
        public void InitiallyShootingTacticsRandom()
        {
            var g = new Gunnery(10, 10, new List<int> {5, 3});
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
        public void ShootingTacticsChangesToSurroundingAfterFirstSquareIsHIt()
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
        public void ShootingTacticsRemainsInlineAfterThirdSquareIsMissed()
        {
            var g = new Gunnery(10, 10, new List<int> { 5, 3 });
            g.ProcessHitResult(HitResult.Hit);
            g.ProcessHitResult(HitResult.Hit);
            g.ProcessHitResult(HitResult.Missed);
            Assert.AreEqual(ShootingTactics.Inline, g.ShootingTactics);
        }

        [TestMethod]
        public void ShootingTacticsChangesToRandomAfterThirdShipIsSunken()
        {
            var g = new Gunnery(10, 10, new List<int> { 5, 2 });
            g.ProcessHitResult(HitResult.Hit);
            g.ProcessHitResult(HitResult.Sunken);
            Assert.AreEqual(ShootingTactics.Random, g.ShootingTactics);
        }
    }
}
