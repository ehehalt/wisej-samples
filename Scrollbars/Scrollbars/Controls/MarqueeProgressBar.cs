using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using Wisej.Web;

namespace ProgressBars.Controls
{
    public class MarqueeProgressBar : HtmlPanel
    {
        private readonly string cssId = "marquee_" + Guid.NewGuid().ToString("N");

        private bool running = true;
        private bool autoStart = true;

        private int speed = 1200;
        private int barWidthPercent = 30;

        private Color barColor = Color.FromArgb(0, 103, 193);
        private Color trackColor = Color.FromArgb(230, 230, 230);

        public MarqueeProgressBar()
        {
            this.Size = new Size(200, 4);

            this.ScrollBars = ScrollBars.None;
            this.BorderStyle = BorderStyle.None;

            CreateHtml();
            UpdateCss();
        }

        // ------------------------------------------------------------
        // AutoStart
        // ------------------------------------------------------------

        [Category("Behavior")]
        [Description("Gibt an, ob die Animation beim Erzeugen des Controls automatisch gestartet wird.")]
        [DefaultValue(true)]
        public bool AutoStart
        {
            get => autoStart;
            set => autoStart = value;
        }

        // ------------------------------------------------------------
        // Running
        // ------------------------------------------------------------

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool Running => running;

        // ------------------------------------------------------------
        // Speed
        // ------------------------------------------------------------

        [Category("Behavior")]
        [Description("Dauer eines kompletten Durchlaufs in Millisekunden.")]
        [DefaultValue(1200)]
        public int Speed
        {
            get => speed;

            set
            {
                value = Math.Max(100, value);

                if (speed == value)
                    return;

                speed = value;

                UpdateCss();
            }
        }

        // ------------------------------------------------------------
        // BarWidthPercent
        // ------------------------------------------------------------

        [Category("Appearance")]
        [Description("Breite des animierten Balkens in Prozent.")]
        [DefaultValue(30)]
        public int BarWidthPercent
        {
            get => barWidthPercent;

            set
            {
                value = Math.Max(5, Math.Min(95, value));

                if (barWidthPercent == value)
                    return;

                barWidthPercent = value;

                UpdateCss();
            }
        }

        // ------------------------------------------------------------
        // BarColor
        // ------------------------------------------------------------

        [Category("Appearance")]
        [Description("Farbe des animierten Balkens.")]
        [DefaultValue(typeof(Color), "0, 103, 192")]
        public Color BarColor
        {
            get => barColor;

            set
            {
                if (barColor == value)
                    return;

                barColor = value;

                UpdateCss();
            }
        }

        // ------------------------------------------------------------
        // TrackColor
        // ------------------------------------------------------------

        [Category("Appearance")]
        [Description("Hintergrundfarbe der ProgressBar.")]
        [DefaultValue(typeof(Color), "230, 230, 230")]
        public Color TrackColor
        {
            get => trackColor;

            set
            {
                if (trackColor == value)
                    return;

                trackColor = value;

                UpdateCss();
            }
        }

        // ------------------------------------------------------------
        // Start / Stop
        // ------------------------------------------------------------

        public void Start()
        {
            if (running)
                return;

            running = true;

            UpdateCss();
        }


        public void Stop()
        {
            if (!running)
                return;

            running = false;

            UpdateCss();
        }

        // ------------------------------------------------------------
        // Wisej lifecycle
        // ------------------------------------------------------------

        protected override void OnCreateControl()
        {
            base.OnCreateControl();

            running = autoStart;

            UpdateCss();
        }


        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            UpdateCss();
        }

        // ------------------------------------------------------------
        // HTML
        // ------------------------------------------------------------

        private void CreateHtml()
        {
            this.Html =
                $$"""
                <div class="{{cssId}}-track">
                    <div class="{{cssId}}-bar"></div>
                </div>
                """;
        }

        // ------------------------------------------------------------
        // CSS
        // ------------------------------------------------------------

        private void UpdateCss()
        {
            int height = Math.Max(1, this.ClientSize.Height);

            double endPosition =
                10000.0 / barWidthPercent;

            string endPositionCss =
                endPosition.ToString("0.###", CultureInfo.InvariantCulture);

            string animation =
                running
                    ? $"{cssId}-animation {speed}ms cubic-bezier(0.4, 0.0, 0.2, 1) infinite"
                    : "none";

            string stoppedPosition =
                running
                    ? ""
                    : "transform: translateX(-100%);";

            this.Css =
                $$"""
                .{{cssId}}-track {
                    position: relative;

                    width: 100%;
                    height: {{height}}px;

                    overflow: hidden;

                    background-color: {{ColorToCss(trackColor)}};

                    border-radius: {{(height / 2.0).ToString(CultureInfo.InvariantCulture)}}px;
                }


                .{{cssId}}-bar {
                    position: absolute;

                    top: 0;
                    left: 0;

                    width: {{barWidthPercent}}%;
                    height: 100%;

                    background-color: {{ColorToCss(barColor)}};

                    border-radius: {{(height / 2.0).ToString(CultureInfo.InvariantCulture)}}px;

                    animation: {{animation}};

                    will-change: transform;

                    {{stoppedPosition}}
                }


                @keyframes {{cssId}}-animation {

                    0% {
                        transform: translateX(-100%);
                    }

                    100% {
                        transform: translateX({{endPositionCss}}%);
                    }
                }
                """;
        }

        // ------------------------------------------------------------
        // Color -> CSS
        // ------------------------------------------------------------

        private static string ColorToCss(Color color)
        {
            if (color.A == 255)
            {
                return $"#{color.R:X2}{color.G:X2}{color.B:X2}";
            }

            double alpha = color.A / 255.0;

            return string.Format(
                CultureInfo.InvariantCulture,
                "rgba({0},{1},{2},{3:0.###})",
                color.R,
                color.G,
                color.B,
                alpha);
        }
    }
}
