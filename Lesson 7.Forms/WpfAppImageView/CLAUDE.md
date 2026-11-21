# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

Використовуй короткі відповіді, без зайвого коду, лише важлива інформація!

Перед рефакторингом і роботою з кодом завжди читай файл @spec.md

## Commands

Run from this folder (where `WpfAppImageView.slnx` lives). Requires the .NET 9 target (`net9.0-windows`) and Windows, because the project is WPF.

- Build: `dotnet build WpfAppImageView.slnx`
- Run: `dotnet run --project WpfAppImageView/WpfAppImageView.csproj`
- Tests and linting: none configured. There is no test project and no analyzer config beyond the default compiler warnings.

The build currently reports 4 nullable warnings in `MainWindow.xaml.cs` (the `object path` parameter of `JobReadImages`). They are known and not errors.

## Architecture

This is a single-window WPF app (a Lesson 7 exercise) that shows a grid of thumbnails from a folder. The whole app is two files of logic:

- `MainWindow.xaml`: a path `TextBox`, a read button, and a `ListBox` (`galleryList`) whose `ItemsPanel` is a `WrapPanel`. Each item template is a 150x150 `Image` bound to `{Binding}`, so the list items are the `BitmapImage` objects themselves.
- `MainWindow.xaml.cs`: all behaviour.
  - `btnReadFile_Click` (UI thread): checks that the typed path is an existing directory, then starts a raw `Thread` running `JobReadImages`.
  - `JobReadImages` (worker thread): lists the files, builds a `BitmapImage` per file with `DecodePixelWidth = 300` and `CacheOption.OnLoad`, and skips files that fail to decode. It then assigns the list to `galleryList.ItemsSource` through `Dispatcher.Invoke`, which is the only hand-off back to the UI.

`App.xaml` sets `StartupUri="MainWindow.xaml"`. `App.xaml.cs` and `AssemblyInfo.cs` are template boilerplate with no custom logic.

Things to know when changing this code:

- The stopwatch timing in `JobReadImages` is computed but never shown (the `MessageBox` is commented out).
- Thumbnails are decoded on the worker thread. `BitmapImage` is a `Freezable`, and the code never calls `Freeze()`, so binding those objects on the UI thread may throw a cross-thread error. This has not been verified by running the app. Test it by running the app with a folder of images before relying on this path.
- The UI strings and code comments are in Ukrainian. Keep new user-facing text consistent with that.
- `bin/`, `obj/` and `.vs/` are gitignored. The git root is the parent `Projects` folder, which holds the other lessons as separate projects.

## Coding rules

- Do not add NuGet packages. The project has no dependencies today, and adding one is a decision for the user to make.
- Do not edit `bin/`, `obj/` or `.vs/`. Do not touch the other lesson folders when working on this project.
- Access WPF controls (`txtPath`, `galleryList`, and so on) only from the UI thread. From a worker thread, go through `Dispatcher.Invoke` or `BeginInvoke`.
- Call `Freeze()` on any `BitmapImage` (or other `Freezable`) before it is handed to another thread.
- Do not add new compiler warnings. The current 4 nullable warnings are the baseline. Fix them when you touch `JobReadImages`, typing the parameter as `object?` and handling null, rather than suppressing with `!`.
- Keep the existing naming: WPF controls use short prefixes (`txt`, `btn`, `gallery`), event handlers use `<control>_<Event>`, and the file-reading method is `JobReadImages`.
- User-facing strings and code comments are in Ukrainian. Identifiers are in English.
- Do not swallow exceptions silently in new code. The current empty `catch` in `JobReadImages` is an existing exception, not a pattern to copy.

## Architecture rules

- Logic currently lives in `MainWindow.xaml.cs`, which is fine for this size. Do not split it into layers unless the feature requires it.
- When adding file enumeration, filtering or thumbnail creation beyond what exists, put it in a separate class that has no dependency on the window or `Dispatcher`. Code-behind should only wire UI events to that class and show results.
- Any background job must have a single active instance. A new load must cancel or ignore the previous one, so two threads never write to `galleryList.ItemsSource` at the same time. Use a `CancellationToken` or a generation counter.
- A background job must not let exceptions escape the thread. Catch them and report the error on the UI thread. Today an exception from `Directory.GetFiles` would crash the app.
- Keep the `ListBox` binding simple: its items are `BitmapImage` objects, and the item template is in XAML. If you change the item type, change the template in `MainWindow.xaml` in the same edit.

## Testing rules

- There is no test project. Do not claim that tests pass. Report only the results of commands you actually ran.
- If you add automated tests, put the testable logic in a class library that does not depend on WPF controls, and test it there. Testing `MainWindow` directly needs a WPF UI thread and is not practical.
- Verify every change with `dotnet build WpfAppImageView.slnx`. The build must succeed with no new warnings.
- Manual check for any change to loading. Run the app and confirm these cases:
  - A folder with images shows thumbnails in a wrapping grid.
  - An empty folder shows an empty gallery and does not crash.
  - A missing path shows the "Папку не знайдено" message.
  - A folder that mixes images with non-image files shows only the images, with no crash.
  - Loading a second folder while the first is still loading does not show results from both.
  - A folder the user cannot read does not crash the app.
