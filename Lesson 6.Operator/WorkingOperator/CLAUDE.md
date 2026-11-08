# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.
Використовуй короткі відповіді, без зайвого коду, лише важлива інформація!

Перед рефакторингом і роботою з кодом завжди читай файл @spec.md


## Commands

Run from this directory (the folder containing `WorkingOperator.slnx`):

- Build: `dotnet build WorkingOperator.slnx`
- Run: `dotnet run --project WorkingOperator/WorkingOperator.csproj`

There is no test project and no linter/formatter configuration yet, so there is no command for running a single test.

## Architecture

- Single console app: `WorkingOperator/WorkingOperator.csproj` (net9.0, `ImplicitUsings` and `Nullable` enabled), referenced by `WorkingOperator.slnx`.
- `Program.cs` uses top-level statements. It sets the console input/output encoding to UTF-8 and prints a header line.
- `Device.cs` contains an empty `Device` class in namespace `WorkingOperator`. It is the likely target for the operator overloading exercise this lesson is about.
- This is a course workspace. The git repository root is the `Projects` folder two levels up, and sibling folders hold other lessons (`Lesson 1` through `Lesson 6`). Work only in this lesson's folder unless asked otherwise.

## Conventions

- User-facing strings and code comments are in Ukrainian, so keep new output in Ukrainian unless the user says otherwise.
- `bin/` and `obj/` are build output; do not edit them.
