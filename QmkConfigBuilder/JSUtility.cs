using Microsoft.JSInterop;

namespace QmkConfigBuilder
{
    public class JSUtility : IDisposable
    {
        private readonly IJSRuntime _js;

        public JSUtility(IJSRuntime js)
        {
            this._js = js;
        }

        private async Task<IJSObjectReference> GetJSModuleAsync()
        {
            return await this._js.InvokeAsync<IJSObjectReference>("import", "./js/utility.js");
        }

        public async ValueTask<double> GetElementHeightAsync(string tag)
        {
            var exists = await this.ExistsElementAsync(tag);

            if (!exists)
            {
                return 0;
            }

            var module = await this.GetJSModuleAsync();

            return await module.InvokeAsync<double>("getElementHeight", tag);
        }

        public async ValueTask<double> GetElementWidthAsync(string tag)
        {
            var exists = await this.ExistsElementAsync(tag);

            if (!exists)
            {
                return 0;
            }

            var module = await this.GetJSModuleAsync();

            var width = await module.InvokeAsync<double>("getElementWidth", tag);

            return width;
        }

        public async ValueTask<bool> ExistsElementAsync(string tag)
        {
            var module = await this.GetJSModuleAsync();

            return await module.InvokeAsync<bool>("exists", tag);
        }

        public async ValueTask<dynamic> GetElementById(string id)
        {
            var module = await this.GetJSModuleAsync();

            return await module.InvokeAsync<dynamic>("getElement", id);
        }

        public async ValueTask<IEnumerable<dynamic>> GetElementsById(IEnumerable<string> ids)
        {
            var module = await this.GetJSModuleAsync();

            return await module.InvokeAsync<IEnumerable<object>>("getElementsById", ids);
        }

        public async ValueTask<string> GetCssPropertyValueAsync(string selector, string propertyName)
        {
            var module = await this.GetJSModuleAsync();

            return await module.InvokeAsync<string>("getCssPropertyValue", selector, propertyName);
        }

        public async ValueTask ShowAsync(string selector)
        {
            var module=await this.GetJSModuleAsync();

            await module.InvokeVoidAsync("show", selector);
        }

        public async ValueTask HideAsync(string selector)
        {
            var module = await this.GetJSModuleAsync();

            await module.InvokeVoidAsync("hide", selector);
        }

        public void Dispose()
        {
        }
    }
}
