using Avalonia.Controls;
using AvaloniaApplication2.Views;
using Avalonia.VisualTree;
using TestProject1;
using static System.Net.Mime.MediaTypeNames;
namespace TestProject1
{
    public class UnitTest1
    {
        private static Dictionary<string, Button> initializeMainWindowButtons(MainWindow mainWindow)
        {

            var buttonI = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "I");
            var buttonV = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "V");
            var buttonX = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "X");
            var buttonL = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "L");
            var buttonC = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "C");
            var buttonD = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "D");
            var buttonM = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "M");
            var buttonPlus = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "Plus");
            var buttonMinus = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "Minus");
            var buttonMultiply = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "Multiply");
            var buttonDivide = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "Divide");
            var buttonEqual = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "Equal");
            var buttonCE = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "Ce");

            Dictionary<string, Button> buttons = new Dictionary<string, Button>
            {
                { "I", buttonI },
                { "V", buttonV },
                { "X", buttonX },
                { "L", buttonL },
                { "C", buttonC },
                { "D", buttonD },
                { "M", buttonM },
                { "CE", buttonCE },
                { "+", buttonPlus },
                { "-", buttonMinus },
                { "*", buttonMultiply },
                { "/", buttonDivide },
                { "=", buttonEqual },
            };
            return buttons;
        }

        private static string getErrorMessage(string expectedValue, string resultValue) => String.Format("Expected '{0}', however got '{1}'", expectedValue, resultValue);

        [Fact]
        public async void TestDivideError()
        {
            var app = AvaloniaApp.GetApp();
            var mainWindow = AvaloniaApp.GetMainWindow();

            await Task.Delay(100);

            var result = mainWindow.GetVisualDescendants().OfType<TextBlock>().First(t => t.Name == "CalculationTextBlock");
            var buttonI = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "I");
            var buttonPlus = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "Plus");
            var buttonV = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "V");
            var buttonResult = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "Equal");
            var buttonCE = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "Ce");

            buttonI.Command.Execute(buttonI.CommandParameter);
            buttonPlus.Command.Execute(buttonPlus.CommandParameter);
            buttonV.Command.Execute(buttonV.CommandParameter);
            buttonResult.Command.Execute(buttonResult.CommandParameter);

            await Task.Delay(50);
            string text = result.Text;
            buttonCE.Command.Execute(buttonCE.CommandParameter);
            Assert.True(text == "VI", "result != VI");
        }


        [Fact]
        public async void TestAdd()
        {
            var app = AvaloniaApp.GetApp();
            var mainWindow = AvaloniaApp.GetMainWindow();

            await Task.Delay(100);
            Dictionary<string, Button> buttons = initializeMainWindowButtons(mainWindow);

            buttons["I"].Command.Execute(buttons["I"].CommandParameter);
            buttons["+"].Command.Execute(buttons["+"].CommandParameter);
            buttons["V"].Command.Execute(buttons["V"].CommandParameter);
            buttons["="].Command.Execute(buttons["="].CommandParameter);

            await Task.Delay(50);
            buttons["CE"].Command.Execute(buttons["CE"].CommandParameter);

            buttons["M"].Command.Execute(buttons["M"].CommandParameter);
            buttons["+"].Command.Execute(buttons["+"].CommandParameter);
            buttons["M"].Command.Execute(buttons["M"].CommandParameter);
            buttons["="].Command.Execute(buttons["="].CommandParameter);

            await Task.Delay(50);
            buttons["CE"].Command.Execute(buttons["CE"].CommandParameter);
        }   
    }
}