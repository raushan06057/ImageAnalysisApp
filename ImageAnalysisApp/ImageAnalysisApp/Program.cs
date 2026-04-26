using Microsoft.Extensions.AI;
using OllamaSharp;

Console.WriteLine("Hello, World!");
try
{
    IChatClient chatClient = new OllamaApiClient(new Uri("http://localhost:11434"), "llava");

    string userPrompt="Describe the image";
    List<ChatMessage> messages = new List<ChatMessage>
    {
        new ChatMessage(ChatRole.System, "You are a helpful assistant that describes the image using a direct style."),
        new ChatMessage(ChatRole.User,userPrompt)
    };

    var imageFileName = "org.jpg";
    string image = Path.Combine(Environment.CurrentDirectory,"Images", imageFileName);
    AIContent aic = new DataContent(File.ReadAllBytes(image),"image/jpeg");
    var message = new ChatMessage(ChatRole.User, [aic]);
    messages.Add(message);

    ChatResponse chat = await chatClient.GetResponseAsync(messages);
    Console.WriteLine(chat.Messages[0].Text);
    Console.ReadKey();
}
catch (Exception ex)
{
	Console.WriteLine($"An error occurred: {ex.Message}");
	throw;
}
