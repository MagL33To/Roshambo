using System.Collections.Generic;
using Roshambo.Enums;

namespace Roshambo.Code.Interfaces
{
    public interface ICpuPlayer
    {
        MoveType BasicMove();
        MoveType AdvancedMove(IList<MoveType> opponentPreviousMoves);
    }
}