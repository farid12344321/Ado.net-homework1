



using Ado.net_homework1;

BrandService brandService = new BrandService();

string opt;
do
{

    Console.WriteLine("1 Brand Create");
    Console.WriteLine("2 Brand Delete");
    Console.WriteLine("3 Brand get by id");
    Console.WriteLine("4 Get all brands");
    Console.WriteLine("5 Update brand");
    Console.WriteLine("0 exit");


    Console.WriteLine("Select opt");
    opt = Console.ReadLine();


    switch (opt)
    {
        case "1":
            Console.WriteLine("Name :");
            n: string nameOpt = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(nameOpt))
            {
                Console.WriteLine("Bos ola bilmez");
                break;
            }
            Console.WriteLine("Yranma tarixini qeyd edin");
            d: string datestr = Console.ReadLine();
            DateTime date;

            if (!DateTime.TryParse(datestr,out date))
            {
                Console.WriteLine("Duzgun daxil edin");
                break;
            }

            brandService.InsertBrands(nameOpt, date);
            break; 
        case "2":
            Console.Write("Brand Id: ");
            string idstr2 = Console.ReadLine();
            int id2;
            if (!int.TryParse(idstr2, out id2))
            {
                Console.WriteLine("Bos ola bilmez");
                break;
            }
            brandService.DeleteBrandById(id2);
            break;
        case "3":
            Console.Write("Brand Id: ");
            string idstr = Console.ReadLine();
            int id;
            if (!int.TryParse(idstr,out id))
            {
                Console.WriteLine("Bos ola bilmez");
                break;
            }
            var data = brandService.GetBrandById(id);
            if (data == null) Console.WriteLine("Brand tapilmadi");
            else Console.WriteLine(data);
            break;
        case "4":
            foreach (var item in brandService.GetAllBrands())
            {
                Console.WriteLine(item);
            }
            break;
        case "5":
            Console.Write("Brand Id: ");
            string idstr3 = Console.ReadLine();
            int id3;
            if (!int.TryParse(idstr3, out id3))
            {
                Console.WriteLine("Bos ola bilmez");
                break;
            }
            Console.WriteLine("Name :");
            string nameOpt2 = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(nameOpt2))
            {
                Console.WriteLine("Bos ola bilmez");
                break;
            }
            Console.WriteLine("Yranma tarixini qeyd edin");
            string datestr2 = Console.ReadLine();
            DateTime date2;

            if (!DateTime.TryParse(datestr2, out date2))
            {
                Console.WriteLine("Duzgun daxil edin");
                break;
            }
            brandService.UpdateBrandById(id3, nameOpt2, date2);
            break;
        case "0":
            Console.WriteLine("Program bitdi");
            break;
        default:
            Console.WriteLine("Choose the correct surgery");
            break;
    }
} while (opt != "0");