using FoodyWebApp.Tests;

namespace FoodyWebApp
{
    public class FoodyWebAppTests : BaseTests
    {
        string lastCreatedTitle;

        string lastCreatedDescription;

        [Test, Order(1)]
        public void AddFoodWithInvalidData()
        {
            addFoodPage.OpenPage();

            addFoodPage.AddFoodButton.Click();

            Assert.That(driver.Url, Is.EqualTo(addFoodPage.Url), "The user was navigated to another Url.");

            Assert.That(addFoodPage.ErrorMessage.Text.Trim(), Is.EqualTo("Unable to add this food revue!"), "The error message was not as expected.");
        }

        [Test, Order(2)]
        public void AddRandomFood()
        {
            addFoodPage.OpenPage();

            lastCreatedTitle = $"Title: {GenerateRandomString()}";
            addFoodPage.FoodNameInput.Clear();
            addFoodPage.FoodNameInput.SendKeys(lastCreatedTitle);

            lastCreatedDescription = $"Description {GenerateRandomString()}";
            addFoodPage.DescriptionInput.Clear();
            addFoodPage.DescriptionInput.SendKeys(lastCreatedDescription);

            addFoodPage.AddFoodButton.Click();

            Assert.That(driver.Url, Is.EqualTo($"{basePage.BaseUrl}/"), "The user was not navigated to the Home page Url.");

            Assert.That(basePage.LastFoodTitle.Text.Trim(), Is.EqualTo(lastCreatedTitle), "The title of the last added food was not as expected.");
        }

        [Test, Order(3)]
        public void EditLastAddedFood()
        {
            basePage.OpenPage();

            actions.ScrollToElement(basePage.LastFoodEditButton).Perform();

            basePage.LastFoodEditButton.Click();

            editFoodPage.FoodNameInput.Clear();
            editFoodPage.FoodNameInput.SendKeys($"Edited Title: {GenerateRandomString()}");

            editFoodPage.AddFoodButton.Click();

            Assert.That(driver.Url, Is.EqualTo($"{basePage.BaseUrl}/"), "The user was not navigated to the Home page Url.");

            Assert.That(basePage.LastFoodTitle.Text.Trim(), Is.EqualTo(lastCreatedTitle), "The edited title of the last added food was not as expected.");

            Console.WriteLine("The title remains unchanged as expected due to incomplete functionality.");
        }

        [Test, Order(4)]
        public void SearchForFoodTitle()
        {
            basePage.OpenPage();

            basePage.SearchInput.Clear();
            basePage.SearchInput.SendKeys(lastCreatedTitle);

            basePage.SearchButton.Click();

            Assert.That(basePage.AllFoodListAfterSearch.Count, Is.EqualTo(1),"The food item was not only one as expected after search.");

            Assert.That(basePage.LastFoodTitleAfterSearch.Text.Trim(), Is.EqualTo(lastCreatedTitle), "The title of the food item was not as expected after search.");
        }

        [Test, Order(5)]
        public void DeleteLastAddedFood()
        {
            basePage.OpenPage();

            int foodCount = basePage.AllFoodList.Count;

            actions.ScrollToElement(basePage.LastFoodDeleteButton).Perform();

            basePage.LastFoodDeleteButton.Click();

            int foodCountAfetDeletion = basePage.AllFoodList.Count;

            Assert.That(foodCountAfetDeletion, Is.LessThan(foodCount), "The count of added foods was not decreased as expected.");

            bool isFoodDeleted = basePage.AllFoodList.All(f => f.Text.Contains(lastCreatedTitle));

            Assert.That(isFoodDeleted, Is.False, "The last food title was not as expected after deletion.");
        }

        [Test, Order(6)]
        public void SearchForDeletedFood()
        {
            basePage.OpenPage();

            basePage.SearchInput.Clear();
            basePage.SearchInput.SendKeys(lastCreatedTitle);

            basePage.SearchButton.Click();

            Assert.That(basePage.NoFoodMessageAfterSearch.Text.Trim(), Is.EqualTo("There are no foods :("), "The No food message afer search was not as expected.");

            Assert.IsTrue(basePage.AddFoodButton.Displayed, "The Add button was not displayed as expected.");
        }
    }
}