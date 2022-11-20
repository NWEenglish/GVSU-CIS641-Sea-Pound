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
| FR1 | The system shall have guard enemies that have a larger range for the player to be within to start chasing the player in the Defensive game mode. |
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
| NFR1 | The system shall add a force of 5 units to the right when the player presses the “D” key. |
| NFR2 | The system shall add a force of 5 units to the left when the player presses the “A” key. |
| NFR3 | The system shall add a force of 5 units upwards when the player presses the “W” key. |
| NFR4 | The system shall add a force of 5 units downwards when the player presses the “S” key. |
| NFR5 | The system shall rotate the player’s tank barrel counterclockwise with a speed of 100 units when the player moves their mouse to relative north of the player’s tank barrel. |

### Bullet Logic
| ID | Requirement |
| :-------------: | :----------: |
| NFR1 | The system shall spawn a missile instantly when the player clicks, while in game. |
| NFR2 | The system shall have a bullet's rigid body be removed instantly upon collision detection. |
| NFR3 | The system shall have a missile’s bullet damage worth 25 units. |
| NFR4 | The system shall have a beam's bullet damage worth 15 units. |
| NFR5 | The system shall have a bullet be destroyed after 5 seconds have elapsed since being spawned. |

### Enemy Logic
| ID | Requirement |
| :-------------: | :----------: |
| NFR1 | The system shall have guard enemies that have a range of 1000 units chasing range to start chasing the player in the Defensive game mode. |
| NFR2 | The system shall have guard enemies that have a range of 15 units chasing range to start chasing the player in the Offensive game mode. |
| NFR3 | The system shall have guard enemies with a max speed of 2 units. |
| NFR4 | The system shall have all enemies start aiming at the player when the player is within 30 units. |
| NFR5 | The system shall have all enemies start shooting at the player when the player is within 12 units. |

| ID | Requirement |
| :-------------: | :----------: |
| NFR1 | The system shall have health regenerate at a rate of 1 every 0.20 seconds when the player is at home base. |
| NFR2 | The system shall have ammo regenerate at a rate of 1 every 0.20 seconds when the player is at home base. |
| NFR3 | The system shall have health decrease by 25 when they is hit by a missile. |
| NFR4 | The system shall have ammo deplete by 1 when the player shoots. |
| NFR5 | The system shall have the player spawn 45 rounds of ammo. |

	