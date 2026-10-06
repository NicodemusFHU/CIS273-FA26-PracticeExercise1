# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## What this is

A CIS273 (data structures) practice exercise: an array-backed list of `int`s in C#. The solution is a starter template, so several `ArrayList` members are intentionally unfinished and most tests fail until they are implemented. Unfinished members are not all marked: some carry `// TODO`, others just `throw new NotImplementedException()`, and `Get` and `ShiftLeft` are silent stubs (`Get` always returns `null`, `ShiftLeft` has an empty body). Conversely, a few `// TODO` comments sit on members that are already implemented.

**Keep the stubs intact.** This is the starter template handed to students, so never fill in the unfinished `ArrayList` members or otherwise make the failing tests pass. Work here is limited to the tests, doc comments, `// TODO` markers, project files, and other scaffolding. Failing tests are the expected state, not a problem to fix.

## Commands

Run from the solution root (the directory containing `PracticeExercise1.sln`). Both projects target `net9.0`.

```sh
dotnet build                                          # build both projects
dotnet test                                           # run all MSTest tests
dotnet test --filter "FullyQualifiedName~TestInsertAt"   # run one test
dotnet test --filter "FullyQualifiedName~TestRemove"     # substring match: also runs TestRemoveAt
dotnet test --filter "Name=TestRemove"                   # exact match
dotnet run --project PracticeExercise1                # run the console app (Main is empty)
```

The test build emits a batch of `CS8602` nullable warnings and `MSTEST0001`; these are pre-existing and not caused by your changes.

## Structure

- `PracticeExercise1/` — console project. `IList.cs` defines the list contract; `ArrayList.cs` is the single implementation, backed by an `int[]` (initial capacity 16) plus a separate `length` count.
- `UnitTests/` — MSTest project (MSTest 4.x) referencing the console project. One test method per `IList` member in `ArrayListUnitTests.cs`.

`IList` and `ArrayList` here are the project's own types in the `PracticeExercise1` namespace, not the BCL ones. Don't add `using System.Collections;`, which would make the names ambiguous.

## Implementation conventions in `ArrayList`

These describe the patterns the provided code models for students; keep any scaffolding changes consistent with them.

- Mutators that grow the list check `length == array.Length` and call `Resize()` (doubles capacity) before writing.
- `ShiftRight(startingIndex)` / `ShiftLeft(startingIndex)` only move elements; the caller writes the new value and adjusts `length` itself (see `Prepend`).
- `Clear()` just resets `length`; slots past `length` hold stale data, so loops must be bounded by `length`, never `array.Length`.

## Behavior the tests pin down

The tests are the spec. Points that are not obvious from the `IList` signatures or doc comments:

- Tests exercise the list through the `IList` interface and assert on `ToString()` with spaces stripped, so output must reduce to the form `[0,1,2]` (`[]` when empty).
- `First` / `Last` return `null` on an empty list rather than throwing.
- `InsertAfter(newValue, existingValue)` inserts after the *first* occurrence; if `existingValue` is absent (including on an empty list) it appends.
- `InsertAt(value, index)` accepts `index == Length` (append); negative or larger indexes throw `IndexOutOfRangeException`.
- `RemoveAt(index)` throws `IndexOutOfRangeException` for `index == Length`, negative indexes, and an empty list.
- `Remove(value)` removes only the first occurrence and is a no-op when the value is absent or the list is empty.
- `FirstIndexOf` returns `-1` when not found.
- `Reverse()` returns a new list and leaves the original unchanged.
- Several tests append 50–64 elements, so they cross the 16-element capacity and depend on `Resize()` being triggered correctly.
