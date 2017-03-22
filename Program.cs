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

using System;

namespace SciMark2Json
{

  public class Program
  {
    /// <summary>
    ///  Benchmark 5 kernels with individual Mflops.
    ///  "results[0]" has the average Mflop rate.
    /// </summary>
    [STAThread]
    public static void Main(System.String[] args)
    {
      double min_time = Constants.RESOLUTION_DEFAULT;

      int FFT_size = Constants.FFT_SIZE;
      int SOR_size = Constants.SOR_SIZE;
      int Sparse_size_M = Constants.SPARSE_SIZE_M;
      int Sparse_size_nz = Constants.SPARSE_SIZE_nz;
      int LU_size = Constants.LU_SIZE;

      var options = new CommandLineOptions();
      if (!CommandLine.Parser.Default.ParseArguments(args, options)) return;

      if (options.Size == Size.Large)
      {
        FFT_size = Constants.LG_FFT_SIZE;
        SOR_size = Constants.LG_SOR_SIZE;
        Sparse_size_M = Constants.LG_SPARSE_SIZE_M;
        Sparse_size_nz = Constants.LG_SPARSE_SIZE_nz;
        LU_size = Constants.LG_LU_SIZE;
      }
      else if (options.Size == Size.Tiny)
      {
        FFT_size = Constants.TINY_FFT_SIZE;
        SOR_size = Constants.TINY_SOR_SIZE;
        Sparse_size_M = Constants.TINY_SPARSE_SIZE_M;
        Sparse_size_nz = Constants.TINY_SPARSE_SIZE_nz;
        LU_size = Constants.TINY_LU_SIZE;
      }
      min_time = options.MinimumDuration;


      Random R = new Random(Constants.RANDOM_SEED);

      Score scores = new Score()
      {

        FFTScore = SciMark2.measureFFT(FFT_size, min_time, R),
        SORScore = SciMark2.measureSOR(SOR_size, min_time, R),
        MonteCarloScore = SciMark2.measureMonteCarlo(min_time, R),
        SparseMatMultScore = SciMark2.measureSparseMatmult(Sparse_size_M, Sparse_size_nz, min_time, R),
        LUScore = SciMark2.measureLU(LU_size, min_time, R)
      };

      Console.WriteLine(
      Newtonsoft.Json.JsonConvert.SerializeObject(new
      {
        Architecture = CompiledFor(),
        Bits = IntPtr.Size * 8,
        Scores = scores
      }, Newtonsoft.Json.Formatting.Indented));
    }

    public static string CompiledFor()
    {
#if X86_RELEASE
      return "x86/Release";
#endif
#if X86_DEBUG
      return "x86/Debug";
#endif
#if X64_RELEASE
      return "x64/Release";
#endif
#if X64_DEBUG
      return "x64/Debug";
#endif
#if ANYCPU_DEBUG
      return "AnyCPU/Debug";
#endif
#if ANYCPU_RELEASE
      return "AnyCPU/Debug";
#else
  #if DEBUG
        return "?/Debug";
  #else
        return "?/Release";
  #endif
#endif

    }
  }
}