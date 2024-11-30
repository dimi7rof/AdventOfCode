namespace AdventOfCode2024;

public static class Endpoints
{
    public static void MapEndpoint(this WebApplication app)
    {
        // Main page with 25 buttons
        app.MapGet("/", async context =>
        {
            var html = "<html><body>";

            for (int i = 1; i <= 25; i++)
            {
                html += $"<button> Day {i}</button><br>";
            }

            html += "<br><a href='/input'>Go to Input Page</a>";
            html += "</body></html>";

            await context.Response.WriteAsync(html);
        });

        // Input page with a text field and execute button
        app.MapGet("/input", async context =>
        {
            var html = @"
        <html>
        <body>
            <form method='post' action='/execute'>
                <label for='inputField'>Enter text:</label>
                <input type='text' id='inputField' name='inputField' />
                <button type='submit'>Execute</button>
            </form>
            <br><a href='/'>Go to Main Page</a>
        </body>
        </html>";

            await context.Response.WriteAsync(html);
        });

        // Handle form submission
        app.MapPost("/execute", async context =>
        {
            var form = await context.Request.ReadFormAsync();
            var input = form["inputField"];

            var html = $"<html><body><p>You entered: {input}</p><br><a href='/input'>Go Back</a></body></html>";
            await context.Response.WriteAsync(html);
        });
    }
}
