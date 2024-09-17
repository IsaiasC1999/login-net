public class ResponseDto
{
    public int status { get; set; }

    public object result { get; set; }

    public string code { get; set; }="";

    public string exception { get; set; }="";

    public string exception_message { get; set; }="";
}