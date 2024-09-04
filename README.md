# Memory Game 🎮

**Memory Game** is a console-based C# application that demonstrates object-oriented programming (OOP) and a clean separation between game logic and user interface (UI). This project emphasizes code organization and best practices in C# development.

## Overview

The project is structured to maintain a clear distinction between the core game logic and the console-based UI. Players can choose between two gameplay modes: playing against another player or challenging the computer. The game showcases strong OOP principles and is written in C# with a focus on maintainable, scalable code.

## Features

- **Separation of Concerns:** The game logic and UI are divided into separate modules, reflecting solid OOP design and maintainability.
- **Two Game Modes:** The game can be played in two modes—against another player or against a computer opponent with basic AI.
- **Console-Based UI:** The interface is simple and text-based, running in the console to provide an accessible experience.

## Technologies Used

- **C#**
- **.NET Core**

## Getting Started

To run the project locally, follow these steps:

1. Clone the repository:

   ```bash
   git clone https://github.com/benhemoshai/MemoryGame.git
   ```

2. Navigate to the project directory:

   ```bash
   cd MemoryGame
   ```
3. **Right-click** on the `MemoryGameUI` project and select **"Set as Startup Project"** to ensure the console UI runs correctly.

4. Build and run the solution using your preferred C# IDE (e.g., Visual Studio or Visual Studio Code).

## Project Structure

```
MemoryGame/
│
├── GameLogic/                # Game logic (core functionality)
│   ├── App.config
│   ├── Board.cs
│   ├── BoardCell.cs
│   ├── MemoryGame.Logic.csproj
│   ├── MemoryGameLogic.cs
│   ├── Player.cs
│
├── UI/                       # Console-based UI
│   ├── App.config
│   ├── ConsoleUI.cs
│   ├── GameRoutine.cs
│   ├── InputValidator.cs
│   ├── MemoryGame.UI.csproj
│   └── Program.cs
│
└── MemoryGame.sln            # Solution file
```

