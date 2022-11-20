# Overview

This document defines the scope of this 2D Tank Game project. That means the following requirements describe what should and should not happen while 
the game is being played. Listed below are both the functional and non-functional requirements, which are not yet organized by level of importance.

## Functional Requirements

### Main Menu
| ID | Requirement |
| :-------------: | :----------: |
| FR1 | The system shall close the game when the player presses the “Quit” button. |
| FR2 | The system shall display the credits for the audio source when the player presses the “Credits” button. |
| FR3 | The system shall display the controls for the player when the player presses the "Controls" button. |
| FR4 | The system shall display the Game Mode Selection screen for the player when the player presses the "Start" button. |
| FR5 | The system shall load the Defense game mode when the player presses the "Defense" button in the Game Mode Selection screen. |

### Player Movement
| ID | Requirement |
| :-------------: | :----------: |
| FR1 | The system shall add a force to the right when the player presses the “D” key. |
| FR2 | The system shall add a force to the left when the player presses the “A” key. |
| FR3 | The system shall add a force upwards when the player presses the “W” key. |
| FR4 | The system shall add a force downwards when the player presses the “S” key. |
| FR5 | The system shall rotate the player’s tank barrel counterclockwise when the player moves their mouse to relative north of the player’s tank barrel. |

### Objectives
| ID | Requirement |
| :-------------: | :----------: |
| FR1 | The system shall load the Defensive objectives when the game loads the Defense game mode. |
| FR2 | The system shall load the Offensive objectives when the game loads the Offensive game mode. |
| FR3 | The system shall mark the game mode objectives as failed if the player is destroyed. |
| FR4 | The system shall load a fresh objectives list when a game mode is loaded. |
| FR5 | The system shall mark the "Destroy the building" objective as completed when the building is destroyed in the Offensive game mode. |

### Enemy Logic
| ID | Requirement |
| :-------------: | :----------: |
| FR1 | The system shall have guard enemies that immediately start chasing the player in the Defensive game mode. |
| FR2 | The system shall have guard enemies that must wait for the player to be within chasing range to start chasing the player in the Offensive game mode. |
| FR3 | The system shall have turret enemies that cannot chase after the player. |
| FR4 | The system shall have all enemies start aiming at the player when the player is within aiming range. |
| FR5 | The system shall have all enemies start shooting at the player when the player is within shooting range. |

### Health and Ammo
| ID | Requirement |
| :-------------: | :----------: |
| FR1 | The system shall have health regenerate for the player when the player is at home base. |
| FR2 | The system shall have ammo regenerate for the player when the player is at home base. |
| FR3 | The system shall have health decrease when they are hit by a missile. |
| FR4 | The system shall have ammo deplete when the player shoots. |
| FR5 | The system shall have the player spawn with ammo. |


## Non-Functional Requirements

1. Main Menu
    1. The system shall load into the main menu is less than 4 seconds.
2. Shooting System
	1. The system shall spawn a missile instantly when the player clicks.
3. Enemy Logic
	1. The system shall have stationary enemy entities detect the player when within 100 units.
4. Player Movement
	1. The system shall keep the camera horizontally centered on the player object.
	