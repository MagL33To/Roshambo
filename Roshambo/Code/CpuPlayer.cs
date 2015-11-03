using System;
using System.Collections.Generic;
using Roshambo.Code.Interfaces;
using Roshambo.Enums;

namespace Roshambo.Code
{
    public class CpuPlayer : ICpuPlayer
    {
        public MoveType BasicMove()
        {
            var rand = new Random();
            return (MoveType) rand.Next(0, 3);
        }

        public MoveType AdvancedMove(IList<MoveType> opponentPreviousMoves)
        {
            throw new System.NotImplementedException();
        }
    }
}