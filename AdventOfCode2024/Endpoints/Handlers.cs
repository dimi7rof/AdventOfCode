namespace AdventOfCode2024.Endpoints;

public static class Handlers
{
    public static async Task MainPageHandler(HttpContext context)
    {
        var html = @"<html>
            <head>
                <link rel='stylesheet' type='text/css' href='/style.css'>
            </head>
            <body>
                <h1>Advent of Code 2024</h1>";

        for (int i = 1; i <= 25; i++)
        {
            html += $"<a href='/days?day={i}'>Day {i}</a><br>";
        }

        html += "</body></html>";

        await context.Response.WriteAsync(html);
    }

    public static async Task DayHandler(HttpContext context, string day)
        => await context.Response.WriteAsync(
$$"""
 <html>
    <head>
        <link rel='stylesheet' type='text/css' href='/style.css'>
    </head>
    <body>
        <form method='post' action='/input'>
            <input type="hidden" name="day" value="{{day}}">
            <label for='inputField'>Input:</label>
            <textarea id='inputField' name='inputField' rows='10' cols='30'></textarea><br>
            <button type='submit'>Execute</button>
        </form>
        <br><a href='/'>Back</a>
    </body>
 </html>
 """);

    public static async Task InputHandler(HttpContext context)
    {
        var form = await context.Request.ReadFormAsync();
        var input = form["inputField"];
        var day = int.Parse(form["day"]!);

        (int partOne,int partTwo)= day switch
        {
            1 => Executor.Day1(input),
            2 => Executor.Day2(input),
            _ => (0, 0)
        };

        var html =
$$"""
<html>
    <head>
        <link rel='stylesheet' type='text/css' href='/style.css'>
    </head>
    <body>
        <p>Part 1: {{partOne}}</p>
        <p>Part 2: {{partTwo}}</p>
        <br>
        <a href='/'>Home</a>
    </body>
</html>
""";

        await context.Response.WriteAsync(html);
    }
}
