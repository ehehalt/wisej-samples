using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using Wisej.Web;

namespace ProgressBars.Controls
{
    public class MarqueeProgressBar : HtmlPanel
    {
        private bool running = true;
        private int speed = 1200;

        public MarqueeProgressBar()
        {
            this.Height = 4;
            this.Width = 200;
            this.ScrollBars = ScrollBars.None;
            this.BorderStyle = BorderStyle.None;

            UpdateContent();
        }

        /// <summary>
        /// Gibt an, ob die Animation läuft.
        /// </summary>
        [DefaultValue(true)]
        public bool Running
        {
            get => running;

            set
            {
                if (running == value)
                    return;

                running = value;
                UpdateContent();
            }
        }

        /// <summary>
        /// Dauer eines kompletten Durchlaufs in Millisekunden.
        /// </summary>
        [DefaultValue(1200)]
        public int Speed
        {
            get => speed;

            set
            {
                if (value < 100)
                    value = 100;

                if (speed == value)
                    return;

                speed = value;
                UpdateContent();
            }
        }

        /// <summary>
        /// Startet die Animation.
        /// </summary>
        public void Start()
        {
            Running = true;
        }

        /// <summary>
        /// Stoppt die Animation.
        /// </summary>
        public void Stop()
        {
            Running = false;
        }

        private void UpdateContent()
        {
            string animationState =
                running ? "running" : "paused";

            this.Html =
                """
                <div class="marqueeProgress">
                    <div class="marqueeProgressIndicator"></div>
                </div>
                """;

            this.Css =
                $$"""
                .marqueeProgress {
                    position: relative;
                    width: 100%;
                    height: 4px;
                    overflow: hidden;
                    background-color: #d0d0d0;
                    border-radius: 2px;
                }

                .marqueeProgressIndicator {
                    position: absolute;
                    top: 0px;
                    left: -30%;
                    width: 30%;
                    height: 4px;

                    background-color: #0067c0;
                    border-radius: 2px;

                    animation: marqueeAnimation {{speed}}ms ease-in-out infinite;
                    animation-play-state: {{animationState}};
                }

                @keyframes marqueeAnimation {
                    0% {
                        left: -30%;
                    }

                    100% {
                        left: 100%;
                    }
                }
                """;
        }
    }
}
