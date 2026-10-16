# .NET 11 New Features Overview and Demos

## ◆ Scope
This document provides a non-exhaustive overview of some of the new .NET 11 features. Selected features include accompanying demos. These features represent those I consider most relevant to our everyday work at CDW.

Features are classified in categories by https://learn.microsoft.com/en-us/dotnet/core/whats-new/dotnet-11/overview

## ◆ .NET Release Cycle

![.NET Release Schedule](https://dotnet.microsoft.com/blob-assets/images/illustrations/release-schedule-dark.svg)

## ◆ Some of the New Features

### ⭐ Union types [DEMO]
Combination of more unrelated types under one hat.

### ⭐ Runtime Async [DEMO] 
  How has it worked until now? When you write an async method, the C# compiler rewrites it into a state machine, i.e. it generates code implementing IAsyncStateMachine that tracks the method’s progress across suspension points. 
  This approach works well but involves trade-offs.
  The new `RuntimeAsync` model is an asynchronous execution feature arriving in .NET 11. Async method handling has been moved from the compiler to the .NET CLR.
  Now the compiler generates simpler IL instead of a state machine, annotated with `[MethodImpl(MethodImplOptions.Async)]`.
  This approach brings performance improvements across the entire async ecosystem, improved debugging and profiling capabilities, and cleaner stack traces.

### ⭐ JSON Lines aka JSONL Output [DEMO]
Newline-delimited JSON.

It works well for log files. It also provides a flexible format for passing messages between cooperating processes.

JSON Lines output can be generated with `System.Text.Json.JsonSerializer`.
By default (`topLevelValues: false`), the output remains a single JSON array.

With `topLevelValues: true`, the output is canonical JSON Lines (JSONL).
The serializer writes each value compactly, followed by a line feed (LF).

### ⭐ Tuple-Returning Joins [DEMO]
New overloads for `Enumerable.Join()` and `Enumerable.GroupJoin()` return tuples directly without requiring a result selector.
These overloads are also available for `FullJoin`, `LeftJoin`, and `RightJoin` operations.


### ⭐ CLI: dotnet run and dotnet test command improvements [DEMO]
Pass environment variables using dotnet run:
`dotnet run -e VAR_1="TestVar1" -e VAR_2="TestVar2"`


### ⭐ Partial Numeric Parsing: `TryParsePartial` for delimiter-aware parsing [DEMO]
`TryParsePartial()` method is available for all numeric types: Benchmarks demonstrate superior efficiency in both
memory allocation and processing time (no need to do a 2nd string walking behind the scenes for the delimiter scan).
	
	

### ⭐ New IEEE 754 Decimal (base-10) floating-point types: `Decimal32`, `Decimal64` and `Decimal128`
 	
	  System.Numerics.Decimal32 -> 7 significant digits,  4 bytes

	  System.Numerics.Decimal64 -> 16 significant digits,  8 bytes
	
	  System.Numerics.Decimal128 -> 34 significant digits, 16 bytes
	
	  System.Decimal (the well-known legacy type) -> 28–29 significant digits in 16 bytes.


	Note:  Not to be confused with the binary floating-point types, `float` and `double`:
	
	IEEE 754 binary (base-2) floating-point types for comparison:	
	
	  System.Single (float) -> 6-9 significant digits, 4 bytes

	  System.Double (double) -> 15-17 significant digits, 8 bytes


## ◆ Sources
- https://versionsof.net/core/
- https://learn.microsoft.com/en-us/dotnet/core/whats-new/dotnet-11/overview
- https://learn.microsoft.com/en-us/dotnet/core/whats-new/dotnet-11/runtime
- https://laurentkempe.com/2026/02/14/exploring-net-11-preview-1-runtime-async-a-dive-into-the-future-of-async-in-net/
- https://medium.com/@skyake/how-fast-is-net-11-runtime-async-b9c821529cd5
- https://www.youtube.com/watch?v=5fvi7m1QxIY&t
