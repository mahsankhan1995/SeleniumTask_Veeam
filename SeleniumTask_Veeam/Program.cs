using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace SeleniumTask_Veeam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String webLink = "https://cz.careers.veeam.com/vacancies";
            int expectedNumberOfJobs;

            Console.WriteLine("Please enter the number of job expected?\n");
            expectedNumberOfJobs = Convert.ToInt32(Console.ReadLine());

            ChromeDriverService service = ChromeDriverService.CreateDefaultService();
            service.SuppressInitialDiagnosticInformation = true;

            Console.WriteLine("\n\n\n--------opening Chrome\n\n\n");
            IWebDriver driver = new ChromeDriver(service);

            Console.WriteLine("\n\n\n--------Navigating to Veeam career page\n\n\n");
            driver.Navigate().GoToUrl(webLink);
             driver.Manage().Window.Maximize();
            
             Thread.Sleep(1000);
             driver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div/div[1]/div/div[5]/button")).Click();
             Thread.Sleep(1000);

             //----------department selection-----------
             driver.FindElement(By.XPath("//*[@id=\"sl\"]")).Click();
             Thread.Sleep(1000);
             driver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div/div[1]/div/div[2]/div/div/div/a[4]")).Click();
             Thread.Sleep(1000);
            Console.WriteLine("\n\n\n--------Department Selected\n\n\n");

            //----------language selection-----------
            driver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div/div[1]/div/div[3]/div/div/button")).Click();
             Thread.Sleep(1000);
             driver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div/div[1]/div/div[3]/div/div/div/div[1]/label")).Click();
             driver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div/div[1]/div/div[3]/div/div/button")).Click();
             Thread.Sleep(1000);
            Console.WriteLine("\n\n\n--------Language Selected\n\n\n");

            //----------Counting number of jobs-----------
            IReadOnlyCollection<IWebElement> obj= driver.FindElements(By.LinkText("LEARN MORE"));
            Console.WriteLine("There are " + obj.Count() + " jobs opening as oppose to the expected " + expectedNumberOfJobs + " jobs");





        }
    }
}
