# GTI745-EQ1-HauntedHouse

## TODO

### Environment
- [ ] Asset decoration for each room
  - Should be done inside the Room prefabs ta faciliate Scaling
  - Should account for Floor and Ceiling in each prefab
  - Rooms:
    - [ ] Toilet
    - [ ] Kitchen
    - [ ] Bedroom
    - [ ] MasterBedroom
    - [ ] Hall/Salon
- [ ] Lighting for the level
  - Preferably dark but not too much
  - Add lightsources to objects like lamps
- [ ] Adapt scaling to model size (player vs environment)
- [ ] Add creepy ambient music

### Objectives
- [ ] <u>Global objective system</u>
  - [ ] **Puzzle 1 (Find whats happening)**
    - [ ] Track that all notes were picked up before activating 2nd puzzle
    - [ ] Create 5 notes that point to the objectives and story
      - [ ] Note about the family disappearance (1)
      - [ ] Note pointing to the birthday on the day of the disappearance and the last preparation steps (2)
      - [ ] Scary note of ghost kid saying how he couldn't celebrate his Bday (3)
      - [ ] Hint at candle number according to height chart in kids room (4)
      - [ ] Note about the kids favorite cake recipe and directions to cook (5)
        - Find the right 3 ingredients
        - Put them on the tray
        - Chuck into the oven
        - Activate preprogrammed cook (rightmost knob)
        - Wait 5 secs
        - Take it out
        - Place on stand on the table
        - Place candles and light them
      - [ ] Play sound on completion
  - [ ] **Puzzle 2 (Cook the cake)**
    - [ ] Different ingridients are scatered in the kitchen (6-10 diff kinds)
    - [ ] There is at least 2 instances of each ingridient
    - [ ] When cooking in the oven, check if the ingridients are of good type
      - If all good, replace the ingridient tray with the BakedCake tray
      - If not replace ingridients with charred lumps (need to find prefab in store)
    - [ ] Detect cake placement on the stand before transitionning to next puzzle
    - [ ] Play sound on completion
  - [ ] **Puzzle 3 (Candles for age)**
    - [ ] Detect candle placement on cake and their number
    - [ ] Detect when those candles are lit up
    - [ ] Play sound on completion
    - [ ] Spawn ghost, eats cake (despawns), spawns key for exit door
    - [ ] End game (YOU ESCAPED) when key touches the door
  
### Mechanics
  - [ ] Toggle between Direct/Ray interactor with a B/A button press (right hand only)
  - [ ] Make doors interactable (open close)
  - [ ] Ghost
    - [ ] Enable only from 2nd Puzzle onwards
    - [ ] Spawns each 30 secs and tries to collide with you for 5 secs (need to run away, his speed is lower)
    - [ ] After a collision apply progressively darker red filter on screen
    - [ ] After 3 collisions you loose

### UI
  - [ ] Startup in main menu with 3 options (Start, Controlls, Quit)
  - [ ] Similar menu in game with 4 options (Resume, Restart, Controlls, Quit)
  - [ ] When starting game, pause and show controls dialog before continuing.


### Other
    - [ ] When starting a game, trigger VR position reset
