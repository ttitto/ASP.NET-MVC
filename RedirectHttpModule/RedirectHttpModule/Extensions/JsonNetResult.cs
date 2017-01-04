namespace RedirectHttpModule.Extensions
{
    using System.Web.Mvc;
    using Newtonsoft.Json;

    public class JsonNetResult : ActionResult
    {
        public object Data { get; set; }

        public override void ExecuteResult(ControllerContext context)
        {
            var response = context.HttpContext.Response;
            response.ContentType = "application/json";
            response.Write(JsonConvert.SerializeObject(this.Data));
        }
    }
}