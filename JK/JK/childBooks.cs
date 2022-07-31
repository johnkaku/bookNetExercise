using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JK
{
    public static class childBooks
    {
        public static void Main()
        {
            var driver = Driver;
            string firstBook = "הנסיכה בשחור 7 והריח הבורח";
            string secondBook = "השרביט והחרב 18 \\ ממלכת האופל";
            string thirdBook = "מעשה בחמישה בלונים";

            //גלוש לאתר צומת ספרים
            driver.Navigate().GoToUrl("https://www.booknet.co.il/");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            //כנס דרך קטגוריות למבצעים-> מבצע ספרי ילדים
            driver.FindElement(By.XPath("//a[@class='menu']"), 20).Click();
            driver.FindElement(By.XPath("//div[@data-parent='250']/a[1]"), 20).Click();

            //בחר 2 ספרים שונים  והוסף לסל
            chooseBookandAddToBasket(firstBook);
            driver.FindElement(By.XPath("//button[text()='להמשך קניה']"), 20).Click();

            driver.Navigate().Back();

            chooseBookandAddToBasket(secondBook);
            driver.FindElement(By.XPath("//a[text()='למעבר לתשלום']"), 20).Click();

            //התקדם למסך הבא
            driver.FindElement(By.XPath("//img[@alt='מעבר לתשלום']"), 20).Click();

            //ובחר אופן משלוח
            driver.FindElement(By.XPath("//select[@id='shipment']/option[3]"), 20).Click();

            //מלא שדות חובה
            fillAllRequiredInForm("book@auto.com", "FirstName", "LastName", "052-2222222", "City", "Street", "9");

            //אשר תקנון
            driver.FindElement(By.XPath("//input[@id='isConfirm']"), 20).Click();

            //התקדם לדף התשלום (אין צורך לשלם כמובן :) )
            driver.FindElement(By.XPath("//input[@class='basket-submit']"), 20).Click();

            //חזור לדף הראשי
            driver.Navigate().Back();
            driver.Navigate().Back();

            //  באמצעות כפתור חפש ,חפש את הספר מעשה בחמישה בלונים והוספה לסל

            FindBookandAddtoBasket(thirdBook);
            

            //מעבר לתשלום (אין צורך לשלם )
            driver.FindElement(By.XPath("//a[text()='למעבר לתשלום']"), 20).Click();
            driver.FindElement(By.XPath("//img[@alt='מעבר לתשלום']"), 20).Click();

            fillAllRequiredInForm("book@auto.com", "FirstName", "LastName", "052-2222222", "City", "Street", "9");
            driver.FindElement(By.XPath("//input[@id='isConfirm']"), 20).Click();
        }

        private static IWebDriver driver;


        public static IWebDriver Driver
        {

            get
            {
                if (driver == null)
                {
                    driver = new ChromeDriver();
                }
                return driver;
            }
        }

        private static void FindBookandAddtoBasket(string book)
        {
            driver.FindElement(By.XPath("//input[@role='combobox']"), 30).SendKeys(book);
            driver.FindElement(By.XPath($"//a[text()='{book}']"), 30).Click();

            //הוסף לסל
            driver.FindElement(By.XPath("//button[contains(@class, 'blue btn')]"), 20).Click();

        }
        private static void fillAllRequiredInForm(string email, string FirstName, string LastName, string phone, string city, string street, string homeNum)
        {
            driver.FindElement(By.XPath("//input[@id='email']"), 20).SendKeys(email);
            driver.FindElement(By.XPath("//input[@id='customerFirstName']"), 20).SendKeys(FirstName);
            driver.FindElement(By.XPath("//input[@id='customerLastName']"), 20).SendKeys(LastName);
            driver.FindElement(By.XPath("//input[@id='phone']"), 20).SendKeys(phone);
            driver.FindElement(By.XPath("//input[@id='city']"), 20).SendKeys(city);
            driver.FindElement(By.XPath("//input[@id='street']"), 20).SendKeys(street);
            driver.FindElement(By.XPath("//input[@id='homenum']"), 20).SendKeys(homeNum);

        }

        private static void chooseBookandAddToBasket(string bookName)
        {
            driver.FindElement(By.XPath($"//img[@alt='{bookName}']"), 20).Click();
            driver.FindElement(By.XPath("//button[contains(@class, 'blue btn')]"), 20).Click();

        }

    }
}
