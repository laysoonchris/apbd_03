using apbd_03.Properties;

var ship1 = new Ship("Maria", 20, 5, 50);
var ship2 = new Ship("Teresa", 25, 10, 100);

var kontener1 = new KontenerC(200, 100, 100, 800, "meat", -15);
kontener1.fill(500);

var kontener2 = new KontenerG(200, 100, 100, 700, 2.5);
kontener2.fill(600);

var kontener3 = new KontenerL(200, 100, 100, 1000,true);

ship1.addKontener(kontener1);
ship1.addKontener(kontener2);

ship1.showShip();

ship1.removeContainer(kontener2.serialNumber);
ship1.showShip();

ship2.addKontener(kontener2);
ship1.moveKontener(kontener1.serialNumber, ship2);

ship2.showShip();
ship2.show(kontener2.serialNumber);

// kontener3.fill(400);
// ship1.addKontener(kontener3);
// ^^wyrzuca wyjątek