using RealEstateCLI;

var ads = Ad.LoadFromCSV("realestates.csv");

var f01 = ads.Where(a => a.Floor == 0).Average(a => a.Area);
Console.WriteLine($"1.: foldszinti ingatlanok atlagos alapterulete: {f01:0.00} m^2");

var mesevar = (x: 47.4164220114023, y: 19.066342425796986);
var f02 = ads
    .Where(a => a.IsFreeOfCharge)
    .MinBy(a => a.DistanceTo(mesevar.x, mesevar.y));

Console.WriteLine($"2.: Mesevar Ovodahoz legvonalban legkozelebbi tehermentes ingatlan adatai:\n{f02}");