namespace Coroutine;

using System.Threading.Channels;

public abstract class CommandLineCoroutine :
    BaseCoroutine<CommandLineSink, Unit, CommandLineSource>
{
    protected CommandLineCoroutine(ChannelReader<CommandLineSource> nextReader) :
        base(nextReader)
    {
    }
}
