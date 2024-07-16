# Environment
- Unity Version: 2022.3.14f1
# Game Background
- You are now a student in Nation Cheng Kung University(NCKU), carving to learn enormous knowledge in each of the lectures.
  So you do not want to be late in any class for fear of losting the precious time for studying. And this game is to let
  students know more about the campus in NCKU so that they will find the classroom in different buildings more immediately.
# How to Play
- Third person game, changing the character's direction by rotating your mouse
- Use WASD to move, space to jump
- Press left shift to move faster
- There are three buttons during the game, "back to menu" will let you got to the initial setting, you can arrange the volume and so on,
  "Help" will list tips to teach you how to play in this game, "exit" will let you exit the game
# Game Logic
## Normal cases
- In the beginning, we will tell the player the place of class player need to go
- Player has three hearts totally, if three hearts are all gone, then game over.
- If the player reached the right place, it will come out three questions, each of the questions has four options,
  finishing the three will show the next place of class for player to bound for. But if player got wrong in any questions,
  one heart will be decrease and has warning sound.
- If player reached all of the place for class, and had at least one heart, then the player won
- If player got minus all of the hearts during the game, then the player loss
- In the game, there will be time, the rest of the hearts icons and the next plce for class
## Special cases
- There is an banana peel on the road, if player uncarefully step on it, the character will still in there for ten seconds
- There is a famous spot in NCKU called "Quit School Door", it is said that if student go through it, then
  they will ultimately quit by school. And there is a copy of it in the map, if player go through it, the player will lost
  all of their hearts and consequently loss
- There is also a famous spot called "NCKU pond", if player drop in this big pond, they will also loss
# Quick Demo
- Demo video: https://youtu.be/otXm0rD-444

# Need to improve
- Help button in game
- A apparent sign for newer in NCKU to find next place
- Maybe some auto vechicles
- More special cases
- Bugs in questions phrase

