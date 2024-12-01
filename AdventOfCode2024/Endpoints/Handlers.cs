using AdventOfCode.Solutions;

namespace AdventOfCode2024.Endpoints;

public static class Handlers
{
    public static async Task YearsPageHandler(HttpContext context)
    {
        var html = @"<html>
            <head>
                <link rel='stylesheet' type='text/css' href='/styles.css'>
            </head>
            <body>
                <h1>Advent of Code</h1>";

        for (int year = 2015; year <= 2024; year++)
        {
            html += $"<a href='/year?year={year}'><button>{year}</button></a><br>";
        }

        html += "</body></html>";

        await context.Response.WriteAsync(html);
    }

    public static async Task DaysPageHandler(HttpContext context)
    {
        var query = context.Request.Query;
        var year = query["year"];

        if (string.IsNullOrEmpty(year))
        {
            context.Response.StatusCode = 400;
            await context.Response.WriteAsync("Invalid year.");
            return;
        }

        var html = $$"""
            <html>
                <head>
                    <link rel='stylesheet' type='text/css' href='/styles.css'>
                </head>
                <body>
                    <h1>Advent of Code {{year}}</h1>
            """;

        for (int day = 1; day <= 25; day++)
        {
            html += $"<a href='/day?year={year}&day={day}'>Day {day}</a><br>";
        }

        html += "<br><a href='/'>Back</a></body></html>";

        await context.Response.WriteAsync(html);
    }

    public static async Task InputPageHandler(HttpContext context)
    {
        var query = context.Request.Query;
        var year = query["year"];
        var day = query["day"];

        if (string.IsNullOrEmpty(year) || string.IsNullOrEmpty(day))
        {
            context.Response.StatusCode = 400;
            await context.Response.WriteAsync("Invalid year or day.");
            return;
        }

        var html = $$"""
            <html>
                <head>
                    <link rel='stylesheet' type='text/css' href='/styles.css'>
                </head>
                <body>
                    <h1>Advent of Code {{year}} - Day {{day}}</h1>
                    <form method='post' action='/execute'>
                        <input type='hidden' name='year' value='{{year}}'>
                        <input type='hidden' name='day' value='{{day}}'>
                        <label for='inputField'>Input:</label>
                        <textarea id='inputField' name='inputField' rows='10' cols='30'></textarea><br>
                        <button type='submit'>Execute</button>
                    </form>
                    <br><a href='/year?year={{year}}'>Back</a>
                </body>
            </html>
            """;

        await context.Response.WriteAsync(html);
    }

    public static async Task ResultPageHandler(HttpContext context)
    {
        var form = await context.Request.ReadFormAsync();
        var year = int.Parse(form["year"]!);
        var day = int.Parse(form["day"]!);
        var input = form["inputField"];

        try
        {
            var (partOne, partTwo) = (year, day) switch
            {
                (2015, 1) => Solution2015.Day1(input),
                (2015, 2) => Solution2015.Day2(input),
                (2015, 3) => Solution2015.Day3(input),
                (2024, 1) => Solution2024.Day1(input),
                (2024, 2) => Solution2024.Day2(input),
                _ => (0, 0)
            };

            var html = $$"""
            <html>
                <head>
                    <link rel='stylesheet' type='text/css' href='/styles.css'>
                </head>
                <body>
                    <h1>Results</h1>
                    <p>Part 1: {{partOne}}</p>
                    <p>Part 2: {{partTwo}}</p>
                    <br>
                    <a href='/year?year={{year}}'>Back</a>
                    <br>
                    <a href='/'>Home</a>
                </body>
            </html>
            """;

            await context.Response.WriteAsync(html);
        }
        catch (Exception ex)
        {
            context.Response.StatusCode = 500;
            await context.Response.WriteAsync($"Error: {ex.Message}");
            return;
        }
    }
}
