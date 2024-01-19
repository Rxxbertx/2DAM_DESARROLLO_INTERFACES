using System.Collections.ObjectModel;

namespace PROYECTO_EV2_RJT.MODEL
{
    class PhoneCollection : ObservableCollection<Phone>
    {


        public PhoneCollection()
        {
            Add(new Phone(1, "Samsung", "Galaxy S10", 8, "Exynos 9820", 3400, "Android 9.0", 6.1f));
            Add(new Phone(2, "Samsung", "Galaxy S10+", 8, "Exynos 9820", 4100, "Android 9.0", 6.4f));
            Add(new Phone(3, "Samsung", "Galaxy S10e", 6, "Exynos 9820", 3100, "Android 9.0", 5.8f));
            Add(new Phone(4, "Samsung", "Galaxy S9", 4, "Exynos 9810", 3000, "Android 8.0", 5.8f));
            Add(new Phone(5, "Samsung", "Galaxy S9+", 6, "Exynos 9810", 3500, "Android 8.0", 6.2f));
            Add(new Phone(6, "Samsung", "Galaxy S8", 4, "Exynos 8895", 3000, "Android 7.0", 5.8f));
            Add(new Phone(7, "Samsung", "Galaxy S8+", 4, "Exynos 8895", 3500, "Android 7.0", 6.2f));
            Add(new Phone(8, "Samsung", "Galaxy S7", 4, "Exynos 8890", 3000, "Android 6.0", 5.1f));
            Add(new Phone(9, "Samsung", "Galaxy S7 Edge", 4, "Exynos 8890", 3600, "Android 6.0", 5.5f));
            Add(new Phone(10, "Samsung", "Galaxy S6", 3, "Exynos 7420", 2550, "Android 5.0", 5.1f));
            Add(new Phone(11, "Samsung", "Galaxy S6 Edge", 3, "Exynos 7420", 2600, "Android 5.0", 5.1f));
        }

    }
}
