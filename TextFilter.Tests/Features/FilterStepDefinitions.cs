using TechTalk.SpecFlow;
using TextFilter.Client;

namespace TextFilter.Tests.Features
{
    [Binding]
    public class FilterStepDefinitions(ScenarioContext scenarioContext)
    {
        private const string FilteredContextKey = "FilteredContent";

        [Given(@"I want to filter text")]
        public void GivenIWantToFilterText()
        {
            scenarioContext[FilteredContextKey] = string.Empty;
        }
       
        [When(@"I apply the filters")]
        public void WhenIApplyTheFilters()
        {
            Program.Main([]);
            scenarioContext[FilteredContextKey] = Program.FilteredContent;
        }

        [Then(@"I see only the filtered text below")]
        public void ThenISeeOnlyTheFilteredTextBelow(string multilineText)
        {
           Assert.Equal(multilineText, scenarioContext[FilteredContextKey]);
        }
    }
}
