using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Vsite.Battleship.Model;
using Vsite.BattleShip.Model;

namespace Vsite.BattleShip.UnitTests
{
    [TestClass]
    public class TestGunnery
    {

        [TestMethod]
        public void InitiallyShootingTacticsIsRandom()
        {
            var gunnery = new Gunnery(10, 10, new List<int> { 5, 3 });
            Assert.AreEqual(ShootingTactics.Random, gunnery.ShootingTactics);
        }

        [TestMethod]
        public void ShootingTacticsRemainsRandomIfHitResultIsMissed()
        {
            var gunnery = new Gunnery(10, 10, new List<int> { 5, 3 });
            gunnery.ProcessHitResult(HitResult.Missed);
            Assert.AreEqual(ShootingTactics.Random, gunnery.ShootingTactics);
        }

        [TestMethod]
        public void ShootingTacticsChangesToSurroundingAfterFirstSquareIsHit()
        {
            var gunnery = new Gunnery(10, 10, new List<int> { 5, 3 });
            gunnery.ProcessHitResult(HitResult.Hit);
            Assert.AreEqual(ShootingTactics.Surrounding, gunnery.ShootingTactics);
        }

        [TestMethod]
        public void ShootingTacticsRemainsSurroundingAfterSecondSquareIsMissed()
        {
            var gunnery = new Gunnery(10, 10, new List<int> { 5, 3 });
            gunnery.ProcessHitResult(HitResult.Hit);
            gunnery.ProcessHitResult(HitResult.Missed);
            Assert.AreEqual(ShootingTactics.Surrounding, gunnery.ShootingTactics);
        }

        [TestMethod]
        public void ShootingTacticsChangesFromSurroundingToInlineAfterSecondSquareIsHit()
        {
            var gunnery = new Gunnery(10, 10, new List<int> { 5, 3 });
            gunnery.ProcessHitResult(HitResult.Hit);
            gunnery.ProcessHitResult(HitResult.Hit);
            Assert.AreEqual(ShootingTactics.Inline, gunnery.ShootingTactics);
        }

        [TestMethod]
        public void ShootingTacticsRemainsInlineAfterThirdSquareIsMissed()
        {
            var gunnery = new Gunnery(10, 10, new List<int> { 5, 3 });
            gunnery.ProcessHitResult(HitResult.Hit);
            gunnery.ProcessHitResult(HitResult.Hit);
            gunnery.ProcessHitResult(HitResult.Missed);
            Assert.AreEqual(ShootingTactics.Inline, gunnery.ShootingTactics);
        }

        [TestMethod]
        public void ShootingTacticsChangesToRandomAfterIsSunken()
        {
            var gunnery = new Gunnery(10, 10, new List<int> { 5, 2 });
            gunnery.ProcessHitResult(HitResult.Hit);
            gunnery.ProcessHitResult(HitResult.Sunken);
            Assert.AreEqual(ShootingTactics.Random, gunnery.ShootingTactics);
        }
    }
}
