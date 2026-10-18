# 3D Stealth Game: Haunted House

A fully playable 3D stealth game built in Unity. The player must navigate a haunted environment, avoid detection from both static and dynamic enemies using line-of-sight mechanics, and reach the exit trigger to escape.

## 🚀 Features Implemented

### Core Systems
*   **Player Controls & Physics:** Implemented a full physics-driven velocity movement system using the New Input System (WASD) with custom orientation locking.
*   **Player Animation:** Dynamic Animator State Machine configured to transition between smooth idle loops and walking animations based on live velocity data.
*   **Smart Camera Configuration:** Configured camera angles and obstacles to ensure clear, unhindered tracking of the player character through interior corridors.
*   **Detection Systems:** Integrated both stationary and patrolling enemies that detect the player using geometric line-of-sight triggers.
*   **Win/Lose States:** Custom UI overlay systems featuring independent screen fades for successful escapes and being caught by enemies.
*   **Audio Engine:** Integrated ambient environment tracks, unique failure sound cues, and victory triggers.

### 🌟 Bonus Extensions Implemented
1.  **Custom Level 2:** Designed and engineered a fully custom second map layer, extending the gameplay beyond the standard single-level course template.
2.  **Dynamic Level Transitions:** Programmed the game-ending states to dynamically detect the current scene index, automatically reloading the active level on death and advancing to Level 2 upon victory.
3.  **NavMesh AI Patrol Routing:** Configured a custom navigation mesh baking layer to handle smart AI enemy pathfinding calculation along patrol routes. 
    *   *Statement of Level Routing:* **Level 1 uses the standard tutorial waypoint system for enemy pathing, while Level 2 is the only level that utilizes the NavMesh AI routing system.**
4.  **Dynamic Player Footstep Audio:** Synchronized a physical script listener to toggle continuous dynamic footstep sound effects only when walking velocity is detected.
5.  **UI Toolkit Main Menu:** Built an interactive home screen using modern UI Toolkit (UXML) elements featuring functioning `PLAY` and `QUIT` system triggers.

---

## 🕹️ Run & Play Instructions

### Controls
*   **W / A / S / D:** Move Character
*   **Mouse Clicks:** Menu Navigation

### How to Play via Unity Play (WebGL)
1.  Click the official **Unity Play Game Link** provided in my submission.
2.  Wait for the WebGL loader to finish loading the game asset inside your web browser.
3.  Click the **Fullscreen** icon in the bottom-right corner of the player canvas for the best gameplay experience.
4.  Click **PLAY** on the Main Menu to begin Level 1.
5.  Reach the exit threshold to advance to the custom Level 2.
6.  If caught by an enemy, the active level will automatically reset so you can try again.
