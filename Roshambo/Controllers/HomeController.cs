using System.Web.Mvc;
using Roshambo.Code.Interfaces;
using Roshambo.Enums;
using Roshambo.Models;

namespace Roshambo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICpuPlayer _cpuPlayer;

        public HomeController(ICpuPlayer cpuPlayer)
        {
            _cpuPlayer = cpuPlayer;
        }
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult PlayMove(MoveType playerMove, bool isPlayerHuman)
        {
            var cpuMove = _cpuPlayer.BasicMove();

            return Json(GetResult(playerMove, cpuMove, isPlayerHuman), JsonRequestBehavior.AllowGet);
        }

        private static RoundResult GetResult(MoveType player1Move, MoveType player2Move, bool isPlayer1Human)
        {
            return new RoundResult
            {
                Player1IsHuman = isPlayer1Human,
                Player1Move = player1Move,
                Player2Move = player2Move,
                Result = DetermineWinner(player1Move, player2Move)
            };
        }

        private static ResultType DetermineWinner(MoveType player1Move, MoveType player2Move)
        {
            switch (player1Move)
            {
                case MoveType.Paper:
                    switch (player2Move)
                    {
                        case MoveType.Rock:
                            return ResultType.Win;
                        case MoveType.Paper:
                            return ResultType.Draw;
                        default:
                            return ResultType.Lose;
                    }
                case MoveType.Rock:
                    switch (player2Move)
                    {
                        case MoveType.Rock:
                            return ResultType.Draw;
                        case MoveType.Paper:
                            return ResultType.Lose;
                        default:
                            return ResultType.Win;
                    }
                default:
                    switch (player2Move)
                    {
                        case MoveType.Rock:
                            return ResultType.Lose;
                        case MoveType.Paper:
                            return ResultType.Win;
                        default:
                            return ResultType.Draw;
                    }
            }
        }
    }
}