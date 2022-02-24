API.v1.Echo echo = new API.v1.Echo();
echo.message = "Teste Pepita!");
EchoResponse response = echo.post();
if (response.statusCode == HttpStatusCode.Created)
{
  // Success
}
else
{
  // Something wrong -- check response for errors
  Console.WriteLine(response.getRawResponse());
}
