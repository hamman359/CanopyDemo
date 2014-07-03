using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace CSharpTests
{
	[TestFixture]
	public class DemoTests
    {
		IWebDriver driver;

		[SetUp]
		public void Setup() {
			driver = new FirefoxDriver();
		}

		[TearDown]
		public void TearDown() {
			driver.Close();
			driver.Quit();
		}

		[Test]
		public void Demo_Test() {
			driver.Navigate().GoToUrl("http://CanopyDemo");

			// Fill out and submit form
			var firstNameText = driver.FindElement(By.Id("FirstName"));
			firstNameText.SendKeys("John");

			var lastNameText = driver.FindElement(By.Id("LastName"));
			lastNameText.SendKeys("Doe");

			var addressText = driver.FindElement(By.Id("Address"));
			addressText.SendKeys("123 Anywhere Dr.");

			var cityText = driver.FindElement(By.Id("City"));
			cityText.SendKeys("Nowhere");

			var stateDdl = driver.FindElement(By.Id("State"));
			stateDdl.SendKeys("Ohio");

			var zipText = driver.FindElement(By.Id("Zip"));
			zipText.SendKeys("12345");

			var emailText = driver.FindElement(By.Id("Email"));
			emailText.SendKeys("John.Doe@Email.com");

			var confirmText = driver.FindElement(By.Id("Confirm"));
			confirmText.SendKeys("John.Doe@Email.com");

			var signUpCheck = driver.FindElement(By.CssSelector("#SignUp[value='true']"));
			signUpCheck.Click();

			var submit = driver.FindElement(By.Id("Submit"));
			submit.Click();

			// Verify data
			var firstName = driver.FindElement(By.Id("FirstName"));
			Assert.That(firstName.Text, Is.EqualTo("John"));

			var lastName = driver.FindElement(By.Id("LastName"));
			Assert.That(lastName.Text, Is.EqualTo("Doe"));

			var address = driver.FindElement(By.Id("Address"));
			Assert.That(address.Text, Is.EqualTo("123 Anywhere Dr."));

			var city = driver.FindElement(By.Id("City"));
			Assert.That(city.Text, Is.EqualTo("Nowhere"));

			var state = driver.FindElement(By.Id("State"));
			Assert.That(state.Text, Is.EqualTo("Ohio"));

			var zip = driver.FindElement(By.Id("Zip"));
			Assert.That(zip.Text, Is.EqualTo("12345"));

			var email = driver.FindElement(By.Id("Email"));
			Assert.That(email.Text, Is.EqualTo("John.Doe@Email.com"));

			var signedUp = driver.FindElement(By.Id("SignedUp"));
			Assert.That(signedUp.Text, Is.EqualTo("True"));
		}
    }
}
