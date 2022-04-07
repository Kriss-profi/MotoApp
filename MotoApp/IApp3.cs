namespace MotoApp
{
    public interface IApp3
    {
        void CarFirstByColor();
        void CarFirstOrDefaultByColor();
        void CarFirstOrDefaultByColorWithDefault();
        void CarLastByColor();
        void CarSingleById();
        void CarsTakeHowMany();
        void CarsTakeRange();
        void CarsTakeWithPrefix();
        void CarsSkipHowMany();
        void CarsSkipWhileNameStartsWithPrefix();
        void CarsDistinctAllColors();
        void CarsDistinctByColows();
        void TabCars();
        List<Car[]> CarsChunk(int i);
        //void GenerateCarsList();

    }
}
