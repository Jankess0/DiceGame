namespace DiceGame.Models;

public enum ScoreRow
{
    [ScoreSections(ScoreSection.Upper)] Ones,
    [ScoreSections(ScoreSection.Upper)] Twos,
    [ScoreSections(ScoreSection.Upper)] Threes,
    [ScoreSections(ScoreSection.Upper)] Fours,
    [ScoreSections(ScoreSection.Upper)] Fives,
    [ScoreSections(ScoreSection.Upper)] Sixes,
    [ScoreSections(ScoreSection.Lower)] ThreeOfAKind,
    [ScoreSections(ScoreSection.Lower)] FourOfAKind,
    [ScoreSections(ScoreSection.Lower)] Full,
    [ScoreSections(ScoreSection.Lower)] SmallStraight,
    [ScoreSections(ScoreSection.Lower)] LargeStraight,
    [ScoreSections(ScoreSection.Lower)] King,
    [ScoreSections(ScoreSection.Lower)] Chance
}