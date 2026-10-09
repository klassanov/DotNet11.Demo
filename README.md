# .NET 11 New Features Overview and Demos

## Scope
This is a non-exhaustive list of some of the new .NET 11 features. Some of them also include a short demo. The features that are shown here are the ones I consider most relevant to our everyday work at CDW.

Features are classified in categories by https://learn.microsoft.com/en-us/dotnet/core/whats-new/dotnet-11/overview

## .NET Release Cycle

![.NET Release Schedule](https://dotnet.microsoft.com/blob-assets/images/illustrations/release-schedule-dark.svg)

## C# 15
- #### Union types [DEMO]

## Runtime


- #### Runtime Async [DEMO]: 
  How it has been so far? When you write an async method, the C# compiler rewrites it into a state machine, i.e. it generates code implementing IAsyncStateMachine that tracks the method’s progress across suspension points. 
  This approach works fine, but comes with some trade-offs.
  The .NET 11 RuntimeAsync is  new asynchronous execution model arriving in .NET 11. Async methods handling has been moved from the compiler to the .NET CLR. 
  Now, the compiler, instead of a state machine, generates  simpler IL annotated with [MethodImpl(MethodImplOptions.Async)].
  This approach brings performance improvements across the entire async ecosystem, better debugging and profiling experiences and a cleaner stacktrace.

## Libraries
- #### System.Text.Json: Union type serialization, JSON Lines output [DEMO]


- #### EqualityComparer<T>.Create [DEMO]



- #### LINQ join improvements (Left, Right, Full) [DEMO]



- #### Partial numeric parsing. INumberBase<TSelf>.TryParsePartial for delimiter-aware parsing [DEMO]
	Partial Parsing for all the Numeric types: most efficient in terms of both Memory allocation and Processing time (no need to do a 2nd string walking behind the scenes for the delimiter scan)
	
	

- #### New IEEE 754 decimal floating-point types  (Decimal32, Decimal64, and Decimal128)
  New IEEE 754 Decimal (base 10) floating point numbers (not to be confused with the binary floating point numbers float and double): 
	
	System.Numerics.Decimal32 -> 7 significant digits,  4 bytes
	System.Numerics.Decimal64 -> 16 significant digits,  8 bytes
	System.Numerics.Decimal128 -> 34 significant digits, 16 bytes
	
	System.Decimal (well known old well known) -> 28–29 significant digits in 16 bytes.


- #### Generic Complex<T>

## SDK and Tooling
- #### dotnet run CLI command improvements: Pass environment variables with dotnet run [DEMO]
- #### dotnet test CLI command improvements

- #### Platform support for more than 1024 CPUs

## Others
- ??? C# devkit for VS Code and C# doctor ???


## Sources
- https://versionsof.net/core/
- https://learn.microsoft.com/en-us/dotnet/core/whats-new/dotnet-11/overview
- https://learn.microsoft.com/en-us/dotnet/core/whats-new/dotnet-11/runtime
- https://laurentkempe.com/2026/02/14/exploring-net-11-preview-1-runtime-async-a-dive-into-the-future-of-async-in-net/
- https://medium.com/@skyake/how-fast-is-net-11-runtime-async-b9c821529cd5
- https://www.youtube.com/watch?v=5fvi7m1QxIY&t
