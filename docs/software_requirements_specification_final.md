# Overview

This document defines the scope of this 2D Tank Game project. That means the following requirements describe what should and should not happen while 
the game is being played. Listed below are both the functional and non-functional requirements, which are not yet organized by level of importance.

# Software Requirements

This section describes the functional and non-functional requirements for the project. Firstly, it lists some of the functional requirements for the 
Main Menu, Player Movement, Objectives, Enemy Logic, and Health and Ammo. Following that, it lists the non-functional requirements for the Main Menu,
Player Movement, Bullet Logic, Enemy Logic, and Health and Ammo.

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
| FR6 | The system shall add a force to the right when the player presses the “D” key. |
| FR7 | The system shall add a force to the left when the player presses the “A” key. |
| FR8 | The system shall add a force upwards when the player presses the “W” key. |
| FR9 | The system shall add a force downwards when the player presses the “S” key. |
| FR10 | The system shall rotate the player’s tank barrel counterclockwise when the player moves their mouse to relative north of the player’s tank barrel. |

### Objectives
| ID | Requirement |
| :-------------: | :----------: |
| FR11 | The system shall load the Defensive objectives when the game loads the Defense game mode. |
| FR12 | The system shall load the Offensive objectives when the game loads the Offensive game mode. |
| FR13 | The system shall mark the game mode objectives as failed if the player is destroyed. |
| FR14 | The system shall load a fresh objectives list when a game mode is loaded. |
| FR15 | The system shall mark the "Destroy the building" objective as completed when the building is destroyed in the Offensive game mode. |

### Enemy Logic
| ID | Requirement |
| :-------------: | :----------: |
| FR16 | The system shall have guard enemies that have a larger range for the player to be within to start chasing the player in the Defensive game mode. |
| FR17 | The system shall have guard enemies that must wait for the player to be within chasing range to start chasing the player in the Offensive game mode. |
| FR18 | The system shall have turret enemies that cannot chase after the player. |
| FR19 | The system shall have all enemies start aiming at the player when the player is within aiming range. |
| FR20 | The system shall have all enemies start shooting at the player when the player is within shooting range. |

### Health and Ammo
| ID | Requirement |
| :-------------: | :----------: |
| FR21 | The system shall have health regenerate for the player when the player is at home base. |
| FR22 | The system shall have ammo regenerate for the player when the player is at home base. |
| FR23 | The system shall have health decrease when they are hit by a missile. |
| FR24 | The system shall have ammo deplete when the player shoots. |
| FR25 | The system shall have the player spawn with ammo. |


## Non-Functional Requirements

### Main Menu
| ID | Requirement |
| :-------------: | :----------: |
| NFR1 | The system shall close the game when the player presses the “Quit” button in less than 0.50 seconds. |
| NFR2 | The system shall display the credits for the audio source when the player presses the “Credits” in less than 0.25 seconds. |
| NFR3 | The system shall display the controls for the player when the player presses the "Controls" button in less than 0.25 seconds. |
| NFR4 | The system shall display the Game Mode Selection screen for the player when the player presses the "Start" button in less than 0.25 seconds. |
| NFR5 | The system shall load the Defense game mode when the player presses the "Defense" button in the Game Mode Selection screen in less than 2 seconds. |

### Player Movement
| ID | Requirement |
| :-------------: | :----------: |
| NFR6 | The system shall add a force of 5 units to the right when the player presses the “D” key. |
| NFR7 | The system shall add a force of 5 units to the left when the player presses the “A” key. |
| NFR8 | The system shall add a force of 5 units upwards when the player presses the “W” key. |
| NFR9 | The system shall add a force of 5 units downwards when the player presses the “S” key. |
| NFR10 | The system shall rotate the player’s tank barrel counterclockwise with a speed of 100 units when the player moves their mouse to relative north of the player’s tank barrel. |

### Bullet Logic
| ID | Requirement |
| :-------------: | :----------: |
| NFR11 | The system shall spawn a missile instantly when the player clicks, while in game. |
| NFR12 | The system shall have a bullet's rigid body be removed instantly upon collision detection. |
| NFR13 | The system shall have a missile’s bullet damage worth 25 units. |
| NFR14 | The system shall have a beam's bullet damage worth 15 units. |
| NFR15 | The system shall have a bullet be destroyed after 5 seconds have elapsed since being spawned. |

### Enemy Logic
| ID | Requirement |
| :-------------: | :----------: |
| NFR16 | The system shall have guard enemies that have a range of 1000 units chasing range to start chasing the player in the Defensive game mode. |
| NFR17 | The system shall have guard enemies that have a range of 15 units chasing range to start chasing the player in the Offensive game mode. |
| NFR18 | The system shall have guard enemies with a max speed of 2 units. |
| NFR19 | The system shall have all enemies start aiming at the player when the player is within 30 units. |
| NFR20 | The system shall have all enemies start shooting at the player when the player is within 12 units. |

