using System;
using System.Collections.Generic;
using NUnit.Framework;
using Roshambo.Code;
using Roshambo.Code.Interfaces;
using Roshambo.Enums;

namespace Roshambo.Tests
{
    [TestFixture]
    public class CpuPlayerTests
    {
        private readonly ICpuPlayer _fakeCpuPlayer = new CpuPlayer();

        [Test]
        public void BasicMove_NoParams_ValidMoveTypeReturned()
        {
            var result = _fakeCpuPlayer.BasicMove();

            Assert.AreEqual(typeof(MoveType), result.GetType());
        }

        [Test]
        public void BasicMove_NoParams_EitherRockPaperOrScissorsReturned()
        {
            var result = _fakeCpuPlayer.BasicMove();

            Assert.Contains(result, new List<MoveType> {MoveType.Rock, MoveType.Paper, MoveType.Scissors});
        }
    }
}