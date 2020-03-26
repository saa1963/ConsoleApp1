using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                driver.Url = @"https://water.drom.ru";
                wait.Until(e => e.FindElement(By.XPath(".//div[@class='menuInner']/a[contains(@id, 'cityNavigator_')]"))).Click();
                wait.Until(e => e.FindElement(By.XPath(".//a[@class='whole-country country']"))).Click();
                var categories = wait.Until(e => e.FindElements(By.XPath(".//div[@id='dirId']//a[@class='option']")));
                Console.OutputEncoding = Encoding.UTF8;
                foreach(var category in categories)
                {
                    Console.WriteLine(category.Text);
                }
            }
        }
    }
}
