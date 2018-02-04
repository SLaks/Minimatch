# Minimatch
A minimal matching utility.

This is a port of Node.js' [minimatch](https://github.com/isaacs/minimatch).

## Usage
First, install [from NuGet](https://www.nuget.org/packages/Minimatch/):

```powershell
dotnet-cli> dotnet add package Minimatch
nuget> nuget install Minimatch
PM> Install-Package Minimatch
packet> paket add Minimatch
```

Just parse the pattern into a `Minimatcher` instance, then call the `IsMatch` function to check whether an input matches it.  You can also use the `Filter()` convenience method to filter a list of paths and find those that match the pattern.

```csharp
var mm = new Minimatcher(searchPattern);

if (mm.IsMatch(somePath)) {
	// The path matches!  Do some cool stuff!
}

var matchingPaths = mm.Filter(allPaths);
```

Minimatch also has `static` versions of these methods that take a pattern a string.  However, these methods will re-parse the pattern on every invocation, making them slower.

## On Windows-style paths
Minimatch's syntax was designed for Linux-style paths (with forward slashes only).  In particular, it uses the backslash as an escape character, so it cannot simply accept Windows-style paths.
My C# version preserves this behavior.

To suppress this, and allow both backslashes and forward slashes as path separators (in patterns or input), set the `AllowWindowsPaths` option:

```csharp
var mm = new Minimatcher(searchPattern, new Options { AllowWindowsPaths = true });
```

Passing this option will disable escape characters entirely.

-----

Quoting the original documentation:

 > ## Features
 > 
 > Supports these glob features:
 > 
 > * Brace Expansion
 > * Extended glob matching
 > * "Globstar" `**` matching
 > 
 > See:
 > 
 > * `man sh`
 > * `man bash`
 > * `man 3 fnmatch`
 > * `man 5 gitignore`
 > 
 > ### Comparisons to other fnmatch/glob implementations
 > 
 > While strict compliance with the existing standards is a worthwhile
 > goal, some discrepancies exist between minimatch and other
 > implementations, and are intentional.
 > 
 > If the pattern starts with a `!` character, then it is negated.  Set the
 > `NoNegate` flag to suppress this behavior, and treat leading `!`
 > characters normally.  This is perhaps relevant if you wish to start the
 > pattern with a negative extglob pattern like `!(a|B)`.  Multiple `!`
 > characters at the start of a pattern will negate the pattern multiple
 > times.
 > 
 > If a pattern starts with `#`, then it is treated as a comment, and
 > will not match anything.  Use `\#` to match a literal `#` at the
 > start of a line, or set the `NoComment` flag to suppress this behavior.
 > 
 > The double-star character `**` is supported by default, unless the
 > `NoGlobStar` flag is set.  This is supported in the manner of bsdglob
 > and bash 4.1, where `**` only has special significance if it is the only
 > thing in a path part.  That is, `a/**/b` will match `a/x/y/b`, but
 > `a/**b` will not.  **Note that this is different from the way that `**` is
 > handled by ruby's `Dir` class.**
 > 
 > If an escaped pattern has no matches, and the `NoNull` flag is set,
 > then minimatch.match returns the pattern as-provided, rather than
 > interpreting the character escapes.  For example,
 > `Minimatcher.Filter(new string[0], "\\*a\\?", new Options { NoNull = true })` will return `"\\*a\\?"` rather than
 > `"*a?"`.  This is akin to setting the `nullglob` option in bash, except
 > that it does not resolve escaped pattern characters.
 > 
 > If brace expansion is not disabled, then it is performed before any
 > other interpretation of the glob pattern.  Thus, a pattern like
 > `+(a|{b),c)}`, which would not be valid in bash or zsh, is expanded
 > **first** into the set of `+(a|b)` and `+(a|c)`, and those patterns are
 > checked for validity.  Since those two are valid, matching proceeds.

# License
[MIT](http://opensource.org/licenses/MIT)
