# Ancient-History
Beware!! These projects were all created when I was very new to and very bad at programming. Enter at your own risk!

This is just a repo so that I do not have to juggle multiple thumb drives full of old projects around anymore. This way they wont go anywhere and I can rest easier. 

Without a doubt though, all projects in this repo took an incredible amount of my time. Sure they are all hot garbage but the time alone makes them worth keeping.

<h3>Journey</h3>
This was the oldest of my projects posted here. The code is unspeakable horrible. <br>
That being said, I did put a lot of time into it back in the day. It is a text-based adventure where you, an average dude, have to rescue your old pet Kerfluffles from an evil necromancer named Zargon of all things. You chase him through 4 levels of dungeon before fighting him, and every boss you have fought thus far, in a climactic fight on level 5. The game is playable but has its quirks.

 - Commands are entered with the space key, not the enter key. I didn't figure out how to do the enter key when I made it.
 - Do not use the longswords. For whatever reason they do negative damage, effectively healing your foes. 
 - All monster and item names cannot have spaces in them. They are not case sensitive though (usually). Go with all lower case to be safe
 - There is no useful help menu, so here is a list of commands to try out. [] denote prose descriptions, "," separate alternate forms
	 - save [slot number]
	 - load [slot number]
	 - throw [item name] [n/e/s/w], throw [item name] at [monster name]
	 - use heathpotion
	 - stats
	 - drop [item name]
	 - equip [item name]
	 - quit game
	 - i issue a challenge!
		 - easter egg
	 - cast spell 
		 - consumes spellbook and casts random spell. None of them will hurt you, but there is a 1/5 chance of it doing nothing at all
	 - give cords
		 - displays your current coordinates
	 - help
		 - will give you a couple commands. I was too lazy back in the day to do them all and I wont now. Not touching that code with a 4 foot pole
	 - items
		 - will display your inventory
	 - search for treasure, s 4 t
	 - attack [monster name] with [item name], a [monstername] w [itemname]
	 - sprint [n/e/s/w]
	 - move [n/e/s/w], g [n/e/s/w]
	 - description please, d p
	 - open [northern/eastern/southern/western] door
		 - yes you cannot abbreviate this one with n,s,e,w. I am not sure why.

If you mean to play it, best of luck to you. 

P.S.
The second floor boss is named Dylan after a friend of mine who helped me with some chunks of this. If you are out there man, cheers.
	 

<h3>Arachaphobia</h3>
This was made to be the successor to Journey,  made around my sophomore year of high school. Although it was never finished, I keep this one around because I was really trying to do better than I did with its predecessor. You will also notice how I actually used the excel spread sheet the program is attached to. I didn't know about SQL or anything about databases in general when I made this, but came up with a system that is actually very similar to a modern relational database system. It was neat stuff and I was super proud of it at the time. All items in the game were defined in the corresponding excel table and were read in at startup. 

This was a cool one to work on though. Every level was painstakingly laid out on paper, I knew what all the quests were going to be and which areas of the level you could access after which events. Every npc, soldier, all of it was planned out in advance. Maybe thats what did the project in after all was said and done. The image of it was done in my head so I sort of just moved onto other things.

<h3>NNGenetic</h3>
This was the last big project I worked on before taking a class on design patterns and OOP, that being the class that blew my mind. Seriously, pretty much everything before that class I now know to be low tier trash code. Now its just mid-tier at best haha. Anyways, I had heard all these NEAT (get it?) things about genetic algorithms and had watched some YouTube videos, and decided to try and make one for myself. I was actually sort of successful. The neural network I fudged my way through had too many hidden layers for any chance of truly complex behavior emerging, and the structure was just really bad/buggy in general. Despite all that, it worked well enough that some interesting strategies emerged. 

<h4>The Setting</h4>
The world is pretty simple. It starts off with a bunch of creatures (colored squares), each of a different species that spawn in random locations. There are also walls (lines of brown squares) and food (pink squares). Creatures that die drop this food. Every tick, creatures can do only one action. Their options are move, eat, or attack.

<h4>Observed Patters</h4>

 - The Killer Plants
	 - These are creatures that opt never to move. All they do is sit in one place and lash out at anything around them. Sometimes they will sense food which will trigger an eat call, sometimes they just hook up an eat to a periodic input. Either way, you get the idea. Think venus fly trap.
 - The Grazers
	 - A simple species. These usually opt to move in one or two directions, with the occasional eat thrown in for spice. 
 - The Mavericks
	 - You would see all kinds of crazy stuff. Most of them would eventually get out-competed by the previous two "more meta" strategies. But if you tweaked the settings just so, you could get some really cool results out of the simulation.
