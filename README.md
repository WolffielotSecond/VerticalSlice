# GDIM33 Vertical Slice
## Milestone 1 Devlog

Q1. For the graph: Zombie Animator Controller
It has two functions, regulate the ShouldMove variable in the zombie animator and manage the alertness of the zombie when it sees the player.
At the start of the scene(On Start Event), the script will get a reference of the animator and the position of the zombie and set it as a vector called last position.
Then Every tick, the script will get the position of the zombie currently and calculate the vector distance between it and the vector stored in last position, it the delta is greater than a tolerance value (on this case there's no tolerance value, I simply did greater than 0), then the zombie is moving and the bool value ShouldMove in the animator will be set to true, vice versa. After all that, the current position of the zombie will be stored into the variable last position.

Meanwhile, there is a sequence in the On Update function. While doing the logic for determining the zombie is moving, the script also constantly gets the Can See Player variable from the Field Of View Script. If it is true, the Alertness Object Variable will increment with a speed of 5 per second, with a cap of 30. If the variable Can See Player is false, the Alertness Object Variable will fall with a speed of 1.25 per second, with a minimum value of zero.

Q2. 

<img width="2288" height="1500" alt="无标题绘图" src="https://github.com/user-attachments/assets/71e06b5d-3a7f-42bd-aa49-68930d03f99d" />

I Updated the Camera sections and made it a new system. Since my original plan is to make a third person over-the-shoulder game but I failed to implement that, so I changed it to a fixed camera game, and it will include a lot of new things like a camera controller to document the different positions of the camera locations and the areas where the camera position will change. There is also a facter of when the direction of the camera change, the input of the player will change correspondingly, but the change isn't abrupt, but with a buffer, the inverse input won't happen unless the player releases all the movement keys.

About the statemachine I used in the zombie AI. There are 5 different states currently, Patrolling, Alert, Pursue, Attack, Stunned. The zombie is Patrolling by default which is walking between 2 patrolling locations. After seeing the player for 2 seconds (Alertness > 10 since Alertness increases 5 per second when seeing the player) the statemachine change to Alert state. In Alert state the zombie will not move and will investigate the surroundings. When Alertness fall back to zero, the zombie returns to patrolling state. When Alertness increases to 17.5, the zombie enters pursuing state, where it will read the position of the player from the singleton of in the scene and chases the player. If Alertness fallback below 17.5 during the chase, it will re-enter alert state. If the zombie get close enough to the player, it will enter attack state where it will trigger the attack trigger in the animator and in the animation, an attack event will trigger to do all the attacking logic. If an attack is landed successfully, currently the zombie will still re-enter pursuing state. If the attack is parried, the zombie will enter stunned state that lasts for 5 seconds where the player can melee the zombie. When exiting from stunned state the alertness will be set to 10 and the zombie will enter alert state. I am planning to add a recovering state when the zombie is being meleed so that the player can't melee it twice in a row.


## Milestone 2 Devlog
Milestone 2 Devlog goes here.
## Milestone 3 Devlog
Milestone 3 Devlog goes here.
## Milestone 4 Devlog
Milestone 4 Devlog goes here.
## Final Devlog
Final Devlog goes here.
## Open-source assets
- Cite any external assets used here!
