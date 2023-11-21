using Coroutine;
using Coroutine.Coordination;
using System.Threading.Channels;

var next = Channel.CreateUnbounded<CommandLineSource>();
CommandLineInterpreter.Interpret(new HelloCommandLine(next), next);