### Health and Ammo
| ID | Requirement |
| :-------------: | :----------: |
| NFR21 | The system shall have health regenerate at a rate of 1 every 0.20 seconds when the player is at home base. |
| NFR22 | The system shall have ammo regenerate at a rate of 1 every 0.20 seconds when the player is at home base. |
| NFR23 | The system shall have health decrease by 25 when they is hit by a missile. |
| NFR24 | The system shall have ammo deplete by 1 when the player shoots. |
| NFR25 | The system shall have the player spawn 45 rounds of ammo. |


# Change Management Plan
This section describes how the system has thus far been tested, how to install the software and operate the software, and then how to report any bugs.

The 2D Tank Game has been thoroughly tested by multiple parties. The game was sent to several individuals, each with unique experience in both software, 
gaming, and testing. Beta testers found minimal bugs, minimal items of confusion, and minimal enhancement requests. After completing those tasks, beta testers reported
no further causes of concern.

The software can be installed by visiting the repository and downloading TankGame.zip. From there, unzip the file and place it in your desired folder.
The game can then be launched by opening that folder and running the executable file. While running the program, the user can open the Controls section
in the Main Menu and see how to operate the player's tank while in the game.

All bugs and enhancement requests should be submitted on the repository in the form of an issue with the "Bug" or 'Enhancement" tag. The dev team will
immediately be notified and will notify the user when the issue is resolved.


# Traceability Links
This section links together the use case diagrams, class diagrams, and activity diagrams with their respective requirement.

## Use Case Description Traceability
| Artifact ID | Artifact Name | Requirement ID |
| :-------------: | :----------: | :----------: |
| 1 | Start Game | FR4-5, NFR4-5 |

## Use Case Diagram Traceability
| Artifact ID | Artifact Name | Requirement ID |
| :-------------: | :----------: | :----------: |
| 2 | Move Entity | FR6-9, NFR6-9 |
| 2 | Shoot Rockets | FR11, FR24, NFR11, NFR24 |
| 2 | Be Destroyed | FR13, FR15 |
| 3 | Start Game | FR4, NFR4 |
| 3 | Start Defensive Game | FR5, NFR5 |
| 3 | View Controls | FR3, NFR3 |
| 3 | View Credits | FR2, NFR2 |
| 3 | Exit Game | FR1, NFR1 |

## Class Diagram Traceability
| Artifact ID | Artifact Name | Requirement ID |
| :-------------: | :-------------: | :----------: |
| 4 | PlayerLogic | FR6-10, NFR6-10|
| 4 | EnemyShootingLogic | FR19-20, NFR19-20 |

## Activity Diagram Traceability
| Artifact ID | Artifact Name | Requirement ID |
| :-------------: | :----------: | :----------: |
| 5 | Wait for Entity Input | FR6-9, FR19-20, NFR6-9, NFR19-20 |
| 5 | Move Entity | FR6-9, NFR6-9 |
| 5 | Rotate Entity | FR10, NFR10 |
| 5 | Shoot Projectile | FR11, FR24, NFR11, NFR24 |
| 5 | Reduce Health | NFR13-14 |
| 5 | Destroy Entity | FR13, FR15 |
| 6 | Exit Game | FR1, NFR1 |
| 6 | View Credits | FR2, NFR2 |
| 6 | View Controls | FR3, NFR3 |
| 6 | Display Game Modes | FR4, NFR4 |
| 6 | Load Defense Game | FR5, NFR5 |


# Software Artifacts
This section holds the direct URL links to the artifacts referenced in the traceability section.
| Artifact ID | Link |
| :-------------: | :----------: |
| 1 | [Use Case Description - Start Game](https://github.com/NWEenglish/GVSU-CIS641-Sea-Pound/blob/b56f23a824c525f88e9ba8a3a8472fd0fc7dae5b/artifacts/Use%20Case%20Description%20-%20Start%20Game.pdf)
| 2 | [Use Case Diagram - Entity Interactions](https://github.com/NWEenglish/GVSU-CIS641-Sea-Pound/blob/038a41946d6a7083e1bf0710e3ea24d58675fd82/artifacts/Use%20Case%20Diagram%20-%20Entity%20Interactions.png) |
| 3 | [Use Case Diagram - Main Menu Interactions](https://github.com/NWEenglish/GVSU-CIS641-Sea-Pound/blob/038a41946d6a7083e1bf0710e3ea24d58675fd82/artifacts/Use%20Case%20Diagram%20-%20Main%20Menu%20Interactions.png) |
| 4 | [Class Diagram - Entity Interactions](https://github.com/NWEenglish/GVSU-CIS641-Sea-Pound/blob/b56f23a824c525f88e9ba8a3a8472fd0fc7dae5b/artifacts/Class%20Diagram%20-%20Entity%20Interactions.png) |
| 5 | [Activity Diagram - Entity Interactions](https://github.com/NWEenglish/GVSU-CIS641-Sea-Pound/blob/b56f23a824c525f88e9ba8a3a8472fd0fc7dae5b/artifacts/Activity%20Diagram%20-%20Entity%20Interactions.png) |
| 6 | [Activity Diagram - Main Menu](https://github.com/NWEenglish/GVSU-CIS641-Sea-Pound/blob/b56f23a824c525f88e9ba8a3a8472fd0fc7dae5b/artifacts/Activity%20Diagram%20-%20Main%20Menu.png) |
