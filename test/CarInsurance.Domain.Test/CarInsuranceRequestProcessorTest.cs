using CarInsurance.Core.Enums;
using CarInsurance.Core.Interfaces;
using CarInsurance.Core.Models;
using CarInsurance.Domain.Processor;
using Shouldly;

namespace CarInsurance.Domain.Test
{
    public class CarInsuranceRequestProcessorTest
    {
        private CarInsuranceProcessor _processor;
        private Mock<ICarInsuranceDomain> _carInsuranceDomainMock;
        private CarInsuranceRequest _request;

        public CarInsuranceRequestProcessorTest()
        {
            _request = new()
            {
                Customer = new()
                {
                    Name = "It's me",
                    DocumentID = 92100151849,
                    BirthDate = new(2000, 06, 20),
                    City = "Tunja",
                    Address = "Carrera 30 # 58-14"
                },
                Car = new()
                {
                    Plate = "ANC 30 C",
                    Model = "Honda",
                    Inspection = true
                },
                Policy = new()
                {
                    Name = "Luke"
                },
                CreationDate = new(2023, 06, 15)
            };
            _carInsuranceDomainMock = new();
            _processor = new(_carInsuranceDomainMock.Object);
        }

        [Fact]
        public void Should_Throw_Null_Exception_For_Null_Request()
        {
            ArgumentNullException? exception =
                Should.Throw<ArgumentNullException>(() => _processor.CreateAsync(null));

            exception.ParamName.ShouldBe(nameof(CarInsuranceRequest));
        }

        [Fact]
        public void Should_Return_Car_Insurance_Response_With_Request_Values()
        {
            //Assert
            _carInsuranceDomainMock.Setup(request => request.CreateAsync(_request)).ReturnsAsync(false);

            _processor = new(_carInsuranceDomainMock.Object);

            //Act
            var result = _processor.CreateAsync(_request);

            //Assert
            result.ShouldNotBeNull();

        }        

        [Theory]
        [InlineData(CarInsuranceResultFlag.Failure, false)]
        [InlineData(CarInsuranceResultFlag.Success, true)]
        public void Should_Return_SuccessOrFailure_Flag_On_Result(CarInsuranceResultFlag? carInsuranceSuccessFlag, bool isAvialable = false)
        {
            if (!isAvialable)
            {
                _carInsuranceDomainMock.Setup(request => request.CreateAsync(_request)).ReturnsAsync(false);

                _processor = new(_carInsuranceDomainMock.Object);

            }

            if (isAvialable)
            {
                _carInsuranceDomainMock.Setup(request => request.CreateAsync(_request)).ReturnsAsync(true);

                _processor = new(_carInsuranceDomainMock.Object);

            }

            var result = _processor.CreateAsync(_request);

            carInsuranceSuccessFlag.ShouldBe(result?.Flag);
        }
    }
}