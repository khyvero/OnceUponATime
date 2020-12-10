# Research And Process Journal (Once upon a time)
By Veronica Kwok
## First statement and Motivation
    
The prototype is call Rapunzel, worked by Nina, Luisa and me. The basic idea is from a fairytale story, Rapunzel. 
The story is about the witch discover that a man stole her blue radishes for his wife. The witch gives up them, but the man should give his baby to the witch. The witch gives her a name, call Rapunzel. The witch does not allow her to leave the tower. The witch let Rapunzel put down her hair from the window. The witch climbs the hair to go back the tower.
I choose Rapunzel story as my semester project because I have many ideas about the interactive and narrative would like to add on game. I also like the story. 
I was happy to group with Nina and Luisa to continue work on the game. We want to make a walking simulator like Gone Home in our game. we also think that the game can pass the message in an interactive way to reach the player easier.

## Process Journal
 
   * ### 29 April 2020
  
    I think that we should clarify that what is our goal, some basic information about our game. So, we spent more time in discussion such as story background, new idea what we have, what idea we want to change, our role, and also set some goal. We will have at least 1 meeting per week. 
    I made the mood board get some idea how the room looks like. I set the color tone for our whole game. I think it is necessary because we all are building the room, making the scene, we don’t set the color tone, finally the color will not much. Also, I play some game about Walking Simulator. 
    We created a Miro board for organize our work. We can work on it together. I can read my groupmate’s work before the meeting. I can leave some text if I do understand something what they did, or I can also write down if I more idea about what they write.  
    I like to work on Miro bard if I am working on small group. Because the board cannot be load in the class. So, my way is read the board before the class and after the class. Also, I dropped note in class. 
    On next week, we will focus more on level 1, animations, programming, in order to achieve mechanics.
    
    
###
  * ### 6 May 2020
  
    After Miro and Martin prestation in class, I got some idea how to think about our game. I think we can add more interactive, but they should relate to the plot. I should also think about how to relate to the plot. We also need to think about what components we can add in our game.
    We planned to do some research and discuses about story background.  I think that it can help us to make the game later. We didn’t think that we have to show a screen shot in class. We didn’t know that we should join the playtest evening yesterday. We should check more Teams message. 
    We should build our own models for our game. We don’t want to have the models which is from the internet. Also, we discussed about the mechanics  
     - use Maya to build, tree, chest, keys, toilet, sink and make animation
     - put the models in Unity
     - I will try somethings, about the coding part, what I learn from internet.
        1. try different ways to pick up and put down the object
        2. try to control the animation by script
        3. try to use key to open the door
  
  
###  
  * ### 6 May 2020
  
     Continue to try somethings, about the coding part, what I learn from internet.
      1. Try to pick up more item
      2. try to lock more item
          - make terrain in unity
     We have a new room and more item. The coding part become harder to do. I should put the script in every object instead of putting it the player only. I should think about what is reacting the object.  I should rewrite the script. This is what I will do on next week. But in 20-05-2020, I can’t show the interaction part. Because they mostly don’t work.


###
  * ### 20 May 2020
  
    In this week, I was more focus on the coding part. 
    After using object-oriented programming to interfaces and distributed the logic over the domain objects, the interaction is work. 
    I was not only let the last interactions works also add some new interaction. For let the player understand what he/she is facing, I make a text box and write the instruction. Luisa design the Controls guide scene, so I also write code for link it to the game.
    I have problem if I keep using trigger and UI text box. The text also will show when the player does not face to the target object. I want to keep the text box on the bottom, I think screen will be clean when the instruction is only showed in the same place, so I use Ray-cast.
    I also write script to show the text message about the Rapunzel’s thoughts
    For future, I think we need to add the inventory, so I create a list by script. To hide some object or show some object. What the player picks up an object, the name of the object will add on list, when the player put down the object, it will remove from the list. For unlock something such as door, computer just check what the list have, and the name is it match with the unlock object needs. 
    Next week I should solve the problem about pick up and put down. I don’t think I am using a good way to make the pickup and put down. I let the object out of the camera because I didn’t finish the “put down” function. 


###
  * ### 27 May 2020
  
    I think the bird is cute we can let it show up long time, it will be cool idea if the player can not only eat food but also feed bird. And I did it. 
    I set a timer by script. It is for every object. I don’t have to many timer scripts. I have this idea to make a timer because I would like to hide the bird when the game start. I think the player shouldn’t see every object when the game start. Some objects can be show after some time.
    We add a woman as Rapunzel’s mother. For the future, she will have some conversation with the player and walk around the room. But It is only a demo for milestone presentation.
    Player can eat food and pick up more things in the game.
    I think we add more objects and interactive part. Sometime two or more pickable objects in screen. I add the object name in the text box, not only the controls guide, to let the player clearer. I think we can change to image in future.
    I think if the text box background is a write square, it looks not good. I draw hair as a background, because the Rapunzel have a long hair. We can show in the screen. 


