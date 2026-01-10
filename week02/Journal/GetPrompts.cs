public class GetPrompts
{
    // List of my journal prompts - it would be nice to have some kind of API to get more prompts
    public List<string> _prompts = new List<string>()
    {
        "What was the best part of my day?",
        "What are you most grateful for today?",
        "What was the most challenging part of my day?",
        "What is one thing I learned today?",
        "How did I make someone else's day better?",
        "If I had to change one thing about today, what would it be?",
        "What made me smile today?",
        "What will I do differently tomorrow?",
        "Before I go to bed, I want to..."
    };

    // Method to get a random prompt from my list
    public string GetRandomPrompt()
    {
        // Generate a random index to select a random prompt from my _prompts list
        int randomIndex = new Random().Next(_prompts.Count);
        // Return the random prompt with the randomly generated index
        return _prompts[randomIndex];
    }
}