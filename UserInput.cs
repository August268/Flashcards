using Spectre.Console;

namespace Flashcards
{
    public class UserInput
    {
        public void ShowMainMenu()
        {
            Dictionary<string, string> stackState = new Dictionary<string, string> {{"id", ""}, {"name", ""}};
            Dictionary<string, string> cardState = new Dictionary<string, string> {{"id", ""}, {"front", ""}, {"back", ""}, {"stackId", ""}};

            List<string> options = ["Manage Stacks", "Manage FlashCards", "Study", "View study session data", "Exit"];

            bool closeApp = false;

            while (!closeApp)
            {
                AnsiConsole.Clear();

                var rule = new Rule("Code Tracker").Border(BoxBorder.Double);

                AnsiConsole.Write(rule);

                var selectedOption = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("Please choose the options below:")
                        .PageSize(10)
                        .MoreChoicesText("[grey](Move up and down to reveal more options.)[/]")
                        .AddChoices(options));

                AnsiConsole.Clear();

                switch (selectedOption)
                {
                    case "Manage Stacks":
                        
                        break;
                    case "Manage FlashCards":
                        
                        break;
                    case "Study":
                        
                        break;
                    case "View study session data":
                        
                        break;
                    case "Exit":
                        AnsiConsole.Clear();
                        var panel = new Panel("Goodbye...")
                            .Header(new PanelHeader("Notice"))
                            .Border(BoxBorder.Double)
                            .Padding(new Padding(2, 2, 2, 2));
                        AnsiConsole.Write(panel);
                        closeApp = true;
                        break;
                    default:
                        AnsiConsole.Clear();
                        AnsiConsole.WriteLine("Invalid input");
                        AnsiConsole.Record();
                        break;
                }
            }
            ;
        }
    }
}