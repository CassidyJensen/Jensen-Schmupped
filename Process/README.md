# 09.23.20 - Beginning Thoughts (Brainstorming)

Some initial ideas I had about this project include the following basic concepts: 

    1. Schmup as a pirate with a rum power up - you can drink rum to increase your score, but you can’t shoot for a period of time after you drink. 

    2. Schmup with the elements. You have 4 different types of ammunition that can only be used against certain enemies. Enemies are immune to the same element. Opposites do more damage. 

    3. Schmup as a pirate ship. There are enemies on both sides. Cannonballs can go through and hit multiple targets. However, they need time to reload. 

    4. Schmup with karma. The longer you let the enemies live, the better/more power ups you get. Players must be careful not to get overwhelmed!

    5. Schmup with a rescue beam. There are hostages that need to be saved - but it takes time to beam them in.

# 09.25.20 - Idea Refinement - Schmup’s Ahoy (#3)
1. Which of Fullerton's Formal Elements are you working with?
- Rules (Two sided weapons)
- Resources (Time or Cannonballs) 

2. What kinds of puzzles or player challenges might you include?
- Cannonballs are on a timer
- Cannonballs have a limited amount, resupply happens slowly
- Resupply based on how many enemies you can hit at once? 
- Boss enemy: The Kraken
- Requires more hits, need a supply of cannonballs ready
- No resupply during the boss
- After boss - resupply of lives? (materials for health) + Increase in difficulty?
- Players attempt to hit multiple targets with one shot. 
- Power-down - players have to shoot from both sides at once
- Have to spend time fixing the ship - but can’t shoot? 

3. What are the basic rules for your game?
- The player is a pirate ship that can move up and down on one axis
- The goal is to survive as long as possible to get a higher score
- The player can fire cannonballs on the left side or right side, depending on which button they press.
- Cannonballs can hit multiple targets.
- Cannonballs have a limited supply. Resupply occasionally drifts by (picked up by shooting it).
- Enemy ships spawns from both sides to fire at the player.
- After 3 hits, the ship is sinking and the player loses a life out of 3. 
- Or every hit brings them close to death, but they can use the fix-up materials to gain health back. However this takes time & stops cannonfire. 
- After a set amount of time, the round ends and the boss appears. 
- The kraken takes a set amount of cannonballs to defeat it. The players must dodge attacks in order to survive. Resupply may occur by hitting a difficult target during the fight? 
- After defeating the kraken, the rounds get harder by adding barriers (islands) and stronger / special enemy types. This cycle repeats. 
- If there are power-ups/power-downs they are either from special enemies hitting the player or from shooting the item in the water. 

# 09.28.20 - Schmup's Ahoy Dev Day 1

First day of development on the game was focused on getting a couple of the basics set up.

- The player was moved to the center of the screen
- Player can now shoot upwards or downwards using the up and down arrow keys
- Projectiles are no longer destroyed upon hitting an enemy, they keep going through until they hit a wall
- Enemies are now spawned on the bottom as well, with the ability to shoot upwards
- Began development on a new enemy spawner program that randomly spawns the ships above and below after some amount of time [in progress]

# 09.30.20 - Schmup's Ahoy Dev Day 2

- Have the kraken appear as  random variant, with different difficulties
- Color changes
    - The background is now blue
    - The player is now red
- Removed old enemy spawning code
- Enemies are now spawned randomly above and below
    - For the most part they don't overlap, but sometimes they do - BUG to fix later
- Player now shoots 3 cannonballs from each side at a time
    - Second two cannonballs shoot at an angle
- Game Manager Script Added
    - Controls ammo supplies and score
    - Updates the text UI
- Text UI added for the score and ammo
- Enemies and player shift up and down on a sin wave, as though shifting on the waves
    - This may be adjusted for the player later as a part of the rum power up 
- Enemies projectiles are round again to be like cannonballs, but still green

Next steps
- Increase the frequency of enemies / fire rate to make it more difficult
- Add ammo resupply (power up)
- Update the sprites / visual components
- Add rum (power up / down)
- Add a Game Over screen

# 10.02.20 - Schmup's Ahoy Dev Day 3

- Ammo Supply Box prefab created
    - adds 10 ammo to supply
    - slowly floats left from the right of screen
    - gets destroyed upon contact
- Decreased size of cannonballs from 1 1 to .5 .5 
- Added pirate ship and enemy ship sprites
    - Hitboxes are smaller for enemies and players
- Added a Game Over Screen
- Moved health control to the game manager script
- Healthbar is now red
- Experimented with enemies shooting more projectiles at a time(Might be used to increase difficulty over time)
- Player speed reduced from .5f to .2f;

Next Steps
- Game Over restart button
- Rum Power Up
- Generate ammo boxes over time
- Adjust difficulty
    - Make enemies stronger over time? 
- Generate power ups over time

# 10.05.20 - Schmup's Ahoy Dev Day 4

- Made a variation on the Ammo supply prefab as a rum power up
    - Implemented the negative effects of rum
    - becomes difficult to move left and right
    - spawns at beginning
- Ammo boxes spawn consistently over time
- Changed the amplitude for ammo boxes to make them missable. This applies to power ups as well
- Experimented with ways to prevent enemies from spawning on top of each other
    - No working solution has been found yet. 
    - Overlap box is having issues. 

Next steps
-Create a second phase where enemies get stronger
-Generate power ups over time
-Finish the rum power up with positive effects as well as negative. 
-Add more power ups
    - Intrigued by the idea of power ups being a choice with good and bad consequences. 
- Game Over Restart button still needed

# 10.07.20 - Schmup's Ahoy Midpoint Evaluation

Playtesting Review
- Recommended having ammo spawn on a random timer (the consistent was too controlled and easy)
- First instinct upon playing the game is shooting a bunch of times, quickly ran out of ammo
    - Had to focus on dodging the enemies while waiting for pickup
    - first pickup should be slow enough to give the user time to learn dodging
    - but fast enough that it doesn't make it impossible
- Enemies might need to become more challenging to evade
    - Currently pretty easy
    - Maybe good for learning evading early, but quickly ramping up? 
- Need labels on score and ammo to make it more clear what is going on
    - might need a status label for pickups
- Additional Cannonballs should be at slightly less of a sharp angle
    - aim it more downwards/upwards
- Voiced interest in more pickups
    - Specifically shooting longer? 
    - Health pickup
- Commented that the controls weren't intuitive at first with the two sides of shooting
    - but noted that it was fun gameplay once they got used to it

Patchnotes
- Ammo spawn is now on a random timer
- Label for score and ammo added
- Double points while rum active
- Rum spawns randomly over time
- Rum and ammo box disappear when they hit the walls!
- Added a status UI element
    - Updates when user has rum power up
    - will update when other power ups are included
- Upped random enemy spawner
    - spawn min 0 -> 2
- Adjusted random range for rum influence (made it smaller)
    - (-.05f, .05f) ->
- Animation disappears once finished
- After 10 rounds enemies get stronger
    - Round 10 - spawnMin and spawnMax increase by +2
    - Round 20 - shoot two bullets 
    - shoot faster?? more likely to shoot?? 

Next steps
- Other power ups --- Health???
- Angle secondary cannons more downward/upwards
- Add ocean texture
- Create pickup sprites
- Game Over Restart button still needed
- Experiment more with increasing enemy difficulty