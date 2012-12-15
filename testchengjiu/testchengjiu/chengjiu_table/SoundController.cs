using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace testchengjiu.chengjiu_table
{
    public class SoundController
    {
        public void PlaySound(string path)
        {
            if (!string.IsNullOrEmpty(path))
            {
                using (var stream = TitleContainer.OpenStream(path))
                {
                    if (stream != null)
                    {
                        var effect = SoundEffect.FromStream(stream);
                        FrameworkDispatcher.Update();
                        effect.Play();
                    }
                }
            }
        }
    }
}
