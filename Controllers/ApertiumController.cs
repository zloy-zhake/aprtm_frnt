using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MvcApp.Controllers
{
    public class ApertiumController : Controller
    {
        // 
        // GET: /Apertium/

        // public string Index()
        // {
        //     return "this...";
        // }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Translate(string source_text, string direction)
        {
            ViewData["source_text"] = source_text;
            ViewData["direction"] = direction;

            string apertium_path = "/home/zhake/Apertium/Source/apertium-eng-kaz/";
            string target_text = "";

            Process cmd = new Process();
            cmd.StartInfo.FileName = "bash";
            cmd.StartInfo.Arguments = "-c \"echo '" + source_text + "' | apertium -d " + apertium_path + " " + direction + "\"";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.RedirectStandardError = true;
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.UseShellExecute = false;
            cmd.Start();


            cmd.WaitForExit();
            target_text = cmd.StandardOutput.ReadToEnd();

            // Process cmd = new Process();
            // cmd.StartInfo.FileName = "apertium";
            // cmd.StartInfo.Arguments = "-d " + apertium_path + direction;
            // cmd.StartInfo.RedirectStandardInput = true;
            // cmd.StartInfo.RedirectStandardOutput = true;
            // cmd.StartInfo.RedirectStandardError = true;
            // cmd.StartInfo.CreateNoWindow = true;
            // cmd.StartInfo.UseShellExecute = false;
            // cmd.Start();

            // cmd.StandardInput.Write(source_text);

            // cmd.WaitForExit();
            // target_text = cmd.StandardOutput.ReadToEnd();

            ViewData["target_text"] = target_text;

            return View();
        }

        // Почему-то перестало работать с атрибутом HttpPost
        // [HttpPost]
        // public IActionResult Translate(string source_text, string direction)
        // {
            
        // }
    }
}