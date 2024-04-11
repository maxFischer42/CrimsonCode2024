# Making Connections App (Working Title)
## Crimson Code 2024 Project
### Awkward Axolotls

[Devpost Link](https://devpost.com/software/social-connections)

### Inspiration
College Campuses can be an intimidating place for new students. Especially for students who suffer from social anxiety it can be tough to put yourself out there and meet new friends. It can be scary to just walk up to people and start a conversation without knowing anything about each other, but what if there was a way an app could help break the ice?

### What it does
Social Connections helps show students just how many new friendly faces are around them by showing the profiles of nearby students who are happy to have a chat. Each user creates a profile with their name, hobbies, student organizations they're part of, major, and minor. When a student opens the app, the profiles of a few students nearby are displayed. Students can look around and wave hi to the other users if they recognize them, or request to start an Instant Messaging conversation within the app. Being able to see common interests explicitly listed on a user's profile helps take a lot of the anxiety and guesswork out of a conversation since users can skip the small talk and go straight to questions about each others' interests and backgrounds. Even if users don't feel comfortable having a conversation at all, just being able to associate names and biographies to some of the anonymous faces they pass by every day can help assuage anxiety and start to turn a scary new campus into a dynamic new community. 

### How we built it
We started by using Figma to flesh out the app design and user story, as well as decide on the required features. The bulk of the app is written in Unity for the Android platform as Android is the most conducive to development on a condensed timeframe. User profile data and similar information is stored on each device in a SQLite database and the SQlite plugin for Unity is used to access and retrieve data. The Mapbox map API is used to generate the dynamic map which shows the location of other students. 

### Challenges we ran into
Unity development is always tougher than expected, and quite a bit of time was spent troubleshooting dependencies, deprecated plugins, the Android location API,  and just general dead ends. There were also some hiccups getting SQLite to talk with the Unity Framework which took a little massaging and modifying some of the db schema. 

### Accomplishments that we're proud of
Having a functional mobile app! Most of our previous hackathon projects and development experience have been regular browser apps so it was really cool to try something new and build directly for mobile. The UI looks pretty close to our Figma mock ups and getting the dynamically adjustable map to work was a huge win. 

### What we learned
We learned what works and what doesn't work with Unity development, and learned a ton about SQL to boot. SQL functions don't always work how we had initially expected them to work under the hood and it took a bit of sifting to find the Unity Plugins we needed. 

### What's next for Social Connections
In the Future, we would like to explore using NFC and/or Bluetooth Near Field to generate a pop up notification whenever another user is near. The messaging feature will also need to be implemented, we identified several plugins with Unity that may be an option, but we would need more time to fiddle with. In order to grow the app into a scalable, deployable service there would also need to be a central SQL server and a method of cloning the data onto each device's local SQLite database. 
