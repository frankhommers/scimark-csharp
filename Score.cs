/// <license>
/// This is a port of the SciMark2a Java Benchmark to C# by
/// Chris Re (cmr28@cornell.edu) and Werner Vogels (vogels@cs.cornell.edu)
///
/// For details on the original authors see http://math.nist.gov/scimark2
///
/// Refactored and JSON output added by Frank Hommers (http://f.hmm.rs/github)
/// 
/// This software is likely to burn your processor, bitflip your memory chips
/// anihilate your screen and corrupt all your disks, so you it at your
/// own risk.
/// </license>

namespace SciMark2Json
{
  public class Score
  {
    public double FFTScore { get; set; }
    public double SORScore { get; set; }
    public double MonteCarloScore { get; set; }
    public double SparseMatMultScore { get; set; }
    public double LUScore { get; set; }
    public double CompositeScore
    {
      get
      {
        return (FFTScore + SORScore + MonteCarloScore + SparseMatMultScore + LUScore) / 5;
      }
    }
  }
}
