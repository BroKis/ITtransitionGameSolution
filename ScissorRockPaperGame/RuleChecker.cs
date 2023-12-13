using ScissorRockPaperGame.Auxillary;

namespace ScissorRockPaperGame
{
    public class RuleChecker
    {
        int _moveCount;
        public RuleChecker(int moveCount)
        {
            _moveCount = moveCount;
        }
        public Verdict TurnCheck(int firstTurn, int secondTurn)
        {
            return (Verdict)CalculateResultTurn(firstTurn, secondTurn);
        }
        private int CalculateResultTurn(int firstTurn,int secondTurn)
        {
            return Math.Sign(( firstTurn - secondTurn + (_moveCount >> 1) + _moveCount) % _moveCount - (_moveCount >> 1));
        }
    }
}
