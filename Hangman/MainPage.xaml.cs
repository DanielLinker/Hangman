using System.ComponentModel;
using System.Diagnostics;

namespace Hangman;

public partial class MainPage : ContentPage, INotifyPropertyChanged
{
    public MainPage()
    {
        InitializeComponent();
        BindingContext = this;
        PickWord();
        CalculateWord(answer, guessed);
    }

    #region UI Properties

    public string Spotlight
    {
        get => spotlight;
        set
        {
            spotlight = value;
            OnPropertyChanged();
        }
    }

    #endregion

    #region Game Engine

    private void PickWord()
    {
        answer =
            words[new Random().Next(0, words.Count)];
        Debug.WriteLine(answer);
    }

    //Boom 
    private void CalculateWord(string answer, List<char> guessed)
    {
        var temp = answer.Select(x => guessed.IndexOf(x) >= 0 ? x : '_').ToArray();
        Spotlight = string.Join(' ', temp);
    }

    #endregion


    #region Fields

    private readonly List<string> words = new()
    {
        "python",
        "javascript",
        "maui",
        "csharp",
        "mongodb",
        "sql",
        "xaml",
        "word",
        "exel",
        "powerpoint",
        "code",
        "hotreload",
        "snippets"
    };

    private string answer = "";
    private string spotlight;
    private readonly List<char> guessed = new();

    #endregion
}