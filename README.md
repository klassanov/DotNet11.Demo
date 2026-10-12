# .NET 11 New Features Overview and Demos

## Scope
This is a non-exhaustive list of some of the new .NET 11 features. A short demo is included for some of them. The features that are shown here are the ones I consider most relevant to our everyday work at CDW.

Features are classified in categories by https://learn.microsoft.com/en-us/dotnet/core/whats-new/dotnet-11/overview

## .NET Release Cycle

![.NET Release Schedule](https://dotnet.microsoft.com/blob-assets/images/illustrations/release-schedule-dark.svg)

## Some of the New Features

### ⭐ Union types [DEMO]
Combination of more unrelated types under one hat

### ⭐ Runtime Async [DEMO] 
  How it has been so far? When you write an async method, the C# compiler rewrites it into a state machine, i.e. it generates code implementing IAsyncStateMachine that tracks the method’s progress across suspension points. 
  This approach works fine, but comes with some trade-offs.
  The .NET 11 RuntimeAsync is  new asynchronous execution model arriving in .NET 11. Async methods handling has been moved from the compiler to the .NET CLR. 
  Now, the compiler, instead of a state machine, generates  simpler IL annotated with [MethodImpl(MethodImplOptions.Async)].
  This approach brings performance improvements across the entire async ecosystem, better debugging and profiling experiences and a cleaner stacktrace.

### ⭐ JSON Lines aka JSONL Output [DEMO]
Newline-delimited JSON.

It's a great format for log files. It's also a flexible format for passing messages between cooperating processes.

JSON Lines Text Format can be generated with System.Text.Json.JsonSerializer.
With the default topLevelValues: false, the output remains one JSON array.

With topLevelValues: true, the output is a canonical JSON Lines (JSONL).
The serializer writes each value compactly and follows it with a line feed (LF)

### ⭐ Tuple-Returning Joins [DEMO]
New overloads of `Enumerable.Join()` and `Enumerable.GroupJoin()` return tuples directly without requiring a result selector.
It is also available on the FullJoin, LeftJoin, and RightJoin operations.


### ⭐ Partial Numeric Parsing: `TryParsePartial` for delimiter-aware parsing [DEMO]
`TryParsePartial()` method for all the Numeric types: benchmarks show that it is the most efficient in terms of
both Memory allocation and Processing time (no need to do a 2nd string walking behind the scenes for the delimiter scan)
	
	

### ⭐ New IEEE 754 Decimal (base 10) Floating-point types: `Decimal32`, `Decimal64` and `Decimal128`
  Not to be confused with the binary floating point numbers float and double: 
	
	  System.Numerics.Decimal32 -> 7 significant digits,  4 bytes

	  System.Numerics.Decimal64 -> 16 significant digits,  8 bytes
	
	  System.Numerics.Decimal128 -> 34 significant digits, 16 bytes
	
	  System.Decimal (well known old well known) -> 28–29 significant digits in 16 bytes.


	Note: IEEE 754 binary (base 10) floating-point types	
	
	
	  System.Single (float) -> 6-9 significant digits, 4 bytes

	  System.Double (double) -> 15-17 significant digits, 8 bytes


### ⭐ CLI: dotnet run and dotnet test command improvements [DEMO]
Pass environment variables with dotnet run 
`dotnet run -e VAR_1="TestVar1" -e VAR_2="TestVar2"`

## Sources
- https://versionsof.net/core/
- https://learn.microsoft.com/en-us/dotnet/core/whats-new/dotnet-11/overview
- https://learn.microsoft.com/en-us/dotnet/core/whats-new/dotnet-11/runtime
- https://laurentkempe.com/2026/02/14/exploring-net-11-preview-1-runtime-async-a-dive-into-the-future-of-async-in-net/
- https://medium.com/@skyake/how-fast-is-net-11-runtime-async-b9c821529cd5
- https://www.youtube.com/watch?v=5fvi7m1QxIY&t
