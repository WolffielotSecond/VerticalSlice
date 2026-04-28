# GDIM33 Vertical Slice
## Milestone 1 Devlog

Q1. For the graph: Zombie Animator Controller
It has two functions, regulate the ShouldMove variable in the zombie animator and manage the alertness of the zombie when it sees the player.
At the start of the scene(On Start Event), the script will get a reference of the animator and the position of the zombie and set it as a vector called last position.
Then Every tick, the script will get the position of the zombie currently and calculate the vector distance between it and the vector stored in last position, it the delta is greater than a tolerance value (on this case there's no tolerance value, I simply did greater than 0), then the zombie is moving and the bool value ShouldMove in the animator will be set to true, vice versa. After all that, the current position of the zombie will be stored into the variable last position.

Meanwhile, there is a sequence in the On Update function. While doing the logic for determining the zombie is moving, the script also constantly gets the Can See Player variable from the Field Of View Script. If it is true, the Alertness Object Variable will increment with a speed of 5 per second, with a cap of 30. If the variable Can See Player is false, the Alertness Object Variable will fall with a speed of 1.25 per second, with a minimum value of zero.

Q2. 

<img width="2288" height="1500" alt="无标题绘图" src="https://github.com/user-attachments/assets/a033f257-ea66-4b6c-9eb8-dfad0aee710a" />

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

[Road](https://sketchfab.com/3d-models/road--avenue--street-7f657c3eceb343ceaf5e542c50dab27a)

[Dirt Material](https://www.fab.com/listings/1b83d08e-77fd-4885-9dce-32d8658b5559)

[Mansion Model](https://sketchfab.com/3d-models/x-ghosthouse-west-4eecf9f0af5a4a9c8c930c9e562434ed)

[Dead Trees](https://sketchfab.com/3d-models/psx-dead-tree-pack-40510061c9814223b204f03941e4c589#download)

[Mansion Interior](https://sketchfab.com/3d-models/the-upper-vestibule-e74928dc62fe457892e52dd97b6aa6e0)

[Chandelier](https://sketchfab.com/3d-models/antique-chandelier-c98d235a1df849388423b06f4e0a858c)

[Wood Planks](https://sketchfab.com/3d-models/set-of-wood-planks-1901d8f1e7354ea289860d29c6ba0046)

[Stone Wall](https://sketchfab.com/3d-models/damaged-wall-11616746d0ea4bd59a2d9cf9a2b2fdfa)

[Doors](https://sketchfab.com/3d-models/low-poly-psx-style-wooden-interior-doors-pack-02e442c6d4a24df29624808d058f010a)

[Key1](https://sketchfab.com/3d-models/key-a4aca11a2259462f8735a60eead33962)

[Key2](https://sketchfab.com/3d-models/key-copper-4b4ff0b9c28c45528553ea3f30692305)

[Key3](https://sketchfab.com/3d-models/vintage-ornamental-skeleton-key-62b40f33a3c24fe78883c624e7571dba)

[Hatchet](https://sketchfab.com/3d-models/tactical-hatchet-89744b83feca42748eb84a465089cfbc)

[Gun](https://sketchfab.com/3d-models/hand-gun-8aaf25a14f034014bfc3b83a69ad26be)

