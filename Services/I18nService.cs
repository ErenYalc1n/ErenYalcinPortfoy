using Microsoft.JSInterop;

namespace ErenYalcinPortfoy.Services
{
    public class I18nService
    {
        private readonly IJSRuntime _js;
        private string _lang = "tr";

        public event Action? OnLanguageChanged;

        public string Lang => _lang;

        public I18nService(IJSRuntime js)
        {
            _js = js;
        }

        public async Task InitAsync()
        {
            _lang = await _js.InvokeAsync<string>("getLang");
        }

        public async Task SetLanguageAsync(string lang)
        {
            _lang = lang;
            await _js.InvokeVoidAsync("setLang", lang);
            OnLanguageChanged?.Invoke();
        }
    }
}
