SciMark2 Numeric Benchmark, see http://math.nist.gov/scimark

This is a CSharp port of the Java code. 

{% blockquote https://code.google.com/p/scimark-csharp %}
This is the C# port of the Scimark benchmark. The original C and Java sources can be found at http://math.nist.gov/scimark2/. The original work to port the benchmark to C# was done by Chris Re and Wener Vogels of the Rotor project.

The Rotor project's page has gone offline, so this project was started to prevent the sources from being lost to history.
{% endblockquote %}

Running an Apples to Apples comparision across platforms and different mono builds using different llvm jitting is not really valid. 

So the following test (based on the run-tests script) is based on the same clang/llvm version compiling the same mono version in x64 and i386 archs.

The test output is then run to produce a matrix of:

Compile:
x64 and x86 Mono Debug versions (Debug Full, no optimize) 
x64 and x86 Mono Release (No Debug, Optimized)

Execution:
Run the resulting 4 CIL (exe) images using mono with LLVM turned off and turned on.

[Benchmark Matrix](http://sushihangover.github.io/images/mono-scmark-chart.png)

I added a Release and Debug x64 platforms to the the original pro file so you can build and clean everything from the cmd line using build, i.e.:

    xbuild /property:Configuration=Release /property:Platform=x64 /target:Build
    xbuild /property:Configuration=Debug /property:Platform=x64 /target:Build
    xbuild /property:Configuration=Release /property:Platform=x86 /target:Build
    xbuild /property:Configuration=Debug /property:Platform=x86 /target:Build


Output sample from running the **run-tests** script located in the root repo dir:

    ~~~~~~~~~~~~~~~~~~~
    Mono JIT compiler version 4.3.0 (master/8b466ec Tue Jun  9 11:56:16 PDT 2015)
    Copyright (C) 2002-2014 Novell, Inc, Xamarin Inc and Contributors. www.mono-project.com
    	TLS:           normal
    	SIGSEGV:       altstack
    	Notification:  kqueue
    	Architecture:  amd64
    	Disabled:      none
    	Misc:          softdebug 
    	LLVM:          yes(3.6.0svn-mono-master/ce4fcec)
    	GC:            sgen
    ~~~~~~~~~~~~~~~~~~~
    
    scimark-csharp-x64-debug.exe
    ~~~~~~~~~~~~~~~~~~~
    **                                                               **
    ** SciMark2a Numeric Benchmark, see http://math.nist.gov/scimark **
    **                                                               **
    Mininum running time = 2 seconds
    
    Composite Score: 367.22 MFlops
    FFT            : 253.12 - (1024)
    SOR            : 736.14 - (100x100)
    Monte Carlo    :  30.89
    Sparse MatMult : 227.53 - (N=1000, nz=5000)
    LU             : 588.44 - (100x100)
    
    scimark-csharp-x64-debug.exe with LLVM
    ~~~~~~~~~~~~~~~~~~~
    **                                                               **
    ** SciMark2a Numeric Benchmark, see http://math.nist.gov/scimark **
    **                                                               **
    Mininum running time = 2 seconds
    
    Composite Score: 559.28 MFlops
    FFT            : 528.39 - (1024)
    SOR            : 742.55 - (100x100)
    Monte Carlo    :  34.95
    Sparse MatMult : 649.41 - (N=1000, nz=5000)
    LU             : 841.08 - (100x100)
    
    scimark-csharp-x64-release.exe
    ~~~~~~~~~~~~~~~~~~~
    **                                                               **
    ** SciMark2a Numeric Benchmark, see http://math.nist.gov/scimark **
    **                                                               **
    Mininum running time = 2 seconds
    
    Composite Score: 370.79 MFlops
    FFT            : 254.80 - (1024)
    SOR            : 739.44 - (100x100)
    Monte Carlo    :  31.53
    Sparse MatMult : 227.61 - (N=1000, nz=5000)
    LU             : 600.57 - (100x100)
    
    scimark-csharp-x64-release.exe with LLVM
    ~~~~~~~~~~~~~~~~~~~
    **                                                               **
    ** SciMark2a Numeric Benchmark, see http://math.nist.gov/scimark **
    **                                                               **
    Mininum running time = 2 seconds
    
    Composite Score: 569.46 MFlops
    FFT            : 538.20 - (1024)
    SOR            : 752.78 - (100x100)
    Monte Carlo    :  34.96
    Sparse MatMult : 652.42 - (N=1000, nz=5000)
    LU             : 868.94 - (100x100)
    ~~~~~~~~~~~~~~~~~~~
    Mono JIT compiler version 4.3.0 (master/8b466ec Tue Jun  9 10:32:24 PDT 2015)
    Copyright (C) 2002-2014 Novell, Inc, Xamarin Inc and Contributors. www.mono-project.com
    	TLS:           normal
    	SIGSEGV:       altstack
    	Notification:  kqueue
    	Architecture:  x86
    	Disabled:      none
    	Misc:          softdebug 
    	LLVM:          yes(3.6.0svn-mono-master/ce4fcec)
    	GC:            sgen
    ~~~~~~~~~~~~~~~~~~~
    
    scimark-csharp-x86-debug.exe
    ~~~~~~~~~~~~~~~~~~~
    **                                                               **
    ** SciMark2a Numeric Benchmark, see http://math.nist.gov/scimark **
    **                                                               **
    Mininum running time = 2 seconds
    
    Composite Score: 371.42 MFlops
    FFT            : 234.11 - (1024)
    SOR            : 742.73 - (100x100)
    Monte Carlo    :  25.43
    Sparse MatMult : 345.03 - (N=1000, nz=5000)
    LU             : 509.79 - (100x100)
    
    scimark-csharp-x86-debug.exe with LLVM
    ~~~~~~~~~~~~~~~~~~~
    **                                                               **
    ** SciMark2a Numeric Benchmark, see http://math.nist.gov/scimark **
    **                                                               **
    Mininum running time = 2 seconds
    
    Composite Score: 465.45 MFlops
    FFT            : 407.50 - (1024)
    SOR            : 747.08 - (100x100)
    Monte Carlo    :  30.39
    Sparse MatMult : 460.94 - (N=1000, nz=5000)
    LU             : 681.32 - (100x100)
    
    scimark-csharp-x86-release.exe
    ~~~~~~~~~~~~~~~~~~~
    **                                                               **
    ** SciMark2a Numeric Benchmark, see http://math.nist.gov/scimark **
    **                                                               **
    Mininum running time = 2 seconds
    
    Composite Score: 295.11 MFlops
    FFT            : 231.72 - (1024)
    SOR            : 388.30 - (100x100)
    Monte Carlo    :  26.18
    Sparse MatMult : 341.13 - (N=1000, nz=5000)
    LU             : 488.20 - (100x100)
    
    scimark-csharp-x86-release.exe with LLVM
    ~~~~~~~~~~~~~~~~~~~
    **                                                               **
    ** SciMark2a Numeric Benchmark, see http://math.nist.gov/scimark **
    **                                                               **
    Mininum running time = 2 seconds
    
    Composite Score: 448.92 MFlops
    FFT            : 432.99 - (1024)
    SOR            : 712.41 - (100x100)
    Monte Carlo    :  30.86
    Sparse MatMult : 415.16 - (N=1000, nz=5000)
    LU             : 653.18 - (100x100)


