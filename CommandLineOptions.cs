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

using CommandLine;
using CommandLine.Text;

namespace SciMark2Json
{

  public enum Size
  {
    Tiny,
    Medium,
    Large
  }

  // Define a class to receive parsed values
  public class CommandLineOptions
  {
    [Option('s', "size", DefaultValue = Size.Medium, HelpText = "Set size.")]
    public Size Size { get; set; }

    [Option('d', "duration", DefaultValue = 2.0f, HelpText = "Set duration.")]
    public double MinimumDuration { get; set; }

    [HelpOption]
    public string GetUsage()
    {
      return HelpText.AutoBuild(this,
        (HelpText current) => HelpText.DefaultParsingErrorsHandler(this, current));
    }
  }
}