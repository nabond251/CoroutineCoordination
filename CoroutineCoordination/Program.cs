﻿using CoroutineCommandLine;
using CoroutineCoordination;

CommandLineInterpreter.Interpret(
    new HelloCommandLine(
        Console.ReadLine));
