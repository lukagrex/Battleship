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
        public void InitiallyShootingTacticsIsRandom()
        {
            var g = new Gunnery(10, 10, new List<int> { 5, 3 });
            Assert.AreEqual(g.ShootingTactics, ShootingTactics.Random);
        }

        [TestMethod]
        public void ShootingTacticsRemainsRandomIfHitResiltIsMissed()
        {
            var g = new Gunnery(10, 10, new List<int> { 5, 3 });
            g.ProcessHitResult(HitResult.Missed);
            Assert.AreEqual(g.ShootingTactics, ShootingTactics.Random);
        }

        [TestMethod]
        public void ShootingTacticsChangesToSurroundingAfterFirstSquareIsHit()
        {
            var g = new Gunnery(10, 10, new List<int> { 5, 3 });
            g.ProcessHitResult(HitResult.Hit);
            Assert.AreEqual(g.ShootingTactics, ShootingTactics.Surrounding);
        }

        [TestMethod]
        public void ShootingTacticsRemainsSurroundingAfterSecondSquareIsMissed()
        {
            var g = new Gunnery(10, 10, new List<int> { 5, 3 });
            g.ProcessHitResult(HitResult.Hit);
            g.ProcessHitResult(HitResult.Missed);
            Assert.AreEqual(g.ShootingTactics, ShootingTactics.Surrounding);
        }

        [TestMethod]
        public void ShootingTacticsChangesFromSurroundingToInlineAfterSecondSquareIsHit()
        {
            var g = new Gunnery(10, 10, new List<int> { 5, 3 });
            g.ProcessHitResult(HitResult.Hit);
            g.ProcessHitResult(HitResult.Hit);
            Assert.AreEqual(g.ShootingTactics, ShootingTactics.Inline);
        }

        [TestMethod]
        public void ShootingTacticsRemainsInlineAfterThirdSquareIsMissed()
        {
            var g = new Gunnery(10, 10, new List<int> { 5, 3 });
            g.ProcessHitResult(HitResult.Hit);
            g.ProcessHitResult(HitResult.Hit);
            g.ProcessHitResult(HitResult.Missed);
            Assert.AreEqual(g.ShootingTactics, ShootingTactics.Inline);
        }

        [TestMethod]
        public void ShootingTacticsChangesToRandomAfterShipIsSunken()
        {
            var g = new Gunnery(10, 10, new List<int> { 5, 2 });
            g.ProcessHitResult(HitResult.Hit);
            g.ProcessHitResult(HitResult.Sunken);
            Assert.AreEqual(g.ShootingTactics, ShootingTactics.Random);
        }
    }
}