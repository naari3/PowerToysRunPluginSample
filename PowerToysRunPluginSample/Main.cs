using System.Windows;
using ManagedCommon;
using Wox.Plugin;

namespace PowerToysRunPluginSample
{
    public class Main : IPlugin
    {
        private string? IconPath { get; set; }

        private PluginInitContext? Context { get; set; }
        public string Name => "Cool Sample";

        public string Description => "This is cool sample plugin";

        public List<Result> Query(Query query)
        {
            return new List<Result>
            {
                new Result
                {
                    Title = "Copy COOL",
                    SubTitle = "Copy COOL",
                    IcoPath = IconPath,
                    Action = e =>
                    {
                        Clipboard.SetText("COOL");

                        return true;
                    },
                },
                new Result
                {
                    Title = $"Copy {query.Search}",
                    SubTitle = $"Copy {query.Search}",
                    IcoPath = IconPath,
                    Action = e =>
                    {
                        Clipboard.SetText(query.Search);

                        return true;
                    },
                },
            };
        }

        public void Init(PluginInitContext context)
        {
            Context = context;
            Context.API.ThemeChanged += OnThemeChanged;
            UpdateIconPath(Context.API.GetCurrentTheme());
        }

        private void UpdateIconPath(Theme theme)
        {
            IconPath = "images/icon.png";
        }

        private void OnThemeChanged(Theme currentTheme, Theme newTheme)
        {
            UpdateIconPath(newTheme);
        }
    }
}