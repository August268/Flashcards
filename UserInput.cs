using Spectre.Console;

namespace Flashcards
{
    public class UserInput
    {
        public void ShowMainMenu()
        {
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
                        .AddChoices("Options"));

                AnsiConsole.Clear();

                switch (selectedOption)
                {
                    case "Add Session":
                        
                        break;
                    case "Delete Session":
                        
                        break;
                    case "Update Session":
                        
                        break;
                    case "Show Sessions":
                        
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