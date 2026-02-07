using System;

class Program
{
    

    static void Main(string[] args)
    {
        // Console.WriteLine("Hello World! This is the EternalQuest Project.");


        // I think I made a mess of what this was supposed to be. I had some grand ideas of how I wanted to change it and it grew out of porportion and I didn't think I would get it done. I wanted to set it up like it was using a database. The only thing I could use was json becasue I didn't think any DB option woudl be able to be graded as it would be a very specific setup. Anyway, this program creates a seperate json file for each type of goal. I also do not like the console format of what was shown in the video so I formated it to look better and for easier readablilty. I realize that this could be done better than it is, but I would have run out of time and not been able to submit it in time. For what it is, it does work, and I believe it is better than what the assignment requires. I hope you think so as well.

        // I do not use GetStringRepresentation because of how I use the JSON files and the List for each type of goal. It just didn't make sense to use it with what I created. I also kept the RecordEvent only in GoalManager due to the nature of the search I have to do, due to having three JSON files. Again, trying to mimic a database, but in the end made it harder for me.

        // I did change up the menus a little - not much, but think it's easier for the user to navigate. I also added a few checks in place to handle what would cause exceptions or other errors. Nothing major.

        var goalManager = new GoalManager();
        goalManager.Start();
    }
}