###
  * ### 3 Jun 2020
  
    After the presentation, we think that we should have a bigger place, because there are Rapunzel and her mother. It is not possible if only one bedroom. 
    I think we should add something to guide the player do the task because we only have one room in our game. Guide the player to find the clue. Or we can use the clue message (e.g. after picking up the family photo, the clue message will be showed) we can give some hints to player or show something relate to next step. So, we plan to use the diary to guide the player. After the player find some clue the diary texture will be change. But after e.g. 5 mins, the player can’t find something what we want the player to find then we can show some hits.
    I build some items for the kitchen, pot, pan spoon, fork, knife. 
    For improve the picking up and put down function, I try the find more information form the internet. Finally, I use “transform” to let the object group with the player and set the position and rotation object by object. Because for put down function, player should see the object.


###
  * ### 10 Jun 2020
  
     I think we should have the scene after the player open the Exit door.  to related to our game, I think we can say the player leave the tower, she can find her father and mother.
     I build a book and make animation in Maya and make the UV mapping. I don’t know why the book fall down very slow. I use the same setting. No problem in other object. after find solution in internet, still can’t solve it. So, I try to ask professor.  
     I also add script to let the player pick up the big items after eating. But for the food, I think I should make script to let them show up after player ate. Because we don’t know what the player will pick up, how many times the player will pick up the big items. Make the fire by the particle system and water by the change shader.
     Nina said that the game is too slow. But I don’t know how to solve the problem. Luisa and I didn’t have this problem.


###
  * ### 17 Jun 2020

     In this week, I try to finish the interaction what we discuss before, such as water , which is control by handle, Rapunzel’s mother can walk around, and go to the her room to let player go out from the room if the player go inside her room. So, when the player goes inside her room, player should close the door.
     For let Rapunzel’s mother walk around I plan to set some random position last week, but I got new knowledge from the internet which is Nav Mesh Agent. But after I use it, I find out some problem, I don’t exactly know how to let her stop for some time. So, I can’t add the dialogue for Rapunzel and her mother. But time is not enough to change it. Her function only for hide the key now.
     Nina and Luisa will play the game more to let me know what I should fix. 
     The key color of the mother’s room is the same as mother’s dress color, so the player doesn’t know it. So, we try to add particle system, but it doesn’t look good so finally we just change the colors.
     Add energy bar
     Try to bake light to let the game faster.  
     Use the state machine to controls the scene. 


###
  * ### 3 Jul 2020
  
     Fix the lighting and bake light again.
     Luisa finish the animation for the introduction. I use Adobe After effects to add effect to let it like a book and turn to another page. 
     Add video in the introduction scene, win scene, credit scene. after finishing the video, the player can get the next scene, game scene, win scene, credit scene. I also set the skip button, player can skip the video and go into the game.
     To get the key of secret room, Player should pick up the bucket, bring it to the bathtub and get water, use water to off the fire, then the player can get the key. But this is quite different for the player we should add some text to guide the player. 



## Final Statements

This is our first video game. I appreciate what we have in our game and this is because we have a good communication. we know that we have the same goal, want to make game. I like to work with them. We don’t mind sharing knowledge what we know. 
When I focus on work, I will get lost. I should talk with them and let me clearer what I should do first. But this is what I should improve.
This was the first time for me to use unity to create and code a game. I was lucky to have grouped with Nina and Luisa. I think we had a very good cooperation. Nina and Luisa were always supportive to me even when I was late for finishing some unity or coding parts, they were always here asking nicely how they can help. In general, we enjoyed working, discussing and sharing our knowledge together.
We have many ideas but didn’t finish all, so we still add some new interaction in the game. But after the submission, I know this is not a good working prosses. We should skip what we didn’t finish and do more playtest and try to fix all the problems. I don’t think about it when I focus on working.
I don't think that this is only my semester project. I have passion for continue to work it. 
Through this game, I learnt a lot. What I learn is divided into 2 things:
1. Technical skills
    writing C# code in unity, 
    unity software to do the interactive animation, about the Rigidbody, Collider, Trigger, Nav Mesh, Raycast, 
    git in bitbucket, 
    how to turn the story into a game, story structure, 
    how to document my work in Miro board, by writing journal,
2. Soft skills
    how to coordinate in group, 
    think together,
    brainstorming,
    time planning
    Those skills not only from Narrative class. I have chance to implement what I learn from other subject. 

  
  
## Research
  * general / historical information:
    * https://en.wikipedia.org/wiki/Rapunzel
      