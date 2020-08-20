# SafeAutoKata
In this project an input file is uploaded by the user in my Razor front end. I verfy the file type and then read the file line by line.
I then break down each line into one of two options of being a driver or a trip. If it is a Driver I add a new driver to the List of drivers. If it is a 
trip, I find the driver from the list of drivers and updated the information from the line of data.
I used this collection of lines and methods in the Driver and TripWork classes to determine the driver's name, and the trip's distance and miles per hour.
When a driver has taken more than one trip, I added the distance traveled together to make total distance traveled, as well as make a new average speed based on the new and old miles per hour.
I then arrange the List in order from longest distance traveled to shortest.
Finally I send the data to the view and display the information in a table that will show the driver's name, the total distance, and the average speed of all their trips.
I realize that some of these methods could have more strict access modifiers However, I wanted to show my ability to organize and follow MVC practices. This might have resulted in a more verbose style of coding than would typically represent my work, but I hope the thought behind this choice is evident and appropriate for an interview level problem.
If I had more time I would have loved to use Angular for the front end and sent the information through an API to the backend and save it to a database. I think it would be fun to get that
set up and have a table for each driver and see every trip that he has made in a list and break it down into visual data. 
