# cat0logic
An application to keep track of "cats" (musicians).

The front-end consists of an Angular app which was based on the Angular "Tour of Heroes" tutorial.  As of March 2020 it is stand-alone and has no connection to the back end.  (The data is hard-coded and simulates HTTP calls using in-memory data).

The back-end is based on samples from IdentityServer4, using labs from NDC 2020 London.  It consists of 3 Visual Studio solutions written in C# and targeting .Net Core; the 3 solutions are an IdentityServer4 host solution, a WebApi, and a "Movies" app.  These apps (as of March 2020) have no connection to the front-end.  It is all very proof-of-concept at this point.  However as of this check-in (2020-04-06) the back-end works in the sense that if you launch all 3 apps in 3 distinct instances of Visual Studio on a local Windows 10 dev machine, you can log in as various users and also the Google OIDC provider works.

The essential concept I'm trying to prove is that the back-end works with respect to using IdentityServer as an OIDC provider; it correctly protects the WebApi, and the front-end (MVC) app works; i.e. the 3 of those back-end solutions correctly work together.

TODO:

- convert the back-end from a "Movies" app to a similar "Music" app that lets the user see albums instead of films.
- decide whether to ditch Angular and just use MVC as a front-end; or hook the Angular front-end to the WebApi back-end and ditch MVC.
- (if that is the case, we may need to use different samples from IdentityServer4; at the moment I'm leaning toward using MVC).
- add Facebook and other OAuth 2 / OIDC providers.
- deploy it to Azure and use KeyVault to hide the secrets.
- use an actual database and user store (CosmosDb, Azure AD)?

- REQUIREMENTS:

- as an Admin user I want to be able to maintain the database.  So I can.
- as a Customer user I want to be able to maintain my list of "cats" and their albums and songs, express preferences, do reviews etc.
- as any kind of user I want to be able to see the complete works of a particular artist.
- for a given work or artist I want links to the Spotify / Apple Music page, Wikipedia page, lots of lists in a tree structure etc.
- Essentially I want this thing to be a tool for musicians, but there might be different tiers (Premium etc) that let you do more things.
- These are the ideas I have at the moment, at a high level.
- test commit

IDEAS for an app of sufficient complexity to demonstrate our various technical skills:

- imagine features of the app such as the ability to organize a gig for musicians.
- various roles could include:
- the music agent (the middleman between the client and the musicians)
- the client (say, the mother of the bride who's paying for a wedding band)
- the bandleader (the one who hires the individual musicians)
- the players (the individual members of the band)
- each role would have different types of access, e.g.:
- the client can create a request for an event (type = wedding, type of band required, genres of music desired etc)
- the music agent puts the bid out to different bands or bandleaders; there may be employees and contractors
- enable the exchange of various info - maybe the music agent has a roster of bands (see my cousin's website for an example: http://elanartists.com/)
- the agency needs to keep track of many events and the musicians / DJs / caterers / photographers etc




