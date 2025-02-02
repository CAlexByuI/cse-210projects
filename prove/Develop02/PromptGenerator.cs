using System;
public class PromptGenerator
{
    private List<string> prompts = new List<string>
    {
        "What are you grateful for today?",
        "What was the highlight of your day?",
        "What is something you learned today?",
        "Describe a challenge you faced today and how you overcame it.",
        "What made you smile today?",
        "What's a regret that you can take steps to resolve today?",
        "What are you looking forward to in the future?",
        "What's a goal you have for tomorrow?",
    };

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(prompts.Count);
        return prompts[index];
    }
}