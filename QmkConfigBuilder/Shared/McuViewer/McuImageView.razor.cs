using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using QmkConfigBuilder.Extensions;
using QmkConfigBuilder.Models.KeyboardDefinitions.Matrix;
using QmkConfigBuilder.Models.MCU;
using QmkConfigBuilder.Models.MCU.Definitions.Pinout;

namespace QmkConfigBuilder.Shared.McuViewer
{
    public partial class McuImageView : ComponentBase
    {
        [Inject]
        private IJSRuntime JS { get; set; } = default!;

        [Parameter]
        public IControllerUnit MCU { get; set; }= default!;

        [Parameter]
        public bool AlternatePinVisiblity { get; set; } = false;

        [Parameter]
        public IPin? SelectedPin { get; set; }
        [Parameter]
        public EventCallback<IPin> SelectedPinChanged { get; set; }

        [Parameter]
        public IEnumerable<MatrixDefinitions> MatrixDefinitionsList { get; set; } = Enumerable.Empty<MatrixDefinitions>();

        private double _verticalItemHeight = 0;
        private double _topPinOffsetY = 0;
        private double _bottomPinOffsetY = 0;

        private readonly IReadOnlyCollection<string> _baseCssClass = new[] { "d-flex", "justify-content-center" };

        private JSUtility? _utility;

        private readonly IReadOnlyDictionary<string, ImageContext> _mcuImageContexts = new Dictionary<string, ImageContext>
        {
            { nameof(ProMicro), new ImageContext("img/ProMicro.svg", 140, 270) },
            { nameof(RaspberryPiPico), new ImageContext("img/RaspberryPiPico.svg", 180, 410) },
            { nameof(ATmega32U4), new ImageContext("img/ATmege32U4.svg", 290, 290) },
            { nameof(RP2040), new ImageContext("img/RP2040.svg", 310, 310) },
        };

        private ImageContext GetImageContext()
        {
            if (this.MCU is not null && this._mcuImageContexts.TryGetValue(this.MCU.Name, out var context))
            {
                return context;
            }

            return new ImageContext();
        }

        private string GetCssClass()
        {
            if (this.MCU is not null
                && this.MCU.GetTopPins().Any()
                && this.MCU.GetBottomPins().Any())
            {
                return this._baseCssClass.Append("align-items-center").JoinSpace();
            }

            return this._baseCssClass.Append("align-items-end").JoinSpace();
        }

        private MatrixDefinitions? GetMatrixDefinitions(IPin pin)
        {
            return this.MatrixDefinitionsList.FirstOrDefault(x => x.ContainsPin(pin));
        }

        private async Task SetSelectedPin(IPin pin)
        {
            if (this.SelectedPin == pin)
            {
                return;
            }

            this.SelectedPin = pin;
            await this.SelectedPinChanged.InvokeAsync(this.SelectedPin);
        }

        private async Task<double> GetVerticalElementWidthAsync()
        {
            if (this._utility is null)
            {
                return 0;
            }

            var top = await this._utility.GetElementWidthAsync("#top-pins");
            var bottom = await this._utility.GetElementWidthAsync("#bottom-pins");

            return Math.Min(top, bottom);
        }

        private async Task<double> GetTopPinOffsetY()
        {
            if (this._utility is null)
            {
                return 0;
            }

            var height = await this.GetVerticalElementWidthAsync(); // swaped width and height by rotated
            var width = await this._utility.GetElementWidthAsync("#top-pins");
            return (height - width) / 2;
        }

        private async Task<double> GetBottomPinOffsetY()
        {
            if (this._utility is null)
            {
                return 0;
            }

            var height = await this.GetVerticalElementWidthAsync(); // swaped width and height by rotated
            var width = await this._utility.GetElementWidthAsync("#bottom-pins");
            return -1 * (height - width) / 2;
        }

        protected override void OnInitialized()
        {
            this._utility = new JSUtility(this.JS);
            base.OnInitialized();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);

            if (firstRender)
            {
                return;
            }

            var verticalElementHeight = await this.GetVerticalElementWidthAsync();
            var topOffset = await this.GetTopPinOffsetY();
            var bottomOffset = await this.GetBottomPinOffsetY();

            if (this._topPinOffsetY != topOffset
                || this._bottomPinOffsetY != bottomOffset
                || this._verticalItemHeight != verticalElementHeight)
            {
                this._topPinOffsetY = topOffset;
                this._bottomPinOffsetY = bottomOffset;
                this._verticalItemHeight = verticalElementHeight;
                this.StateHasChanged();
            }
        }

        private class ImageContext
        {
            public string Path { get; } = string.Empty;
            public int Width { get; } = 0;
            public int Height { get; } = 0;

            public ImageContext() { }
            public ImageContext(string path, int width, int height)
            {
                this.Path = path;
                this.Height = height;
                this.Width = width;
            }
        }
    }
}
