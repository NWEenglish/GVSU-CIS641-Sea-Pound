# Overview

This document defines the scope of this 2D Tank Game project. That means the following requirements describe what should and should not happen while 
the game is being played. Listed below are both the functional and non-functional requirements, which are not yet organized by level of importance.

# Functional Requirements

1. Main Menu
    1. The system shall close the game when the player presses the “Exit Game” button.
    2. The system shall display the credits for the audio source when the player presses the “View Credits” button.
2. Player Movement
	1. The system shall add a force to the right when the player presses the “D” key.
	2. The system shall rotate the player’s tank barrel counterclockwise when the player moves their mouse to relative north of the player’s tank barrel.

# Non-Functional Requirements

1. Main Menu
    1. The system shall load into the main menu is less than 4 seconds.
2. Shooting System
	1. The system shall spawn a missile instantly when the player clicks.
3. Enemy Logic
	1. The system shall have stationary enemy entities detect the player when within 100 units.
4. Player Movement
	1. The system shall keep the camera horizontally centered on the player object.
	