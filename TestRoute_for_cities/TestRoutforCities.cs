using Route_for_cities;
using Route_for_cities.Structure;
using System;

namespace TestRoute_for_cities
{
    public class TestRoutforCities
    {
        Helper helper = new Helper();
        [Fact]
        public void Helper_ValidateNumberOfRequests_number()
        {
            //Arrange
            
            long num;
            //Act
            num = helper.ValidateNumberOfRequests("1252");
            //Assert
            Assert.Equal(1252, num);
        }
        [Fact]
        public void Helper_ValidateNumberOfRequests_ExceptionZero()
        {
            //Arrange
            
            long num;
            //Act
            num = helper.ValidateNumberOfRequests("khilkjkj;");
            //Assert
            Assert.Equal(0, num);
        }
        [Fact]
        public void HelperValidateCityString()
        {
            //Arrange
            
            List<PathCity> paths = new List<PathCity>
                {
                    new PathCity{ From = "a", To = "b" },
                    new PathCity{ From = "b", To = "c" },
                    new PathCity{ From = "c", To = "d" },
                };
            //Act
            var StartPath = helper.ValidatePath(paths);
            //Assert
            Assert.Equal("a", StartPath);
        }
        [Fact]
        public void HelperValidateCityStringError()
        {
            //Arrange

            List<PathCity> paths = new List<PathCity>
                {
                    new PathCity{ From = "a", To = "b" },
                    new PathCity{ From = "b", To = "c" },
                    new PathCity{ From = "c", To = "a" },
                };
            //Act
            var StartPath = helper.ValidatePath(paths);
            //Assert
            Assert.Equal("ERRORR", StartPath);
        }


    }
}