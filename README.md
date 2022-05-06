# Twitch Hackathon 2022

Welcome to the hackathon!
These folders will contain example code that could be useful for you to create the different applications in your setup.
Below you'll also find the teams and the schedules for the day.

## Teams

### Team 1
- *Team lead*: Pål Bendiksen
- Rohini Kawale
- Lars Gøran Forwall hansen
- Bidyendu Dey

### Team 2
- *Team lead*: Arturo Viveros
- Vitaly Moshkov
- Vijay Jadhav
- Brahmareddy Yaram
- Soroush Ghodrat

### Team 3
- *Team lead*: Dalibor Blazevic
- Madeeha Khan
- Siva Kumar Meejuru
- Sarah E Rayfuse

### Team 4
- *Team lead*: Prakhar Srivastav
- Agnija Bako
- Silje Møller
- Sureshram Chandramohan

### Team 5
- *Team lead*: Barnabas Davoti
- Fredrik Lygre Bergesen
- Ole Jørgen Hongset
- Jan Greger Hemb

## Tasks 

![Architecture model](/TwitchHackathon2022.png "Architecture model")

## GOAL
Create a infrastructure and applications to support a 10-15 minute stream on Twitch!

## Requirements
- You must integrate at least one front-facing service to OBS (streaming software) through a central hub/bus (e.g. Azure Service Bus - will be provided)
- Infrastructure and code must run on Microsoft Azure

### Recommended step 1
- Get OBS installed and up and running - [Download](https://obsproject.com)
- Install OBS Websockets [Download](https://obsproject.com/forum/resources/obs-websocket-remote-control-obs-studio-from-websockets.466/)
- Use an adapter of your language choice to connect to OBS [Download](https://github.com/obsproject/obs-websocket/blob/4.x-current/README.md)
    - Connect this adapter to ServiceBus, or the central hub of your choice so that this is the trigger/input and output for the adapter.
- Create an application of your choice that posts something into the ServiceBus, which is received and makes an action in OBS

*Note*: The communication over ServiceBus should always follow the standard set in the [Example file](/CommunicationModel_Example.json)
<br>
If you need to transfer more data than supported by ServiceBus (256 KB), you should store the data in a Data Store and just use ServiceBus to alert services about the location of the data.

### Recommended step 2
- Integrate The application of your choice to a third party API to enrich the data in some way
    - Use the list at the end of this page as an inspiration

### Recommended step 3
- Set up full CI/CD pipeline for your applications
    - Use standard github workflows, Cake or whatever framework you choose to deploy the services to Azure

### Bonus
- Set up more than one external application to integrate with your stream.
    - E.g. if you have a web page as front end, try to implement twitch chat integration as well. 

### Bonus 2 - Extra points
- ...will be revealed later...

## Schedule
### Day 1
08:00 - Transport from Lysaker<br>
09:00 - ish... Checkin!<br>
10:00 - Initial brainstorming - divide into teams and get information about the tasks<br>
12:00 - Lunch<br>
13:00 - Coding time!<br>
18:00 - Take a break, get ready for dinner<br>
19:00 - Dinner!<br>
Late - Social, beers and just getting to know eachother! (Note: We'll get up early day 2!)<br>

### Day 2
08:00 - Breakfast<br>
09:00 - Let's code some more!<br>
12:00 - Lunch<br>
13:00 - Final coordination and panic coding<br>
15:00 - Broadcast! Let's put on a show!<br>
17:00 - Time to go home :)<br>

## Resources 

| Resource                  | Comment                                                                                    | Url                                                                                                                                                                                                                                                                                                                                                                                                     |
| ------------------------- | ------------------------------------------------------------------------------------------ | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Discord API               | Discord.net NuGet package - Task-based Asyncroneous Pattern                                | [Documentation](https://discordnet.dev/guides/introduction/intro.html)                                                                                                                                                                                                                                                                                                                                  |
| Twitch chat API           | IRC server (Good old)                                                                      | [Documentation](https://dev.twitch.tv/docs/irc/tags)                                                                                                                                                                                                                                                                                                                                                    |
| Twitch event API          | Pub/sub async api                                                                          | [Documentation](https://dev.twitch.tv/docs/eventsub)                                                                                                                                                                                                                                                                                                                                                    |
| Azure Cognitive Services  | Everything from Natural Language Processing to Computer Vision, object recognition, etc... | [Overview](https://azure.microsoft.com/en-us/services/cognitive-services/?&ef_id=CjwKCAiA9tyQBhAIEiwA6tdCrIP6a8YFN6_GuIoy3Gi6fDSvccMcv2KAusT5aWdJizSVtyJPlUnRvBoCHgMQAvD_BwE:G:s&OCID=AID2200230_SEM_CjwKCAiA9tyQBhAIEiwA6tdCrIP6a8YFN6_GuIoy3Gi6fDSvccMcv2KAusT5aWdJizSVtyJPlUnRvBoCHgMQAvD_BwE:G:s&gclid=CjwKCAiA9tyQBhAIEiwA6tdCrIP6a8YFN6_GuIoy3Gi6fDSvccMcv2KAusT5aWdJizSVtyJPlUnRvBoCHgMQAvD_BwE) |
| Felles Datakatalog        | A collection of public APIs from Norwegian government and other services                   | [Overview](https://data.norge.no)                                                                                                                                                                                                                                                                                                                                                                       |
| RapidAPI                  | A collection of public/professional APIs (Mostly free for few requests)                    | [Overview](https://rapidapi.com/hub)                                                                                                                                                                                                                                                                                                                                                                    |
| OBS Websockets            | A plugin to control OBS (Streaming software) via Websockets                                | [Documentation](https://github.com/obsproject/obs-websocket/blob/4.x-current/README.md)                                                                                                                                                                                                                                                                                                                 |
| OBS Studio                | Streaming software                                                                         | [Download](https://obsproject.com)                                                                                                                                                                                                                                                                                                                                                                      |
| Public APIs               | A list of publicly available APIs                                                          | [Overview](https://github.com/public-apis/public-apis)                                                                                                                                                                                                                                                                                                                                                  |
| Public-apis.xyz           | Another list of public available APIs                                                      | [Overview](https://public-apis.xyz)                                                                                                                                                                                                                                                                                                                                                                     |
| Spotify API               | gives the opportunity to search, play, get currently playing, queue...                     | [Documentation](https://developer.spotify.com/console/)                                                                                                                                                                                                                                                                                                                                                 |
| OBS Plugins and Resources | A catalogue of pre-defined filter, plugins, themes, etc...                                 | [Forum](https://obsproject.com/forum/resources/)                                                                                                                                                                                                                                                                                                                                                        |
| OWN3D                     | Free (and paid) Twitch overlays (stream designs)                                           | [Catalogue](https://www.own3d.tv/en/shop/twitch-stream-overlays-templates/)                                                                                                                                                                                                                                                                                                                                                                                                        |
