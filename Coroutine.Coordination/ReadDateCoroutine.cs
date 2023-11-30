﻿namespace Coroutine.Coordination;

using System.Globalization;

public class ReadDateCoroutine : Coroutine<DateTime>
{
    public override IEnumerator<IEffect> GetEnumerator()
    {
        yield return new WriteLine(
            "Please enter your desired date:");

        var date = new ReadLine();
        yield return date;
        var l = date.Result;

        if (DateTime.TryParse(l.Single(), CultureInfo.CurrentCulture, out var dt))
        {
            yield return new Result(dt);
        }
        else
        {
            yield return new WriteLine(
                "Not a date.");

            var readDate = new Call<DateTime>(
                new ReadDateCoroutine());
            yield return readDate;

            yield return new Result(readDate.Result.Single());
        }
    }
}
