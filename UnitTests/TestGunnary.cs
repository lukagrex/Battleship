using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Vsite.Battleship.Model;

namespace Vsite.Battleship
{
    [TestClass]
    public class TestGunnary
    {
        [TestMethod]
        public void InitiallyGunneryState()
        {
            var gunnary = new Gunnery(10, 10, new List<int>() {5, 3 });

            Assert.AreEqual(ShootingTactics.Random, gunnary.ShootingTactics);
        }

        [TestMethod]
        public void HitResultMissedGunnaryStateIsRandomIfPreviousStateIsRandom()
        {
            var gunnary = new Gunnery(10, 10, new List<int>() { 5, 3 });

            gunnary.ProcessHitResult(HitResult.Missed);

            Assert.AreEqual(ShootingTactics.Random, gunnary.ShootingTactics);
        }

        [TestMethod]
        public void HitResultHitGunnaryStateIsSourroundingIfPreviousStateIsRandom()
        {
            var gunnary = new Gunnery(10, 10, new List<int>() { 5, 3 });

            gunnary.ProcessHitResult(HitResult.Hit);

            Assert.AreEqual(ShootingTactics.Surrounding, gunnary.ShootingTactics);
        }

        [TestMethod]
        public void HitResultMissedGunnaryStateIsSourroundingIfPreviousStateIsSourrounding()
        {
            var gunnary = new Gunnery(10, 10, new List<int>() { 5, 3 });

            gunnary.ProcessHitResult(HitResult.Hit);
            gunnary.ProcessHitResult(HitResult.Missed);

            Assert.AreEqual(ShootingTactics.Surrounding, gunnary.ShootingTactics);
        }

        [TestMethod]
        public void HitResultHitGunnaryStateIsInlineIfPreviousStateIsSourrounding()
        {
            var gunnary = new Gunnery(10, 10, new List<int>() { 5, 3 });

            gunnary.ProcessHitResult(HitResult.Hit);
            gunnary.ProcessHitResult(HitResult.Hit);

            Assert.AreEqual(ShootingTactics.Inline, gunnary.ShootingTactics);
        }

        [TestMethod]
        public void HitResultMissedGunnaryStateIsInlineIfPreviousStateIsInline()
        {
            var gunnary = new Gunnery(10, 10, new List<int>() { 5, 3 });

            gunnary.ProcessHitResult(HitResult.Hit);
            gunnary.ProcessHitResult(HitResult.Hit);
            gunnary.ProcessHitResult(HitResult.Missed);


            Assert.AreEqual(ShootingTactics.Inline, gunnary.ShootingTactics);
        }

        [TestMethod]
        public void HitResultSunkenGunnaryStateIsRandomIfPreviousStateIsInline()
        {
            var gunnary = new Gunnery(10, 10, new List<int>() { 5, 3 });

            gunnary.ProcessHitResult(HitResult.Hit);
            gunnary.ProcessHitResult(HitResult.Hit);
            gunnary.ProcessHitResult(HitResult.Sunken);

            Assert.AreEqual(ShootingTactics.Random, gunnary.ShootingTactics);
        }
    }
}
