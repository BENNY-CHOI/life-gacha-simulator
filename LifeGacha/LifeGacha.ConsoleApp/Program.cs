using System.ClientModel;

using Azure;
using Azure.AI.OpenAI;

using Microsoft.Extensions.Configuration;
using Microsoft.SemanticKernel;

using Microsoft.SemanticKernel.Agents;
using Microsoft.SemanticKernel.ChatCompletion;

using OpenAI;

var config = new ConfigurationBuilder()
                 .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                 .AddUserSecrets<Program>()
                 .Build();

var builder = Kernel.CreateBuilder();
if (string.IsNullOrWhiteSpace(config["Azure:OpenAI:Endpoint"]!) == false)
{
    var client = new AzureOpenAIClient(
        new Uri(config["Azure:OpenAI:Endpoint"]!),
        new AzureKeyCredential(config["Azure:OpenAI:ApiKey"]!));

    builder.AddAzureOpenAIChatCompletion(
                deploymentName: config["Azure:OpenAI:DeploymentName"]!,
                azureOpenAIClient: client);
}
else
{
    var client = new OpenAIClient(
        credential: new ApiKeyCredential(config["GitHub:Models:AccessToken"]!),
        options: new OpenAIClientOptions { Endpoint = new Uri(config["GitHub:Models:Endpoint"]!) });

    builder.AddOpenAIChatCompletion(
                modelId: config["GitHub:Models:ModelId"]!,
                openAIClient: client);
}
var kernel = builder.Build();

var definition = File.ReadAllText(Path.Combine(AppContext.BaseDirectory, "../../..", "Plugins", "LifeGachaAgent", "LifeGacha.yaml"));
var template = KernelFunctionYaml.ToPromptTemplateConfig(definition);

var agent = new ChatCompletionAgent(template, new KernelPromptTemplateFactory())
{
    Kernel = kernel
};

var history = new ChatHistory();
history.AddSystemMessage("당신은 유쾌한 운빨 인생 시뮬레이터입니다. 매번 인생의 랜덤한 하루를 재밌는 이야기 형식으로 들려줍니다. 모든 대답은 한국어로 해주세요.");

var input = default(string);
var message = default(string);
while (true)
{
    Console.WriteLine("오늘 하루 운세를 뽑아볼까요? 아무 단어나 입력해주세요 (종료하려면 엔터):");

    Console.Write("User: ");
    input = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(input))
    {
        break;
    }

    Console.Write("Assistant: ");

    history.AddUserMessage(input);
    var arguments = new KernelArguments()
    {
        { "dayInput", input },
        { "events", 3 }
    };

    var response = agent.InvokeStreamingAsync(history, arguments);

    message = "";
    await foreach (var content in response)
    {
        await Task.Delay(20);
        message += content;
        Console.Write(content);
    }

    history.AddAssistantMessage(message!);
    Console.WriteLine("\n");
}
