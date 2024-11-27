namespace InterfacesExample.Tests;

public class CarRepositoryTests
{
    [Fact]
    public void InsertingNewModel_ShouldIncreaseRecordCount()
    {
        //Arange
        IRepository<CarModel> carRepository = new CarRepository();
        int recordBefore = carRepository.RecordCount();
        //Act
        carRepository.Insert(new CarModel("208", "Peugeot"));
        int recordAfter = carRepository.RecordCount();
        //Assert
        Assert.True(recordBefore < recordAfter);
    }

    [Fact]
    public void InsertingNull_ShouldSustainRecordCount()
    {
        //Arange
        IRepository<CarModel> carRepository = new CarRepository();
        int recordBefore = carRepository.RecordCount();
        //Act
        carRepository.Insert(null);
        int recordAfter = carRepository.RecordCount();
        //Assert
        Assert.True(recordAfter == recordBefore);
    }

    [Fact]
    public void GettingAllRecords_WithTwoRecords_ShouldReturnListOfTwoRecords()
    {
        //Arange
        IRepository<CarModel> carRepository = new CarRepository();
        List<CarModel> carsList = new List<CarModel>();
        int numberOfRecords = 2;
        carRepository.Insert(new CarModel("C3", "Citroen"));
        carRepository.Insert(new CarModel("Clio", "Renault"));
        //Act
        List<CarModel> carModels = carRepository.Get();
        //Assert
        Assert.True(carModels.Count() == numberOfRecords);
        Assert.Equal(carModels.Count(), numberOfRecords);
    }

    [Fact]
    public void GettingInsertedRecordWithId_WithTwoRecords_ShouldReturnInsertedRecord()
    {
        // Arrange
        int numberOfRecords = 2;
        IRepository<CarModel> carRepo = new CarRepository();

        for (int i = 0; i < numberOfRecords; i++)
        {
            CarModel car = new CarModel($"Enyaq {i}", $"Skoda {i}");
            carRepo.Insert(car);
        }
        List<CarModel> modelRecordsFromRepo = carRepo.Get().ToList();
                    
        // Act
        carRepo.Delete(modelRecordsFromRepo[0].Id);
        carRepo.Delete(modelRecordsFromRepo[1].Id);

        // Assert
        Assert.True(carRepo.RecordCount() == 0);
        Assert.Equal(0, carRepo.RecordCount());
    }

    [Fact]
    public void GettingNotInsertedRecordWithId_WithTwoRecords_ShouldReturnNull()
    {
        IRepository<CarModel> carRepo = new CarRepository();
        Guid carId = new Guid();
        List<CarModel> prevRepo = carRepo.Get().ToList();
                    
        // Act
        carRepo.Delete(carId);
        List<CarModel> currRepo = carRepo.Get().ToList();

        // Assert
        Assert.Equal(prevRepo, currRepo);
    }
}