using Retro.Crt;

namespace DotNet11.Demo.ConsoleApp
{
    internal class FunConsoleWriter
    {
        internal static void WriteLine(string text)
        {
            Typewriter.TypeLine(
                        text: text,
                        msPerChar: 1,
                        fg: Color.Rgb(51, 255, 51),
                        cursor: TypewriterCursor.Underline,
                        fade: TypewriterFade.Alpha);
        }
    }
}
