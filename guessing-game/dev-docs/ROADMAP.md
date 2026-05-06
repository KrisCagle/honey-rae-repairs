<!-- Last updated: 2026-05-06 -->
<!-- Last change: Initial roadmap creation -->

# Guessing Game - Implementation Roadmap

Generated from: dev-docs/PRD.md

## Steps

- [x] **Step 1: Prompt and echo**
  Prompt the player to enter a guess and print it back. This establishes the basic console I/O pattern that every later phase builds on: read input, do something with it, print output.

  **User Stories:**
  - As a player, I want to enter a number so the game acknowledges my input.

- [x] **Step 2: Win or lose against a hardcoded number**
  Introduce a hardcoded secret number (42). After the player guesses, tell them whether they won or lost. Introduces the first conditional logic in the game.

  **User Stories:**
  - As a player, I want to know if my guess was correct so I can find out if I won.

- [x] **Step 3: Multiple attempts**
  Allow up to four attempts before the game ends. Wraps the guess logic in a loop for the first time.

  **User Stories:**
  - As a player, I want multiple attempts so I have a fair chance to guess the number.

- [x] **Step 4: Show guess number and exit on correct guess**
  Display which guess the player is currently on in the prompt. Exit the loop immediately when the player guesses correctly so they are not prompted again unnecessarily. Introduces the `guessCount` variable and a loop exit condition.

  **User Stories:**
  - As a player, I want to see which guess I am on so I can track my progress.
  - As a player, I want the game to stop immediately when I guess correctly.

- [ ] **Step 5: Random secret number and remaining guesses display**
  Replace the hardcoded 42 with a randomly generated number between 1 and 100. Show how many guesses remain each turn. Introduces `Random` and the `secretNumber` and `maxGuesses` variables from the data model.

  **User Stories:**
  - As a player, I want the secret number to be random so every game is different.
  - As a player, I want to see how many guesses I have left so I can plan ahead.

- [ ] **Step 6: High and low feedback**
  After a wrong guess, tell the player whether their guess was too high or too low. Small addition to the loop but makes the game actually playable.

  **User Stories:**
  - As a player, I want feedback after each wrong guess so I can narrow down the answer.

- [ ] **Step 7: Difficulty selection**
  Before gameplay begins, prompt the player to choose Easy (8 guesses), Medium (6), or Hard (4). Sets `maxGuesses` based on the choice. Introduces the Difficulty Selection component from the architecture.

  **User Stories:**
  - As a player, I want to choose my difficulty before the game starts so I can control how challenging it is.

- [ ] **Step 8: Cheater mode**
  Add a fourth difficulty option, Cheater, that gives unlimited guesses. Represents unlimited as `int.MaxValue` so the loop logic does not need a special case.

  **User Stories:**
  - As a player, I want an unlimited-guess option so I can explore the game without losing.
