using Moq;
using NUnit.Framework;
using Roshambo.Code.Interfaces;
using Roshambo.Controllers;
using Roshambo.Enums;
using Roshambo.Models;

namespace Roshambo.Tests
{
    [TestFixture]
    public class HomeControllerTests
    {
        private Mock<ICpuPlayer> _fakeCpuPlayer;
        private HomeController _fakeHomeController;

        [SetUp]
        public void Setup()
        {
            _fakeCpuPlayer = new Mock<ICpuPlayer>();
            _fakeHomeController = new HomeController(_fakeCpuPlayer.Object);
        }

        [TestCase(MoveType.Paper)]
        [TestCase(MoveType.Rock)]
        [TestCase(MoveType.Scissors)]
        public void PlayMove_ValidMoveFromHumanPlayer_RoundResultObjectReturned(MoveType move)
        {
            var result = _fakeHomeController.PlayMove(move, true);

            Assert.AreEqual(typeof(RoundResult), result.Data.GetType());
        }

        [TestCase(MoveType.Paper)]
        [TestCase(MoveType.Rock)]
        [TestCase(MoveType.Scissors)]
        public void PlayMove_ValidMoveFromCPUPlayer_RoundResultObjectReturned(MoveType move)
        {
            var result = _fakeHomeController.PlayMove(move, false);

            Assert.AreEqual(typeof(RoundResult), result.Data.GetType());
        }

        [Test]
        public void PlayMove_Player1PlaysRockPlayer2PlaysScissors_Player1Wins()
        {
            _fakeCpuPlayer.Setup(x => x.BasicMove()).Returns(MoveType.Scissors);

            var result = _fakeHomeController.PlayMove(MoveType.Rock, true).Data as RoundResult;

            Assert.AreEqual(ResultType.Win, result.Result);
        }

        [Test]
        public void PlayMove_Player1PlaysRockPlayer2PlaysRock_Draw()
        {
            _fakeCpuPlayer.Setup(x => x.BasicMove()).Returns(MoveType.Rock);

            var result = _fakeHomeController.PlayMove(MoveType.Rock, true).Data as RoundResult;

            Assert.AreEqual(ResultType.Draw, result.Result);
        }

        [Test]
        public void PlayMove_Player1PlaysRockPlayer2PlaysPaper_Player1Loses()
        {
            _fakeCpuPlayer.Setup(x => x.BasicMove()).Returns(MoveType.Paper);

            var result = _fakeHomeController.PlayMove(MoveType.Rock, true).Data as RoundResult;

            Assert.AreEqual(ResultType.Lose, result.Result);
        }

        [Test]
        public void PlayMove_Player1PlaysPaperPlayer2PlaysScissors_Player1Loses()
        {
            _fakeCpuPlayer.Setup(x => x.BasicMove()).Returns(MoveType.Scissors);

            var result = _fakeHomeController.PlayMove(MoveType.Paper, true).Data as RoundResult;

            Assert.AreEqual(ResultType.Lose, result.Result);
        }

        [Test]
        public void PlayMove_Player1PlaysPaperPlayer2PlaysRock_Player1Wins()
        {
            _fakeCpuPlayer.Setup(x => x.BasicMove()).Returns(MoveType.Rock);

            var result = _fakeHomeController.PlayMove(MoveType.Paper, true).Data as RoundResult;

            Assert.AreEqual(ResultType.Win, result.Result);
        }

        [Test]
        public void PlayMove_Player1PlaysPaperPlayer2PlaysPaper_Draw()
        {
            _fakeCpuPlayer.Setup(x => x.BasicMove()).Returns(MoveType.Paper);

            var result = _fakeHomeController.PlayMove(MoveType.Paper, true).Data as RoundResult;

            Assert.AreEqual(ResultType.Draw, result.Result);
        }

        [Test]
        public void PlayMove_Player1PlaysScissorsPlayer2PlaysScissors_Draw()
        {
            _fakeCpuPlayer.Setup(x => x.BasicMove()).Returns(MoveType.Scissors);

            var result = _fakeHomeController.PlayMove(MoveType.Scissors, true).Data as RoundResult;

            Assert.AreEqual(ResultType.Draw, result.Result);
        }

        [Test]
        public void PlayMove_Player1PlaysScissorsPlayer2PlaysRock_Player1Loses()
        {
            _fakeCpuPlayer.Setup(x => x.BasicMove()).Returns(MoveType.Rock);

            var result = _fakeHomeController.PlayMove(MoveType.Scissors, true).Data as RoundResult;

            Assert.AreEqual(ResultType.Lose, result.Result);
        }

        [Test]
        public void PlayMove_Player1PlaysScissorsPlayer2PlaysPaper_Player1Wins()
        {
            _fakeCpuPlayer.Setup(x => x.BasicMove()).Returns(MoveType.Paper);

            var result = _fakeHomeController.PlayMove(MoveType.Scissors, true).Data as RoundResult;

            Assert.AreEqual(ResultType.Win, result.Result);
        }

        [Test]
        public void PlayMove_HumanPlayerBeatsCpuPlayer_TextIndicatesHumanPlayerWon()
        {
            _fakeCpuPlayer.Setup(x => x.BasicMove()).Returns(MoveType.Paper);

            var result = _fakeHomeController.PlayMove(MoveType.Scissors, true).Data as RoundResult;

            Assert.That(result.ResultText.ToLower().Contains("you win"));
        }

        [Test]
        public void PlayMove_CpuPlayerBeatsHumanPlayer_TextIndicatesCpuPlayerWon()
        {
            _fakeCpuPlayer.Setup(x => x.BasicMove()).Returns(MoveType.Rock);

            var result = _fakeHomeController.PlayMove(MoveType.Scissors, true).Data as RoundResult;

            Assert.That(result.ResultText.ToLower().Contains("cpu wins"));
        }

        [Test]
        public void PlayMove_Cpu1BeatsCPU2_TextIndicatesCpu1Won()
        {
            _fakeCpuPlayer.Setup(x => x.BasicMove()).Returns(MoveType.Paper);

            var result = _fakeHomeController.PlayMove(MoveType.Scissors, false).Data as RoundResult;

            Assert.That(result.ResultText.ToLower().Contains("cpu1 wins"));
        }

        [Test]
        public void PlayMove_Cpu2BeatsCPU1_TextIndicatesCpu2Won()
        {
            _fakeCpuPlayer.Setup(x => x.BasicMove()).Returns(MoveType.Rock);

            var result = _fakeHomeController.PlayMove(MoveType.Scissors, false).Data as RoundResult;

            Assert.That(result.ResultText.ToLower().Contains("cpu2 wins"));
        }

        [Test]
        public void PlayMove_HumanPlayerDrawsWithCpu_TextIndicatesDraw()
        {
            _fakeCpuPlayer.Setup(x => x.BasicMove()).Returns(MoveType.Rock);

            var result = _fakeHomeController.PlayMove(MoveType.Rock, true).Data as RoundResult;

            Assert.That(result.ResultText.ToLower().Contains("draw"));
        }

        [Test]
        public void PlayMove_Cpu1DrawsWithCpu2_TextIndicatesDraw()
        {
            _fakeCpuPlayer.Setup(x => x.BasicMove()).Returns(MoveType.Rock);

            var result = _fakeHomeController.PlayMove(MoveType.Rock, false).Data as RoundResult;

            Assert.That(result.ResultText.ToLower().Contains("draw"));
        }
    }
}