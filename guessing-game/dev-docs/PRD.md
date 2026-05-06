<!-- Last updated: 2026-05-06 -->
<!-- Last change: Initial PRD creation -->

# Guessing Game - Product Requirements Document

## Problem Statement

Build a number-guessing game as a C# console application, developed incrementally across eight phases. Each phase adds one layer of functionality so the codebase grows in complexity without being rewritten from scratch. This mirrors real-world iterative development and reinforces C# fundamentals learned in NSS Book 1.

## Core Requirements

The game is built phase by phase, each one shipping before the next begins.

| Phase | What it adds |
|-------|-------------|
| 1 | Prompt the user for a guess and echo it back |
| 2 | Introduce a hardcoded secret number (42); tell the player if they won or lost |
| 3 | Allow up to four attempts before the game ends |
| 4 | Show the current guess number in the prompt; exit the loop immediately on a correct guess |
| 5 | Replace the hardcoded number with a random number (1-100); display remaining guesses each turn |
| 6 | After a wrong guess, tell the player whether their guess was too high or too low |
| 7 | Before gameplay begins, prompt the player to choose a difficulty: Easy (8 guesses), Medium (6), Hard (4) |
| 8 | Add a "Cheater" difficulty option that gives unlimited guesses |

## Technical Stack

### Stack Decisions

- **Language:** C# - required by the assignment and the NSS curriculum track
- **Runtime:** .NET console application - lightweight, no framework overhead needed for a CLI game
- **Project type:** Single console app, no external dependencies

## Scope

### In Scope (v1)

- All eight phases as defined in the assignment
- Random number generation (Phase 5+)
- High/low feedback (Phase 6+)
- Difficulty selection with four tiers including unlimited mode (Phases 7-8)
- Incremental development: each phase is a working, shippable state of the app

### Out of Scope

- Score tracking or leaderboards
- Play-again loop after game over
- Multiplayer or networked features
- Persistent storage of any kind

## Success Criteria

- All eight phases are implemented and working
- Each phase is committed before moving to the next (incremental development)
- Random number is generated within 1-100 range
- Difficulty selection correctly maps to the right guess counts
- Cheater mode allows unlimited guesses without crashing or behaving unexpectedly
- Code is readable: clear variable names, no leftover debug output

## Learning Goals

- Practice C# control flow: `if/else`, loops (`for`, `while`)
- Use `Console.ReadLine()` and `Console.WriteLine()` for user I/O
- Work with `int.Parse()` or `int.TryParse()` for input conversion
- Apply `Random` class for number generation
- Understand how to incrementally evolve a codebase without full rewrites
