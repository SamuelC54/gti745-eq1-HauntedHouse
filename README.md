# GTI745-EQ1-HauntedHouse

## TODO

### Environment

- [x] Asset decoration for each room
  - Should be done inside the Room prefabs ta facilitate Scaling
  - Should account for Floor and Ceiling in each prefab
  - Rooms:
    - [x] Toilet
    - [x] Kitchen
    - [x] Bedroom
    - [x] MasterBedroom
    - [x] Hall/Salon
- [ ] Lighting for the level
  - Chamge to night skybox, and add needed light sources
  - Preferably dark but not too much
  - Add light sources to objects like lamps
- [x] Adapt scaling to model size (player vs environment)
- [ ] Add creepy ambient music

### Objectives

- [x] Global objective system
  - [x] **Puzzle 1 (Find whats happening)**
    - [x] Track that all notes were picked up before activating 2nd puzzle
    - [x] Create 5 notes that point to the objectives and story
      - [x] Note about the family disappearance (1) 
        - --> commode a l'entree
      - [x] Note pointing to the birthday on the day of the disappearance and the last preparation steps (2)
        - --> master bedroom
      - [x] Scary note of ghost kid saying how he couldn't celebrate his Bday (3)
        - --> kid bedroom
      - [x] Hint at candle number according to height chart in kids room (4)
        - --> toilet
      - [x] Note about the kids favorite cake recipe and directions to cook (5)
        - --> Kitchen
        - Find the right 3 ingredients
        - Put them on the tray
        - Chuck into the oven
        - Activate preprogrammed cook (rightmost knob)
        - Wait 5 secs
        - Take it out
        - Place on stand on the table
        - Place candles and light them
      - [x] Play sound on completion
  - [x] **Puzzle 2 (Cook the cake)**
    - [ ] Different ingredients are scattered in the kitchen (6-10 diff kinds)
    - [ ] There is at least 2 instances of each ingredient
    - [x] When cooking in the oven, check if the ingredients are of good type
      - If all good, replace the ingredient tray with the BakedCake tray
      - If not replace ingredients with charred lumps (need to find prefab in store)
    - [x] Detect cake placement on the stand before transitioning to next puzzle
    - [x] Play sound on completion
  - [x] **Puzzle 3 (Candles for age)**
    - [x] Detect candle placement on cake and their number
    - [x] Detect when those candles are lit up
    - [x] Play sound on completion
    - [x] Spawn ghost, eats cake (despawn), spawns key for exit door
    - [x] End game (YOU ESCAPED) when key touches the door
  
### Mechanics

- [x] Toggle between Direct/Ray interactor with a B/A button press (right hand only)
- [ ] Ghost
  - [ ] Enable only from 2nd Puzzle onwards
  - [ ] Spawns each 30 secs and tries to collide with you for 5 secs (need to run away, his speed is lower)
  - [ ] After a collision apply progressively darker red filter on screen
  - [ ] After 3 collisions you loose
- [ ] Make doors interactable (open close) --> Optional

### UI

- [x] Startup in main menu with 3 options (Start, Controls, Quit)
- [x] Similar menu in game with 4 options (Resume, Restart, Controls, Quit)
- [ ] Comlete the controlls option in Menu

