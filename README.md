# Trivia Game Project

## Table of Contents

- [Project Description](#project-description)
- [Features](#features)
- [Installation](#installation)
  - [Prerequisites](#prerequisites)
  - [Building](#building)
- [Running the Application](#running-the-application)
- [Contributing](#contributing)
- [License](#license)

## Project Description

This project is a fun and interactive trivia game implemented in C#. The game supports multiple question types including boolean and multiple-choice questions, with a flexible answer-checking mechanism to account for minor typos or misspellings. The primary user interface is a console application, but the design allows for easy integration with other UI platforms.

## Features

- **Multiple Question Types**: Supports boolean (True/False) and multiple-choice questions.
- **Flexible Answer Checking**: Uses the Levenshtein distance algorithm to allow for minor spelling errors in answers.
- **Scoring System**: Tracks player scores and determines the winner at the end of the game.
- **Extensible Design**: Separate UI and game logic for easy extension and integration with different interfaces.

## Installation

### Prerequisites

- [.NET SDK 6.0](https://dotnet.microsoft.com/download/dotnet/6.0) or later

### Building

Clone the repository and build the project using the .NET CLI:

```sh
git clone https://github.com/yourusername/your-repo.git
cd your-repo
dotnet build
