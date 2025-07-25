using Microsoft.JSInterop;

namespace ErenYalcinPortfoy.Services
{
    public class I18nService
    {
        private readonly IJSRuntime _js;
        public string Lang { get; private set; } = "tr";

        public event Func<Task>? OnLanguageChanged;

        public I18nService(IJSRuntime js)
        {
            _js = js;
        }

        public async Task InitAsync()
        {
            var lang = await _js.InvokeAsync<string>("getLang");

            if (!string.IsNullOrWhiteSpace(lang))
                Lang = lang;
        }

        public async Task SetLanguageAsync(string lang)
        {
            Lang = lang;
            await _js.InvokeVoidAsync("setLang", lang);

            if (OnLanguageChanged is not null)
                await OnLanguageChanged.Invoke();
        }

        public void SetLanguage(string lang)
        {
            Lang = lang;
            OnLanguageChanged?.Invoke();
        }

    }
}
