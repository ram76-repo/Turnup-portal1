using NUnit.Framework;
using Reqnroll.CommonModels;

namespace ReqnrollProject2.StepDefinitions
{
    [Binding]
    public sealed class CalculatorStepDefinitions

    {
        private readonly Calculator calculator = new Calculator();
        private int Result;
                   
        [Given("the first number is {int}")]
        public void GivenTheFirstNumberIs(int firstNumber)
        {
            calculator.FirstNumber = firstNumber;
         }

        [Given("the second number is {int}")]
        public void GivenTheSecondNumberIs(int number)

        {
            calculator.SecondNumber = number;
        }

        [When("the two numbers are added")]
        public void WhenTheTwoNumbersAreAdded()
        {
            Result = calculator.Add();
        }

        
        [When("the two numbers are subtracted")]
        public void WhenTheTwoNumbersAreSubtracted()
        {
            Result = calculator.Subtract();
        }

        [When("the two numbers are multiplied")]
        public void WhenTheTwoNumbersAreMultiplied()
        {
            Result = calculator.Multiply();
        }

        [When("the two numbers are divided")]
        public void WhenTheTwoNumbersAreDivided()
        {
            Result = calculator.Divide();
        }


        [Then("the result should be {int}")]
        public void ThenTheResultShouldBe(int result)
        {
            Assert.Equals(Result, Is.EqualTo(Result));
        }

    }
}
