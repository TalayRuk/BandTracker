# _BAND TRACKER_

#### _Create a program to track bands and the venues where they've played concerts._

#### By _** Vichitra Pool / September 29th, 2016**_

## Description

_* Allow a user to create Bands that have played at a Venue.
* Allow a venue can host many bands, and a band can play at many venues.
* Create a join table to store the bands_venues relationships.
* Allow a user to view a single concert venue, list out all of the bands that have played at that venue.
* Allow user to add a band to that venue.
* Create a method to get the bands who have played at a venue, and use a join statement in it.
* When a user is viewing a single Band, list out all of the Venues that have hosted that band.
* Allow the user to add a Venue to that Band by using a join statement._


## Specs

| Behavior     | Input Example  |Output Example  |
| ------------- |:-------------:| -----:|
|GetAll() return all rows present in database |2 band's instances | list containing 2 bands
|GetAll().Count return Number of rows in database | no input | database empty
|Override bool Equal function return 2 same inputs with different Id | 2 same bands'name instances |  2 bands' instances that have same name
|Save() return input save to the list | a new band instance | list containing the new band
|Save() and GetId() return instance's Id that saved to the list | new client instance.Save() | return the same Id as the previously saved instance
|Find() return specific row from database | RadioHead | found RadioHead
|Many-to-many relationship set up = add join table
|AddBand() to the Venue and GetBands() to return all bands for the venue | add new band to a venue | return new added band and all bands for that venue.
|AddVenue() to the band and GetVenues() to return all venues for the band | add new venue to a band | return new added venue and all venues for that band.
|Update() to edit the name of the venue and return new name | new venue's name to replace existing one | return new edited venue's name.
|Delete() to clear all venues from the database | 3 venue's instances | succesfully deleted all venues.
|HomeModule add edit/Patch /delete route
|*CRUD functionality for each class been built in Nancy
|*RESTful routes used in Nancy


## Setup/Installation
#### Files can be cloned from https://github.com/TalayRuk/BandTracker.git and run in a browser (requires a server environment).

#### Using Mono in the root directory, type the following at the command prompt:

##### To install dependencies:

\>dnu restore

#### To use the database, in SQLCMD:

\>CREATE DATABASE band_tracker;

\>GO

\>USE band_tracker;

\>GO

\>CREATE TABLE bands (id INT IDENTITY (1,1), name VARCHAR(255), );

\>CREATE TABLE venues (id INT IDENTITY (1,1), name VARCHAR(255), location VARCHAR(255));

\>GO

\> CREATE TABLE bands_venues (id INT IDENTITY (1,1), band_id INT, venue_id INT);

#### To run the local server:

\>dnx kestrel

#### Copy: http://localhost:5004 in your browser.

## Support and contact details

Please contact the authors if you have any questions or comments.

## Technologies Used

C#, Nancy, Razor, Xunit, Database and cshtml.

### License

Copyright (c) 2016 **_Vichitra Pool_**

This software is licensed under the MIT license.
